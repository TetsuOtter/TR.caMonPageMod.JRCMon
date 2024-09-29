using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class SleepState : Canvas, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	private readonly Button GoToMenuPageButton = ComponentFactory.GetEmptyButton(
		new(0),
		Constants.DISPLAY_WIDTH,
		Constants.DISPLAY_HEIGHT
	);

	public SleepState()
	{
		GoToMenuPageButton.Click += (s, e) => RootGrid?.SetPageType<MenuPage>();
		Children.Add(GoToMenuPageButton);
	}
}
