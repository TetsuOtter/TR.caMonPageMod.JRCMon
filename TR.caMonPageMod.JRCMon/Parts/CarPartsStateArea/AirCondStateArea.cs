using System.Windows.Controls;
using System.Windows.Media;

using TR.caMonPageMod.JRCMon.Parts.CarPartsState;

namespace TR.caMonPageMod.JRCMon.Parts.CarPartsStateArea;

public class AirCondStateArea : Canvas
{
	public AirCondStateArea(AppState state)
	{
		StateAreaConstants.setTop(this, 2);

		BitmapLabel toheiLabel = ComponentFactory.Get1XLongLabel();
		toheiLabel.Text = "空調運転モード";
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
		public enum StateType
		{
			AUTO_HEATING,
			AUTO_COOLING,
			OFF,
		}

		private static readonly Dictionary<StateType, Brush> ForegroundColors = new()
		{
			[StateType.AUTO_HEATING] = Brushes.White,
			[StateType.AUTO_COOLING] = Brushes.Black,
			[StateType.OFF] = Brushes.White,
		};
		static readonly Dictionary<StateType, Brush> BackgroundColors = new()
		{
			[StateType.AUTO_HEATING] = Brushes.Magenta,
			[StateType.AUTO_COOLING] = Brushes.Aqua,
			[StateType.OFF] = Brushes.Transparent,
		};
		static readonly Dictionary<StateType, string> Labels = new()
		{
			[StateType.AUTO_HEATING] = "自暖",
			[StateType.AUTO_COOLING] = "自冷",
			[StateType.OFF] = "切",
		};

		public SteteComponent(int carIndex, int top) : base(carIndex, top)
		{
			State = StateType.AUTO_COOLING;
		}

		private StateType _State = StateType.OFF;
		public StateType State
		{
			get => _State;
			set
			{
				_State = value;
				OnChange(value, IsEnabled);
			}
		}

		void OnChange(StateType state, bool isEnabled)
		{
			if (isEnabled)
			{
				Background = BackgroundColors[state];
				Foreground = ForegroundColors[state];
				Text = Labels[state];
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
