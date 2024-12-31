using System.Windows.Controls;
using System.Windows.Media;

using TR.caMonPageMod.JRCMon.TrainFormation;
using TR.caMonPageMod.JRCMon.Utils;

namespace TR.caMonPageMod.JRCMon.Parts.Unit;

public class CarImage : Canvas
{
	private readonly Image image = new()
	{
		Width = CarImageGen.WIDTH,
		Height = CarImageGen.HEIGHT,
	};
	private readonly BitmapLabel TypeLabel;
	private readonly CarImageGen.CarImageInfo carImageInfo;
	public CarImage(
		CarInfo carInfo,
		bool isLeftCab,
		bool isRightCab,
		bool is315,
		bool isOtherSeries,
		int carNumber
	)
	{

		Width = CarImageGen.WIDTH;
		Height = CarImageGen.HEIGHT;

		carImageInfo = new(
			IsLeftCab: isLeftCab,
			IsRightCab: isRightCab,
			HasPantograph: !isOtherSeries && carInfo.HasPantograph,
			HasSecondPantograph: !isOtherSeries && carInfo.HasSecondPantograph,
			IsLeftBogieMotored: !isOtherSeries && carInfo.IsLeftBogieMotored,
			IsRightBogieMotored: !isOtherSeries && carInfo.IsRightBogieMotored,
			IsLeftBogieMotorWorking: false,
			IsRightBogieMotorWorking: false,
			Is315: is315,
			IsDriverCab: false
		);
		image.Source = CarImageGen.GetCarImage(carImageInfo);

		Children.Add(image);

		TypeLabel = ComponentFactory.Get1XLabel(is315 ? Brushes.Black : Brushes.White);
		SetLeft(TypeLabel, 1);
		SetTop(TypeLabel, CarImageGen.ROOF_Y + 1);
		TypeLabel.Height = CarImageGen.SEPARATOR_Y - CarImageGen.ROOF_Y - 1;
		TypeLabel.Width = CarImageGen.WIDTH - 2;
		TypeLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
		TypeLabel.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
		TypeLabel.Text = carInfo.CarType;
		Children.Add(TypeLabel);

		BitmapLabel carNumberLabel = ComponentFactory.Get1XLabel();
		carNumberLabel.Text = carNumber.ToString().ToWide();
		carNumberLabel.Width = CarImageGen.WIDTH;
		carNumberLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
		SetLeft(carNumberLabel, 0);
		SetTop(carNumberLabel, CarImageGen.HEIGHT + 2);
		Children.Add(carNumberLabel);
	}
}
