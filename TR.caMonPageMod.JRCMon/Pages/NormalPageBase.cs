using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages;

public abstract class NormalPageBase : Canvas, IBaseImage
{
	public Image BaseImage { get; }
	public NormalPageBase(ResourceManager.ResourceFiles baseImageResource)
	{
		Image baseImage = ResourceManager.GetResourceAsImage(baseImageResource);
		baseImage.Height = Constants.NORMAL_BODY_IMG_HEIGHT;
		baseImage.Width = Constants.DISPLAY_WIDTH;
		Children.Add(baseImage);
		BaseImage = baseImage;
	}
}
