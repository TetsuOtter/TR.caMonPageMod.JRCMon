using System.Windows.Controls;

using caMon;

namespace TR.caMonPageMod.JRCMon;

public class CaMonIF : Page, IPages
{
	private bool disposedValue;

	public Page FrontPage => this;

#pragma warning disable CS0067
	public event EventHandler? BackToHome;
	public event EventHandler? CloseApp;
#pragma warning restore CS0067

	private readonly Grid RootGrid = new RootGrid();

	public CaMonIF()
	{
		Viewbox viewbox = new()
		{
			Child = RootGrid
		};
		Content = viewbox;
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
