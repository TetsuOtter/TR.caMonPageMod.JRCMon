using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式故障", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesTrouble : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.OTHER_SERIES_BASE;

	public OtherSeriesTrouble() : base(ResourceManager.ResourceFiles.OtherSeriesTrouble)
	{
	}
}
