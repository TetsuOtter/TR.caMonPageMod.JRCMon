using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TR.caMonPageMod.JRCMon;

static internal class ResourceManager
{
	public enum ResourceFiles
	{
		HeaderBase,
		AppInfo,
	}

	static readonly Assembly CurrentAssembly = Assembly.GetExecutingAssembly();

	const string RESOURCE_PATH_PREFIX = "TR.caMonPageMod.JRCMon.Resources.";

	static readonly IReadOnlyDictionary<ResourceFiles, string[]> ResourceFileNames = new Dictionary<ResourceFiles, string[]>
	{
		[ResourceFiles.HeaderBase] = ["Header", "Base.png"],
		[ResourceFiles.AppInfo] = ["Body", "AppInfo.png"],
	};

	public static string GetResourcePath(ResourceFiles resourceFile)
		=> RESOURCE_PATH_PREFIX + string.Join('.', ResourceFileNames[resourceFile]);

	public static Image GetResourceAsImage(ResourceFiles resourceFile)
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
		var image = new Image
		{
			Source = bitmapImage,
			Stretch = Stretch.Fill,
		};
		return image;
	}
}
