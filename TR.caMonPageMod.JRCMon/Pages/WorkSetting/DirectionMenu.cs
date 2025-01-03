using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Header;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Utils;

namespace TR.caMonPageMod.JRCMon.Pages.WorkSetting;

[PageTypes.NormalPage("運行設定", ResourceManager.ResourceFiles.WorkSettingIcon, "行先設定")]
public partial class DirectionMenu : NormalPageBase, IHeaderOverride, IFooterInfo, IHoldRootGridInstance
{
	public string HeaderTitle => Context.HeaderTitle;
	public ResourceManager.ResourceFiles HeaderIcon { get; } = ResourceManager.ResourceFiles.WorkSettingIcon;
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_MENU;

	public RootGrid? RootGrid { get; set; }

	const int LABEL_LEFT = 16;
	const int LABEL_BOTTOM = 14;

	const int BUTTON_WIDTH = 100;
	const int BUTTON_HEIGHT = TITLE_HEIGHT + 10;

	const int TITLE_HEIGHT = 42;
	const int TITLE_WIDTH = Constants.FONT_SIZE_1X * 9;
	static readonly Thickness TITLE_PADDING = new(0, 4, 0, 0);

	const int TYPE_DIRECTION_DISPLAY_WIDTH = Constants.FONT_SIZE_1X * 15;

	const int BUTTON_DISPLAY_PADDING = 8;

	const int SUBMIT_BUTTON_LEFT = TRAIN_TYPE_DISPLAY_LEFT + TYPE_DIRECTION_DISPLAY_WIDTH - SUBMIT_BUTTON_WIDTH;
	const int SUBMIT_BUTTON_BOTTOM = LABEL_BOTTOM + Constants.FONT_SIZE_1X * 5 + 10;
	const int SUBMIT_BUTTON_HEIGHT = 30;
	const int SUBMIT_BUTTON_WIDTH = 90;

	#region Train Number
	const int TRAIN_NUMBER_AREA_TOP = 82;
	const int TRAIN_NUMBER_AREA_LEFT = 12;
	const int TRAIN_NUMBER_AREA_HEIGHT = 122;

	const int TRAIN_NUMBER_BUTTON_LEFT = 56;
	const int TRAIN_NUMBER_BUTTON_TOP = TRAIN_NUMBER_AREA_TOP + (TRAIN_NUMBER_AREA_HEIGHT - BUTTON_HEIGHT) / 2;
	const int TRAIN_NUMBER_DISPLAY_SPACING = 24;
	const int TRAIN_NUMBER_DISPLAY_LEFT = TRAIN_NUMBER_BUTTON_LEFT + BUTTON_WIDTH + TRAIN_NUMBER_DISPLAY_SPACING;
	const int TRAIN_NUMBER_DISPLAY_WIDTH = 140;
	#endregion

	#region TrainType
	const int TRAIN_TYPE_AREA_TOP = 234;
	const int TRAIN_TYPE_AREA_LEFT = TRAIN_NUMBER_AREA_LEFT;

	const int TRAIN_TYPE_TITLE_TOP = TRAIN_TYPE_AREA_TOP + 16;
	const int TRAIN_TYPE_TITLE_LEFT = TRAIN_TYPE_BUTTON_LEFT + BUTTON_WIDTH;

	const int TRAIN_TYPE_TITLE_SPACING = 16;

	const int TRAIN_TYPE_BUTTON_LEFT = TRAIN_TYPE_AREA_LEFT + Constants.FONT_SIZE_1X;
	const int TRAIN_TYPE_BUTTON_TOP = TRAIN_TYPE_TITLE_TOP + TITLE_HEIGHT + TRAIN_TYPE_TITLE_SPACING;

	const int TRAIN_TYPE_DISPLAY_LEFT = TRAIN_TYPE_BUTTON_LEFT + BUTTON_WIDTH + BUTTON_DISPLAY_PADDING;
	#endregion

	#region Direction
	const int DIRECTION_AREA_TOP = 28;
	const int DIRECTION_AREA_LEFT = 408;

	const int DIRECTION_BUTTON_LEFT = DIRECTION_AREA_LEFT + 16;
	const int DIRECTION_BUTTON_TOP = DIRECTION_TITLE_TOP + TITLE_HEIGHT + DIRECTION_DISPLAY_DISPLAY_SPACING;

	const int DIRECTION_TITLE_LEFT = DIRECTION_BUTTON_LEFT + BUTTON_WIDTH + BUTTON_DISPLAY_PADDING;
	const int DIRECTION_TITLE_TOP = DIRECTION_AREA_TOP + 12;

	const int DIRECTION_DISPLAY_DISPLAY_SPACING = 5;

