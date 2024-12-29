using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.WorkSetting;

[PageTypes.NormalPage("運行設定", ResourceManager.ResourceFiles.WorkSettingIcon, "列番設定")]
public partial class DirectionSettingNumber : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.WORK_SETTING;

	public DirectionSettingNumber() : base(ResourceManager.ResourceFiles.DirectionSettingNumber)
	{
	}
}
