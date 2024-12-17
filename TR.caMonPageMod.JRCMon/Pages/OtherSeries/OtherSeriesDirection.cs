using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式行先設定", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesDirection : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.OTHER_SERIES_WORK_SETTING;

	public OtherSeriesDirection() : base(ResourceManager.ResourceFiles.OtherSeriesDirection)
	{
	}
}
