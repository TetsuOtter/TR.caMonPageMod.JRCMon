using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

using TR.caMonPageMod.JRCMon.Utils;

namespace TR.caMonPageMod.JRCMon.Parts.Unit;

public static class CarImageGen
{
	public const int HEIGHT = 60;
	public const int WIDTH = 48;
	const PixelFormat PIXEL_FORMAT = PixelFormat.Format32bppArgb;
	const int BYTE_PER_PIXEL = 4;
	public const int CAB_Y = 1;
	public const int ROOF_Y = 11;
	public const int SEPARATOR_Y = ROOF_Y + Constants.FONT_SIZE_1X;
	public const int SEPARATOR_HEIGHT = 2;
	const int CAB_WIDTH = 25;
	const int CAB_BORDER_ROW_COUNT = ROOF_Y - CAB_Y + 1;
	const double CAB_BORDER_WIDTH = (double)CAB_WIDTH / CAB_BORDER_ROW_COUNT;
	const int RIGHT_CAB_CLIFF_COL = WIDTH - CAB_WIDTH;
	const int BOGIE_H_W = 7;
	const int BOGIE_PADDING_LR = 1;
	const int BOGIE_AREA_WIDTH = BOGIE_H_W + BOGIE_PADDING_LR * 2;
	const int PANTOGRAPH_H_W = 11;
	static readonly Color DRIVER_CAB_COLOR = Color.FromArgb(0xFF, 0x00, 0x5F, 0xED);
	static readonly byte[] DRIVER_CAB_COLOR_BYTES = BitConverter.GetBytes(DRIVER_CAB_COLOR.ToArgb());
	static readonly Color TYPE315_COLOR = Color.White;
	static readonly byte[] TYPE315_COLOR_BYTES = BitConverter.GetBytes(TYPE315_COLOR.ToArgb());

	static readonly byte[][] BOGLE = [
		[0, 0, 1, 1, 1, 0, 0],
		[0, 1, 0, 0, 0, 1, 0],
		[1, 0, 0, 0, 0, 0, 1],
		[1, 0, 0, 0, 0, 0, 1],
		[1, 0, 0, 0, 0, 0, 1],
		[0, 1, 0, 0, 0, 1, 0],
		[0, 0, 1, 1, 1, 0, 0],
	];

	const byte CAB_BORDER = 1;
	const byte CAB_INNER = 2;
	static readonly byte[][] LEFT_CAB;
	static readonly byte[][] RIGHT_CAB;
	static CarImageGen()
	{
		LEFT_CAB = new byte[CAB_BORDER_ROW_COUNT][];
		RIGHT_CAB = new byte[CAB_BORDER_ROW_COUNT][];

		static int getLeftCabStartCol(int cabRow)
			=> (int)(CAB_BORDER_WIDTH * (CAB_BORDER_ROW_COUNT - cabRow - 1));
		for (int row = 0; row < CAB_BORDER_ROW_COUNT; ++row)
		{
			byte[] rowBytes = new byte[CAB_WIDTH];
			Span<byte> rowSpan = rowBytes;
			int startCol = getLeftCabStartCol(row);
			int endCol = getLeftCabStartCol(row - 1);
			rowSpan[startCol..endCol].Fill(CAB_BORDER);
			if (endCol < (CAB_WIDTH - 1))
				rowSpan[endCol..(CAB_WIDTH - 1)].Fill(CAB_INNER);
			rowSpan[CAB_WIDTH - 1] = CAB_BORDER;

			LEFT_CAB[row] = rowBytes;
			RIGHT_CAB[row] = rowBytes.Reverse().ToArray();
		}
	}

