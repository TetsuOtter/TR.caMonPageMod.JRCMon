using System.Windows.Controls;
using System.Windows.Media;

using caMon;

namespace TR.caMonPageMod.JRCMon;

public class CaMonIF : Page, IPages
{
	private bool disposedValue;

	public Page FrontPage => this;

	public event EventHandler? BackToHome;
	public event EventHandler? CloseApp;

	public CaMonIF()
	{
		Content = new TextBlock
		{
			Text = "JRCMon",
			Background = Brushes.LightGreen,
			FontFamily = new FontFamily("JF Dot jiskan16s")
		};
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
