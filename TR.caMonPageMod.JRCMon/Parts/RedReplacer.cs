using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

namespace TR.caMonPageMod.JRCMon.Parts;

public static class RedReplacer
{
	const PixelFormat PIXEL_FORMAT = PixelFormat.Format32bppArgb;
	const int BYTE_PER_PIXEL = 4;
	static readonly Color RED = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00);
	static readonly byte[] RED_BYTES = BitConverter.GetBytes(RED.ToArgb());

	record Info(ResourceManager.ResourceFiles resource, Color color);
	static readonly Dictionary<Info, BitmapImage> cache = [];
	public static BitmapImage GetImage(ResourceManager.ResourceFiles resource, Color color)
	{
		Info info = new(resource, color);
		if (cache.TryGetValue(info, out BitmapImage? img))
			return img;

		using var memory = new System.IO.MemoryStream();
		Bitmap bmp;
		using (var imgStream = ResourceManager.GetResourceAsStream(resource))
		{
			bmp = new(imgStream);
		}
		setPixel(bmp, info);

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

	static void setPixel(Bitmap bmp, in Info info)
	{
		BitmapData data = bmp.LockBits(
			new Rectangle(0, 0, bmp.Width, bmp.Height),
			ImageLockMode.WriteOnly,
			PIXEL_FORMAT
		);

		byte[] fillColorBytes = BitConverter.GetBytes(info.color.ToArgb());

		IntPtr ptr = data.Scan0;
		byte[] imgBytes = new byte[data.Stride * data.Height];
		Marshal.Copy(ptr, imgBytes, 0, imgBytes.Length);

		Span<byte> imgSpan = imgBytes.AsSpan();
		Span<byte> redBytesSpan = RED_BYTES.AsSpan();
		Span<byte> fillColorSpan = fillColorBytes.AsSpan();
		for (int row = 0; row < data.Height; row++)
		{
			int rowTopIndex = row * data.Stride;
			Span<byte> rowSpan = imgSpan[rowTopIndex..(rowTopIndex + data.Width * BYTE_PER_PIXEL)];
			for (int col = 0; col < data.Width; col++)
			{
				int index = col * BYTE_PER_PIXEL;
				Span<byte> target = rowSpan[index..(index + BYTE_PER_PIXEL)];
				if (target.SequenceEqual(redBytesSpan))
				{
					fillColorSpan.CopyTo(target);
				}
			}
		}
		Marshal.Copy(imgBytes, 0, ptr, imgBytes.Length);
		bmp.UnlockBits(data);
	}
}
