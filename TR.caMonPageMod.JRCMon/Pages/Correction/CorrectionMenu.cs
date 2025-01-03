using System.Windows;
using System.Windows.Controls;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon.Pages.Correction;

[PageTypes.NormalPage("補　正", ResourceManager.ResourceFiles.CorrectionIcon, "補正ﾒﾆｭｰ")]
public partial class CorrectionMenu : NormalPageBase, IHoldRootGridInstance, IFooterInfo
{
	public RootGrid? RootGrid { get; set; }
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MENU;

	public CorrectionMenu() : base(ResourceManager.ResourceFiles.CorrectionMenu)
	{
		AddButtonWithXY<ClockCorrection>(157, 230, "時刻設定");
		AddButtonWithXY<FrameworkElement>(532, 230, "乗車率体重", true);
	}

	void AddButtonWithXY<T>(int x, int y, string labelStr, bool isNotImplemented = false) where T : FrameworkElement
	{
		BitmapLabel label = ComponentFactory.Get1XLongLabel();
		Button btn = ComponentFactory.GetBasicButton(new(x, y, 0, 0), 132, 68);
		label.Text = labelStr;
		if (!isNotImplemented)
		{
			btn.Click += (s, e) => RootGrid?.SetPageType<T>();
		}
		btn.Content = label;
		Children.Add(btn);
	}
}
