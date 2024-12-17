using TR.caMonPageMod.JRCMon.Footer;

namespace TR.caMonPageMod.JRCMon.Pages.OtherSeries;

[PageTypes.NormalPage("他形式副設定", ResourceManager.ResourceFiles.OtherSeriesIcon)]
public partial class OtherSeriesSubSettingPage : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.OTHER_SERIES_ANNOUNCE_AC_SUB;

	public OtherSeriesSubSettingPage() : base(ResourceManager.ResourceFiles.OtherSeriesSubSetting)
	{
	}
}
