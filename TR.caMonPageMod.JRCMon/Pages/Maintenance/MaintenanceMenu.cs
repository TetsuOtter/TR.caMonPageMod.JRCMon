using System.Windows;
using System.Windows.Controls;

using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("検修メニュー", ResourceManager.ResourceFiles.MaintenanceIcon)]
public partial class MaintenanceMenuPage : NormalPageBase, IHoldRootGridInstance, IFooterInfo
{
	public RootGrid? RootGrid { get; set; }
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.MAINTENANCE_MENU;

	public MaintenanceMenuPage() : base(ResourceManager.ResourceFiles.MaintenanceMenu)
	{
		AddButtonWithXY<PerformanceRecordPage>(191, 230);
		AddButtonWithXY<FrameworkElement>(508, 230, true);
	}

	void AddButtonWithXY<T>(int x, int y, bool isNotImplemented = false) where T: FrameworkElement, new()
	{
		Button btn = ComponentFactory.GetEmptyButton(new(x, y, 0, 0), 113, 67);
		if (isNotImplemented)
			btn.Content = "未実装";
		else
			btn.Click += (s, e) => RootGrid?.SetPageType<T>();
		Children.Add(btn);
	}
}
