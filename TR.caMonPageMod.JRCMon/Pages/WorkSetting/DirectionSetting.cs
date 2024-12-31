using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Header;

namespace TR.caMonPageMod.JRCMon.Pages.WorkSetting;

[PageTypes.NormalPage("運行設定", ResourceManager.ResourceFiles.WorkSettingIcon, "行先設定")]
public partial class DirectionSetting : NormalPageBase, IHeaderOverride, IMultiPageFooterInfo
{
	public string HeaderTitle => Context.HeaderTitle;
	public ResourceManager.ResourceFiles HeaderIcon { get; } = ResourceManager.ResourceFiles.WorkSettingIcon;
	public IReadOnlyList<FooterInfo> FooterInfoList { get; }
	public int SelectedIndex { get; set; }
	public int MaxIndex { get; } = 2;

	WorkSettingContext Context;
	public DirectionSetting(WorkSettingContext context) : base(ResourceManager.ResourceFiles.DirectionSetting)
	{
		Context = context;
		FooterInfoList = FooterType.getCurrentAndBackWithArgs(() => [Context]);
	}
}
