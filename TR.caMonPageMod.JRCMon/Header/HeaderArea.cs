using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using TR.BIDSSMemLib;
using TR.caMonPageMod.JRCMon.PageTypes;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Utils;

namespace TR.caMonPageMod.JRCMon.Header;

class HeaderArea : Canvas
{
	const int PAGE_ICON_SIZE = 40;
	const double TEXT_AREA_BOTTOM = 3.75;
	const int TRAIN_NUMBER_LR_PADDING = 8;
	const int TRAIN_TYPE_LEFT_PADDING = Constants.FONT_SIZE_1X;
	const int TRAIN_DEST_LEFT_PADDING = Constants.FONT_SIZE_1X * 2;

	readonly Dictionary<ResourceManager.ResourceFiles, BitmapImage> IconImageCache = [];
	readonly Image PageIcon = new()
	{
		Width = PAGE_ICON_SIZE,
		Height = PAGE_ICON_SIZE,
		Stretch = Stretch.Fill,
		VerticalAlignment = System.Windows.VerticalAlignment.Center,
		HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
	};
	readonly BitmapLabel PageName = ComponentFactory.Get1XLongLabel();
	readonly BitmapLabel TrainNumber = ComponentFactory.Get1XLongLabel();
	readonly BitmapLabel TrainType = ComponentFactory.Get1XLongLabel();
	readonly BitmapLabel TrainDirection = ComponentFactory.Get1XLongLabel();
	readonly BitmapLabel TimeLabel = ComponentFactory.Get2XLabel();
	readonly AppState State;
	public HeaderArea(AppState state)
	{
		State = state;
		State.TrainInfoChanged += (_, _) => OnTrainInfoChanged();

		Height = Constants.HEADER_HEIGHT;
		Width = Constants.DISPLAY_WIDTH;
		Background = Brushes.Black;

		Image baseImage = ResourceManager.GetResourceAsImage(ResourceManager.ResourceFiles.HeaderBase);
		Children.Add(baseImage);

		SetLeft(PageIcon, 6);

		SetLeft(PageName, 52);
		SetBottom(PageName, TEXT_AREA_BOTTOM);
		Children.Add(PageIcon);
		Children.Add(PageName);

		SetLeft(TrainNumber, 200 + TRAIN_NUMBER_LR_PADDING);
		SetBottom(TrainNumber, TEXT_AREA_BOTTOM);
		TrainNumber.Width = 120 - TRAIN_NUMBER_LR_PADDING * 2;
		TrainNumber.Height = Constants.FONT_SIZE_2X;
		TrainNumber.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
		Children.Add(TrainNumber);

		SetLeft(TrainType, 320 + TRAIN_TYPE_LEFT_PADDING);
		SetBottom(TrainType, TEXT_AREA_BOTTOM);
		TrainType.Width = 162 - TRAIN_TYPE_LEFT_PADDING;
		TrainType.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
		Children.Add(TrainType);

		SetLeft(TrainDirection, 520 + TRAIN_DEST_LEFT_PADDING);
		SetBottom(TrainDirection, TEXT_AREA_BOTTOM);
		TrainDirection.Width = 160 - TRAIN_DEST_LEFT_PADDING;
		TrainDirection.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
		Children.Add(TrainDirection);

		SetLeft(TimeLabel, 680);
		SetBottom(TimeLabel, TEXT_AREA_BOTTOM);
		TimeLabel.Width = 120;
		TimeLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
		Children.Add(TimeLabel);

		OnTrainInfoChanged();
		SetTimeLabel(12, 34);

		SMemLib.SMC_BSMDChanged += (s, e) =>
		{
			try
			{
				Dispatcher.Invoke(() =>
				{
					SetTimeLabel(
						(e.NewValue.StateData.T / (3600 * 1000)) % 24,
						(e.NewValue.StateData.T / (60 * 1000)) % 60
					);
				});
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
			}
		};
	}

	private void OnTrainInfoChanged()
	{
		try
		{
			Dispatcher.Invoke(() =>
			{
				TrainNumber.Text = State.TrainNumber.ToWide();
				TrainType.Text = State.TrainType.ToWide();
				TrainDirection.Text = State.TrainDirection;
			});
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine(ex);
		}
	}

	private void SetTimeLabel(int hh, int mm)
	{
		string hhStr = hh.ToString("D2");
		string mmStr = mm.ToString("D2").PadLeft(2, '0');
		Dispatcher.Invoke(() =>
		{
			TimeLabel.Text = $"{hhStr}:{mmStr}";
		});
	}

	public void OnChangePage(NormalPageAttribute pageAttribute)
	{
		if (IconImageCache.TryGetValue(pageAttribute.IconImage, out BitmapImage? iconImage) is false)
		{
			iconImage = ResourceManager.GetResourceAsBitmapImage(pageAttribute.IconImage);
			IconImageCache[pageAttribute.IconImage] = iconImage;
		}
		PageIcon.Source = iconImage;
		PageName.Text = pageAttribute.PageName;
	}
}
