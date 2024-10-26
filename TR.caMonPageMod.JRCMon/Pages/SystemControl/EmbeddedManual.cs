using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class EmbeddedManual : Canvas, IHoldRootGridInstance
{
  public RootGrid? RootGrid { get; set; }

	private readonly Button GoToAppInfoButton = ComponentFactory.GetEmptyButton(
		new(82, 139, 0, 0),
		132,
		68
	);

	private readonly Button GoToMenuButton = ComponentFactory.GetEmptyButton(
		new(195, 493, 0, 0),
		132,
		68
	);

	private readonly Button CloseAppButton = ComponentFactory.GetEmptyButton(
		new(642, 511, 0, 0),
		98,
		42
	);

	public EmbeddedManual()
	{
		Image baseImage = ResourceManager.GetResourceAsImage(ResourceManager.ResourceFiles.EmbeddedManual);
		baseImage.Height = Constants.DISPLAY_HEIGHT;
		baseImage.Width = Constants.DISPLAY_WIDTH;
		Children.Add(baseImage);

		GoToAppInfoButton.Click += (s, e) => RootGrid?.SetPageType<AppInfoPage>();
		Children.Add(GoToAppInfoButton);

		GoToMenuButton.Click += (s, e) => RootGrid?.SetPageType<MenuPage>();
		Children.Add(GoToMenuButton);

		CloseAppButton.Click += (s, e) => RootGrid?.CloseAppInvoke();
		Children.Add(CloseAppButton);
	}

}
