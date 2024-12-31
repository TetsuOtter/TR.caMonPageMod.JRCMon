using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Header;

namespace TR.caMonPageMod.JRCMon.Pages.WorkSetting;

[PageTypes.NormalPage("種別", ResourceManager.ResourceFiles.WorkSettingIcon)]
public partial class TrainTypeSetting : NormalPageBase, IHeaderOverride, IMultiPageFooterInfo
{
	public string HeaderTitle => Context.HeaderTitle;
	public ResourceManager.ResourceFiles HeaderIcon { get; } = ResourceManager.ResourceFiles.TrainTypeSetting;
	public IReadOnlyList<FooterInfo> FooterInfoList { get; }
	public int SelectedIndex { get; set; }
	public int MaxIndex { get; } = 2;

	WorkSettingContext Context;
	public TrainTypeSetting(WorkSettingContext context) : base(ResourceManager.ResourceFiles.TrainTypeSetting)
	{
		Context = context;
		FooterInfoList = FooterType.getCurrentAndBackWithArgs(() => [Context]);
	}
}
