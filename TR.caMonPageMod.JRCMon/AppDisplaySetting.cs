namespace TR.caMonPageMod.JRCMon;

	public interface IReadonlyAppDisplaySetting
	{
		bool IsDoorSemiSelfMode { get; }
		bool IsFirstRevisionMode { get; }
		bool IsCarNumberReversed { get; }
		bool ShowDetailedInfoOnDetectionPage { get; }
		bool ShowWaitingPageOnPageChage { get; }
		bool PlayAntiPassingSound { get; }
		bool ShowError { get; }
		bool ShowLowBatteryWarning { get; }
		bool IsFullScreen { get; }
	}
	public class AppDisplaySetting : IReadonlyAppDisplaySetting
	{
		public bool IsDoorSemiSelfMode { get; set; }
		public bool IsFirstRevisionMode { get; set; }
		public bool IsCarNumberReversed { get; set; }
		public bool ShowDetailedInfoOnDetectionPage { get; set; } = true;
		public bool ShowWaitingPageOnPageChage { get; set; }
		public bool PlayAntiPassingSound { get; set; } = true;
		public bool ShowError { get; set; } = false;
		public bool ShowLowBatteryWarning { get; set; } = false;
		public bool IsFullScreen { get; set; } = true;

		public AppDisplaySetting() { }
		public AppDisplaySetting(IReadonlyAppDisplaySetting src)
		{
			IsDoorSemiSelfMode = src.IsDoorSemiSelfMode;
			IsFirstRevisionMode = src.IsFirstRevisionMode;
			IsCarNumberReversed = src.IsCarNumberReversed;
			ShowDetailedInfoOnDetectionPage = src.ShowDetailedInfoOnDetectionPage;
			ShowWaitingPageOnPageChage = src.ShowWaitingPageOnPageChage;
			PlayAntiPassingSound = src.PlayAntiPassingSound;
			ShowError = src.ShowError;
			ShowLowBatteryWarning = src.ShowLowBatteryWarning;
			IsFullScreen = src.IsFullScreen;
		}
	}
