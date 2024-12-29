using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Parts.Unit;

public class TrainFormationImage : Canvas
{
	public const int TOP = 60;
	public const int LEFT = 191;

	private readonly AppState state;
	public TrainFormationImage(AppState state)
	{
		SetLeft(this, LEFT);
		SetTop(this, TOP);
		Height = CarImageGen.HEIGHT;
		this.state = state;
		state.TrainFormationChanged += (_, _) => OnTrainFormationChanged();
		OnTrainFormationChanged();
	}

	private void OnTrainFormationChanged()
	{
		Children.Clear();
		var trainFormation = state.TrainFormation;
		if (trainFormation is null)
			return;

		int carCount = 0;
		for (int iCarSet = 0; iCarSet < trainFormation.Count; ++iCarSet)
		{
			var carSet = trainFormation[iCarSet];
			for (int iCar = 0; iCar < carSet.CarInfoList.Count; ++iCar)
			{
				var carInfo = carSet.CarInfoList[iCar];
				CarImage carImage = new(
					carInfo,
					iCar == 0,
					iCar == carSet.CarInfoList.Count - 1,
					carSet.Is315,
					carSet.IsOtherSeries
				);
				SetLeft(carImage, carCount++ * CarImageGen.WIDTH);
				Children.Add(carImage);
			}
		}
		Width = carCount * CarImageGen.WIDTH;
	}
}
