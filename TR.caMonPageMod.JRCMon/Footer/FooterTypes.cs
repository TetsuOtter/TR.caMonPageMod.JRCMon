using TR.caMonPageMod.JRCMon.Pages.CarState;
using TR.caMonPageMod.JRCMon.Pages.Conductor;
using TR.caMonPageMod.JRCMon.Pages.Correction;
using TR.caMonPageMod.JRCMon.Pages.Driver;
using TR.caMonPageMod.JRCMon.Pages.Maintenance;
using TR.caMonPageMod.JRCMon.Pages.OtherSeries;
using TR.caMonPageMod.JRCMon.Pages.SystemControl;
using TR.caMonPageMod.JRCMon.Pages.WorkSetting;

namespace TR.caMonPageMod.JRCMon.Footer;

public abstract record FooterInfo(bool IsForceSelected = false, bool IsLeftAligned = false, bool IsEnabled = true);
public record FooterInfoPage(Type PageClass, string? Label = null, Func<object[]>? getArgs = null, bool IsForceSelected = false, bool IsLeftAligned = false, bool IsEnabled = true) : FooterInfo(IsForceSelected, IsLeftAligned, IsEnabled);
public record FooterInfoCurrentPage(bool IsLeftAligned = false) : FooterInfo(false, IsLeftAligned, true);
public record FooterInfoGoBack(Func<object[]>? getArgs = null, bool IsLeftAligned = false) : FooterInfo(false, IsLeftAligned, true);
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
	public static IReadOnlyList<FooterInfo> getCurrentAndBackWithArgs(Func<object[]> getArgs)
	 => [
			new FooterInfoCurrentPage(),
			new FooterInfoGoBack(getArgs),
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

	public static IReadOnlyList<FooterInfo> getForWorkSetting(Func<WorkSettingContext> getContext)
	{
		if (getContext().Source == PageSource.Driver)
			return CURRENT_AND_MENU;

		return [
			new FooterInfoDummy("号車"),
			new FooterInfoPage(typeof(DirectionMenu), getArgs: () => [getContext()]),
			new FooterInfoPage(typeof(DirectionSettingNumber), getArgs: () => [getContext()]),
			new FooterInfoPage(typeof(MenuPage)),
		];
	}

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

	public static IReadOnlyList<FooterInfo> CAR_STATE { get; } =
	[
		new FooterInfoPage(typeof(CarStatePowerBrake)),
		new FooterInfoPage(typeof(CarStateThreePhase)),
		new FooterInfoDummy("制動確認"),
		new FooterInfoDummy("起動確認"),
		new FooterInfoPage(typeof(CarStateInfo)),
		new FooterInfoGoBack(),
	];
	public static IReadOnlyList<FooterInfo> CAR_STATE_INFO { get; } =
	[
		new FooterInfoPage(typeof(CarStateSW.Page1), "次画面", IsLeftAligned: true),

		new FooterInfoPage(typeof(CarStatePowerBrake)),
		new FooterInfoPage(typeof(CarStateThreePhase)),
		new FooterInfoDummy("制動確認"),
		new FooterInfoDummy("起動確認"),
		new FooterInfoPage(typeof(CarStateInfo)),
		new FooterInfoGoBack(),
	];
	public static IReadOnlyList<FooterInfo> CAR_STATE_SW1 { get; } =
	[
		new FooterInfoPage(typeof(CarStateSW.Page2), "次画面", IsLeftAligned: true),
		new FooterInfoPage(typeof(CarStateInfo), "前画面", IsLeftAligned: true),

		new FooterInfoPage(typeof(CarStatePowerBrake)),
		new FooterInfoPage(typeof(CarStateThreePhase)),
		new FooterInfoDummy("制動確認"),
		new FooterInfoDummy("起動確認"),
		new FooterInfoPage(typeof(CarStateSW.Page1)),
		new FooterInfoGoBack(),
	];
	public static IReadOnlyList<FooterInfo> CAR_STATE_SW2 { get; } =
	[
		new FooterInfoPage(typeof(CarStateSW.Page1), "前画面", IsLeftAligned: true),

		new FooterInfoPage(typeof(CarStatePowerBrake)),
		new FooterInfoPage(typeof(CarStateThreePhase)),
		new FooterInfoDummy("制動確認"),
		new FooterInfoDummy("起動確認"),
		new FooterInfoPage(typeof(CarStateSW.Page2)),
		new FooterInfoGoBack(),
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

	public static IReadOnlyList<FooterInfo> DRIVER_BASE { get; } =
	[
		new FooterInfoPage(typeof(ReduceSpeed)),
		new FooterInfoPage(typeof(LocationCorrectionPage), getArgs: () => [PageSource.Driver]),
		new FooterInfoPage(typeof(DirectionSettingNumber), "運行設定", () => [new WorkSettingContext(PageSource.Driver)]),
		new FooterInfoPage(typeof(CarStateInfo), "車両状態"),
		new FooterInfoPage(typeof(DriveInfo)),
		new FooterInfoPage(typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> DRIVER_ONEMAN { get; } =
	[
		new FooterInfoPage(typeof(ConductorInto)),
		new FooterInfoPage(typeof(ReduceSpeed)),
		new FooterInfoPage(typeof(LocationCorrectionPage), getArgs: () => [PageSource.Driver]),
		new FooterInfoPage(typeof(DirectionSettingNumber), "運行設定", () => [new WorkSettingContext(PageSource.Driver)]),
		new FooterInfoPage(typeof(CarStateInfo), "車両状態"),
		new FooterInfoPage(typeof(DriveInfo)),
		new FooterInfoPage(typeof(MenuPage)),
	];

	public static IReadOnlyList<FooterInfo> CONDUCTOR_BASE { get; } =
	[
		new FooterInfoPage(typeof(CarStateSW.Page1), "車両状態"),
		new FooterInfoPage(typeof(LocationCorrectionPage), getArgs: () => [PageSource.Conductor]),
		new FooterInfoPage(typeof(ConductorAC_Sub), "空調制御"),
		new FooterInfoPage(typeof(ConductorService)),
		new FooterInfoPage(typeof(ConductorInto)),
		new FooterInfoPage(typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> CONDUCTOR_BASE_315 { get; } =
	[
		new FooterInfoPage(typeof(Conductor315)),
		new FooterInfoPage(typeof(CarStateSW.Page1), "車両状態"),
		new FooterInfoPage(typeof(LocationCorrectionPage), getArgs: () => [PageSource.Conductor]),
		new FooterInfoPage(typeof(ConductorAC_Sub), "空調制御"),
		new FooterInfoPage(typeof(ConductorService)),
		new FooterInfoPage(typeof(ConductorInto)),
		new FooterInfoPage(typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> CONDUCTOR_INFO { get; } =
	[
		new FooterInfoPage(typeof(DirectionSettingNumber), "運行設定", () => [new WorkSettingContext(PageSource.Conductor)]),

		new FooterInfoPage(typeof(CarStateSW.Page1), "車両状態"),
		new FooterInfoPage(typeof(LocationCorrectionPage), getArgs: () => [PageSource.Conductor]),
		new FooterInfoPage(typeof(ConductorAC_Sub), "空調制御"),
		new FooterInfoPage(typeof(ConductorService)),
		new FooterInfoPage(typeof(ConductorInto)),
		new FooterInfoPage(typeof(MenuPage)),
	];

	public static IReadOnlyList<FooterInfo> CONDUCTOR_AIR_COND { get; } =
	[
		new FooterInfoPage(typeof(ConductorAC), IsLeftAligned: true),
		new FooterInfoPage(typeof(ConductorAC_Vent)),
		new FooterInfoPage(typeof(ConductorAC_Sub)),
		new FooterInfoPage(typeof(ConductorAC_CrossFlow)),

		new FooterInfoDummy("空調制御", IsForceSelected: true),
		new FooterInfoPage(typeof(ConductorService)),
		new FooterInfoPage(typeof(ConductorInto)),
		new FooterInfoPage(typeof(MenuPage)),
	];
}
