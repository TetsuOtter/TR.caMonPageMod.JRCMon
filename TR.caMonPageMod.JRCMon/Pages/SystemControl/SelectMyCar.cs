namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class SelectMyCar : FullScreenPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public SelectMyCar() : base(ResourceManager.ResourceFiles.SelectMyCar)
	{
	}
}
