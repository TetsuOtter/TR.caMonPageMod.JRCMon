using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using TR.BIDSSMemLib;
using TR.caMonPageMod.JRCMon.PageTypes;
using TR.caMonPageMod.JRCMon.Utils;

namespace TR.caMonPageMod.JRCMon.Header;

class HeaderArea : Grid
{
	const int PAGE_ICON_SIZE = 40;
	const int TEXT_AREA_TOP = 5;
	const int TEXT_AREA_HEIGHT = 42;
	const int TRAIN_NUMBER_LR_PADDING = 8;
	const int TRAIN_INFO_TB_PADDING = 1;
	const int TRAIN_INFO_LEFT_PADDING = 16;

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
	readonly Label TrainNumber = ComponentFactory.Get1XLong2Label();
	readonly Label TrainType = ComponentFactory.Get1XLong2Label();
	readonly Label TrainDirection = ComponentFactory.Get1XLong2Label();
	readonly Label TimeHH = ComponentFactory.Get2XLongLabel();
	readonly Label TimeMM = ComponentFactory.Get2XLongLabel();
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

		PageIcon.Margin = new(6, 2, 0, 0);
		PageName.Margin = new(52, TEXT_AREA_TOP, 0, 0);
		PageName.Padding = new(0, TRAIN_INFO_TB_PADDING, 0, TRAIN_INFO_TB_PADDING);
		PageName.Height = TEXT_AREA_HEIGHT / 2;
		PageName.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
		Children.Add(PageIcon);
		Children.Add(PageName);

		TrainNumber.Margin = new(190, TEXT_AREA_TOP, 0, 0);
		TrainNumber.Padding = new(TRAIN_NUMBER_LR_PADDING, TRAIN_INFO_TB_PADDING, TRAIN_NUMBER_LR_PADDING, TRAIN_INFO_TB_PADDING);
		TrainNumber.Height = TEXT_AREA_HEIGHT / 2;
		TrainNumber.Width = 124;
		TrainNumber.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
		TrainNumber.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
		Children.Add(TrainNumber);

		TrainType.Margin = new(316, TEXT_AREA_TOP, 0, 0);
		TrainType.Padding = new(TRAIN_INFO_LEFT_PADDING, TRAIN_INFO_TB_PADDING, 0, TRAIN_INFO_TB_PADDING);
		TrainType.Height = TEXT_AREA_HEIGHT / 2;
		TrainType.Width = 165;
		TrainType.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
		TrainType.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
		Children.Add(TrainType);

		TrainDirection.Margin = new(524, TEXT_AREA_TOP, 0, 0);
		TrainDirection.Padding = new(TRAIN_INFO_LEFT_PADDING, TRAIN_INFO_TB_PADDING, 0, TRAIN_INFO_TB_PADDING);
		TrainDirection.Height = TEXT_AREA_HEIGHT / 2;
		TrainDirection.Width = 155;
		TrainDirection.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
		TrainDirection.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
		Children.Add(TrainDirection);

		TimeHH.Margin = new(682, 0.5, 0, 0);
		TimeHH.Width = 56;
		TimeHH.Height = (TEXT_AREA_HEIGHT + TEXT_AREA_TOP) / 1.5;
		TimeHH.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
		TimeHH.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
		Children.Add(TimeHH);

		TimeMM.Margin = new(738, 0.5, 0, 0);
		TimeMM.Width = 56;
		TimeMM.Height = (TEXT_AREA_HEIGHT + TEXT_AREA_TOP) / 1.5;
		TimeMM.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
		TimeMM.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
		Children.Add(TimeMM);

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
				TrainNumber.Content = State.TrainNumber.ToWide();
				TrainType.Content = State.TrainType.ToWide();
				TrainDirection.Content = State.TrainDirection;
			});
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine(ex);
		}
	}

	private void SetTimeLabel(int hh, int mm)
	{
		Dispatcher.Invoke(() =>
		{
			TimeHH.Content = hh.ToString("D2");
			TimeMM.Content = mm.ToString("D2");
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
		PageName.Content = pageAttribute.PageName;
	}
}
