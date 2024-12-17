using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.WorkSetting;

[PageTypes.NormalPage("行先メニュ", ResourceManager.ResourceFiles.WorkSettingIcon)]
public partial class DirectionMenu : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.DIRECTION_MENU;

	public DirectionMenu() : base(ResourceManager.ResourceFiles.DirectionMenu)
	{
	}
}
