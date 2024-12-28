using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("記録詳細", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class MaintenanceRecordDetail : NormalPageBase, IMultiPageFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MAINTENANCE_MENU;

	public int SelectedIndex { get; set; }

	public int MaxIndex { get; } = 2;

	public MaintenanceRecordDetail() : base(ResourceManager.ResourceFiles.MaintenanceRecordDetail)
	{
	}
}
