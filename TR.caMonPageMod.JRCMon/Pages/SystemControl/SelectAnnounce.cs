using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class SelectAnnounce : FullScreenPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.SELECT_ANNOUNCE;

	public SelectAnnounce() : base(ResourceManager.ResourceFiles.SelectAnnounce)
	{
	}
}
