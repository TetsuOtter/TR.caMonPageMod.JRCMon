using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("性能記録", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class PerformanceRecordPage : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MAINTENANCE_MENU;

	public PerformanceRecordPage() : base(ResourceManager.ResourceFiles.PerformanceRecord)
	{
		Children.Add(new LocationLabel());
	}
}
