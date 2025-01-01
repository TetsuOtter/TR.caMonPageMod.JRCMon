using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TR.caMonPageMod.JRCMon.Parts;

public class BitmapLabel : Canvas
{
	public BitmapLabel()
	{
		Children.Add(image);
	}

	bool isCustomHeightSet = false;
	bool isCustomWidthSet = false;
	protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnPropertyChanged(e);
		if (e.Property.Name is nameof(Width) or nameof(Height))
			OnSizePosChanged();
		isCustomHeightSet = isCustomHeightSet || e.Property.Name == nameof(Height);
		isCustomWidthSet = isCustomWidthSet || e.Property.Name == nameof(Width);
	}

	private Brush _Foreground = Brushes.White;
	public Brush Foreground
	{
		get => _Foreground;
		set
		{
			if (_Foreground == value)
				return;
			_Foreground = value;
			OnImageChanged();
		}
	}

	private string _Text = "";
	public string Text
	{
		get => _Text;
		set
		{
			if (_Text == value)
				return;
			_Text = value;
			OnImageChanged();
		}
	}

	private int _ScaleX = 1;
	public int ScaleX
	{
		get => _ScaleX;
		set
		{
			if (_ScaleX == value)
				return;
			_ScaleX = value;
			OnSizePosChanged();
		}
	}
	private int _ScaleY = 1;
	public int ScaleY
	{
		get => _ScaleY;
		set
		{
			if (_ScaleY == value)
				return;
			_ScaleY = value;
			OnSizePosChanged();
		}
	}

	public Thickness Padding
	{
		get => image.Margin;
		set => image.Margin = value;
	}

	private HorizontalAlignment _HorizontalContentAlignment = HorizontalAlignment.Left;
	public HorizontalAlignment HorizontalContentAlignment
	{
		get => _HorizontalContentAlignment;
		set
		{
			if (_HorizontalContentAlignment == value)
				return;
			_HorizontalContentAlignment = value;
			OnSizePosChanged();
		}
	}
	private VerticalAlignment _VerticalContentAlignment = VerticalAlignment.Top;
	public VerticalAlignment VerticalContentAlignment
	{
		get => _VerticalContentAlignment;
		set
		{
			if (_VerticalContentAlignment == value)
				return;
			_VerticalContentAlignment = value;
			OnSizePosChanged();
		}
	}

	private RenderTargetBitmap? _Source;
	public RenderTargetBitmap? Source
	{
		get => _Source;
		private set
		{
			if (_Source == value)
				return;
			_Source = value;
			image.Source = value;
		}
	}
	private readonly Image image = new()
	{
		Stretch = Stretch.Fill,
	};

	private void OnImageChanged()
	{
		if (string.IsNullOrEmpty(Text))
		{
			Source = null;
			return;
		}

		FormattedText formattedText = new(
			Text,
			System.Globalization.CultureInfo.CurrentCulture,
			FlowDirection.LeftToRight,
			Constants.FONT_TYPEFACE,
			Constants.FONT_SIZE_1X,
			_Foreground,
			1
		);

		DrawingVisual drawingVisual = new();
		using (var drawingContext = drawingVisual.RenderOpen())
		{
			drawingContext.DrawText(formattedText, new Point(0, 0));
		}

		RenderTargetBitmap renderTargetBitmap = new(
			(int)Math.Ceiling(formattedText.Width),
			(int)Math.Ceiling(formattedText.Height),
			96,
			96,
			PixelFormats.Pbgra32
		);
		renderTargetBitmap.Render(drawingVisual);
		Source = renderTargetBitmap;

		OnSizePosChanged();
	}

	bool isSizePosChangedHandlerInProgress = false;
	private void OnSizePosChanged()
	{
		if (isSizePosChangedHandlerInProgress)
			return;
		isSizePosChangedHandlerInProgress = true;
		try
		{
			_OnSizePosChanged();
		}
		finally
		{
			isSizePosChangedHandlerInProgress = false;
		}
	}
	private void _OnSizePosChanged()
	{
		if (Source is null || Width == 0 || Height == 0)
			return;
		image.Width = Source.Width * ScaleX;
		image.Height = Source.Height * ScaleY;
		if (!isCustomWidthSet)
			Width = image.Width;
		if (!isCustomHeightSet)
			Height = image.Height;

		switch (HorizontalContentAlignment)
		{
			case HorizontalAlignment.Right:
				if (!double.IsNaN(GetLeft(image)))
					SetLeft(image, double.NaN);
				break;

			case HorizontalAlignment.Left:
			case HorizontalAlignment.Center:
			default:
				if (!double.IsNaN(GetRight(image)))
					SetRight(image, double.NaN);
				break;
		}
		switch (HorizontalContentAlignment)
		{
			case HorizontalAlignment.Center:
				if (double.IsNaN(Width))
					SetLeft(image, 0);
				else
					SetLeft(image, Math.Round((Width - image.Width) / 2));
				break;
			case HorizontalAlignment.Right:
				SetRight(image, 0);
				break;

			case HorizontalAlignment.Left:
			default:
				SetLeft(image, 0);
				break;
		}

		switch (VerticalContentAlignment)
		{
			case VerticalAlignment.Bottom:
				if (!double.IsNaN(GetTop(image)))
					SetTop(image, double.NaN);
				break;

			case VerticalAlignment.Top:
			case VerticalAlignment.Center:
			default:
				if (!double.IsNaN(GetBottom(image)))
					SetBottom(image, double.NaN);
				break;
		}
		switch (VerticalContentAlignment)
		{
			case VerticalAlignment.Center:
				if (double.IsNaN(Height))
					SetTop(image, 0);
				else
					SetTop(image, Math.Round((Height - image.Height) / 2));
				break;
			case VerticalAlignment.Bottom:
				SetBottom(image, 0);
				break;

			case VerticalAlignment.Top:
			default:
				SetTop(image, 0);
				break;
		}
	}
}
