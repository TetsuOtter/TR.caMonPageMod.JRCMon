using System.Windows;
using System.Windows.Controls;

using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Correction;

[PageTypes.NormalPage("補正メニュ", ResourceManager.ResourceFiles.CorrectionIcon)]
public partial class CorrectionMenu : NormalPageBase, IHoldRootGridInstance, IFooterInfo
{
	public RootGrid? RootGrid { get; set; }
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CORRECTION_MENU;

	public CorrectionMenu() : base(ResourceManager.ResourceFiles.CorrectionMenu)
	{
		AddButtonWithXY<ClockCorrection>(157, 230);
		AddButtonWithXY<FrameworkElement>(532, 230, true);
	}

	void AddButtonWithXY<T>(int x, int y, bool isNotImplemented = false) where T: FrameworkElement, new()
	{
		Button btn = ComponentFactory.GetEmptyButton(new(x, y, 0, 0), 132, 68);
		if (isNotImplemented)
			btn.Content = "未実装";
		else
			btn.Click += (s, e) => RootGrid?.SetPageType<T>();
		Children.Add(btn);
	}
}
