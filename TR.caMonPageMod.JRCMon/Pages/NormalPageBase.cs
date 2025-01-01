using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages;

public abstract class NormalPageBase : Canvas, IBaseImage
{
	public Image BaseImage { get; }
	public NormalPageBase(ResourceManager.ResourceFiles baseImageResource)
	{
		Image baseImage = ResourceManager.GetResourceAsImage(baseImageResource);
		Children.Add(baseImage);
		BaseImage = baseImage;
	}
}
