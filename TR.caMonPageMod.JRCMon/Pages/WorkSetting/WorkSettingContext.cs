namespace TR.caMonPageMod.JRCMon.Pages.WorkSetting;

public record WorkSettingContext(
	PageSource Source,
	string TrainNumber,
	string TrainType,
	string TrainDestination_All,
	string[] TrainDestination,
	int Direction_EditingTarget
)
{
	public const int TRAIN_DESTINATION_COUNT = 6;

	public WorkSettingContext(PageSource Source) : this(
		Source: Source,
		TrainNumber: string.Empty,
		TrainType: string.Empty,
		TrainDestination_All: string.Empty,
		TrainDestination: new string[TRAIN_DESTINATION_COUNT],
		Direction_EditingTarget: 0
	)
	{ }

	public string HeaderTitle => Source switch
	{
		PageSource.Menu => "運行設定",
		PageSource.Driver => "運転士運行設定",
		PageSource.Conductor => "車掌運行設定",
		_ => throw new NotImplementedException(),
	};
}
