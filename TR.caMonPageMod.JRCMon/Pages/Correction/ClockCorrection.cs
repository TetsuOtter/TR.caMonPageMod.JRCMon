using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Correction;

[PageTypes.NormalPage("時刻設定", ResourceManager.ResourceFiles.CorrectionIcon)]
public partial class ClockCorrection : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CLOCK_CORRECTION;

	public ClockCorrection() : base(ResourceManager.ResourceFiles.ClockCorrection)
	{
	}
}
