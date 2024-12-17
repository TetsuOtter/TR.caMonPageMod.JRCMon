using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Correction;

[PageTypes.NormalPage("補正メニュ", ResourceManager.ResourceFiles.CorrectionIcon)]
public partial class CorrectionMenu : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CORRECTION_MENU;

	public CorrectionMenu() : base(ResourceManager.ResourceFiles.CorrectionMenu)
	{
	}
}
