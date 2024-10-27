namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class AppSettingPage : FullScreenPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public AppSettingPage() : base(ResourceManager.ResourceFiles.AppSetting)
	{
	}
}
