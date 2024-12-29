using System.Windows;
using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage("応急ﾏﾆｭｱ")]
public partial class EmbeddedManual : FullScreenPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	private readonly Button CloseAppButton = ComponentFactory.GetEmptyButton(
		new(642, 511, 0, 0),
		98,
		42
	);
	const int FIRST_COL_X = 82;
	const int COL_STEP_X = 245;
	const int FIRST_ROW_Y = 139;
	const int ROW_STEP_Y = 137;

	public EmbeddedManual() : base(ResourceManager.ResourceFiles.EmbeddedManual)
	{
		AddButtonWithRowCol<AppInfoPage>(0, 0);
		AddButtonWithRowCol(1, 0);
		AddButtonWithRowCol<AppSettingPage>(2, 0);

		AddButtonWithRowCol(0, 1);
		AddButtonWithRowCol<SelectCarUnit>(1, 1);
		AddButtonWithRowCol<SelectAnnounce>(2, 1);

		AddButtonWithXY<MenuPage>(195, 493);

		CloseAppButton.Click += (s, e) => RootGrid?.CloseAppInvoke();
		Children.Add(CloseAppButton);
	}

	void AddButtonWithRowCol<T>(int col, int row, bool isNotImplemented = false) where T : FrameworkElement
	{
		int x = FIRST_COL_X + COL_STEP_X * col;
		int y = FIRST_ROW_Y + ROW_STEP_Y * row;
		AddButtonWithXY<T>(x, y, isNotImplemented);
	}
	void AddButtonWithRowCol(int col, int row)
		=> AddButtonWithRowCol<FrameworkElement>(col, row, true);

	void AddButtonWithXY<T>(int x, int y, bool isNotImplemented = false) where T : FrameworkElement
	{
		Button btn = ComponentFactory.GetEmptyButton(new(x, y, 0, 0), 132, 68);
		if (isNotImplemented)
			btn.Content = "未実装";
		else
			btn.Click += (s, e) => RootGrid?.SetPageType<T>();
		Children.Add(btn);
	}
}
