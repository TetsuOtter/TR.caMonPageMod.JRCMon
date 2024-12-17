using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式運行設定", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesWorkSetting : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.OTHER_SERIES_WORK_SETTING;

	public OtherSeriesWorkSetting() : base(ResourceManager.ResourceFiles.OtherSeriesWorkSetting)
	{
	}
}
