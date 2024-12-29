using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("試運転", ResourceManager.ResourceFiles.MaintenanceIcon)]
public class MaintenanceTestRun : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MAINTENANCE_MENU;

	public MaintenanceTestRun(AppState state) : base(ResourceManager.ResourceFiles.MaintenanceTestRun)
	{
		Children.Add(new LocationLabel());

		Children.Add(new TrainFormationImage(state));
	}
}
