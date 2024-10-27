namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式放送空調", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesAnnounceACPage : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public OtherSeriesAnnounceACPage() : base(ResourceManager.ResourceFiles.OtherSeriesAnnounceAC)
	{
	}
}
