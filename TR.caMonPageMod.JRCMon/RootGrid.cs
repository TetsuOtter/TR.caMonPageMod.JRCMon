using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using TR.caMonPageMod.JRCMon.Header;
using TR.caMonPageMod.JRCMon.PageTypes;

namespace TR.caMonPageMod.JRCMon;

public class RootGrid : Grid
{
	public event EventHandler? BackToHome;
	public event EventHandler? CloseApp;

	private readonly HeaderArea HeaderArea = new();
	public RootGrid()
	{
		Height = Constants.DISPLAY_HEIGHT;
		Width = Constants.DISPLAY_WIDTH;
		Background = Brushes.Black;

		RowDefinitions.Add(new RowDefinition { Height = new GridLength(Constants.HEADER_HEIGHT) });
		RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

		SetPageType<Pages.SystemControl.MenuPage>();
	}

	public void SetPageType<T>() where T: FrameworkElement, new()
	{
		Children.Clear();
		FrameworkElement cc = new T
		{
			Width = Constants.DISPLAY_WIDTH,
		};
		if (typeof(T).GetCustomAttribute<FullScreenPageAttribute>() is not null)
		{
			SetRowSpan(cc, 2);
			cc.Height = Constants.DISPLAY_HEIGHT;
			Children.Add(cc);
		}
		else if (typeof(T).GetCustomAttribute<NormalPageAttribute>() is NormalPageAttribute pageAttribute)
		{
			SetRow(HeaderArea, 0);
			SetRow(cc, 1);
			cc.Height = Constants.BODY_HEIGHT;
			Children.Add(HeaderArea);
			Children.Add(cc);
			HeaderArea.OnChangePage(pageAttribute);
		}
		else
		{
			throw new InvalidOperationException("Invalid Page Type");
		}

		if (cc is IHoldRootGridInstance page)
		{
			page.RootGrid = this;
		}
	}

	public void BackToHomeInvoke() => BackToHome?.Invoke(this, EventArgs.Empty);
	public void CloseAppInvoke() => CloseApp?.Invoke(this, EventArgs.Empty);
}
