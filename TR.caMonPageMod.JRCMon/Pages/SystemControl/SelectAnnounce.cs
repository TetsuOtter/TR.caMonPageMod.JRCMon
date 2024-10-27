namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class SelectAnnounce : FullScreenPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public SelectAnnounce() : base(ResourceManager.ResourceFiles.SelectAnnounce)
	{
	}
}
