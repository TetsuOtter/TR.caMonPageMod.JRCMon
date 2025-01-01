using System.Windows.Media;

using TR.BIDSSMemLib;

namespace TR.caMonPageMod.JRCMon.Parts.CarPartsState;

public class DoorState : CarPartsStateBase
{
	bool isEnabled = true;
	bool isDoorClosed = true;
	public DoorState(int carIndex, int top) : base(carIndex, top)
	{
		OnChangeDoorState(true, true);

		SMemLib.SMC_BSMDChanged += (s, e) =>
		{
			if (e.NewValue.IsDoorClosed == isDoorClosed && isEnabled == e.NewValue.IsEnabled)
				return;
			try
			{
				Dispatcher.Invoke(() => OnChangeDoorState(e.NewValue.IsDoorClosed, e.NewValue.IsEnabled));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
			}
		};
	}

	void OnChangeDoorState(bool isDoorClosed, bool IsEnabled)
	{
		this.isDoorClosed = isDoorClosed;
		this.isEnabled = IsEnabled;
		Foreground = Brushes.White;

		if (IsEnabled)
		{
			Background = isDoorClosed ? Brushes.Transparent : Brushes.Red;
			Text = isDoorClosed ? "閉" : "開";
		}
		else
		{
			Background = Brushes.Transparent;
			Text = "-";
		}
	}
}
