using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using TR.caMonPageMod.JRCMon.Pages.CarState;
using TR.caMonPageMod.JRCMon.Pages.Conductor;
using TR.caMonPageMod.JRCMon.Pages.Correction;
using TR.caMonPageMod.JRCMon.Pages.Driver;
using TR.caMonPageMod.JRCMon.Pages.Maintenance;
using TR.caMonPageMod.JRCMon.Pages.Other;
using TR.caMonPageMod.JRCMon.Pages.WorkSetting;
using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.NormalPage("メニュー", ResourceManager.ResourceFiles.MenuIcon)]
public partial class MenuPage : Canvas, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	const int FIRST_COL_X = 90;
	const int COL_STEP_X = 159;
	const int FIRST_ROW_Y = 35;
	const int ROW_STEP_Y = 144;
	const int BUTTON_WIDTH = 114;
	const int BUTTON_HEIGHT = 68;

	public MenuPage()
	{
		AddButton(3, 0, ResourceManager.ResourceFiles.ToCIcon, "目次画面");

		AddButton<DriveInfo>(0, 1, ResourceManager.ResourceFiles.DriverIcon, "運転士");
		AddButton<ConductorInto>(1, 1, ResourceManager.ResourceFiles.ConductorIcon, "車　掌");
		AddButton<MaintenanceMenuPage>(2, 1, ResourceManager.ResourceFiles.MaintenanceIcon, "検　修");
		AddButton<EmbeddedManual>(3, 1, ResourceManager.ResourceFiles.EmbeddedManualIcon, "応急ﾏﾆｭｱﾙ");

		AddButton<DirectionMenu>(0, 2, ResourceManager.ResourceFiles.WorkSettingIcon, "運行設定");
		AddButton<CarStateSW>(1, 2, ResourceManager.ResourceFiles.CarInfoIcon, "車両状態");
		AddButton<OccupancyRatePage>(2, 2, ResourceManager.ResourceFiles.OccupancyRateIcon, "乗車率");
		AddButton<CorrectionMenu>(3, 2, ResourceManager.ResourceFiles.CorrectionIcon, "補　正");

		AddSleepButton();
	}

	void AddSleepButton()
	{
		Button btn = ComponentFactory.GetBasicButton(
			new(633, 464, 0, 0),
			104,
			38,
			isSmall: true,
			color: Colors.Yellow,
			isShadowColored: true
		);

		BitmapLabel label = ComponentFactory.Get1XLabel();
		label.Text = "画面消去";
		label.Foreground = Brushes.Black;
		btn.Content = label;

		btn.Click += (s, e) => RootGrid?.SetPageType<SleepState>();
		Children.Add(btn);
	}

	void AddButton<T>(int col, int row, ResourceManager.ResourceFiles resource, string labelStr, bool isNotImplemented = false) where T : FrameworkElement
	{
		Image img = ResourceManager.GetResourceAsImage(resource);
		img.Stretch = Stretch.None;
		int x = FIRST_COL_X + COL_STEP_X * col;
		int y = FIRST_ROW_Y + ROW_STEP_Y * row;
		Button btn = ComponentFactory.GetBasicButton(new(x, y, 0, 0), BUTTON_WIDTH, BUTTON_HEIGHT);
		if (!isNotImplemented)
		{
			btn.Click += (s, e) => RootGrid?.SetPageType<T>();
		}
		btn.Content = img;
		Children.Add(btn);

		BitmapLabel label = ComponentFactory.Get1XLongLabel();
		label.Text = labelStr;
		label.Margin = new(x, y + BUTTON_HEIGHT + 4, 0, 0);
		label.Width = BUTTON_WIDTH;
		label.HorizontalContentAlignment = HorizontalAlignment.Center;
		Children.Add(label);
	}
	void AddButton(int col, int row, ResourceManager.ResourceFiles resource, string labelStr)
		=> AddButton<FrameworkElement>(col, row, resource, labelStr, true);
}
