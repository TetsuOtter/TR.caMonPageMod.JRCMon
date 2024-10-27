using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TR.caMonPageMod.JRCMon;

public static class ResourceManager
{
	public enum ResourceFiles
	{
		HeaderBase,

		AppInfo,
		AppSetting,
		CarDetect,
		CarDetect_1,
		CarDetect_2,
		EmbeddedManual,
		LocationCorrection_1,
		LocationCorrection_2,
		LocationCorrection_3,
		MaintenanceMenu,
		MenuPage,
		OccupancyRatePage,
		OtherSeriesAnnounceAC,
		OtherSeriesDirection,
		OtherSeriesReduceSpeed,
		OtherSeriesSubSetting,
		OtherSeriesTrouble,
		OtherSeriesWorkSetting,

		CorrectionIcon,
		MaintenanceIcon,
		MenuIcon,
		OccupancyRateIcon,
		OtherSeriesIcon,
	}

	public static readonly Assembly CurrentAssembly = Assembly.GetExecutingAssembly();

	const string RESOURCE_PATH_PREFIX = "TR.caMonPageMod.JRCMon.Resources.";

	static readonly IReadOnlyDictionary<ResourceFiles, string[]> ResourceFileNames = new Dictionary<ResourceFiles, string[]>
	{
		[ResourceFiles.HeaderBase] = ["Header", "Base.png"],

		[ResourceFiles.AppInfo] = ["Body", "AppInfo.png"],
		[ResourceFiles.AppSetting] = ["Body", "AppSetting.png"],
		[ResourceFiles.CarDetect] = ["Body", "CarDetect.png"],
		[ResourceFiles.CarDetect_1] = ["Body", "CarDetect_1.png"],
		[ResourceFiles.CarDetect_2] = ["Body", "CarDetect_2.png"],
		[ResourceFiles.EmbeddedManual] = ["Body", "EmbeddedManual.png"],
		[ResourceFiles.LocationCorrection_1] = ["Body", "LocationCorrection_1.png"],
		[ResourceFiles.LocationCorrection_2] = ["Body", "LocationCorrection_2.png"],
		[ResourceFiles.LocationCorrection_3] = ["Body", "LocationCorrection_3.png"],
		[ResourceFiles.MaintenanceMenu] = ["Body", "MaintenanceMenu.png"],
		[ResourceFiles.MenuPage] = ["Body", "MenuPage.png"],
		[ResourceFiles.OccupancyRatePage] = ["Body", "OccupancyRate.png"],
		[ResourceFiles.OtherSeriesAnnounceAC] = ["Body", "OtherSeriesAnnounceAC.png"],
		[ResourceFiles.OtherSeriesDirection] = ["Body", "OtherSeriesDirection.png"],
		[ResourceFiles.OtherSeriesReduceSpeed] = ["Body", "OtherSeriesReduceSpeed.png"],
		[ResourceFiles.OtherSeriesSubSetting] = ["Body", "OtherSeriesSubSetting.png"],
		[ResourceFiles.OtherSeriesTrouble] = ["Body", "OtherSeriesTrouble.png"],
		[ResourceFiles.OtherSeriesWorkSetting] = ["Body", "OtherSeriesWorkSetting.png"],

		[ResourceFiles.CorrectionIcon] = ["Header", "PageIcon", "Correction.png"],
		[ResourceFiles.MaintenanceIcon] = ["Header", "PageIcon", "Maintenance.png"],
		[ResourceFiles.MenuIcon] = ["Header", "PageIcon", "Menu.png"],
		[ResourceFiles.OccupancyRateIcon] = ["Header", "PageIcon", "OccupancyRate.png"],
		[ResourceFiles.OtherSeriesIcon] = ["Header", "PageIcon", "OtherSeries.png"],
	};

	public static string GetResourcePath(ResourceFiles resourceFile)
		=> RESOURCE_PATH_PREFIX + string.Join('.', ResourceFileNames[resourceFile]);

	public static BitmapImage GetResourceAsBitmapImage(ResourceFiles resourceFile)
	{
		BitmapImage bitmapImage = new();
		using (var stream = CurrentAssembly.GetManifestResourceStream(GetResourcePath(resourceFile)))
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
		var image = new Image
		{
			Source = GetResourceAsBitmapImage(resourceFile),
			Stretch = Stretch.Fill,
		};
		return image;
	}
}
