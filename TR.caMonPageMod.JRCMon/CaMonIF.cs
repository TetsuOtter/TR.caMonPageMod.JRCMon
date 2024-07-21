using System.Windows.Controls;

using caMon;

namespace TR.caMonPageMod.JRCMon;

public class CaMonIF : Page, IPages
{
	private bool disposedValue;

	public Page FrontPage => this;

	public event EventHandler? BackToHome { add => RootGrid.BackToHome += value; remove => RootGrid.BackToHome -= value; }
	public event EventHandler? CloseApp { add => RootGrid.CloseApp += value; remove => RootGrid.CloseApp -= value; }

	private readonly RootGrid RootGrid = new RootGrid();

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
