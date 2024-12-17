using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("性能記録", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class PerformanceRecordPage : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.PERFORMANCE_RECORD;

	public PerformanceRecordPage() : base(ResourceManager.ResourceFiles.PerformanceRecord)
	{
	}
}
