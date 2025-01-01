using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.Unit;
using TR.caMonPageMod.JRCMon.TrainFormation;
using TR.caMonPageMod.JRCMon.Utils;

namespace TR.caMonPageMod.JRCMon.Pages.CarState;

[PageTypes.NormalPage("車両状態", ResourceManager.ResourceFiles.CarInfoIcon, "ｽｲｯﾁ状態")]
public abstract class CarStateSW : Canvas, IFooterInfo
{
	public abstract IReadOnlyList<FooterInfo> FooterInfoList { get; }

	const int TABLE_ROW_COUNT = 18;
	const int TABLE_LEFT = 36;
	const int TABLE_BORDER_THICKNESS = 1;
	const int HEAD_COL_INNER_WIDTH = TrainFormationImage.LEFT - TABLE_LEFT - TABLE_BORDER_THICKNESS;
	const int HEAD_COL_LABEL_LEFT = TABLE_LEFT + Constants.FONT_SIZE_1X / 2;
	const int ROW_INNER_HEIGHT = Constants.FONT_SIZE_1X + 1;
	const int TABLE_BOTTOM = ROW_INNER_HEIGHT;
	const int TABLE_OUTER_HEIGHT = (ROW_INNER_HEIGHT + TABLE_BORDER_THICKNESS) * TABLE_ROW_COUNT + TABLE_BORDER_THICKNESS;
	const int TABLE_OUTER_TOP = Constants.BODY_HEIGHT - TABLE_OUTER_HEIGHT - TABLE_BOTTOM;


	static readonly string[] HEAD_LABELS_1 = [
		"SIV".ToWide(),
			"CP".ToWide(),
			"元溜圧力",
			"CabSeS".ToWide(),
			"VVVF2".ToWide(),
			"CgK".ToWide() + " (SIV)",
			"CgK".ToWide() + " (VVVF2)",
			"車上試験SW".ToWide(),
			"BH非常".ToWide(),
			"車掌非常",
			"耐雪B".ToWide(),
			"直予備B".ToWide(),
		];
	static readonly string[] HEAD_LABELS_2 = [
		"MS".ToWide(),
			"HB".ToWide(),
			"LB1".ToWide(),
			"LB2".ToWide(),
			"LB3".ToWide(),
			"MCOS1".ToWide(),
			"MCOS2".ToWide(),
			"MCOS3".ToWide(),
			"MCOS4".ToWide(),
			"CCOS".ToWide(),
		];

	readonly StateLabel?[][] StateLabels;
	protected readonly AppState State;
	public CarStateSW(AppState state, string[] labels)
	{
		State = state;
		Children.Add(new LocationLabel());
		Children.Add(new TrainFormationImage(state));

		int tableOuterWidth = TABLE_BORDER_THICKNESS + HEAD_COL_INNER_WIDTH + (CarImageGen.WIDTH * state.CarCount);
		Rectangle tableOuter = new()
		{
			Width = tableOuterWidth,
			Height = TABLE_OUTER_HEIGHT,
			Stroke = Brushes.Lime,
			StrokeThickness = TABLE_BORDER_THICKNESS,
		};
		SetLeft(tableOuter, TABLE_LEFT);
		SetBottom(tableOuter, TABLE_BOTTOM);
		Children.Add(tableOuter);
		for (int i = 1; i < TABLE_ROW_COUNT; ++i)
		{
			Line line = new()
			{
				X1 = 0,
				Y1 = TABLE_BORDER_THICKNESS * 0.5,
				X2 = tableOuterWidth,
				Y2 = TABLE_BORDER_THICKNESS * 0.5,
				Stroke = Brushes.Lime,
				StrokeThickness = TABLE_BORDER_THICKNESS,
			};
			SetLeft(line, TABLE_LEFT);
			SetBottom(line, TABLE_BOTTOM + (ROW_INNER_HEIGHT + TABLE_BORDER_THICKNESS) * i);
			Children.Add(line);
		}

		StateLabels = new StateLabel[labels.Length][];
		for (int i = 0; i < labels.Length; i++)
		{
			BitmapLabel label = ComponentFactory.Get1XLabel();
			label.Text = labels[i];
			SetTop(label, TABLE_OUTER_TOP + (ROW_INNER_HEIGHT + TABLE_BORDER_THICKNESS) * i + TABLE_BORDER_THICKNESS);
			SetLeft(label, HEAD_COL_LABEL_LEFT);
			Children.Add(label);

			StateLabels[i] = new StateLabel[state.CarCount];
		}

		// 縦罫線を引く
		for (int i = 0; i < state.CarCount; i++)
		{
			Line line = new()
			{
				X1 = TABLE_BORDER_THICKNESS * 0.5,
				Y1 = 0,
				X2 = TABLE_BORDER_THICKNESS * 0.5,
				Y2 = TABLE_OUTER_HEIGHT,
				Stroke = Brushes.Lime,
				StrokeThickness = TABLE_BORDER_THICKNESS,
			};
			SetLeft(line, TABLE_LEFT + HEAD_COL_INNER_WIDTH + (CarImageGen.WIDTH * i));
			SetBottom(line, TABLE_BOTTOM);
			Children.Add(line);
		}

		SetPageStateDummyLabels();
	}

	protected abstract void SetPageStateDummyLabels();

	public class Page1(AppState state) : CarStateSW(state, HEAD_LABELS_1)
	{
		public override IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CAR_STATE_SW1;

