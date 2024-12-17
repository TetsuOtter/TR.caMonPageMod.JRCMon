using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class SelectCarUnit : FullScreenPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.SELECT_CAR_UNIT;

	public SelectCarUnit() : base(ResourceManager.ResourceFiles.SelectCarUnit)
	{
	}
}
