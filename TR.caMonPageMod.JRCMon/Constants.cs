using System.Windows.Media;

namespace TR.caMonPageMod.JRCMon;

static internal class Constants
{
	public const int DISPLAY_WIDTH = 800;
	public const int DISPLAY_HEIGHT = 600;

	public const int HEADER_HEIGHT = 40;
	public const int FOOTER_HEIGHT = 32;
	public const int NORMAL_BODY_IMG_HEIGHT = 550;
	public const int BODY_IMG_HEIGHT = 508;
	public const int BODY_HEIGHT = DISPLAY_HEIGHT - HEADER_HEIGHT - FOOTER_HEIGHT;

	public static readonly FontFamily FONT_FAMILY = new("JF Dot jiskan16");
	public static readonly Typeface FONT_TYPEFACE = FONT_FAMILY.GetTypefaces().First();
	public const int FONT_SIZE_1X = 16;
	public const int FONT_SIZE_2X = 32;

	public const int TEXT_PADDING_Y = 2;

	public const double FOOTER_LINE_HEIGHT = 1;
	public const int FOOTER_MENU_BUTTON_HEIGHT = FOOTER_HEIGHT;
	public const int FOOTER_MENU_BUTTON_WIDTH = 84;
}
