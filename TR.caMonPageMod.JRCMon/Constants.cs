using System.Windows.Media;

namespace TR.caMonPageMod.JRCMon;

static internal class Constants
{
	public const int DISPLAY_WIDTH = 800;
	public const int DISPLAY_HEIGHT = 600;

	public const int HEADER_HEIGHT = 54;
	public const int BODY_HEIGHT = DISPLAY_HEIGHT - HEADER_HEIGHT;

	public static readonly FontFamily FONT_FAMILY = new("JF Dot Ayu Mincho 18");
	public const int FONT_SIZE_1X = 18;
	public const int FONT_SIZE_2X = 36;

	public const int FOOTER_MENU_BUTTON_HEIGHT = 36;
	public const int FOOTER_MENU_BUTTON_WIDTH = 82;
}
