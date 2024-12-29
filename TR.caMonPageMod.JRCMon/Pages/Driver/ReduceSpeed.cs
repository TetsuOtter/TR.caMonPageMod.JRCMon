using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.Driver;

[PageTypes.NormalPage("運転士", ResourceManager.ResourceFiles.DriverIcon, "徐行情報")]
public partial class ReduceSpeed : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.DRIVER_BASE;

	public ReduceSpeed() : base(ResourceManager.ResourceFiles.ReduceSpeed)
	{
	}
}