	public record CarImageInfo(
		bool IsLeftCab,
		bool IsRightCab,

		bool HasPantograph,
		bool HasSecondPantograph,

		bool IsLeftBogieMotored,
		bool IsRightBogieMotored,
		bool IsLeftBogieMotorWorking,
		bool IsRightBogieMotorWorking,

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

		byte[]? ColorBytes = info.IsDriverCab ? DRIVER_CAB_COLOR_BYTES : info.Is315 ? TYPE315_COLOR_BYTES : null;
		Span<byte> colorSpan = ColorBytes.AsSpan();

		if (info.IsLeftCab || info.IsRightCab)
		{
			byte[][] src = info.IsLeftCab ? LEFT_CAB : RIGHT_CAB;
			int imgCabStartCol = info.IsLeftCab ? 0 : RIGHT_CAB_CLIFF_COL;
			for (int cabRow = 0; cabRow < LEFT_CAB.Length; ++cabRow)
			{
				int imgRow = CAB_Y + cabRow;
				Span<byte> rowSpan = imgSpan[(imgRow * data.Stride)..((imgRow + 1) * data.Stride)];
				for (int cabCol = 0; cabCol < src[cabRow].Length; ++cabCol)
				{
					int imgCol = imgCabStartCol + cabCol;
					Span<byte> targetSpan = rowSpan[(imgCol * BYTE_PER_PIXEL)..((imgCol + 1) * BYTE_PER_PIXEL)];
					if (src[cabRow][cabCol] == CAB_BORDER)
					{
						targetSpan.Fill(0xFF);
					}
					else if (ColorBytes is not null && src[cabRow][cabCol] == CAB_INNER)
					{
						colorSpan.CopyTo(targetSpan);
					}
				}
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
			else if (row == (HEIGHT - BOGIE_H_W - 1) || (SEPARATOR_Y <= row && row < SEPARATOR_Y + SEPARATOR_HEIGHT))
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
			for (int row = ROOF_Y + 1; row < SEPARATOR_Y; ++row)
			{
				Span<byte> rowSpan = imgSpan[(row * data.Stride)..((row + 1) * data.Stride)];
				colorSpan.CopyAndFill(rowSpan[(1 * BYTE_PER_PIXEL)..((WIDTH - 1) * BYTE_PER_PIXEL)]);
			}
		}

		if (info.IsLeftBogieMotored)
		{
			SetBogiePixels(imgSpan, data.Stride, BOGIE_PADDING_LR, info.IsLeftBogieMotorWorking);
			SetBogiePixels(imgSpan, data.Stride, BOGIE_AREA_WIDTH + BOGIE_PADDING_LR, info.IsLeftBogieMotorWorking);
		}
		if (info.IsRightBogieMotored)
		{
			SetBogiePixels(imgSpan, data.Stride, WIDTH - BOGIE_AREA_WIDTH + BOGIE_PADDING_LR, info.IsRightBogieMotorWorking);
			SetBogiePixels(imgSpan, data.Stride, WIDTH - BOGIE_AREA_WIDTH * 2 + BOGIE_PADDING_LR, info.IsRightBogieMotorWorking);
		}

		Marshal.Copy(imgBytes, 0, data.Scan0, imgBytes.Length);
		bmp.UnlockBits(data);
	}

	static void SetBogiePixels(Span<byte> imgSpan, int stride, int col, bool isBogieWorking)
	{
		for (int bogieRow = 0; bogieRow < BOGLE.Length; ++bogieRow)
		{
			int imgRow = HEIGHT - BOGIE_H_W + bogieRow;
			Span<byte> rowSpan = imgSpan[(imgRow * stride + (col * BYTE_PER_PIXEL))..((imgRow + 1) * stride)];
			ReadOnlySpan<byte> bogieRowBytes = BOGLE[bogieRow];
			if (isBogieWorking)
			{
				int startBogieCol = bogieRowBytes.IndexOf((byte)1);
				int endBogieCol = bogieRowBytes.LastIndexOf((byte)1);
				rowSpan[(startBogieCol * BYTE_PER_PIXEL)..((endBogieCol + 1) * BYTE_PER_PIXEL)].Fill(0xFF);
			}
			else
			{
				for (int bogieCol = 0; bogieCol < bogieRowBytes.Length; ++bogieCol)
				{
					if (bogieRowBytes[bogieCol] == 1)
					{
						rowSpan[(bogieCol * BYTE_PER_PIXEL)..((bogieCol + 1) * BYTE_PER_PIXEL)].Fill(0xFF);
					}
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
