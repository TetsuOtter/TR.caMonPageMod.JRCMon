using System.Windows.Controls;
using System.Windows.Media;

using TR.caMonPageMod.JRCMon.Parts.CarPartsState;

namespace TR.caMonPageMod.JRCMon.Parts.CarPartsStateArea;

public class AnnounceStateArea : Canvas
{
	public AnnounceStateArea(AppState state)
	{
		StateAreaConstants.setTop(this, 1);

		BitmapLabel toheiLabel = ComponentFactory.Get2XLabel();
		toheiLabel.Text = "放　送";
		SetLeft(toheiLabel, StateAreaConstants.LEFT);
		Children.Add(toheiLabel);

		int carIndex = 0;
		foreach (var trainFormation in state.TrainFormation ?? [])
		{
			foreach (var carInfo in trainFormation.CarInfoList)
			{
				SteteComponent stateLabel = new(carIndex++, StateAreaConstants.STATE_TOP);
				Children.Add(stateLabel);
			}
		}
	}

	class SteteComponent : CarPartsStateBase
	{
		public SteteComponent(int carIndex, int top) : base(carIndex, top)
		{
			IsOn = true;
		}

		private bool _IsOn = false;
		public bool IsOn
		{
			get => _IsOn;
			set
			{
				_IsOn = value;
				OnChange(value, IsEnabled);
			}
		}

		void OnChange(bool isOn, bool isEnabled)
		{
			if (isEnabled)
			{
				Background = isOn ? Brushes.White : Brushes.Transparent;
				Foreground = isOn ? Brushes.Black : Brushes.White;
				Text = isOn ? "入" : "切";
			}
			else
			{
				Background = Brushes.Transparent;
				Foreground = Brushes.White;
				Text = "-";
			}
		}
	}
}
