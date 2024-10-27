namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class SelectOtherCar : FullScreenPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public SelectOtherCar() : base(ResourceManager.ResourceFiles.SelectOtherCar)
	{
	}
}
