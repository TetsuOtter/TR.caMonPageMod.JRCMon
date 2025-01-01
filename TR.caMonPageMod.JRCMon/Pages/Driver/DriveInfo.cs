using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Pages.Driver;

[PageTypes.NormalPage("運転士", ResourceManager.ResourceFiles.DriverIcon, "運転情報")]
public class DriveInfo : Canvas, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.DRIVER_BASE;

	const int LOWER_BOX_HEIGHT = Constants.FONT_SIZE_1X * 3;
	const int LOWER_BOX_LEFT = 0;
	const int LOWER_BOX_BOTTOM = 0;
	const int LOWER_BOX_SEPARATOR_LEFT = 160;

	const int NEXT_STOP_LABEL_PADDING_TOP = 2;

	public DriveInfo(AppState state)
	{
		Children.Add(new LocationLabel());
		Children.Add(new BrightnessControlButton());

		Children.Add(new Line()
		{
			X1 = LOWER_BOX_LEFT + (Constants.FOOTER_LINE_HEIGHT / 2),
			Y1 = Constants.BODY_HEIGHT - LOWER_BOX_HEIGHT,
			X2 = LOWER_BOX_LEFT + (Constants.FOOTER_LINE_HEIGHT / 2),
			Y2 = Constants.BODY_HEIGHT - LOWER_BOX_BOTTOM,
			Stroke = Brushes.White,
			StrokeThickness = Constants.FOOTER_LINE_HEIGHT,
		});
		Children.Add(new Line()
		{
			X1 = LOWER_BOX_LEFT,
			Y1 = Constants.BODY_HEIGHT - LOWER_BOX_HEIGHT + (Constants.FOOTER_LINE_HEIGHT / 2),
			X2 = Constants.DISPLAY_WIDTH,
			Y2 = Constants.BODY_HEIGHT - LOWER_BOX_HEIGHT + (Constants.FOOTER_LINE_HEIGHT / 2),
			Stroke = Brushes.White,
			StrokeThickness = Constants.FOOTER_LINE_HEIGHT,
		});
		Children.Add(new Line()
		{
			X1 = LOWER_BOX_SEPARATOR_LEFT + (Constants.FOOTER_LINE_HEIGHT / 2),
			Y1 = Constants.BODY_HEIGHT - LOWER_BOX_HEIGHT,
			X2 = LOWER_BOX_SEPARATOR_LEFT + (Constants.FOOTER_LINE_HEIGHT / 2),
			Y2 = Constants.BODY_HEIGHT - LOWER_BOX_BOTTOM,
			Stroke = Brushes.White,
			StrokeThickness = Constants.FOOTER_LINE_HEIGHT,
		});

		BitmapLabel nextStopLabel = ComponentFactory.Get1XLabel();
		nextStopLabel.Text = "次停車駅";
		nextStopLabel.Width = LOWER_BOX_SEPARATOR_LEFT;
		nextStopLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
		SetTop(nextStopLabel, Constants.BODY_HEIGHT - LOWER_BOX_HEIGHT + NEXT_STOP_LABEL_PADDING_TOP);
		Children.Add(nextStopLabel);

		Children.Add(ComponentFactory.Driver.GetAssistLabel());
		Children.Add(new TrainFormationImage(state));
	}
}
