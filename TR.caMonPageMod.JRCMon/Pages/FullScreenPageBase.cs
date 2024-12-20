using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages;

public abstract class FullScreenPageBase : Canvas, IBaseImage
{
	public Image BaseImage { get; }
	public FullScreenPageBase(ResourceManager.ResourceFiles baseImageResource)
	{
		Image baseImage = ResourceManager.GetResourceAsImage(baseImageResource);
		baseImage.Height = Constants.DISPLAY_HEIGHT;
		baseImage.Width = Constants.DISPLAY_WIDTH;
		Children.Add(baseImage);
		BaseImage = baseImage;
	}
}
