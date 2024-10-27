namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("検修メニュー", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class MaintenanceMenuPage : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public MaintenanceMenuPage() : base(ResourceManager.ResourceFiles.MaintenanceMenu)
	{
	}
}
