using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.WorkSetting;

[PageTypes.NormalPage("運行設定", ResourceManager.ResourceFiles.WorkSettingIcon, "行先設定")]
public partial class DirectionMenu : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MENU;

	public DirectionMenu() : base(ResourceManager.ResourceFiles.DirectionMenu)
	{
	}
}
