using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using caMon;

namespace TR.caMonPageMod.JRCMon;

public class CaMonIF : Page, IPages
{
	private bool disposedValue;

	public Page FrontPage => this;

	public event EventHandler? BackToHome { add => RootGrid.BackToHome += value; remove => RootGrid.BackToHome -= value; }
	public event EventHandler? CloseApp { add => RootGrid.CloseApp += value; remove => RootGrid.CloseApp -= value; }

	private readonly RootGrid RootGrid = new();

	const string ASSEMBLY_NS = "TR.caMonPageMod.JRCMon.";
	const string PAGES_NS = "TR.caMonPageMod.JRCMon.Pages.";

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
		KeyDown += (s, e) =>
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
		KeyDown += (s, e) =>
		{
			switch (e.Key)
			{
				case System.Windows.Input.Key.P:
					if (e.KeyboardDevice.Modifiers.HasFlag(System.Windows.Input.ModifierKeys.Control))
						GetImage();
					return;
				default:
					return;
			}
		};
	}

	private void GetImage()
	{
		try
		{
			RenderTargetBitmap renderTargetBitmap = new(Constants.DISPLAY_WIDTH, Constants.DISPLAY_HEIGHT, 96, 96, PixelFormats.Pbgra32);
			renderTargetBitmap.Render(RootGrid);
			string path = ResourceManager.CurrentAssembly.Location;
			string pageName = RootGrid.CurrentPageType.FullName ?? RootGrid.CurrentPageType.Name;
			if (pageName.StartsWith(PAGES_NS))
				pageName = pageName[PAGES_NS.Length..];
			else if (pageName.StartsWith(ASSEMBLY_NS))
				pageName = pageName[ASSEMBLY_NS.Length..];
			string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}.{pageName}.png";
			string savePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path) ?? "", fileName);

			using System.IO.FileStream fileStream = new(savePath, System.IO.FileMode.Create);
			PngBitmapEncoder pngBitmapEncoder = new();
			pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
			pngBitmapEncoder.Save(fileStream);
			System.Windows.MessageBox.Show($"Saved to {savePath}");
		}
		catch (Exception ex)
		{
			System.Windows.MessageBox.Show(ex.ToString());
		}
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
