using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("伝送情報", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class MaintenanceCommState : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MAINTENANCE_MENU;

	public MaintenanceCommState() : base(ResourceManager.ResourceFiles.MaintenanceCommState)
	{
	}
}
