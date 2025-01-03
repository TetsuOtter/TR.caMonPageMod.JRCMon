using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TR.caMonPageMod.JRCMon;

public static class ResourceManager
{
	public enum ResourceFiles
	{
		Test,
		HeaderBase,

		AppSetting,
		CarDetect,
		CarDetect_1,
		CarDetect_2,
		CarStatePowerBrake,
		CarStateThreePhase,
		ClockCorrection,
		Conductor315,
		ConductorAC_CrossFlow,
		ConductorAC_Sub,
		ConductorAC_Vent,
		ConductorAC,
		ConductorService,
		CorrectionMenu,
		DirectionMenu,
		DirectionSetting,
		DirectionSettingNumber,
		EmbeddedManual,
		LocationCorrection,
		MaintenanceCommState,
		MaintenanceRecordDetail,
		MaintenanceRecordList,
		MaintenanceTestRun,
		OccupancyRatePage,
		OtherSeriesAnnounceAC,
		OtherSeriesDirection,
		OtherSeriesSubSetting,
		OtherSeriesTrouble,
		OtherSeriesWorkSetting,
		PerformanceRecord,
		ReduceSpeed,
		SelectAnnounce,
		SelectCarUnit,
		SelectMyCar,
		SelectOtherCar,
		TrainTypeSetting,

		CarInfoIcon,
		ConductorIcon,
		CorrectionIcon,
		DriverIcon,
		EmbeddedManualIcon,
		MaintenanceIcon,
		MenuIcon,
		OccupancyRateIcon,
		OtherSeriesIcon,
		ToCIcon,
		WorkSettingIcon,

		FooterSW_OFF,
		FooterSW_ON,
		CircleSW,
		RoundSW_S,
		RoundSW_M,
		RoundSW_L,
	}

	public static readonly Assembly CurrentAssembly = Assembly.GetExecutingAssembly();

	const string RESOURCE_PATH_PREFIX = "TR.caMonPageMod.JRCMon.Resources.";

