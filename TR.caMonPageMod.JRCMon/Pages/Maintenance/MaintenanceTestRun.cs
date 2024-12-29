using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("試運転", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class MaintenanceTestRun : NormalPageBase, IFooterInfo, IAppStateSetter
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MAINTENANCE_MENU;

	public MaintenanceTestRun() : base(ResourceManager.ResourceFiles.MaintenanceTestRun)
	{
		Children.Add(new LocationLabel());
	}

	TrainFormationImage? trainFormationImage;
	public void SetAppState(AppState state)
	{
		if (trainFormationImage is not null)
			Children.Remove(trainFormationImage);
		trainFormationImage = new(state);
		trainFormationImage.Opacity = 0.5;
		Children.Add(trainFormationImage);
	}
}
