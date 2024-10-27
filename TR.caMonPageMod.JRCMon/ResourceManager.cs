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
		EmbeddedManual,
		MenuPage,

		MenuIcon,
	}

	public static readonly Assembly CurrentAssembly = Assembly.GetExecutingAssembly();

	const string RESOURCE_PATH_PREFIX = "TR.caMonPageMod.JRCMon.Resources.";

	static readonly IReadOnlyDictionary<ResourceFiles, string[]> ResourceFileNames = new Dictionary<ResourceFiles, string[]>
	{
		[ResourceFiles.HeaderBase] = ["Header", "Base.png"],

		[ResourceFiles.AppInfo] = ["Body", "AppInfo.png"],
		[ResourceFiles.EmbeddedManual] = ["Body", "EmbeddedManual.png"],
		[ResourceFiles.MenuPage] = ["Body", "MenuPage.png"],

		[ResourceFiles.MenuIcon] = ["Header", "PageIcon", "Menu.png"],
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
