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

	const int LOWER_BOX_STROKE_THICKNESS = 2;
	const int LOWER_BOX_HEIGHT = 70;
	const int LOWER_BOX_LEFT = 2;
	const int LOWER_BOX_BOTTOM = -1;
	const int LOWER_BOX_SEPARATOR_LEFT = 188;

	public DriveInfo(AppState state)
	{
		Children.Add(new LocationLabel());
		Children.Add(new BrightnessControlButton());

		Children.Add(new Line()
		{
			X1 = LOWER_BOX_LEFT + (LOWER_BOX_STROKE_THICKNESS / 2),
			Y1 = Constants.BODY_HEIGHT - LOWER_BOX_HEIGHT,
			X2 = LOWER_BOX_LEFT + (LOWER_BOX_STROKE_THICKNESS / 2),
			Y2 = Constants.BODY_HEIGHT - LOWER_BOX_BOTTOM,
			Stroke = Brushes.White,
			StrokeThickness = LOWER_BOX_STROKE_THICKNESS,
		});
		Children.Add(new Line()
		{
			X1 = LOWER_BOX_LEFT,
			Y1 = Constants.BODY_HEIGHT - LOWER_BOX_HEIGHT + (LOWER_BOX_STROKE_THICKNESS / 2),
			X2 = Constants.DISPLAY_WIDTH,
			Y2 = Constants.BODY_HEIGHT - LOWER_BOX_HEIGHT + (LOWER_BOX_STROKE_THICKNESS / 2),
			Stroke = Brushes.White,
			StrokeThickness = LOWER_BOX_STROKE_THICKNESS,
		});
		Children.Add(new Line()
		{
			X1 = LOWER_BOX_SEPARATOR_LEFT + (LOWER_BOX_STROKE_THICKNESS / 2),
			Y1 = Constants.BODY_HEIGHT - LOWER_BOX_HEIGHT,
			X2 = LOWER_BOX_SEPARATOR_LEFT + (LOWER_BOX_STROKE_THICKNESS / 2),
			Y2 = Constants.BODY_HEIGHT - LOWER_BOX_BOTTOM,
			Stroke = Brushes.White,
			StrokeThickness = LOWER_BOX_STROKE_THICKNESS,
		});

		Children.Add(new TrainFormationImage(state));
	}
}
