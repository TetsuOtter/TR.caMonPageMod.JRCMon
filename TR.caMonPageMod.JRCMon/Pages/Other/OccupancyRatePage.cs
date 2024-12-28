using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Other;

[PageTypes.NormalPage("乗車率", ResourceManager.ResourceFiles.OccupancyRateIcon)]
public partial class OccupancyRatePage : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MENU;

	public OccupancyRatePage() : base(ResourceManager.ResourceFiles.OccupancyRatePage)
	{
	}
}
