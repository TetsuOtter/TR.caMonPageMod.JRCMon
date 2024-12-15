using System.Windows.Controls;

using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class AppInfoPage : FullScreenPageBase, IHoldRootGridInstance, IFooterInfo
{
	public RootGrid? RootGrid { get; set; }

  public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.APP_INFO;

  readonly Label AppVersionLabel = ComponentFactory.Get1XLongLabel();

	public AppInfoPage() : base(ResourceManager.ResourceFiles.AppInfo)
	{
		AppVersionLabel.Height = 28;
		AppVersionLabel.Width = 180;
		AppVersionLabel.Margin = new(162, 104, 0, 0);
		AppVersionLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
		AppVersionLabel.Content = ResourceManager.CurrentAssembly.GetName().Version?.ToString() ?? "Unknown";
		Children.Add(AppVersionLabel);
	}
}
