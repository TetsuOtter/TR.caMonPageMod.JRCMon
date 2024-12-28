using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage("表示設定")]
public partial class AppSettingPage : FullScreenPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_BACK;

	public AppSettingPage() : base(ResourceManager.ResourceFiles.AppSetting)
	{
	}
}
