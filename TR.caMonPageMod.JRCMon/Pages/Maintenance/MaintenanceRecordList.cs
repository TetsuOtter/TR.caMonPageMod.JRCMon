using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("記録内容", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class MaintenanceRecordList : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MAINTENANCE_MENU;

	public MaintenanceRecordList() : base(ResourceManager.ResourceFiles.MaintenanceRecordList)
	{
	}
}
