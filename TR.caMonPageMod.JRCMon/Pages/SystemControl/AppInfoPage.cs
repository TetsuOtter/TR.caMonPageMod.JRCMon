using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class AppInfoPage : FullScreenPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	readonly Label AppVersionLabel = ComponentFactory.Get1XLongLabel();
	readonly Button GoToEmbeddedManualButton = ComponentFactory.GetFooterMenuButton(2, true);

	public AppInfoPage() : base(ResourceManager.ResourceFiles.AppInfo)
	{
		AppVersionLabel.Height = 28;
		AppVersionLabel.Width = 180;
		AppVersionLabel.Margin = new(162, 104, 0, 0);
		AppVersionLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
		AppVersionLabel.Content = ResourceManager.CurrentAssembly.GetName().Version?.ToString() ?? "Unknown";
		Children.Add(AppVersionLabel);

		GoToEmbeddedManualButton.Click += (s, e) => RootGrid?.SetPageType<EmbeddedManual>();
		Children.Add(GoToEmbeddedManualButton);
	}
}
