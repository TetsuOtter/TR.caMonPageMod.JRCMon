namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式行先設定", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesDirection : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public OtherSeriesDirection() : base(ResourceManager.ResourceFiles.OtherSeriesDirection)
	{
	}
}
