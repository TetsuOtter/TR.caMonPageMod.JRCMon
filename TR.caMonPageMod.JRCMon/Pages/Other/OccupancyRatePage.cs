namespace TR.caMonPageMod.JRCMon.Pages.Other;

[PageTypes.NormalPage("乗車率", ResourceManager.ResourceFiles.OccupancyRateIcon)]
public partial class OccupancyRatePage : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public OccupancyRatePage() : base(ResourceManager.ResourceFiles.OccupancyRatePage)
	{
	}
}
