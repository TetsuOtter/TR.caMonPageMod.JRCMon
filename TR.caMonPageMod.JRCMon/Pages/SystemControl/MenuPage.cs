using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.NormalPage("メニュー", ResourceManager.ResourceFiles.MenuIcon)]
public partial class MenuPage : Canvas, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	private readonly Button GoToEmbeddedManualButton = ComponentFactory.GetEmptyButton(
		new(568, 178, 0, 0),
		113,
		66
	);

	public MenuPage()
	{
		Image baseImage = ResourceManager.GetResourceAsImage(ResourceManager.ResourceFiles.MenuPage);
		baseImage.Height = Constants.BODY_HEIGHT;
		baseImage.Width = Constants.DISPLAY_WIDTH;
		Children.Add(baseImage);

		GoToEmbeddedManualButton.Click += (s, e) => RootGrid?.SetPageType<EmbeddedManual>();
		Children.Add(GoToEmbeddedManualButton);
	}
}
