using System.Windows;
using System.Windows.Controls;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Header;
using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon.Pages.WorkSetting;

[PageTypes.NormalPage("運行設定", ResourceManager.ResourceFiles.WorkSettingIcon, "行先設定")]
public partial class DirectionMenu : NormalPageBase, IHeaderOverride, IFooterInfo, IHoldRootGridInstance
{
	public string HeaderTitle => Context.HeaderTitle;
	public ResourceManager.ResourceFiles HeaderIcon { get; } = ResourceManager.ResourceFiles.WorkSettingIcon;
	public IReadOnlyList<FooterInfo> FooterInfoList { get; }

	public RootGrid? RootGrid { get; set; }

	const int BUTTON_WIDTH = 95;
	const int BUTTON_HEIGHT = 48;

	private WorkSettingContext Context;

	public DirectionMenu(WorkSettingContext context) : base(ResourceManager.ResourceFiles.DirectionMenu)
	{
		Context = context;
		FooterInfoList = FooterType.getCurrentAndBackWithArgs(() => [Context]);

		Children.Add(new LocationLabel());

		AddButton<DirectionSettingNumber>(47, 97, "列車番号", context);
		AddButton<DirectionSetting>(47, 284, "一　括", context);

		AddButton<DirectionSetting>(422, 88, "一　括", context);

		for (int i = 0; i < 6; ++i)
		{
			AddButton<DirectionSetting>(422, 146 + BUTTON_HEIGHT * i, $"{i + 1}編成", context with { Direction_EditingTarget = i });
		}
	}

	void AddButton<T>(int x, int y, string labelStr, WorkSettingContext context, bool isNotImplemented = false) where T : FrameworkElement
	{
		Button btn = ComponentFactory.GetBasicButton(new(x, y, 0, 0), BUTTON_WIDTH, BUTTON_HEIGHT, isSmall: true);
		if (!isNotImplemented)
		{
			btn.Click += (s, e) => RootGrid?.SetPageType<T>(context);
		}
		Children.Add(btn);

		BitmapLabel label = ComponentFactory.Get1XLongLabel();
		label.Text = labelStr;
		btn.Content = label;
	}
	void AddButton(int col, int row, string labelStr)
		=> AddButton<FrameworkElement>(col, row, labelStr, Context, true);
}
