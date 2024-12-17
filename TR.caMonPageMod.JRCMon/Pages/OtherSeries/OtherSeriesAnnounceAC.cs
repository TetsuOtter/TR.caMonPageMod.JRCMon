using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式放送空調", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesAnnounceACPage : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.OTHER_SERIES_ANNOUNCE_AC;

	public OtherSeriesAnnounceACPage() : base(ResourceManager.ResourceFiles.OtherSeriesAnnounceAC)
	{
	}
}
