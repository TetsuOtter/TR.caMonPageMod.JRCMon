using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Other;

[PageTypes.NormalPage("乗車率", ResourceManager.ResourceFiles.OccupancyRateIcon)]
public partial class OccupancyRatePage : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.OCCUPANCY_RATE;

	public OccupancyRatePage() : base(ResourceManager.ResourceFiles.OccupancyRatePage)
	{
	}
}
