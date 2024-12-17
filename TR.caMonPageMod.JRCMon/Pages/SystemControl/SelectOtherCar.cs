using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class SelectOtherCar : FullScreenPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.SELECT_OTHER_CAR;

	public SelectOtherCar() : base(ResourceManager.ResourceFiles.SelectOtherCar)
	{
	}
}
