using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

using TR.caMonPageMod.JRCMon.Utils;

namespace TR.caMonPageMod.JRCMon.Parts.Unit;

public static class CarImageGen
{
	public const int HEIGHT = 62;
	public const int WIDTH = 48;
	const PixelFormat PIXEL_FORMAT = PixelFormat.Format32bppArgb;
	const int BYTE_PER_PIXEL = 4;
	const int ROOF_Y = 11;
	const int SEPARATOR_Y = 29;
	const int CAB_WIDTH = 22;
	const int RIGHT_CAB_CLIFF_COL = WIDTH - CAB_WIDTH;
	const int BOGIE_H_W = 8;
	const int PANTOGRAPH_H_W = 11;
	static readonly Color DRIVER_CAB_COLOR = Color.FromArgb(0xFF, 0x00, 0x5F, 0xED);
	static readonly byte[] DRIVER_CAB_COLOR_BYTES = BitConverter.GetBytes(DRIVER_CAB_COLOR.ToArgb());
	static readonly Color TYPE315_COLOR = Color.White;
	static readonly byte[] TYPE315_COLOR_BYTES = BitConverter.GetBytes(TYPE315_COLOR.ToArgb());

	static readonly byte[][] BOGLE = [
		[0, 0, 0, 1, 1, 0, 0, 0],
		[0, 0, 1, 0, 0, 1, 0, 0],
		[0, 1, 0, 0, 0, 0, 1, 0],
		[1, 0, 0, 0, 0, 0, 0, 1],
		[1, 0, 0, 0, 0, 0, 0, 1],
		[0, 1, 0, 0, 0, 0, 1, 0],
		[0, 0, 1, 0, 0, 1, 0, 0],
		[0, 0, 0, 1, 1, 0, 0, 0],
	];

