using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Header;
using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon.Pages.Correction;

[PageTypes.NormalPage("地点補正", ResourceManager.ResourceFiles.CorrectionIcon)]
public partial class LocationCorrectionPage : NormalPageBase, IHeaderOverride, IMultiPageFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_BACK;
	public int SelectedIndex { get; set; }
	public int MaxIndex { get; } = 2;

	public string HeaderTitle => "地点補正";

	public ResourceManager.ResourceFiles HeaderIcon { get; }

	public LocationCorrectionPage(PageSource source) : base(ResourceManager.ResourceFiles.LocationCorrection)
	{
		HeaderIcon = source switch
		{
			PageSource.Menu => ResourceManager.ResourceFiles.CorrectionIcon,
			PageSource.Driver => ResourceManager.ResourceFiles.DriverIcon,
			PageSource.Conductor => ResourceManager.ResourceFiles.ConductorIcon,
			_ => throw new NotImplementedException(),
		};
		Children.Add(new LocationLabel());
	}
}
