using System.Windows.Controls;
using System.Windows.Media;

using caMon;

namespace TR.caMonPageMod.JRCMon;

public class CaMonIF : Page, IPages
{
	private bool disposedValue;

	public Page FrontPage => this;

	public event EventHandler? BackToHome { add => RootGrid.BackToHome += value; remove => RootGrid.BackToHome -= value; }
	public event EventHandler? CloseApp { add => RootGrid.CloseApp += value; remove => RootGrid.CloseApp -= value; }

	private readonly RootGrid RootGrid = new();

	public CaMonIF()
	{
		Viewbox viewbox = new()
		{
			Child = RootGrid,
		};
		RenderOptions.SetEdgeMode(viewbox, EdgeMode.Aliased);
		RenderOptions.SetBitmapScalingMode(viewbox, BitmapScalingMode.NearestNeighbor);
#if DEBUG
		Background = new SolidColorBrush(Color.FromRgb(0x20, 0x20, 0x20));
		ScrollViewer scrollViewer = new()
		{
			Content = viewbox,
			VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
			HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
		};
		scrollViewer.KeyDown += (s, e) =>
		{
			switch (e.Key)
			{
				case System.Windows.Input.Key.D0:
				case System.Windows.Input.Key.D1:
					viewbox.LayoutTransform = new ScaleTransform(1, 1);
					break;
				case System.Windows.Input.Key.D2:
					viewbox.LayoutTransform = new ScaleTransform(2, 2);
					break;
				case System.Windows.Input.Key.D3:
					viewbox.LayoutTransform = new ScaleTransform(3, 3);
					break;
				case System.Windows.Input.Key.D4:
					viewbox.LayoutTransform = new ScaleTransform(4, 4);
					break;
				case System.Windows.Input.Key.D5:
					viewbox.LayoutTransform = new ScaleTransform(5, 5);
					break;
				case System.Windows.Input.Key.D6:
					viewbox.LayoutTransform = new ScaleTransform(6, 6);
					break;
				case System.Windows.Input.Key.D7:
					viewbox.LayoutTransform = new ScaleTransform(7, 7);
					break;
				case System.Windows.Input.Key.D8:
					viewbox.LayoutTransform = new ScaleTransform(8, 8);
					break;
				case System.Windows.Input.Key.D9:
					viewbox.LayoutTransform = new ScaleTransform(9, 9);
					break;
				default:
					return;
			}
			if (e.Key == System.Windows.Input.Key.D0)
			{
				viewbox.Height = Constants.DISPLAY_HEIGHT;
				viewbox.Width = Constants.DISPLAY_WIDTH;
			}
			else
			{
				viewbox.Height = double.NaN;
				viewbox.Width = double.NaN;
			}
		};
		Content = scrollViewer;
#else
		Content = viewbox;
#endif
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
			}

			disposedValue = true;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
