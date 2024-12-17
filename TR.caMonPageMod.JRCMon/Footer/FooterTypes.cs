using TR.caMonPageMod.JRCMon.Pages.Correction;
using TR.caMonPageMod.JRCMon.Pages.Maintenance;
using TR.caMonPageMod.JRCMon.Pages.Other;
using TR.caMonPageMod.JRCMon.Pages.OtherSeries;
using TR.caMonPageMod.JRCMon.Pages.SystemControl;
using TR.caMonPageMod.JRCMon.Pages.WorkSetting;

namespace TR.caMonPageMod.JRCMon.Footer;

public record FooterInfo(string Label, Type PageClass, bool IsForceSelected = false, bool IsLeftAligned = false);

public static class FooterType
{
	public static IReadOnlyList<FooterInfo> APP_INFO { get; } =
	[
		new("ｱﾌﾟﾘ情報", typeof(AppInfoPage)),
		new("応急ﾏﾆｭｱ", typeof(EmbeddedManual)),
	];
	public static IReadOnlyList<FooterInfo> APP_SETTING { get; } =
	[
		new("表示設定", typeof(AppSettingPage)),
		new("戻る", typeof(EmbeddedManual)),
	];

	public static IReadOnlyList<FooterInfo> SELECT_CAR_UNIT { get; } =
	[
		new("ﾕﾆｯﾄ設定", typeof(SelectCarUnit)),
		new("応急ﾏﾆｭｱ", typeof(EmbeddedManual)),
	];
	public static IReadOnlyList<FooterInfo> SELECT_MY_CAR { get; } =
	[
		new("自車設定", typeof(SelectMyCar)),
		new("ﾕﾆｯﾄ設定", typeof(SelectCarUnit)),
	];
	public static IReadOnlyList<FooterInfo> SELECT_OTHER_CAR { get; } =
	[
		new("車両選択", typeof(SelectOtherCar)),
		new("ﾕﾆｯﾄ設定", typeof(SelectCarUnit)),
	];

