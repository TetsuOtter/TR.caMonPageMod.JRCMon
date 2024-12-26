namespace TR.caMonPageMod.JRCMon.TrainFormation;

public record CarInfo(
	string CarType,
	bool HasPantograph,
	bool HasSecondPantograph,
	bool IsLeftBogieMotored,
	bool IsRightBogieMotored,
	int MaxPassenger,

	bool HasSIV,
	bool HasCP
);