	public record CarImageInfo(
		bool IsLeftCab,
		bool IsRightCab,

		bool HasPantograph,
		bool HasSecondPantograph,

		bool IsLeftBogieMotored,
		bool IsRightBogieMotored,

		bool Is315,
		bool IsDriverCab
	);
	private static readonly Dictionary<CarImageInfo, BitmapImage> cache = [];
	public static BitmapImage GetCarImage(CarImageInfo info)
	{
		if (cache.TryGetValue(info, out BitmapImage? img))
			return img;

		Bitmap bmp = new(WIDTH, HEIGHT);
		setPixel(bmp, info);

		using var memory = new System.IO.MemoryStream();
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

	static void setPixel(Bitmap bmp, CarImageInfo info)
	{
		BitmapData data = bmp.LockBits(
			new Rectangle(0, 0, WIDTH, HEIGHT),
			ImageLockMode.WriteOnly,
			PIXEL_FORMAT
		);

		byte[] imgBytes = new byte[data.Stride * HEIGHT];
		Span<byte> imgSpan = new(imgBytes);
		imgSpan.Clear();

		static int getLeftCabStartCol(int row) => CAB_WIDTH - ((row + 1) * 2);
		static int getRightCabStartCol(int row) => (RIGHT_CAB_CLIFF_COL - 1) + (row * 2);
		if (info.IsLeftCab)
		{
			int cliffCol = CAB_WIDTH - 1;
			for (int row = 0; row < ROOF_Y; ++row)
			{
				Span<byte> rowSpan = imgSpan[(row * data.Stride)..((row + 1) * data.Stride)];
				int startCol = getLeftCabStartCol(row);
				int endCol = startCol + 3;
				if (row == 0)
				{
					endCol = cliffCol;
				}
				rowSpan[(startCol * BYTE_PER_PIXEL)..(endCol * BYTE_PER_PIXEL)].Fill(0xFF);
				rowSpan[(cliffCol * BYTE_PER_PIXEL)..((cliffCol + 1) * BYTE_PER_PIXEL)].Fill(0xFF);
			}
		}
		if (info.IsRightCab)
		{
			for (int row = 0; row < ROOF_Y; ++row)
			{
				Span<byte> rowSpan = imgSpan[(row * data.Stride)..((row + 1) * data.Stride)];
				int startCol = getRightCabStartCol(row);
				int endCol = startCol + 3;
				if (row == 0)
				{
					startCol = RIGHT_CAB_CLIFF_COL + 1;
				}
				rowSpan[(startCol * BYTE_PER_PIXEL)..(endCol * BYTE_PER_PIXEL)].Fill(0xFF);
				rowSpan[(RIGHT_CAB_CLIFF_COL * BYTE_PER_PIXEL)..((RIGHT_CAB_CLIFF_COL + 1) * BYTE_PER_PIXEL)].Fill(0xFF);
			}
		}

		for (int row = ROOF_Y; row < HEIGHT - BOGIE_H_W; ++row)
		{
			Span<byte> rowSpan = imgSpan[(row * data.Stride)..((row + 1) * data.Stride)];
			if (row == ROOF_Y)
			{
				int roofStartCol = info.IsLeftCab ? (CAB_WIDTH - 1) : 0;
				int roofEndCol = info.IsRightCab ? WIDTH - CAB_WIDTH + 1 : WIDTH;
				rowSpan[(roofStartCol * BYTE_PER_PIXEL)..(roofEndCol * BYTE_PER_PIXEL)].Fill(0xFF);
				if (info.IsLeftCab)
				{
					rowSpan[..BYTE_PER_PIXEL].Fill(0xFF);
				}
				if (info.IsRightCab)
				{
					rowSpan[((WIDTH - 1) * BYTE_PER_PIXEL)..(WIDTH * BYTE_PER_PIXEL)].Fill(0xFF);
				}
			}
			else if (row == (HEIGHT - BOGIE_H_W - 1) || row == SEPARATOR_Y)
			{
				rowSpan[(0 * BYTE_PER_PIXEL)..(WIDTH * BYTE_PER_PIXEL)].Fill(0xFF);
			}
			else
			{
				rowSpan[..(1 * BYTE_PER_PIXEL)].Fill(0xFF);
				rowSpan[((WIDTH - 1) * BYTE_PER_PIXEL)..(WIDTH * BYTE_PER_PIXEL)].Fill(0xFF);
			}
		}

		if (info.HasPantograph)
		{
			if (info.IsRightCab)
			{
				SetPantographPixels(imgSpan, data.Stride, 0);
			}
			else if (info.IsLeftCab)
			{
				SetPantographPixels(imgSpan, data.Stride, WIDTH - PANTOGRAPH_H_W);
			}
			else
			{
				SetPantographPixels(imgSpan, data.Stride, WIDTH / 2 - PANTOGRAPH_H_W / 2);
			}
		}

		if (info.HasSecondPantograph)
		{
			if (info.IsLeftCab)
			{
				SetPantographPixels(imgSpan, data.Stride, CAB_WIDTH);
			}
			else if (info.IsRightCab)
			{
				SetPantographPixels(imgSpan, data.Stride, WIDTH - CAB_WIDTH - PANTOGRAPH_H_W);
			}
			else
			{
				// TODO: 中間車の第二パンタ対応
			}
		}

		if (info.Is315 || info.IsDriverCab)
		{
			byte[] ColorBytes = info.IsDriverCab ? DRIVER_CAB_COLOR_BYTES : TYPE315_COLOR_BYTES;
			Span<byte> colorSpan = ColorBytes.AsSpan();
			if (info.IsLeftCab || info.IsRightCab)
			{
				for (int row = 2; row < ROOF_Y; ++row)
				{
					Span<byte> rowSpan = imgSpan[(row * data.Stride)..((row + 1) * data.Stride)];
					if (info.IsLeftCab)
					{
						int startCol = getLeftCabStartCol(row) + 3;
						colorSpan.CopyAndFill(rowSpan[(startCol * BYTE_PER_PIXEL)..((CAB_WIDTH - 1) * BYTE_PER_PIXEL)]);
					}
					if (info.IsRightCab)
					{
						int endCol = getRightCabStartCol(row);
						colorSpan.CopyAndFill(rowSpan[((RIGHT_CAB_CLIFF_COL + 1) * BYTE_PER_PIXEL)..(endCol * BYTE_PER_PIXEL)]);
					}
				}
				Span<byte> roofRowSpan = imgSpan[(ROOF_Y * data.Stride)..((ROOF_Y + 1) * data.Stride)];
				if (info.IsLeftCab)
				{
					colorSpan.CopyAndFill(roofRowSpan[BYTE_PER_PIXEL..((CAB_WIDTH - 1) * BYTE_PER_PIXEL)]);
				}
				if (info.IsRightCab)
				{
					colorSpan.CopyAndFill(roofRowSpan[((RIGHT_CAB_CLIFF_COL + 1) * BYTE_PER_PIXEL)..((WIDTH - 1) * BYTE_PER_PIXEL)]);
				}
			}
			for (int row = ROOF_Y + 1; row < SEPARATOR_Y; ++row)
			{
				Span<byte> rowSpan = imgSpan[(row * data.Stride)..((row + 1) * data.Stride)];
				colorSpan.CopyAndFill(rowSpan[(1 * BYTE_PER_PIXEL)..((WIDTH - 1) * BYTE_PER_PIXEL)]);
			}
		}

		if (info.IsLeftBogieMotored)
		{
			SetBogiePixels(imgSpan, data.Stride, 1);
			SetBogiePixels(imgSpan, data.Stride, 1 + BOGIE_H_W);
		}
		if (info.IsRightBogieMotored)
		{
			SetBogiePixels(imgSpan, data.Stride, WIDTH - 1 - BOGIE_H_W);
			SetBogiePixels(imgSpan, data.Stride, WIDTH - 1 - BOGIE_H_W * 2);
		}

		Marshal.Copy(imgBytes, 0, data.Scan0, imgBytes.Length);
		bmp.UnlockBits(data);
	}

	static void SetBogiePixels(Span<byte> imgSpan, int stride, int col)
	{
		for (int bogieRow = 0; bogieRow < BOGLE.Length; ++bogieRow)
		{
			int imgRow = HEIGHT - BOGIE_H_W + bogieRow;
			Span<byte> rowSpan = imgSpan[(imgRow * stride)..((imgRow + 1) * stride)];
			for (int bogieCol = 0; bogieCol < BOGLE[bogieRow].Length; ++bogieCol)
			{
				int imgCol = col + bogieCol;
				if (BOGLE[bogieRow][bogieCol] == 1)
				{
					rowSpan[(imgCol * BYTE_PER_PIXEL)..((imgCol + 1) * BYTE_PER_PIXEL)].Fill(0xFF);
				}
			}
		}
	}

	static void SetPantographPixels(Span<byte> imgSpan, int stride, int col)
	{
		for (int pantographRow = 0; pantographRow < PANTOGRAPH_H_W; ++pantographRow)
		{
			bool isUpper = pantographRow <= (PANTOGRAPH_H_W / 2);
			int imgRow = 0 + pantographRow;
			Span<byte> rowSpan = imgSpan[(imgRow * stride)..((imgRow + 1) * stride)];
			int startPanCol = 5 - (isUpper ? pantographRow : (PANTOGRAPH_H_W - pantographRow - 1));
			int endPanCol = PANTOGRAPH_H_W - startPanCol;
			int startImgCol = col + startPanCol;
			int endImgCol = col + endPanCol;
			rowSpan[(startImgCol * BYTE_PER_PIXEL)..(endImgCol * BYTE_PER_PIXEL)].Fill(0xFF);
		}
	}
}