	public static IReadOnlyList<FooterInfo> CLOCK_CORRECTION { get; } =
	[
		new("時刻補正", typeof(ClockCorrection)),
		new("補正ﾒﾆｭｰ", typeof(CorrectionMenu)),
	];
	public static IReadOnlyList<FooterInfo> CORRECTION_MENU { get; } =
	[
		new("補正ﾒﾆｭｰ", typeof(CorrectionMenu)),
		new("メニュー", typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> LOCATION_CORRECTION { get; } =
	[
		new("地点補正", typeof(LocationCorrectionPage)),
		new("戻る", typeof(CorrectionMenu)),
	];

	public static IReadOnlyList<FooterInfo> DIRECTION_MENU { get; } =
	[
		new("行先設定", typeof(DirectionMenu)),
		new("メニュー", typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> DIRECTION_SETTING { get; } =
	[
		new("行先設定", typeof(DirectionSetting)),
		new("戻る", typeof(DirectionMenu)),
	];
	public static IReadOnlyList<FooterInfo> TRAIN_TYPE_SETTING { get; } =
	[
		new("行先設定", typeof(TrainTypeSetting)),
		new("戻る", typeof(DirectionMenu)),
	];
	public static IReadOnlyList<FooterInfo> WORK_SETTING { get; } =
	[
		new("号車", typeof(MenuPage)),
		new("行先設定", typeof(MenuPage)),
		new("列番設定", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> DRIVER_WORK_SETTING { get; } =
	[
		new("列番設定", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	];

	public static IReadOnlyList<FooterInfo> OTHER_SERIES_BASE { get; } =
	[
		new("徐行情報", typeof(OtherSeriesReduceSpeedPage)),
		new("形式変更", typeof(MenuPage)),
		new("地点補正", typeof(LocationCorrectionPage)),
		new("列番設定", typeof(OtherSeriesWorkSetting)),
		new("行先設定", typeof(OtherSeriesDirection)),
		new("放送空調", typeof(OtherSeriesAnnounceACPage)),
		new("故障状態", typeof(OtherSeriesTrouble)),
	];
	public static IReadOnlyList<FooterInfo> OTHER_SERIES_ANNOUNCE_AC { get; } =
	[
		new("形式変更", typeof(MenuPage)),
		new("地点補正", typeof(LocationCorrectionPage)),
		new("副設定", typeof(OtherSeriesSubSettingPage)),
		new("列番設定", typeof(OtherSeriesWorkSetting)),
		new("行先設定", typeof(OtherSeriesDirection)),
		new("放送空調", typeof(OtherSeriesAnnounceACPage)),
		new("故障状態", typeof(OtherSeriesTrouble)),
	];
	public static IReadOnlyList<FooterInfo> OTHER_SERIES_ANNOUNCE_AC_SUB { get; } =
	[
		new("副設定", typeof(OtherSeriesSubSettingPage)),
		new("列番設定", typeof(OtherSeriesWorkSetting)),
		new("行先設定", typeof(OtherSeriesDirection)),
		new("放送空調", typeof(OtherSeriesAnnounceACPage), IsForceSelected: true),
		new("故障状態", typeof(OtherSeriesTrouble)),
	];
	public static IReadOnlyList<FooterInfo> OTHER_SERIES_WORK_SETTING { get; } =
	[
		new("列番設定", typeof(OtherSeriesWorkSetting)),
		new("行先設定", typeof(OtherSeriesDirection)),
		new("放送空調", typeof(OtherSeriesAnnounceACPage)),
		new("故障状態", typeof(OtherSeriesTrouble)),
	];

	public static IReadOnlyList<FooterInfo> MAINTENANCE_MENU { get; } =
	[
		new("検修ﾒﾆｭｰ", typeof(MaintenanceMenuPage)),
		new("ﾒﾆｭｰ", typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> PERFORMANCE_RECORD { get; } =
	[
		new("性能記録", typeof(PerformanceRecordPage)),
		new("検修ﾒﾆｭｰ", typeof(MaintenanceMenuPage)),
	];

	public static IReadOnlyList<FooterInfo> OCCUPANCY_RATE { get; } =
	[
		new("乗車率", typeof(OccupancyRatePage)),
		new("メニュー", typeof(MenuPage)),
	];

	public static IReadOnlyList<FooterInfo> CAR_INFO { get; } =
	[
		new("起動制動", typeof(MenuPage)),
		new("三相給電", typeof(MenuPage)),
		new("制動確認", typeof(MenuPage)),
		new("起動確認", typeof(MenuPage)),
		new("ｽｲｯﾁ状態", typeof(MenuPage)),
		new("戻る", typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> DRIVER_BASE { get; } =
	[
		new("徐行情報", typeof(MenuPage)),
		new("地点補正", typeof(LocationCorrectionPage)),
		// TODO: どのページに飛ぶのか確認して修正
		new("運行設定", typeof(DirectionMenu)),
		new("車両状態", typeof(MenuPage)),
		new("運転情報", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> SELECT_ANNOUNCE { get; } =
	[
		new("自動放送", typeof(SelectAnnounce)),
		new("戻る", typeof(MenuPage)),
	];

	public static IReadOnlyList<FooterInfo> CONDUCTOR_BASE { get; } =
	[
		new("車両状態", typeof(MenuPage)),
		new("地点補正", typeof(LocationCorrectionPage)),
		new("空調制御", typeof(MenuPage)),
		new("サービス", typeof(MenuPage)),
		new("車掌情報", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	];
	public static IReadOnlyList<FooterInfo> CONDUCTOR_INFO { get; } =
	[
		new("運行設定", typeof(MenuPage)),

		new("車両状態", typeof(MenuPage)),
		new("地点補正", typeof(LocationCorrectionPage)),
		new("空調制御", typeof(MenuPage)),
		new("サービス", typeof(MenuPage)),
		new("車掌情報", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	];

	public static IReadOnlyList<FooterInfo> CONDUCTOR_AIR_COND { get; } =
	[
		new("空調ﾓｰﾄﾞ", typeof(MenuPage), IsLeftAligned: true),
		new("換気", typeof(MenuPage)),
		new("副設定", typeof(MenuPage)),
		new("横流ﾌｧﾝ", typeof(MenuPage)),

		new("空調制御", typeof(MenuPage), IsForceSelected: true),
		new("サービス", typeof(MenuPage)),
		new("車掌情報", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	];
}
