using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages;

public abstract class FullScreenPageBase : Canvas, IBaseImage
{
	public Image BaseImage { get; }
	public FullScreenPageBase(ResourceManager.ResourceFiles baseImageResource)
	{
		Image baseImage = ResourceManager.GetResourceAsImage(baseImageResource);
		Children.Add(baseImage);
		BaseImage = baseImage;
	}
}
