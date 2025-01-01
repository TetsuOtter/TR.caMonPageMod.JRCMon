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

	const int LABEL_LEFT = 8;
	const int LABEL_BOTTOM = 8;

	const int BUTTON_WIDTH = 104;
	const int BUTTON_HEIGHT = 54;

	const int BUTTON_DISPLAY_PADDING = 6;

	const int TRAIN_NUMBER_BUTTON_LEFT = 60;
	const int TRAIN_NUMBER_BUTTON_TOP = 108;
	const int TRAIN_NUMBER_BUTTON_WIDTH = BUTTON_WIDTH;
	const int TRAIN_NUMBER_BUTTON_HEIGHT = BUTTON_HEIGHT - 4;
	const int TRAIN_NUMBER_DISPLAY_SPACING = 20;
	const int TRAIN_NUMBER_DISPLAY_LEFT = TRAIN_NUMBER_BUTTON_LEFT + BUTTON_WIDTH + TRAIN_NUMBER_DISPLAY_SPACING;
	const int TRAIN_NUMBER_DISPLAY_WIDTH = Constants.FONT_SIZE_1X * 8 + 10;

	const int TRAIN_TYPE_TITLE_TOP = 240;
	const int TRAIN_TYPE_TITLE_LEFT = 132;
	const int TRAIN_TYPE_TITLE_HEIGHT = 38;
	const int TRAIN_TYPE_TITLE_SPACING = 16;
	const int TRAIN_TYPE_BUTTON_LEFT = 32;
	const int TRAIN_TYPE_BUTTON_TOP = TRAIN_TYPE_TITLE_TOP + TRAIN_TYPE_TITLE_HEIGHT + TRAIN_TYPE_TITLE_SPACING;
	const int TRAIN_TYPE_BUTTON_WIDTH = BUTTON_WIDTH;
	const int TRAIN_TYPE_BUTTON_HEIGHT = BUTTON_HEIGHT - 4;
	const int TRAIN_TYPE_DISPLAY_LEFT = TRAIN_TYPE_BUTTON_LEFT + BUTTON_WIDTH + BUTTON_DISPLAY_PADDING;
	const int TRAIN_TYPE_DISPLAY_WIDTH = 234;

	const int DIRECTION_TITLE_LEFT = 540;
	const int DIRECTION_TITLE_TOP = 32;
	const int DIRECTION_TITLE_HEIGHT = 38;
	const int DIRECTION_BUTTON_LEFT = 422;
	const int DIRECTION_BUTTON_TOP = DIRECTION_TITLE_TOP + DIRECTION_TITLE_HEIGHT + 8;
	const int DIRECTION_BUTTON_SPACING = 6;
	const int DIRECTION_DISPLAY_LEFT = DIRECTION_BUTTON_LEFT + BUTTON_WIDTH + BUTTON_DISPLAY_PADDING;
	const int DIRECTION_DISPLAY_WIDTH = 234;

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

		AddTrainNumberArea();
		AddTrainTypeArea();
		AddDirectionArea();
	}

	void AddTrainNumberArea()
	{
		Button btn = ComponentFactory.GetBasicButton(
			new(TRAIN_NUMBER_BUTTON_LEFT, TRAIN_NUMBER_BUTTON_TOP, 0, 0),
			TRAIN_NUMBER_BUTTON_WIDTH,
			TRAIN_NUMBER_BUTTON_HEIGHT
		);
		btn.Click += (s, e) => RootGrid?.SetPageType<DirectionSettingNumber>(Context);
		Children.Add(btn);

		BitmapLabel label = ComponentFactory.Get1XLongLabel();
		label.Text = "列車番号";
		btn.Content = label;

		Image displayArea = new()
		{
			Source = ButtonBaseImage.GetButtonImage(
				TRAIN_NUMBER_DISPLAY_WIDTH,
				TRAIN_NUMBER_BUTTON_HEIGHT,
				false,
				System.Drawing.Color.Black
			),
			Width = TRAIN_NUMBER_DISPLAY_WIDTH,
			Height = TRAIN_NUMBER_BUTTON_HEIGHT,
		};
		SetLeft(displayArea, TRAIN_NUMBER_DISPLAY_LEFT);
		SetTop(displayArea, TRAIN_NUMBER_BUTTON_TOP);
		Children.Add(displayArea);

		BitmapLabel label2 = ComponentFactory.Get1XLongLabel();
		label2.Text = "1216F".ToWide();
		label2.Padding = new(Constants.FONT_SIZE_1X, 0, Constants.FONT_SIZE_1X, 0);
		label2.Height = TRAIN_NUMBER_BUTTON_HEIGHT - 10;
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
		directionTitleLabel.Width = Constants.FONT_SIZE_1X * 8;
		directionTitleLabel.Height = TRAIN_TYPE_TITLE_HEIGHT;
		directionTitleLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
		directionTitleLabel.Padding = new(0, 2, 0, 0);
		SetLeft(directionTitleLabel, TRAIN_TYPE_TITLE_LEFT);
		SetTop(directionTitleLabel, TRAIN_TYPE_TITLE_TOP);
		Children.Add(directionTitleLabel);

		Button btn = ComponentFactory.GetBasicButton(
			new(TRAIN_TYPE_BUTTON_LEFT, TRAIN_TYPE_BUTTON_TOP, 0, 0),
			TRAIN_TYPE_BUTTON_WIDTH,
			TRAIN_TYPE_BUTTON_HEIGHT
			);
		btn.Click += (s, e) => RootGrid?.SetPageType<DirectionSetting>(Context);
		Children.Add(btn);

		BitmapLabel label = ComponentFactory.Get1XLongLabel();
		label.Text = "一　括";
		btn.Content = label;

		Image displayArea = new()
		{
			Source = ButtonBaseImage.GetButtonImage(
				TRAIN_TYPE_DISPLAY_WIDTH,
				TRAIN_TYPE_BUTTON_HEIGHT,
				false,
				System.Drawing.Color.Black
			),
			Width = TRAIN_TYPE_DISPLAY_WIDTH,
			Height = TRAIN_TYPE_BUTTON_HEIGHT,
		};
		SetLeft(displayArea, TRAIN_TYPE_DISPLAY_LEFT);
		SetTop(displayArea, TRAIN_TYPE_BUTTON_TOP);
		Children.Add(displayArea);

		BitmapLabel label2 = ComponentFactory.Get1XLongLabel();
		label2.Text = "1.回 送".ToWide();
		label2.Padding = new(Constants.FONT_SIZE_1X, 0, Constants.FONT_SIZE_1X, 0);
		label2.Height = TRAIN_TYPE_BUTTON_HEIGHT - 10;
		label2.Width = TRAIN_TYPE_DISPLAY_WIDTH - 10;
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
		directionTitleLabel.Width = Constants.FONT_SIZE_1X * 8;
		directionTitleLabel.Height = 38;
		directionTitleLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
		directionTitleLabel.Padding = new(0, 2, 0, 0);
		SetLeft(directionTitleLabel, DIRECTION_TITLE_LEFT);
		SetTop(directionTitleLabel, DIRECTION_TITLE_TOP);
		Children.Add(directionTitleLabel);

		AddDirectionRow(DIRECTION_BUTTON_TOP, 0);
		for (int i = 0; i < 6; ++i)
		{
			int baseTop = DIRECTION_BUTTON_TOP + BUTTON_HEIGHT + DIRECTION_BUTTON_SPACING;
			AddDirectionRow(baseTop + BUTTON_HEIGHT * i, i + 1);
		}

		void AddDirectionRow(int top, int index)
		{
			Button btn = ComponentFactory.GetBasicButton(new(DIRECTION_BUTTON_LEFT, top, 0, 0), BUTTON_WIDTH, BUTTON_HEIGHT);
			btn.Click += (s, e) => RootGrid?.SetPageType<DirectionSetting>(index == 0 ? Context : Context with { Direction_EditingTarget = index - 1 });
			Children.Add(btn);

			BitmapLabel label = ComponentFactory.Get1XLongLabel();
			label.Text = index == 0 ? "一　括" : $"{index.ToString().ToWide()}編成";
			btn.Content = label;

			Image displayArea = new()
			{
				Source = ButtonBaseImage.GetButtonImage(DIRECTION_DISPLAY_WIDTH, BUTTON_HEIGHT, false, System.Drawing.Color.Black),
				Width = DIRECTION_DISPLAY_WIDTH,
				Height = BUTTON_HEIGHT,
			};
			SetLeft(displayArea, DIRECTION_DISPLAY_LEFT);
			SetTop(displayArea, top);
			Children.Add(displayArea);
		}
	}
}
