namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式運行設定", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesWorkSetting : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public OtherSeriesWorkSetting() : base(ResourceManager.ResourceFiles.OtherSeriesWorkSetting)
	{
	}
}
