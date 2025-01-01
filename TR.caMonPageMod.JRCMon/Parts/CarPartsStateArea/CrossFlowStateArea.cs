using System.Windows.Controls;
using System.Windows.Media;

using TR.caMonPageMod.JRCMon.Parts.CarPartsState;

namespace TR.caMonPageMod.JRCMon.Parts.CarPartsStateArea;

public class CrossFlowStateArea : Canvas
{
	public CrossFlowStateArea(AppState state)
	{
		StateAreaConstants.setTop(this, 3);

		BitmapLabel toheiLabel = ComponentFactory.Get1XLongLabel();
		toheiLabel.Text = "横流ファンモード";
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
			AUTO_HIGH,
			AUTO_LOW,
			AUTO_OFF,

			MANUAL_HIGH,
			MANUAL_LOW,
			MANUAL_OFF,
		}

		private static readonly Dictionary<StateType, Brush> ForegroundColors = new()
		{
			[StateType.AUTO_HIGH] = Brushes.White,
			[StateType.AUTO_LOW] = Brushes.Black,
			[StateType.AUTO_OFF] = Brushes.White,

			[StateType.MANUAL_HIGH] = Brushes.White,
			[StateType.MANUAL_LOW] = Brushes.Black,
			[StateType.MANUAL_OFF] = Brushes.White,
		};
		static readonly Dictionary<StateType, Brush> BackgroundColors = new()
		{
			[StateType.AUTO_HIGH] = Brushes.Blue,
			[StateType.AUTO_LOW] = Brushes.Lime,
			[StateType.AUTO_OFF] = Brushes.Transparent,

			[StateType.MANUAL_HIGH] = Brushes.Blue,
			[StateType.MANUAL_LOW] = Brushes.Lime,
			[StateType.MANUAL_OFF] = Brushes.Transparent,
		};
		static readonly Dictionary<StateType, string> Labels = new()
		{
			[StateType.AUTO_HIGH] = "自強",
			[StateType.AUTO_LOW] = "自弱",
			[StateType.AUTO_OFF] = "自切",

			[StateType.MANUAL_HIGH] = "手強",
			[StateType.MANUAL_LOW] = "手弱",
			[StateType.MANUAL_OFF] = "手切",
		};

		public SteteComponent(int carIndex, int top) : base(carIndex, top)
		{
			State = StateType.AUTO_OFF;
		}

		private StateType _State = StateType.AUTO_OFF;
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
