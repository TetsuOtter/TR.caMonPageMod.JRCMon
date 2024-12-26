using TR.caMonPageMod.JRCMon.TrainFormation;

namespace TR.caMonPageMod.JRCMon;

public class AppState
{
	public string TrainNumber { get; private set; } = "列番123F";
	public string TrainType { get; private set; } = "普通(各停)";
	public string TrainDirection { get; private set; } = "国府津";
	public event EventHandler? TrainInfoChanged;
	public void SetTrainInfo(string trainNumber, string trainType, string trainDirection)
	{
		TrainNumber = trainNumber;
		TrainType = trainType;
		TrainDirection = trainDirection;
		TrainInfoChanged?.Invoke(this, EventArgs.Empty);
	}

	/// <summary>
	/// 車両編成情報 ([0]が先頭編成)
	/// </summary>
	public IReadOnlyList<CarSetInfo>? TrainFormation { get; private set; } = [
		new CarSetInfo(
			"Y123",
			"テスト用",
			[
				new(
					CarType: "Mc",
					HasPantograph: true,
					HasSecondPantograph: true,
					IsLeftBogieMotored: true,
					IsRightBogieMotored: true,
					MaxPassenger: 100,
					HasSIV: true,
					HasCP: true
				),
				new(
					CarType: "T",
					HasPantograph: true,
					HasSecondPantograph: false,
					IsLeftBogieMotored: false,
					IsRightBogieMotored: true,
					MaxPassenger: 100,
					HasSIV: false,
					HasCP: false
				),
				new(
					CarType: "Tc",
					HasPantograph: false,
					HasSecondPantograph: false,
					IsLeftBogieMotored: false,
					IsRightBogieMotored: true,
					MaxPassenger: 100,
					HasSIV: false,
					HasCP: false
				),
			],
			Is315: false,
			IsOtherSeries: false
		),
		new CarSetInfo(
			"Y123",
			"テスト用",
			[
				new(
					CarType: "Mc",
					HasPantograph: true,
					HasSecondPantograph: true,
					IsLeftBogieMotored: true,
					IsRightBogieMotored: true,
					MaxPassenger: 100,
					HasSIV: true,
					HasCP: true
				),
				new(
					CarType: "T",
					HasPantograph: true,
					HasSecondPantograph: false,
					IsLeftBogieMotored: false,
					IsRightBogieMotored: true,
					MaxPassenger: 100,
					HasSIV: false,
					HasCP: false
				),
				new(
					CarType: "Tc",
					HasPantograph: false,
					HasSecondPantograph: false,
					IsLeftBogieMotored: false,
					IsRightBogieMotored: true,
					MaxPassenger: 100,
					HasSIV: false,
					HasCP: false
				),
			],
			Is315: true,
			IsOtherSeries: false
		)
	];
	/// <summary>
	/// それぞれの編成が逆向きかどうか
	/// </summary>
	public bool IsCarSetReversed { get; private set; }
	public bool IsOtherSeriesConnected { get; private set; }
	public bool Is315Connected { get; private set; }
	public event EventHandler? TrainFormationChanged;
	public void SetTrainFormation(IReadOnlyList<CarSetInfo> trainFormation, bool isCarSetReversed)
	{
		if (trainFormation.Count == 0)
			throw new ArgumentException("TrainFormation must have at least one element.");
		TrainFormation = trainFormation;
		IsCarSetReversed = isCarSetReversed;
		IsOtherSeriesConnected = trainFormation.Any(v => v.IsOtherSeries);
		Is315Connected = trainFormation.Any(v => v.Is315);
		TrainFormationChanged?.Invoke(this, EventArgs.Empty);
	}

	public double LocationCorrection { get; set; } = 0;

	public TimeSpan TimeCorrection { get; set; } = TimeSpan.Zero;

	public IReadonlyAppDisplaySetting DisplaySetting { get; set; } = new AppDisplaySetting();
}
