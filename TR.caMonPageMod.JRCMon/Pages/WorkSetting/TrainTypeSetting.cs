using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.WorkSetting;

[PageTypes.NormalPage("種別", ResourceManager.ResourceFiles.WorkSettingIcon)]
public partial class TrainTypeSetting : NormalPageBase, IMultiPageFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.SELECT_ANNOUNCE;
	public int SelectedIndex { get; set; }
	public int MaxIndex { get; } = 2;

	public TrainTypeSetting() : base(ResourceManager.ResourceFiles.TrainTypeSetting)
	{
	}
}
