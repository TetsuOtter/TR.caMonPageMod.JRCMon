using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("検修メニュー", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class MaintenanceMenuPage : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.MAINTENANCE_MENU;

	public MaintenanceMenuPage() : base(ResourceManager.ResourceFiles.MaintenanceMenu)
	{
	}
}
