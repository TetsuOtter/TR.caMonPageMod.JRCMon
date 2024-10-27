namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class SelectCarUnit : FullScreenPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public SelectCarUnit() : base(ResourceManager.ResourceFiles.SelectCarUnit)
	{
	}
}
