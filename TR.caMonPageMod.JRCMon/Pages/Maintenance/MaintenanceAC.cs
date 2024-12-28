using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("空調状態", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class MaintenanceAC : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.MAINTENANCE_AC;

	public MaintenanceAC() : base(ResourceManager.ResourceFiles.MaintenanceAC)
	{
	}
}
