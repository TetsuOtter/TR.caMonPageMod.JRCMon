namespace TR.caMonPageMod.JRCMon.TrainFormation;

public record CarSetInfo(
	string Category,
	string Name,
	IReadOnlyList<CarInfo> CarInfoList,
	bool Is315,
	bool IsOtherSeries
);
