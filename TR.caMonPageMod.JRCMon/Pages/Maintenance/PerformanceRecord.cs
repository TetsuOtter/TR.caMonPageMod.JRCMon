namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("検修メニュー", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class PerformanceRecordPage : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public PerformanceRecordPage() : base(ResourceManager.ResourceFiles.PerformanceRecord)
	{
	}
}