	static readonly IReadOnlyDictionary<ResourceFiles, string[]> ResourceFileNames = new Dictionary<ResourceFiles, string[]>
	{
		[ResourceFiles.Test] = ["Body", "運転情報.png"],
		[ResourceFiles.HeaderBase] = ["Header", "Base.png"],

		[ResourceFiles.AppSetting] = ["Body", "AppSetting.png"],
		[ResourceFiles.CarDetect] = ["Body", "CarDetect.png"],
		[ResourceFiles.CarDetect_1] = ["Body", "CarDetect_1.png"],
		[ResourceFiles.CarDetect_2] = ["Body", "CarDetect_2.png"],
		[ResourceFiles.CarStatePowerBrake] = ["Body", "CarStatePowerBrake.png"],
		[ResourceFiles.CarStateThreePhase] = ["Body", "CarStateThreePhase.png"],
		[ResourceFiles.ClockCorrection] = ["Body", "ClockCorrection.png"],
		[ResourceFiles.Conductor315] = ["Body", "Conductor315.png"],
		[ResourceFiles.ConductorAC_CrossFlow] = ["Body", "ConductorAC_CrossFlow.png"],
		[ResourceFiles.ConductorAC_Sub] = ["Body", "ConductorAC_Sub.png"],
		[ResourceFiles.ConductorAC_Vent] = ["Body", "ConductorAC_Vent.png"],
		[ResourceFiles.ConductorAC] = ["Body", "ConductorAC.png"],
		[ResourceFiles.ConductorService] = ["Body", "ConductorService.png"],
		[ResourceFiles.CorrectionMenu] = ["Body", "CorrectionMenu.png"],
		[ResourceFiles.DirectionMenu] = ["Body", "DirectionMenu.png"],
		[ResourceFiles.DirectionSetting] = ["Body", "DirectionSetting.png"],
		[ResourceFiles.DirectionSettingNumber] = ["Body", "DirectionSettingNumber.png"],
		[ResourceFiles.EmbeddedManual] = ["Body", "EmbeddedManual.png"],
		[ResourceFiles.LocationCorrection] = ["Body", "LocationCorrection.png"],
		[ResourceFiles.MaintenanceCommState] = ["Body", "MaintenanceCommState.png"],
		[ResourceFiles.MaintenanceRecordDetail] = ["Body", "MaintenanceRecordDetail.png"],
		[ResourceFiles.MaintenanceRecordList] = ["Body", "MaintenanceRecordList.png"],
		[ResourceFiles.MaintenanceTestRun] = ["Body", "MaintenanceTestRun.png"],
		[ResourceFiles.OccupancyRatePage] = ["Body", "OccupancyRate.png"],
		[ResourceFiles.OtherSeriesAnnounceAC] = ["Body", "OtherSeriesAnnounceAC.png"],
		[ResourceFiles.OtherSeriesDirection] = ["Body", "OtherSeriesDirection.png"],
		[ResourceFiles.OtherSeriesSubSetting] = ["Body", "OtherSeriesSubSetting.png"],
		[ResourceFiles.OtherSeriesTrouble] = ["Body", "OtherSeriesTrouble.png"],
		[ResourceFiles.OtherSeriesWorkSetting] = ["Body", "OtherSeriesWorkSetting.png"],
		[ResourceFiles.PerformanceRecord] = ["Body", "PerformanceRecord.png"],
		[ResourceFiles.ReduceSpeed] = ["Body", "ReduceSpeed.png"],
		[ResourceFiles.SelectAnnounce] = ["Body", "SelectAnnounce.png"],
		[ResourceFiles.SelectCarUnit] = ["Body", "SelectCarUnit.png"],
		[ResourceFiles.SelectMyCar] = ["Body", "SelectMyCar.png"],
		[ResourceFiles.SelectOtherCar] = ["Body", "SelectOtherCar.png"],
		[ResourceFiles.TrainTypeSetting] = ["Body", "TrainTypeSetting.png"],

		[ResourceFiles.CarInfoIcon] = ["Header", "PageIcon", "CarInfo.png"],
		[ResourceFiles.ConductorIcon] = ["Header", "PageIcon", "Conductor.png"],
		[ResourceFiles.CorrectionIcon] = ["Header", "PageIcon", "Correction.png"],
		[ResourceFiles.DriverIcon] = ["Header", "PageIcon", "Driver.png"],
		[ResourceFiles.EmbeddedManualIcon] = ["Header", "PageIcon", "EmbeddedManual.png"],
		[ResourceFiles.MaintenanceIcon] = ["Header", "PageIcon", "Maintenance.png"],
		[ResourceFiles.MenuIcon] = ["Header", "PageIcon", "Menu.png"],
		[ResourceFiles.OccupancyRateIcon] = ["Header", "PageIcon", "OccupancyRate.png"],
		[ResourceFiles.OtherSeriesIcon] = ["Header", "PageIcon", "OtherSeries.png"],
		[ResourceFiles.ToCIcon] = ["Header", "PageIcon", "ToC.png"],
		[ResourceFiles.WorkSettingIcon] = ["Header", "PageIcon", "WorkSetting.png"],

		[ResourceFiles.FooterSW_OFF] = ["Parts", "FooterSW_OFF.png"],
		[ResourceFiles.FooterSW_ON] = ["Parts", "FooterSW_ON.png"],
		[ResourceFiles.CircleSW] = ["Parts", "CircleSW.png"],
		[ResourceFiles.RoundSW_S] = ["Parts", "RoundSW_S.png"],
		[ResourceFiles.RoundSW_M] = ["Parts", "RoundSW_M.png"],
		[ResourceFiles.RoundSW_L] = ["Parts", "RoundSW_L.png"],
	};

	public static string GetResourcePath(ResourceFiles resourceFile)
		=> RESOURCE_PATH_PREFIX + string.Join('.', ResourceFileNames[resourceFile]);

	public static Stream GetResourceAsStream(ResourceFiles resourceFile)
	{
		string path = GetResourcePath(resourceFile);
		Stream? stream = CurrentAssembly.GetManifestResourceStream(path) ?? throw new($"Resource {resourceFile} not found.");
		return stream;
	}
	public static BitmapImage GetResourceAsBitmapImage(ResourceFiles resourceFile)
	{
		BitmapImage bitmapImage = new();
		using (var stream = GetResourceAsStream(resourceFile))
		{
			bitmapImage.BeginInit();
			bitmapImage.StreamSource = stream;
			bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
			bitmapImage.EndInit();
			bitmapImage.Freeze();
		}
		return bitmapImage;
	}
	public static Image GetResourceAsImage(ResourceFiles resourceFile)
	{
		BitmapImage src = GetResourceAsBitmapImage(resourceFile);
		var image = new Image
		{
			Source = src,
			Stretch = Stretch.Fill,
			Height = src.PixelHeight,
			Width = src.PixelWidth,
		};

		return image;
	}
}
