using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.WorkSetting;

[PageTypes.NormalPage("運行設定", ResourceManager.ResourceFiles.WorkSettingIcon, "行先設定")]
public partial class DirectionSetting : NormalPageBase, IMultiPageFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_BACK;
	public int SelectedIndex { get; set; }
	public int MaxIndex { get; } = 2;

	public DirectionSetting() : base(ResourceManager.ResourceFiles.DirectionSetting)
	{
	}
}
