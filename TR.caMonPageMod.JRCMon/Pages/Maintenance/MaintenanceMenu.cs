using System.Windows;
using System.Windows.Controls;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Pages.SystemControl;
using TR.caMonPageMod.JRCMon.Utils;

namespace TR.caMonPageMod.JRCMon.Pages.Maintenance;

[PageTypes.NormalPage("検　修", ResourceManager.ResourceFiles.MaintenanceIcon, "検修ﾒﾆｭｰ")]
public partial class MaintenanceMenuPage : Canvas, IHoldRootGridInstance, IFooterInfo
{
	public RootGrid? RootGrid { get; set; }
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MENU;

	const int FIRST_COL_X = 42;
	const int COL_STEP_X = 153;
	const int FIRST_ROW_Y = 141;
	const int ROW_STEP_Y = 140;

	const int BUTTON_WIDTH = 104;
	const int BUTTON_HEIGHT = 64;

	public MaintenanceMenuPage()
	{
		AddButton<PerformanceRecordPage>(0, 0, "性能記録");
		AddButton<MaintenanceTestRun>(1, 0, "試運転");
		AddButton(2, 0, "DI/DO".ToWide());
		AddButton<MaintenanceCommState>(3, 0, "伝送情報");
		AddButton<EmbeddedManual>(4, 0, ResourceManager.ResourceFiles.EmbeddedManualIcon, "応急ﾏﾆｭｱﾙ");

		AddButton<MaintenanceAC>(0, 1, "空調状態");
		AddButton(1, 1, "機器状態");
		AddButton<MaintenanceRecordList>(2, 1, "記録内容");
		AddButton(3, 1, "設定状態");
	}

	void AddButton<T>(int col, int row, string labelStr, bool isNotImplemented = false) where T : FrameworkElement, new()
	{
		Label label = ComponentFactory.Get1XLong2Label();
		label.Content = labelStr;
		AddButtonWithContent<T>(col, row, label, isNotImplemented);
	}
	void AddButton<T>(int col, int row, ResourceManager.ResourceFiles resource, string labelStr, bool isNotImplemented = false) where T : FrameworkElement, new()
	{
		Image img = ResourceManager.GetResourceAsImage(resource);
		img.Stretch = System.Windows.Media.Stretch.None;
		AddButtonWithContent<T>(col, row, img, isNotImplemented);

		Label label = ComponentFactory.Get1XLong2Label();
		label.Content = labelStr;
		int buttonX = FIRST_COL_X + COL_STEP_X * col;
		int buttonY = FIRST_ROW_Y + ROW_STEP_Y * row;
		label.Margin = new(buttonX, buttonY + BUTTON_HEIGHT, 0, 0);
		label.Padding = new(0, 1, 0, 0);
		label.Width = BUTTON_WIDTH;
		label.HorizontalContentAlignment = HorizontalAlignment.Center;
		Children.Add(label);
	}
	void AddButton(int col, int row, string labelStr)
		=> AddButton<FrameworkElement>(col, row, labelStr, true);
	void AddButtonWithContent<T>(int col, int row, object content, bool isNotImplemented = false) where T : FrameworkElement, new()
	{
		int x = FIRST_COL_X + COL_STEP_X * col;
		int y = FIRST_ROW_Y + ROW_STEP_Y * row;
		Button btn = ComponentFactory.GetBasicButton(new(x, y, 0, 0), BUTTON_WIDTH, BUTTON_HEIGHT);
		if (!isNotImplemented)
		{
			btn.Click += (s, e) => RootGrid?.SetPageType<T>();
		}
		btn.Content = content;
		Children.Add(btn);
	}
}
