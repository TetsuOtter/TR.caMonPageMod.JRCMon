using System.Windows.Controls;
using System.Windows.Media;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.CarPartsStateArea;
using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Pages.Conductor;

[PageTypes.NormalPage("車　掌", ResourceManager.ResourceFiles.ConductorIcon, "車掌情報")]
public class ConductorInto : Canvas, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CONDUCTOR_INFO;

	const int ROOM_LIGHT_TOP = 332;
	const int LABEL_LEFT = 8;
	const int LABEL_BOTTOM = 8;

	public ConductorInto(AppState state)
	{
		Children.Add(new LocationLabel());

		Children.Add(new TrainFormationImage(state));

		Children.Add(new DoorStateArea(state));
		Children.Add(new AnnounceStateArea(state));
		Children.Add(new AirCondStateArea(state));
		Children.Add(new CrossFlowStateArea(state));
		Children.Add(new TemperatureArea(state));
		Children.Add(new HumidityArea(state));

		BitmapLabel roomLightLabel = ComponentFactory.Get2XLabel();
		roomLightLabel.Text = "室内灯";
		SetLeft(roomLightLabel, 4);
		SetTop(roomLightLabel, ROOM_LIGHT_TOP);
		Children.Add(roomLightLabel);

		BitmapLabel roomLightState = ComponentFactory.Get2XLabel();
		roomLightState.Text = "入";
		roomLightState.Foreground = Brushes.Black;
		roomLightState.Background = Brushes.Yellow;
		roomLightState.Width = 90;
		roomLightState.Height = Constants.FONT_SIZE_2X + 4;
		roomLightState.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
		roomLightState.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
		SetLeft(roomLightState, 108);
		SetTop(roomLightState, ROOM_LIGHT_TOP - 2);
		Children.Add(roomLightState);

		if (state.Is315Connected)
		{
			BitmapLabel guideDisplayLabel = ComponentFactory.Get1XLongLabel();
			guideDisplayLabel.Text = "車内案内・自動放送";
			SetLeft(guideDisplayLabel, 234);
			SetTop(guideDisplayLabel, ROOM_LIGHT_TOP);
			Children.Add(guideDisplayLabel);
		}
		else
		{
			BitmapLabel guideDisplayLabel = ComponentFactory.Get2XLabel();
			guideDisplayLabel.Text = "車内案内";
			SetLeft(guideDisplayLabel, 234);
			SetTop(guideDisplayLabel, ROOM_LIGHT_TOP);
			Children.Add(guideDisplayLabel);
		}

		BitmapLabel guideDisplayState = ComponentFactory.Get2XLabel();
		guideDisplayState.Text = "入";
		guideDisplayState.Foreground = Brushes.Black;
		guideDisplayState.Background = Brushes.Yellow;
		guideDisplayState.Width = 90;
		guideDisplayState.Height = Constants.FONT_SIZE_2X + 4;
		guideDisplayState.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
		guideDisplayState.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
		SetLeft(guideDisplayState, 386);
		SetTop(guideDisplayState, ROOM_LIGHT_TOP - 2);
		Children.Add(guideDisplayState);

		if (state.Is315Connected)
		{
			guideDisplayState.Text = "個別";

			BitmapLabel label315 = ComponentFactory.Get1XLabel();
			label315.Text = "車内案内、自動放送、315系車外表示器の設定は、315系設定画面で行ってください。";
			SetLeft(label315, LABEL_LEFT);
			SetBottom(label315, LABEL_BOTTOM + Constants.FONT_SIZE_1X + Constants.TEXT_PADDING_Y);
			Children.Add(label315);
		}

		BitmapLabel label = ComponentFactory.Get1XLabel();
		label.Text = "サービス機器のスイッチ扱いは「空調制御」または「サービス」キーを押して下さい。";
		SetLeft(label, LABEL_LEFT);
		SetBottom(label, LABEL_BOTTOM);
		Children.Add(label);
	}
}