	const int DIRECTION_DISPLAY_LEFT = DIRECTION_TITLE_LEFT;
	#endregion

	private WorkSettingContext Context;

	public DirectionMenu(WorkSettingContext context) : base(ResourceManager.ResourceFiles.DirectionMenu)
	{
		Context = context;

		Children.Add(new LocationLabel());

		BitmapLabel label1 = ComponentFactory.Get1XLabel();
		label1.Text = "車内案内表示器は、作動しません。";
		SetLeft(label1, LABEL_LEFT);
		SetBottom(label1, LABEL_BOTTOM + Constants.FONT_SIZE_1X * 4);
		Children.Add(label1);

		BitmapLabel label2 = ComponentFactory.Get1XLabel();
		label2.Text = "種別、行先を設定してください。";
		SetLeft(label2, LABEL_LEFT);
		SetBottom(label2, LABEL_BOTTOM + Constants.FONT_SIZE_1X * 1);
		Children.Add(label2);
		BitmapLabel label3 = ComponentFactory.Get1XLabel();
		label3.Text = "設定内容を確認して、「起動」キーを押すと、行先表示器に表示されます。";
		SetLeft(label3, LABEL_LEFT);
		SetBottom(label3, LABEL_BOTTOM + Constants.FONT_SIZE_1X * 0);
		Children.Add(label3);

		AddSubmitButton();
		AddTrainNumberArea();
		AddTrainTypeArea();
		AddDirectionArea();
	}

	void AddSubmitButton()
	{
		Button btn = ComponentFactory.GetBasicButton(
			new(),
			SUBMIT_BUTTON_WIDTH,
			SUBMIT_BUTTON_HEIGHT,
			ButtonBaseImage.SHADOW_WIDTH_EXTRA_SMALL
		);
		SetLeft(btn, SUBMIT_BUTTON_LEFT);
		SetBottom(btn, SUBMIT_BUTTON_BOTTOM);
		btn.Click += (s, e) => RootGrid?.SetPageType<DirectionSetting>(Context);
		Children.Add(btn);

		BitmapLabel label = ComponentFactory.Get1XLabel();
		label.Text = "起　動";
		btn.Content = label;
	}

	void AddTrainNumberArea()
	{
		Button btn = ComponentFactory.GetBasicButton(
			new(),
			BUTTON_WIDTH,
			BUTTON_HEIGHT,
			ButtonBaseImage.SHADOW_WIDTH_SMALL
		);
		SetLeft(btn, TRAIN_NUMBER_BUTTON_LEFT);
		SetTop(btn, TRAIN_NUMBER_BUTTON_TOP);
		btn.Click += (s, e) => RootGrid?.SetPageType<DirectionSettingNumber>(Context);
		Children.Add(btn);

		BitmapLabel label = ComponentFactory.Get1XLongLabel();
		label.Text = "列車番号";
		btn.Content = label;

		Image displayArea = new()
		{
			Source = ButtonBaseImage.GetButtonImage(
				TRAIN_NUMBER_DISPLAY_WIDTH,
				BUTTON_HEIGHT,
				ButtonBaseImage.SHADOW_WIDTH_DEFAULT,
				System.Drawing.Color.Black
			),
			Width = TRAIN_NUMBER_DISPLAY_WIDTH,
			Height = BUTTON_HEIGHT,
		};
		SetLeft(displayArea, TRAIN_NUMBER_DISPLAY_LEFT);
		SetTop(displayArea, TRAIN_NUMBER_BUTTON_TOP);
		Children.Add(displayArea);

		BitmapLabel label2 = ComponentFactory.Get1XLongLabel();
		label2.Text = "1216F".ToWide();
		label2.Padding = new(Constants.FONT_SIZE_1X, 0, Constants.FONT_SIZE_1X, 0);
		label2.Height = BUTTON_HEIGHT - 10;
		label2.Width = TRAIN_NUMBER_DISPLAY_WIDTH - 10;
		label2.HorizontalContentAlignment = HorizontalAlignment.Right;
		label2.VerticalContentAlignment = VerticalAlignment.Center;
		SetLeft(label2, TRAIN_NUMBER_DISPLAY_LEFT + 5);
		SetTop(label2, TRAIN_NUMBER_BUTTON_TOP + 5);
		Children.Add(label2);
	}

