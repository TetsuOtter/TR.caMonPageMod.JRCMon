using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages.System;

[PageTypes.FullScreenPage]
public partial class AppInfoPage : Grid
{
	public AppInfoPage()
	{
		Image baseImage = ResourceManager.GetResourceAsImage(ResourceManager.ResourceFiles.AppInfo);
		Children.Add(baseImage);
	}
}
