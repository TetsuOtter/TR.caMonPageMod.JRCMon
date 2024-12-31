using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Header;

namespace TR.caMonPageMod.JRCMon.Pages.WorkSetting;

[PageTypes.NormalPage("運行設定", ResourceManager.ResourceFiles.WorkSettingIcon, "列番設定")]
public partial class DirectionSettingNumber : NormalPageBase, IHeaderOverride, IFooterInfo
{
	public string HeaderTitle => Context.HeaderTitle;
	public ResourceManager.ResourceFiles HeaderIcon { get; } = ResourceManager.ResourceFiles.WorkSettingIcon;
	public IReadOnlyList<FooterInfo> FooterInfoList { get; }

	WorkSettingContext Context;
	public DirectionSettingNumber(WorkSettingContext context) : base(ResourceManager.ResourceFiles.DirectionSettingNumber)
	{
		Context = context;
		FooterInfoList = FooterType.getForWorkSetting(() => Context);
	}
}
