using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage("ﾕﾆｯﾄ設定")]
public partial class SelectCarUnit : FullScreenPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_EMBED_MAN;

	public SelectCarUnit() : base(ResourceManager.ResourceFiles.SelectCarUnit)
	{
	}
}