	void AddTrainTypeArea()
	{
		BitmapLabel directionTitleLabel = ComponentFactory.Get1XLongLabel();
		directionTitleLabel.Text = "種別表示器";
		directionTitleLabel.Background = Brushes.Black;
		directionTitleLabel.Width = TITLE_WIDTH;
		directionTitleLabel.Height = TITLE_HEIGHT;
		directionTitleLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
		directionTitleLabel.Padding = TITLE_PADDING;
		SetLeft(directionTitleLabel, TRAIN_TYPE_TITLE_LEFT);
		SetTop(directionTitleLabel, TRAIN_TYPE_TITLE_TOP);
		Children.Add(directionTitleLabel);

		Button btn = ComponentFactory.GetBasicButton(
			new(0),
			BUTTON_WIDTH,
			BUTTON_HEIGHT,
			ButtonBaseImage.SHADOW_WIDTH_SMALL
			);
		SetLeft(btn, TRAIN_TYPE_BUTTON_LEFT);
		SetTop(btn, TRAIN_TYPE_BUTTON_TOP);
		btn.Click += (s, e) => RootGrid?.SetPageType<DirectionSetting>(Context);
		Children.Add(btn);

		BitmapLabel label = ComponentFactory.Get1XLongLabel();
		label.Text = "一　括";
		btn.Content = label;

		Image displayArea = new()
		{
			Source = ButtonBaseImage.GetButtonImage(
				TYPE_DIRECTION_DISPLAY_WIDTH,
				BUTTON_HEIGHT,
				ButtonBaseImage.SHADOW_WIDTH_DEFAULT,
				System.Drawing.Color.Black
			),
			Width = TYPE_DIRECTION_DISPLAY_WIDTH,
			Height = BUTTON_HEIGHT,
		};
		SetLeft(displayArea, TRAIN_TYPE_DISPLAY_LEFT);
		SetTop(displayArea, TRAIN_TYPE_BUTTON_TOP);
		Children.Add(displayArea);

		BitmapLabel label2 = ComponentFactory.Get1XLongLabel();
		label2.Text = "1.回 送".ToWide();
		label2.Padding = new(Constants.FONT_SIZE_1X, 0, Constants.FONT_SIZE_1X, 0);
		label2.Height = BUTTON_HEIGHT - 10;
		label2.Width = TYPE_DIRECTION_DISPLAY_WIDTH - 10;
		label2.HorizontalContentAlignment = HorizontalAlignment.Left;
		label2.VerticalContentAlignment = VerticalAlignment.Center;
		SetLeft(label2, TRAIN_TYPE_DISPLAY_LEFT + 5);
		SetTop(label2, TRAIN_TYPE_BUTTON_TOP + 5);
		Children.Add(label2);
	}

	void AddDirectionArea()
	{
		BitmapLabel directionTitleLabel = ComponentFactory.Get1XLongLabel();
		directionTitleLabel.Text = "行先表示器";
		directionTitleLabel.Background = Brushes.Black;
		directionTitleLabel.Width = TITLE_WIDTH;
		directionTitleLabel.Height = TITLE_HEIGHT;
		directionTitleLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
		directionTitleLabel.Padding = TITLE_PADDING;
		SetLeft(directionTitleLabel, DIRECTION_TITLE_LEFT);
		SetTop(directionTitleLabel, DIRECTION_TITLE_TOP);
		Children.Add(directionTitleLabel);

		AddDirectionRow(DIRECTION_BUTTON_TOP, 0);
		for (int i = 0; i < 6; ++i)
		{
			int baseTop = DIRECTION_BUTTON_TOP + BUTTON_HEIGHT + DIRECTION_DISPLAY_DISPLAY_SPACING;
			AddDirectionRow(baseTop + BUTTON_HEIGHT * i, i + 1);
		}

		void AddDirectionRow(int top, int index)
		{
			Button btn = ComponentFactory.GetBasicButton(
				new(),
				BUTTON_WIDTH,
				BUTTON_HEIGHT,
				ButtonBaseImage.SHADOW_WIDTH_SMALL
			);
			SetLeft(btn, DIRECTION_BUTTON_LEFT);
			SetTop(btn, top);
			btn.Click += (s, e) => RootGrid?.SetPageType<DirectionSetting>(index == 0 ? Context : Context with { Direction_EditingTarget = index - 1 });
			Children.Add(btn);

			BitmapLabel label = ComponentFactory.Get1XLongLabel();
			label.Text = index == 0 ? "一　括" : $"{index.ToString().ToWide()}編成";
			btn.Content = label;

			Image displayArea = new()
			{
				Source = ButtonBaseImage.GetButtonImage(
					TYPE_DIRECTION_DISPLAY_WIDTH,
					BUTTON_HEIGHT,
					ButtonBaseImage.SHADOW_WIDTH_DEFAULT,
					System.Drawing.Color.Black
				),
				Width = TYPE_DIRECTION_DISPLAY_WIDTH,
				Height = BUTTON_HEIGHT,
			};
			SetLeft(displayArea, DIRECTION_DISPLAY_LEFT);
			SetTop(displayArea, top);
			Children.Add(displayArea);
		}
	}
}
