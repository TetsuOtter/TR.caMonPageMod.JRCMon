using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TR.caMonPageMod.JRCMon;

class RootGrid : Grid
{
	private readonly ContentControl FullScreenContent = new();
	private readonly Header Header = new();
	private readonly ContentControl BodyContent = new();
	public Type CurrentPageType { get; private set; }

	public RootGrid()
	{
		Height = Constants.DISPLAY_HEIGHT;
		Width = Constants.DISPLAY_WIDTH;
		Background = Brushes.Black;

		RowDefinitions.Add(new RowDefinition { Height = new GridLength(Constants.HEADER_HEIGHT) });
		RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

		SetRow(FullScreenContent, 0);
		SetRow(Header, 0);
		SetRow(BodyContent, 1);

		SetRowSpan(FullScreenContent, 2);

		Children.Add(Header);
		Children.Add(BodyContent);
		Children.Add(FullScreenContent);

		CurrentPageType = typeof(Pages.System.AppInfoPage);
		SetPageType<Pages.System.AppInfoPage>();
	}

	public void SetPageType<T>() where T: FrameworkElement, new()
	{
		FullScreenContent.Content = null;
		BodyContent.Content = null;

		FrameworkElement cc = new T
		{
			Width = Constants.DISPLAY_WIDTH,
		};
		if (typeof(T).GetCustomAttribute<PageTypes.FullScreenPageAttribute>() is not null)
		{
			FullScreenContent.Content = cc;
			cc.Height = Constants.DISPLAY_HEIGHT;
		}
		else
		{
			BodyContent.Content = cc;
			cc.Height = Constants.BODY_HEIGHT;
		}

		CurrentPageType = typeof(T);
	}
}
