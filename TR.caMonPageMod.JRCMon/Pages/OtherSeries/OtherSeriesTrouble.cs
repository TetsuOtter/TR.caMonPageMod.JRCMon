namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式故障", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesTrouble : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public OtherSeriesTrouble() : base(ResourceManager.ResourceFiles.OtherSeriesTrouble)
	{
	}
}
