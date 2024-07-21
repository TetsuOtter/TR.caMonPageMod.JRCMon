using System.Windows.Controls;
using System.Windows.Media;

namespace TR.caMonPageMod.JRCMon;

class Header : Grid
{
	public Header()
	{
		Height = Constants.HEADER_HEIGHT;
		Width = Constants.DISPLAY_WIDTH;
		Background = Brushes.Black;

		Image baseImage = ResourceManager.GetResourceAsImage(ResourceManager.ResourceFiles.HeaderBase);
		Children.Add(baseImage);
	}
}
