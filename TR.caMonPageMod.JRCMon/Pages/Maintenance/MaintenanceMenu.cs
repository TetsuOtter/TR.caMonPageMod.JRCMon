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
		AddButtonWithXY<PerformanceRecordPage>(191, 230, "性能記録");
		AddButtonWithXY<FrameworkElement>(508, 230, "検修情報", true);
	}

	void AddButtonWithXY<T>(int x, int y, string labelStr, bool isNotImplemented = false) where T: FrameworkElement, new()
	{
		Label label = ComponentFactory.Get1HalfXLabel();
		Button btn = ComponentFactory.GetBasicButton(new(x, y, 0, 0), 113, 67);
		if (isNotImplemented)
			label.Content = $"未実装\n{labelStr}";
		else
		{
			label.Content = labelStr;
			btn.Click += (s, e) => RootGrid?.SetPageType<T>();
		}
		btn.Content = label;
		Children.Add(btn);
	}
}
