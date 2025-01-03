using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon.Pages.SystemControl;

[PageTypes.FullScreenPage("ｱﾌﾟﾘ情報")]
public partial class AppInfoPage : Canvas, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CURRENT_AND_EMBED_MAN;

	const int TITLE_LABEL_LEFT_MARGIN = 8;
	const int PAGE_TITLE_LABEL_TOP_MARGIN = 12;
	const int APP_VERSION_BORDER_WIDTH = 4;

	static readonly Thickness AppVersionLabelMargin = new(162, 104, 0, 0);
	static readonly Thickness AppVersionBorderMargin = new(AppVersionLabelMargin.Left - APP_VERSION_BORDER_WIDTH, AppVersionLabelMargin.Top - APP_VERSION_BORDER_WIDTH, 0, 0);
	static readonly Thickness AppVersionTitleLabelMargin = new(TITLE_LABEL_LEFT_MARGIN, AppVersionLabelMargin.Top + 2, 0, 0);
	static readonly Thickness AppVersionUpdateButtonMargin = new(157, 168, 0, 0);
	static readonly Thickness AppVersionUpdateButtonTitleLabelMargin = new(TITLE_LABEL_LEFT_MARGIN, AppVersionUpdateButtonMargin.Top + 8, 0, 0);

	static readonly Thickness BVEConnectionTitleLabelMargin = new(TITLE_LABEL_LEFT_MARGIN, 378, 0, 0);
	static readonly Thickness StartBVEConnectionButtonMargin = new(156, 380, 0, 0);
	static readonly Thickness EndBVEConnectionButtonMargin = StartBVEConnectionButtonMargin with { Left = 250 };

	static readonly Thickness SyncMonitorTitleLabelMargin = new(TITLE_LABEL_LEFT_MARGIN, 435, 0, 0);
	static readonly Thickness StartSyncMonitorButtonMargin = StartBVEConnectionButtonMargin with { Top = 437 };
	static readonly Thickness EndSyncMonitorButtonMargin = EndBVEConnectionButtonMargin with { Top = 437 };

	const int APP_VERSION_LABEL_HEIGHT = 41;
	const int APP_VERSION_LABEL_WIDTH = 180;
	const int APP_VERSION_UPDATE_BUTTON_WIDTH = 94;
	const int APP_VERSION_UPDATE_BUTTON_HEIGHT = 48;

	public AppInfoPage()
	{
		BitmapLabel PageTitleLabel = ComponentFactory.Get2XLabel();
		PageTitleLabel.Margin = new(0, PAGE_TITLE_LABEL_TOP_MARGIN, 0, 0);
		PageTitleLabel.Text = "アプリ情報";
		PageTitleLabel.Width = Constants.DISPLAY_WIDTH;
		PageTitleLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
		PageTitleLabel.Foreground = Brushes.Yellow;
		Children.Add(PageTitleLabel);

		PutTitleLabel("アプリバージョン", AppVersionTitleLabelMargin);
		Rectangle AppVersionBorder = new()
		{
			Width = APP_VERSION_LABEL_WIDTH + APP_VERSION_BORDER_WIDTH * 2,
			Height = APP_VERSION_LABEL_HEIGHT + APP_VERSION_BORDER_WIDTH * 2,
			Margin = AppVersionBorderMargin,
			Fill = Brushes.Transparent,
			Stroke = Brushes.White,
			StrokeThickness = APP_VERSION_BORDER_WIDTH
		};
		Children.Add(AppVersionBorder);
		BitmapLabel AppVersionLabel = ComponentFactory.Get1XLongLabel();
		AppVersionLabel.Height = APP_VERSION_LABEL_HEIGHT / 1.5;
		AppVersionLabel.Width = APP_VERSION_LABEL_WIDTH;
		AppVersionLabel.Margin = AppVersionLabelMargin;
		AppVersionLabel.VerticalContentAlignment = VerticalAlignment.Center;
		AppVersionLabel.HorizontalContentAlignment = HorizontalAlignment.Right;
		AppVersionLabel.Text = ResourceManager.CurrentAssembly.GetName().Version?.ToString() ?? "Unknown";
		Children.Add(AppVersionLabel);

		PutTitleLabel("バージョンを更新", AppVersionUpdateButtonTitleLabelMargin);
		BitmapLabel AppVersionUpdateLabel = ComponentFactory.Get1XLongLabel();
		AppVersionUpdateLabel.Text = "更新する";
		Button AppVersionUpdateButton = ComponentFactory.GetBasicButton(
			AppVersionUpdateButtonMargin,
			APP_VERSION_UPDATE_BUTTON_WIDTH,
			APP_VERSION_UPDATE_BUTTON_HEIGHT,
			AppVersionUpdateLabel,
			ButtonBaseImage.SHADOW_WIDTH_SMALL
		);
		Children.Add(AppVersionUpdateButton);

		PutTitleLabel("BVE接続", BVEConnectionTitleLabelMargin);
		PutRoundSW_S("開始", StartBVEConnectionButtonMargin, Colors.Aqua, Brushes.Black);
		PutRoundSW_S("終了", EndBVEConnectionButtonMargin, Colors.Red, Brushes.White);

		PutTitleLabel("モニタ同期", SyncMonitorTitleLabelMargin);
		PutRoundSW_S("開始", StartSyncMonitorButtonMargin, Colors.Aqua, Brushes.Black);
		PutRoundSW_S("終了", EndSyncMonitorButtonMargin, Colors.Red, Brushes.White);
	}

	void PutTitleLabel(string title, Thickness margin)
	{
		BitmapLabel titleLabel = ComponentFactory.Get1XLongLabel();
		titleLabel.Margin = margin;
		titleLabel.Text = title;
		titleLabel.HorizontalContentAlignment = HorizontalAlignment.Left;
		Children.Add(titleLabel);
	}

	Button PutRoundSW_S(string title, Thickness margin, Color color, Brush textColor)
	{
		BitmapLabel label = ComponentFactory.Get1XLabel();
		label.Text = title;
		label.Foreground = textColor;
		Button button = ComponentFactory.GetRedReplacedImgButton(
			ResourceManager.ResourceFiles.RoundSW_S,
			margin,
			label,
			color
		);
		Children.Add(button);
		return button;
	}
}
