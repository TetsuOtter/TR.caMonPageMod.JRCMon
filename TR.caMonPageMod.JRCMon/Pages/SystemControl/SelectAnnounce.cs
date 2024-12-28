using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage("自動放送")]
public partial class SelectAnnounce : FullScreenPageBase, IMultiPageFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_BACK;
	public int SelectedIndex { get; set; }
	public int MaxIndex { get; } = 2;

	public SelectAnnounce() : base(ResourceManager.ResourceFiles.SelectAnnounce)
	{
	}
}
