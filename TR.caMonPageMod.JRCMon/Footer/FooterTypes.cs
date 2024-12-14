using System.Collections.Generic;

namespace TR.caMonPageMod.JRCMon.Footer;

public static record FooterInfo(string Label, Type PageClass, bool IsForceSelected = false, bool IsLeftAligned = false);

public static class FooterType
{
	public static IReadOnlyList<FooterInfo> APP_INFO { get; } = new List<FooterInfo>
	{
		new("ｱﾌﾟﾘ情報", typeof(AppInfoPage)),
		new("応急ﾏﾆｭｱ", typeof(EmbeddedManual)),
	};
	public static IReadOnlyList<FooterInfo> APP_SETTING { get; } = new List<FooterInfo>
	{
		new("表示設定", typeof(AppSettingPage)),
		new("戻る", typeof(EmbeddedManual)),
	};

	public static IReadOnlyList<FooterInfo> CLOCK_CORRECTION { get; } = new List<FooterInfo>
	{
		new("時刻補正", typeof(ClockCorrection)),
		new("補正ﾒﾆｭｰ", typeof(CorrectionMenu)),
	};
	public static IReadOnlyList<FooterInfo> CORRECTION_MENU { get; } = new List<FooterInfo>
	{
		new("補正ﾒﾆｭｰ", typeof(CorrectionMenu)),
		new("メニュー", typeof(MenuPage)),
	};
	public static IReadOnlyList<FooterInfo> LOCATION_CORRECTION { get; } = new List<FooterInfo>
	{
		new("地点補正", typeof(LocationCorrection)),
		new("戻る", typeof(CorrectionMenu)),
	};

	public static IReadOnlyList<FooterInfo> DIRECTION_MENU { get; } = new List<FooterInfo>
	{
		new("行先設定", typeof(DirectionMenu)),
		new("メニュー", typeof(MenuPage)),
	};
	public static IReadOnlyList<FooterInfo> DIRECTION_SETTING { get; } = new List<FooterInfo>
	{
		new("行先設定", typeof(DirectionSetting)),
		new("戻る", typeof(DirectionMenu)),
	};
	public static IReadOnlyList<FooterInfo> WORK_SETTING { get; } = new List<FooterInfo>
	{
		new("号車", typeof(MenuPage)),
		new("行先設定", typeof(MenuPage)),
		new("列番設定", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	};
	public static IReadOnlyList<FooterInfo> DRIVER_WORK_SETTING { get; } = new List<FooterInfo>
	{
		new("列番設定", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	};

	public static IReadOnlyList<FooterInfo> OTHER_SERIES_BASE { get; } = new List<FooterInfo>
	{
		new("徐行情報", typeof(MenuPage)),
		new("形式変更", typeof(MenuPage)),
		new("地点補正", typeof(LocationCorrection)),
		new("列番設定", typeof(MenuPage)),
		new("行先設定", typeof(MenuPage)),
		new("放送空調", typeof(MenuPage)),
		new("故障状態", typeof(MenuPage)),
	};
	public static IReadOnlyList<FooterInfo> OTHER_SERIES_WORK_SETTING { get; } = new List<FooterInfo>
	{
		// 列番設定ページでのみ表示
		// new("列番設定", typeof(MenuPage)),
		new("行先設定", typeof(MenuPage)),
		new("放送空調", typeof(MenuPage)),
		new("故障状態", typeof(MenuPage)),
	};

	public static IReadOnlyList<FooterInfo> MAINTENANCE_MENU { get; } = new List<FooterInfo>
	{
		new("検修ﾒﾆｭｰ", typeof(MaintenanceMenu)),
		new("ﾒﾆｭｰ", typeof(MenuPage)),
	};
	public static IReadOnlyList<FooterInfo> PERFORMANCE_RECORD { get; } = new List<FooterInfo>
	{
		new("性能記録", typeof(PerformanceRecord)),
		new("検修ﾒﾆｭｰ", typeof(MaintenanceMenu)),
	};

	public static IReadOnlyList<FooterInfo> OCCUPANCY_RATE { get; } = new List<FooterInfo>
	{
		new("乗車率", typeof(OccupancyRate)),
		new("メニュー", typeof(MenuPage)),
	};

	public static IReadOnlyList<FooterInfo> CAR_INFO { get; } = new List<FooterInfo>
	{
		new("起動制動", typeof(MenuPage)),
		new("三相給電", typeof(MenuPage)),
		new("制動確認", typeof(MenuPage)),
		new("起動確認", typeof(MenuPage)),
		new("ｽｲｯﾁ状態", typeof(MenuPage)),
		new("戻る", typeof(MenuPage)),
	};
	public static IReadOnlyList<FooterInfo> DRIVER_BASE { get; } = new List<FooterInfo>
	{
		new("徐行情報", typeof(DriverCarInfo)),
		new("地点補正", typeof(LocationCorrection)),
		// TODO: どのページに飛ぶのか確認して修正
		new("運行設定", typeof(DirectionMenu)),
		new("車両状態", typeof(MenuPage)),
		new("運転情報", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	};

	public static IReadOnlyList<FooterInfo> CONDUCTOR_BASE { get; } = new List<FooterInfo>
	{
		new("車両状態", typeof(MenuPage)),
		new("地点補正", typeof(LocationCorrection)),
		new("空調制御", typeof(MenuPage)),
		new("サービス", typeof(MenuPage)),
		new("車掌情報", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	};
	public static IReadOnlyList<FooterInfo> CONDUCTOR_INFO { get; } = new List<FooterInfo>
	{
		new("運行設定", typeof(MenuPage)),

		new("車両状態", typeof(MenuPage)),
		new("地点補正", typeof(LocationCorrection)),
		new("空調制御", typeof(MenuPage)),
		new("サービス", typeof(MenuPage)),
		new("車掌情報", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	};

	public static IReadOnlyList<FooterInfo> CONDUCTOR_AIR_COND { get; } = new List<FooterInfo>
	{
		new("空調ﾓｰﾄﾞ", typeof(MenuPage), IsLeftAligned: true),
		new("換気", typeof(MenuPage)),
		new("副設定", typeof(MenuPage)),
		new("横流ﾌｧﾝ", typeof(MenuPage)),

		new("空調制御", typeof(MenuPage), IsForceSelected: true),
		new("サービス", typeof(MenuPage)),
		new("車掌情報", typeof(MenuPage)),
		new("メニュー", typeof(MenuPage)),
	};
}