		protected override void SetPageStateDummyLabels()
		{
			if (State.TrainFormation is null)
				return;

			int carIndex = 0;
			foreach (var trainFormation in State.TrainFormation)
			{
				for (int i = 0; i < trainFormation.CarInfoList.Count; i++)
				{
					CarInfo carInfo = trainFormation.CarInfoList[i];

					bool isEven = carIndex % 2 == 0;
					if (carInfo.HasSIV)
					{
						StateLabels[0][carIndex] = new(carIndex, 0, isEven)
						{
							Text = isEven ? "動作" : "停止",
						};
					}
					if (carInfo.HasCP)
					{
						StateLabels[1][carIndex] = new(carIndex, 1, isEven)
						{
							Text = isEven ? "動作" : "停止",
						};
					}

					StateLabels[2][carIndex] = new(carIndex, 2, isEven, !isEven)
					{
						Text = isEven ? "正常" : "異常",
					};

					if (i == 0 || i == trainFormation.CarInfoList.Count - 1)
					{
						bool isFront = carIndex == 0;
						bool isRear = carIndex == State.CarCount - 1;
						StateLabels[3][carIndex] = new(carIndex, 3, false)
						{
							Text = isFront ? "前" : isRear ? "後" : "中",
						};
					}

					if (carInfo.IsLeftBogieMotored || carInfo.IsRightBogieMotored)
					{
						StateLabels[4][carIndex] = new(carIndex, 4, true)
						{
							Text = "VVVF",
						};

						StateLabels[5][carIndex] = new(carIndex, 5, isEven)
						{
							Text = isEven ? "入" : "切",
						};
						StateLabels[6][carIndex] = new(carIndex, 6, isEven)
						{
							Text = isEven ? "入" : "切",
						};
					}

					StateLabels[8][carIndex] = new(carIndex, 8, isEven)
					{
						Text = isEven ? "入" : "切",
					};

					if (i == 0 || i == trainFormation.CarInfoList.Count - 1)
					{
						StateLabels[9][carIndex] = new(carIndex, 9, isEven)
						{
							Text = isEven ? "入" : "切",
						};
						StateLabels[10][carIndex] = new(carIndex, 10, isEven)
						{
							Text = isEven ? "入" : "切",
						};
						StateLabels[11][carIndex] = new(carIndex, 11, isEven)
						{
							Text = isEven ? "入" : "切",
						};
					}

					carIndex++;
				}
			}

			foreach (var labels in StateLabels)
			{
				foreach (var label in labels)
				{
					if (label is not null)
						Children.Add(label);
				}
			}
		}
	}

	public class Page2(AppState state) : CarStateSW(state, HEAD_LABELS_2)
	{
		public override IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CAR_STATE_SW2;

		protected override void SetPageStateDummyLabels()
		{
			if (State.TrainFormation is null)
				return;

			int carIndex = 0;
			foreach (var trainFormation in State.TrainFormation)
			{
				for (int i = 0; i < trainFormation.CarInfoList.Count; i++)
				{
					CarInfo carInfo = trainFormation.CarInfoList[i];
					bool isMotoredCar = carInfo.IsLeftBogieMotored || carInfo.IsRightBogieMotored;
					if (!isMotoredCar)
					{
						++carIndex;
						continue;
					}

					bool isEven = carIndex % 2 == 0;
					StateLabels[0][carIndex] = new(carIndex, 0, isEven)
					{
						Text = isEven ? "入" : "切",
					};
					StateLabels[1][carIndex] = new(carIndex, 1, isEven)
					{
						Text = isEven ? "入" : "切",
					};

					StateLabels[2][carIndex] = new(carIndex, 2, isEven)
					{
						Text = isEven ? "入" : "切",
					};
					StateLabels[3][carIndex] = new(carIndex, 3, isEven)
					{
						Text = isEven ? "入" : "切",
					};
					StateLabels[4][carIndex] = new(carIndex, 4, isEven)
					{
						Text = isEven ? "入" : "切",
					};

					StateLabels[5][carIndex] = new(carIndex, 5, isEven)
					{
						Text = isEven ? "入" : "切",
					};
					StateLabels[6][carIndex] = new(carIndex, 6, isEven)
					{
						Text = isEven ? "入" : "切",
					};
					StateLabels[7][carIndex] = new(carIndex, 7, isEven)
					{
						Text = isEven ? "入" : "切",
					};
					StateLabels[8][carIndex] = new(carIndex, 8, isEven)
					{
						Text = isEven ? "入" : "切",
					};

					StateLabels[9][carIndex] = new(carIndex, 9, isEven, !isEven)
					{
						Text = isEven ? "正常" : "異常",
					};

					++carIndex;
				}
			}

			foreach (var labels in StateLabels)
			{
				foreach (var label in labels)
				{
					if (label is not null)
						Children.Add(label);
				}
			}
		}
	}

	class StateLabel : BitmapLabel
	{
		public StateLabel(int carIndex, int rowIndex, bool isYellow, bool isError = false)
		{
			SetTop(this, TABLE_OUTER_TOP + TABLE_BORDER_THICKNESS + (ROW_INNER_HEIGHT + TABLE_BORDER_THICKNESS) * rowIndex);
			SetLeft(this, TABLE_LEFT + HEAD_COL_INNER_WIDTH + TABLE_BORDER_THICKNESS + (CarImageGen.WIDTH * carIndex));
			HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
			Height = ROW_INNER_HEIGHT;
			Width = CarImageGen.WIDTH - TABLE_BORDER_THICKNESS;
			Background = isError ? Brushes.Red : isYellow ? Brushes.Yellow : Brushes.White;
			Foreground = isError ? Brushes.White : Brushes.Black;
		}
	}
}
