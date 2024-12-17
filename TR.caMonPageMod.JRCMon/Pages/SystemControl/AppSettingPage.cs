using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class AppSettingPage : FullScreenPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.APP_SETTING;

	public AppSettingPage() : base(ResourceManager.ResourceFiles.AppSetting)
	{
	}
}
