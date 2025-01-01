using System.Windows;
using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Parts.CarPartsStateArea;

public static class StateAreaConstants
{
	public const int TOP = ComponentFactory.Driver.ASSIST_LABEL_TOP - Constants.FONT_SIZE_2X - 8;
	public const int LEFT = ComponentFactory.Driver.ASSIST_LABEL_LEFT + 6;
	public const int AREA_PADDING = 2;
	public const int STATE_TOP = 4;

	public static int getTop(int index) => TOP + (Constants.FONT_SIZE_2X + AREA_PADDING) * index;
	public static void setTop(UIElement element, int index) => Canvas.SetTop(element, getTop(index));
}
