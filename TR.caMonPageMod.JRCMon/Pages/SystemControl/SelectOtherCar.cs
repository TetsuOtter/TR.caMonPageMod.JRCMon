using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage("車両選択")]
public partial class SelectOtherCar : FullScreenPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_SELECT_CAR_UNIT;

	public SelectOtherCar() : base(ResourceManager.ResourceFiles.SelectOtherCar)
	{
	}
}
