using System.Windows.Controls;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("空調状態", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class MaintenanceAC : Canvas, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.MAINTENANCE_AC;

	public MaintenanceAC()
	{
		Children.Add(new LocationLabel());
	}
}
