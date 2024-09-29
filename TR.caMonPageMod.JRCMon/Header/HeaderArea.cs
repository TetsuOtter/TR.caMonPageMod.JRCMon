using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using TR.BIDSSMemLib;
using TR.caMonPageMod.JRCMon.PageTypes;

namespace TR.caMonPageMod.JRCMon.Header;

class HeaderArea : Grid
{
	const int PAGE_ICON_SIZE = 40;

	readonly Dictionary<ResourceManager.ResourceFiles, BitmapImage> IconImageCache = [];
	readonly Image PageIcon = new()
	{
		Width = PAGE_ICON_SIZE,
		Height = PAGE_ICON_SIZE,
		Stretch = Stretch.Fill,
		VerticalAlignment = System.Windows.VerticalAlignment.Center,
		HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
	};
	readonly Label PageName = ComponentFactory.Get1XLong2Label();
	readonly Label TimeHH = ComponentFactory.Get2XLongLabel();
	readonly Label TimeMM = ComponentFactory.Get2XLongLabel();
	public HeaderArea()
	{
		Height = Constants.HEADER_HEIGHT;
		Width = Constants.DISPLAY_WIDTH;
		Background = Brushes.Black;

		Image baseImage = ResourceManager.GetResourceAsImage(ResourceManager.ResourceFiles.HeaderBase);
		Children.Add(baseImage);

		PageIcon.Margin = new(6, 2, 0, 0);
		PageName.Margin = new(52, 0, 0, 0);
		PageName.Height = Constants.HEADER_HEIGHT;
		PageName.VerticalAlignment = System.Windows.VerticalAlignment.Center;
		PageName.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
		Children.Add(PageIcon);
		Children.Add(PageName);

		TimeHH.Margin = new(682, 0, 0, 0);
		TimeHH.Width = 56;
		TimeHH.Height = Constants.HEADER_HEIGHT;
		TimeHH.Content = "00";
		TimeHH.VerticalAlignment = System.Windows.VerticalAlignment.Center;
		TimeHH.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
		TimeHH.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
		Children.Add(TimeHH);

		TimeMM.Margin = new(738, 0, 0, 0);
		TimeMM.Width = 56;
		TimeMM.Height = Constants.HEADER_HEIGHT;
		TimeMM.Content = "00";
		TimeMM.VerticalAlignment = System.Windows.VerticalAlignment.Center;
		TimeMM.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
		TimeMM.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
		Children.Add(TimeMM);

		SMemLib.SMC_BSMDChanged += (s, e) =>
		{
			Dispatcher.Invoke(() =>
			{
				TimeHH.Content = ((e.NewValue.StateData.T / (3600 * 1000)) % 24).ToString("D2");
				TimeMM.Content = ((e.NewValue.StateData.T / (60 * 1000)) % 60).ToString("D2");
			});
		};
	}

	public void OnChangePage(NormalPageAttribute pageAttribute)
	{
		if (IconImageCache.TryGetValue(pageAttribute.IconImage, out BitmapImage? iconImage) is false)
		{
			iconImage = ResourceManager.GetResourceAsBitmapImage(pageAttribute.IconImage);
			IconImageCache[pageAttribute.IconImage] = iconImage;
		}
		PageIcon.Source = iconImage;
		PageName.Content = pageAttribute.PageName;
	}
}
