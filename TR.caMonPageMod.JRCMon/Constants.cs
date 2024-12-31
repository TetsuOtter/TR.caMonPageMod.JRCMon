using System.Windows.Media;

namespace TR.caMonPageMod.JRCMon;

static internal class Constants
{
	public const int DISPLAY_WIDTH = 800;
	public const int DISPLAY_HEIGHT = 600;

	public const int HEADER_HEIGHT = 50;
	public const int FOOTER_HEIGHT = 32;
	public const int BODY_IMG_HEIGHT = 508;
	public const int BODY_HEIGHT = DISPLAY_HEIGHT - HEADER_HEIGHT - FOOTER_HEIGHT;

	public static readonly FontFamily FONT_FAMILY = new("JF Dot Ayu Mincho 18");
	public static readonly FontFamily FONT_FAMILY_FOOTER = new("JF Dot jiskan16");
	public const int FONT_SIZE_FOOTER = 16;
	public const int FONT_SIZE_1X = 18;
	public const int FONT_SIZE_1_HALF_X = 27;
	public const int FONT_SIZE_2X = 36;

	public const double FOOTER_LINE_HEIGHT = 1;
	public const int FOOTER_MENU_BUTTON_HEIGHT = FOOTER_HEIGHT;
	public const int FOOTER_MENU_BUTTON_WIDTH = 84;
}
