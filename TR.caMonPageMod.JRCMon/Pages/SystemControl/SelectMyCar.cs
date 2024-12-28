using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage("自車設定")]
public partial class SelectMyCar : FullScreenPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_SELECT_CAR_UNIT;

	public SelectMyCar() : base(ResourceManager.ResourceFiles.SelectMyCar)
	{
	}
}
