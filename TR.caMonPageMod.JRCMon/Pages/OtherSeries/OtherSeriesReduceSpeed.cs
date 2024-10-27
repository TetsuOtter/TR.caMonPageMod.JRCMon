namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式徐行", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesReduceSpeedPage : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public OtherSeriesReduceSpeedPage() : base(ResourceManager.ResourceFiles.OtherSeriesReduceSpeed)
	{
	}
}
