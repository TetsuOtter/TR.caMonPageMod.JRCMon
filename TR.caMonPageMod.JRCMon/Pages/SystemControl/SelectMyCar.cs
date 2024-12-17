using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class SelectMyCar : FullScreenPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.SELECT_MY_CAR;

	public SelectMyCar() : base(ResourceManager.ResourceFiles.SelectMyCar)
	{
	}
}
