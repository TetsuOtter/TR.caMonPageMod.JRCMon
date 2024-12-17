using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式徐行", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesReduceSpeedPage : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.OTHER_SERIES_BASE;

	public OtherSeriesReduceSpeedPage() : base(ResourceManager.ResourceFiles.OtherSeriesReduceSpeed)
	{
	}
}
