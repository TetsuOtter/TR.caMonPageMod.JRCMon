namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式副設定", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesSubSettingPage : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public OtherSeriesSubSettingPage() : base(ResourceManager.ResourceFiles.OtherSeriesSubSetting)
	{
	}
}
