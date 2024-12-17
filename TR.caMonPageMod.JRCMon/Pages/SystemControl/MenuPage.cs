using System.Windows;
using System.Windows.Controls;

using TR.caMonPageMod.JRCMon.Pages.Correction;
using TR.caMonPageMod.JRCMon.Pages.Maintenance;
using TR.caMonPageMod.JRCMon.Pages.Other;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.NormalPage("メニュー", ResourceManager.ResourceFiles.MenuIcon)]
public partial class MenuPage : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	private readonly Button GoToSleepStateButton = ComponentFactory.GetEmptyButton(
		new(633, 464, 0, 0),
		104,
		38
	);

	const int FIRST_COL_X = 90;
	const int COL_STEP_X = 159;
	const int FIRST_ROW_Y = 35;
	const int ROW_STEP_Y = 144;

	public MenuPage() : base(ResourceManager.ResourceFiles.MenuPage)
	{
		AddMenuButton(3, 0);

		AddMenuButton(0, 1);
		AddMenuButton(1, 1);
		AddMenuButton<MaintenanceMenuPage>(2, 1);
		AddMenuButton<EmbeddedManual>(3, 1);

		AddMenuButton(0, 2);
		AddMenuButton(1, 2);
		AddMenuButton<OccupancyRatePage>(2, 2);
		AddMenuButton<CorrectionMenu>(3, 2);

		GoToSleepStateButton.Click += (s, e) => RootGrid?.SetPageType<SleepState>();
		Children.Add(GoToSleepStateButton);
	}

	void AddMenuButton<T>(int col, int row, bool isNotImplemented = false) where T: FrameworkElement, new()
	{
		int x = FIRST_COL_X + COL_STEP_X * col;
		int y = FIRST_ROW_Y + ROW_STEP_Y * row;
		Button btn = ComponentFactory.GetEmptyButton(new(x, y, 0, 0), 113, 68);
		if (isNotImplemented)
			btn.Content = "未実装";
		else
			btn.Click += (s, e) => RootGrid?.SetPageType<T>();
		Children.Add(btn);
	}
	void AddMenuButton(int col, int row)
		=> AddMenuButton<FrameworkElement>(col, row, true);
}
