using TR.caMonPageMod.JRCMon.Pages.Correction;
using TR.caMonPageMod.JRCMon.Pages.Driver;
using TR.caMonPageMod.JRCMon.Pages.Maintenance;
using TR.caMonPageMod.JRCMon.Pages.OtherSeries;
using TR.caMonPageMod.JRCMon.Pages.SystemControl;
using TR.caMonPageMod.JRCMon.Pages.WorkSetting;

namespace TR.caMonPageMod.JRCMon.Footer;

public abstract record FooterInfo(bool IsForceSelected = false, bool IsLeftAligned = false, bool IsEnabled = true);
public record FooterInfoPage(Type PageClass, bool IsForceSelected = false, bool IsLeftAligned = false, bool IsEnabled = true) : FooterInfo(IsForceSelected, IsLeftAligned, IsEnabled);
public record FooterInfoCurrentPage(bool IsLeftAligned = false) : FooterInfo(false, IsLeftAligned, true);
public record FooterInfoGoBack(bool IsLeftAligned = false) : FooterInfo(false, IsLeftAligned, true);
public record FooterInfoDummy(string label, bool IsForceSelected = false, bool IsLeftAligned = false) : FooterInfo(IsForceSelected, IsLeftAligned, false);

public static class FooterType
{
	public static IReadOnlyList<FooterInfo> CURRENT_AND_EMBED_MAN { get; } =
	[
		new FooterInfoCurrentPage(),
		new FooterInfoPage(typeof(EmbeddedManual)),
	];
	public static IReadOnlyList<FooterInfo> CURRENT_AND_BACK { get; } =
	[
		new FooterInfoCurrentPage(),
		new FooterInfoGoBack(),
	];

	public static IReadOnlyList<FooterInfo> CURRENT_AND_SELECT_CAR_UNIT { get; } =
	[
		new FooterInfoCurrentPage(),
		new FooterInfoPage(typeof(SelectCarUnit)),
	];

	public static IReadOnlyList<FooterInfo> CURRENT_AND_CORRECTION_MENU { get; } =
	[
		new FooterInfoCurrentPage(),
		new FooterInfoPage(typeof(CorrectionMenu)),
	];
	public static IReadOnlyList<FooterInfo> CURRENT_AND_MENU { get; } =
	[
		new FooterInfoCurrentPage(),
		new FooterInfoPage(typeof(MenuPage)),
	];

	public static IReadOnlyList<FooterInfo> WORK_SETTING { get; } =
	[
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage)),
	];

	public static IReadOnlyList<FooterInfo> OTHER_SERIES_BASE { get; } =
	[
		new FooterInfoPage(typeof(OtherSeriesReduceSpeedPage)),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(LocationCorrectionPage)),
		new FooterInfoPage(typeof(OtherSeriesWorkSetting)),
		new FooterInfoPage(typeof(OtherSeriesDirection)),
		new FooterInfoPage(typeof(OtherSeriesAnnounceACPage)),
		new FooterInfoPage(typeof(OtherSeriesTrouble)),
	];
	public static IReadOnlyList<FooterInfo> OTHER_SERIES_ANNOUNCE_AC { get; } =
	[
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(LocationCorrectionPage)),
		new FooterInfoPage(typeof(OtherSeriesSubSettingPage)),
		new FooterInfoPage(typeof(OtherSeriesWorkSetting)),
		new FooterInfoPage(typeof(OtherSeriesDirection)),
		new FooterInfoPage(typeof(OtherSeriesAnnounceACPage)),
		new FooterInfoPage(typeof(OtherSeriesTrouble)),
	];
	public static IReadOnlyList<FooterInfo> OTHER_SERIES_ANNOUNCE_AC_SUB { get; } =
	[
		new FooterInfoPage(typeof(OtherSeriesSubSettingPage)),
		new FooterInfoPage(typeof(OtherSeriesWorkSetting)),
		new FooterInfoPage(typeof(OtherSeriesDirection)),
		new FooterInfoPage(typeof(OtherSeriesAnnounceACPage), IsForceSelected: true),
		new FooterInfoPage(typeof(OtherSeriesTrouble)),
	];
	public static IReadOnlyList<FooterInfo> OTHER_SERIES_WORK_SETTING { get; } =
	[
		new FooterInfoPage(typeof(OtherSeriesWorkSetting)),
		new FooterInfoPage(typeof(OtherSeriesDirection)),
		new FooterInfoPage(typeof(OtherSeriesAnnounceACPage)),
		new FooterInfoPage(typeof(OtherSeriesTrouble)),
	];

	public static IReadOnlyList<FooterInfo> CURRENT_AND_MAINTENANCE_MENU { get; } =
	[
		new FooterInfoCurrentPage(),
		new FooterInfoPage(typeof(MaintenanceMenuPage)),
	];

	public static IReadOnlyList<FooterInfo> MAINTENANCE_AC { get; } =
	[
		new FooterInfoDummy("ﾛｰﾙﾌｨﾙﾀ"),
		new FooterInfoDummy("内蔵ﾋｰﾀ"),
		new FooterInfoPage(typeof(MaintenanceAC)),
		new FooterInfoPage(typeof(MaintenanceMenuPage)),
	];

	public static IReadOnlyList<FooterInfo> CAR_INFO { get; } =
	[
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoGoBack(),
	];
	public static IReadOnlyList<FooterInfo> DRIVER_BASE { get; } =
	[
		new FooterInfoDummy("徐行情報"),
		new FooterInfoPage(typeof(LocationCorrectionPage)),
		new FooterInfoPage(typeof(DirectionMenu)),
		new FooterInfoDummy("車両状態"),
		new FooterInfoPage(typeof(DriveInfo)),
		new FooterInfoPage(typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> DRIVER_ONEMAN { get; } =
	[
		new FooterInfoDummy("車掌情報"),
		new FooterInfoDummy("徐行情報"),
		new FooterInfoPage(typeof(LocationCorrectionPage)),
		new FooterInfoPage(typeof(DirectionMenu)),
		new FooterInfoDummy("車両状態"),
		new FooterInfoPage(typeof(DriveInfo)),
		new FooterInfoPage(typeof(MenuPage)),
	];

	public static IReadOnlyList<FooterInfo> CONDUCTOR_BASE { get; } =
	[
		new FooterInfoDummy("車両状態"),
		new FooterInfoPage(typeof(LocationCorrectionPage)),
		new FooterInfoDummy("空調制御"),
		new FooterInfoDummy("サービス"),
		new FooterInfoDummy("車掌情報"),
		new FooterInfoPage(typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> CONDUCTOR_INFO { get; } =
	[
		new FooterInfoDummy("運行設定"),

		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(LocationCorrectionPage)),
		new FooterInfoDummy("空調制御"),
		new FooterInfoDummy("サービス"),
		new FooterInfoDummy("車掌情報"),
		new FooterInfoPage(typeof(MenuPage)),
	];

	public static IReadOnlyList<FooterInfo> CONDUCTOR_AIR_COND { get; } =
	[
		new FooterInfoPage(typeof(MenuPage), IsLeftAligned: true, IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),

		new FooterInfoPage(typeof(MenuPage), IsForceSelected: true, IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage), IsEnabled: false),
		new FooterInfoPage(typeof(MenuPage)),
	];
}
