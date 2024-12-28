using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("試運転", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class MaintenanceTestRun : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MAINTENANCE_MENU;

	public MaintenanceTestRun() : base(ResourceManager.ResourceFiles.MaintenanceTestRun)
	{
		Children.Add(new LocationLabel());
	}
}
