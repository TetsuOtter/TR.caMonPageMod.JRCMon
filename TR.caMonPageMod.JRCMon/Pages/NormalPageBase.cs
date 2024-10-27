using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages;

public abstract class NormalPageBase : Canvas
{
	public NormalPageBase(ResourceManager.ResourceFiles baseImageResource)
	{
		Image baseImage = ResourceManager.GetResourceAsImage(baseImageResource);
		baseImage.Height = Constants.BODY_HEIGHT;
		baseImage.Width = Constants.DISPLAY_WIDTH;
		Children.Add(baseImage);
	}
}
