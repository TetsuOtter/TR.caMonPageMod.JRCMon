using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

namespace TR.caMonPageMod.JRCMon.Parts;

public static class ButtonBaseImage
{
	const int SHADOW_WIDTH_SMALL = 2;
	const int SHADOW_WIDTH_DEFAULT = 3;
	const PixelFormat PIXEL_FORMAT = PixelFormat.Format32bppArgb;
	const int BYTE_PER_PIXEL = 4;
	static readonly byte[] BASE_COLOR_BYTES = BitConverter.GetBytes(ComponentFactory.WpfColorToDrawingColor(ComponentFactory.BASIC_BUTTON_COLOR).ToArgb());

	record Info(int Width, int Height, Color color);
	static readonly Dictionary<Info, BitmapImage> cache = [];
	public static BitmapImage GetButtonImage(int Width, int Height, bool isSmall, Color color)
	{
		Info info = new(Width, Height, color);
		if (cache.TryGetValue(info, out BitmapImage? img))
			return img;

		using var memory = new System.IO.MemoryStream();
		Bitmap bmp = new(Width, Height);
		setPixel(bmp, info, isSmall ? SHADOW_WIDTH_SMALL : SHADOW_WIDTH_DEFAULT);

		bmp.Save(memory, ImageFormat.Png);
		memory.Position = 0;
		img = new();
		img.BeginInit();
		img.StreamSource = memory;
		img.CacheOption = BitmapCacheOption.OnLoad;
		img.EndInit();
		img.Freeze();
		cache[info] = img;
		return img;
	}

	static void setPixel(Bitmap bmp, in Info info, int shadowWidth)
	{
		BitmapData data = bmp.LockBits(
			new Rectangle(0, 0, info.Width, info.Height),
			ImageLockMode.WriteOnly,
			PIXEL_FORMAT
		);

		IntPtr ptr = data.Scan0;
		byte[] line = new byte[info.Width * BYTE_PER_PIXEL];
		Span<byte> rgbValues = new(line);
		rgbValues.Fill(0xFF);
		// 一番下の辺
		Marshal.Copy(line, 0, ptr + data.Stride * (info.Height - 1), line.Length);
		for (int row = 0; row <= (shadowWidth + 1); ++row)
		{
			if (row != 0 && row != (shadowWidth + 1))
			{
				// 右上の段々
				int fillColorTargetTop = (info.Width - 1 - row) * BYTE_PER_PIXEL;
				for (int i = 0; i < BYTE_PER_PIXEL; ++i)
					line[fillColorTargetTop + i] = BASE_COLOR_BYTES[i];
			}
			// 上の白い部分
			Marshal.Copy(line, 0, ptr + data.Stride * row, line.Length);
		}
		// 下から2番目の辺
		Marshal.Copy(line, 0, ptr + data.Stride * (info.Height - 2 - shadowWidth), line.Length);

		byte[] fillColorBytes = BitConverter.GetBytes(info.color.ToArgb());
		for (int col = 2 + shadowWidth; col < (info.Width - 2 - shadowWidth); ++col)
		{
			// 中の色
			int fillColorTarget = col * BYTE_PER_PIXEL;
			for (int i = 0; i < BYTE_PER_PIXEL; ++i)
				line[fillColorTarget + i] = fillColorBytes[i];
		}

		for (int row = 2 + shadowWidth; row < (info.Height - 2 - shadowWidth); ++row)
		{
			Marshal.Copy(line, 0, ptr + data.Stride * row, line.Length);
		}

		for (int col = 1 + shadowWidth; col < (info.Width - 1 - shadowWidth); ++col)
		{
			// 下の隙間
			int fillColorTarget = col * BYTE_PER_PIXEL;
			for (int i = 0; i < BYTE_PER_PIXEL; ++i)
				line[fillColorTarget + i] = BASE_COLOR_BYTES[i];
		}
		for (int row = info.Height - 1 - shadowWidth; row < (info.Height - 1); ++row)
		{
			// 左下の段々
			int v = row - (info.Height - 1 - shadowWidth);
			int fillColorTargetTop = (1 + shadowWidth - v - 1) * BYTE_PER_PIXEL;
			for (int i = 0; i < BYTE_PER_PIXEL; ++i)
				line[fillColorTargetTop + i] = BASE_COLOR_BYTES[i];
			Marshal.Copy(line, 0, ptr + data.Stride * row, line.Length);
		}

		bmp.UnlockBits(data);
	}
}
