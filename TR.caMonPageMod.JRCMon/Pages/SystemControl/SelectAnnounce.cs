using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage]
public partial class SelectAnnounce : FullScreenPageBase, IMultiPageFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.SELECT_ANNOUNCE;
	public int SelectedIndex { get; set; }
	public int MaxIndex { get; } = 2;

	public SelectAnnounce() : base(ResourceManager.ResourceFiles.SelectAnnounce)
	{
	}
}
