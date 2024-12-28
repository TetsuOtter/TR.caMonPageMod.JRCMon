using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Correction;

[PageTypes.NormalPage("地点補正", ResourceManager.ResourceFiles.CorrectionIcon)]
public partial class LocationCorrectionPage : NormalPageBase, IMultiPageFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_BACK;
	public int SelectedIndex { get; set; }
	public int MaxIndex { get; } = 2;

	public LocationCorrectionPage() : base(ResourceManager.ResourceFiles.LocationCorrection_1)
	{
	}
}
