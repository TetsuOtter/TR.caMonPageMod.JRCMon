using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using TR.caMonPageMod.JRCMon.PageTypes;

namespace TR.caMonPageMod.JRCMon.Footer;

public class FooterArea : Canvas
{
	private int currentPageIndex = 0;
	private readonly int maxPageIndex = 0;
	public event EventHandler<int>? PageChanged;

	private const int FOOTER_AREA_TOP = 1;

	private readonly (Image, Button)? goNextPageButton;
	private readonly (Image, Button)? goPrevPageButton0;
	private readonly (Image, Button)? goPrevPageButton1;

	public FooterArea(
		RootGrid rootGrid,
		IReadOnlyList<FooterInfo> footerInfoList,
		Type pageType,
		Type lastPageType
	)
	{
		Height = Constants.FOOTER_HEIGHT;
		Width = Constants.DISPLAY_WIDTH;

		Children.Add(new Line
		{
			X1 = 0,
			Y1 = FOOTER_AREA_TOP + (Constants.FOOTER_LINE_HEIGHT / 2),
			X2 = Constants.DISPLAY_WIDTH,
			Y2 = FOOTER_AREA_TOP + (Constants.FOOTER_LINE_HEIGHT / 2),
			Stroke = Brushes.White,
			StrokeThickness = Constants.FOOTER_LINE_HEIGHT,
			HorizontalAlignment = HorizontalAlignment.Left,
			VerticalAlignment = VerticalAlignment.Top
		});
		foreach (var (info, index) in footerInfoList.Where(v => v.IsLeftAligned).Select((f, i) => (f, i)))
		{
			bool isSelected = getIsSelected(info, pageType);
			string label = getLabel(info, pageType);
			(_, Button btn) = AddButton(true, label, isSelected, index, isEnabled: info.IsEnabled);
			if (info.IsEnabled)
			{
				Type pageClass = getPageType(info, pageType, lastPageType);
				btn.Click += (s, e) => rootGrid.SetPageType(pageClass);
			}
		}
		foreach (var (info, index) in footerInfoList.Where(v => !v.IsLeftAligned).Reverse().Select((f, i) => (f, i)))
		{
			bool isSelected = getIsSelected(info, pageType);
			string label = getLabel(info, pageType);
			(_, Button btn) = AddButton(false, label, isSelected, index, isEnabled: info.IsEnabled);
			if (info.IsEnabled)
			{
				Type pageClass = getPageType(info, pageType, lastPageType);
				btn.Click += (s, e) => rootGrid.SetPageType(pageClass);
			}
		}
	}

	static bool getIsSelected(FooterInfo info, Type pageType)
	{
		if (info.IsForceSelected)
		{
			return true;
		}

		if (info is FooterInfoPage infoPage)
		{
			return pageType.Equals(infoPage.PageClass) || pageType.IsSubclassOf(infoPage.PageClass);
		}
		else if (info is FooterInfoCurrentPage)
		{
			return true;
		}
		else if (info is FooterInfoGoBack)
		{
			return false;
		}

		return false;
	}

	static Type getPageType(FooterInfo info, Type pageType, Type lastPageType)
		=> info switch
		{
			FooterInfoPage infoPage => infoPage.PageClass,
			FooterInfoCurrentPage => pageType,
			FooterInfoGoBack => lastPageType,
			_ => throw new NotSupportedException("Unsupported FooterInfo")
		};
	static string getLabel(FooterInfo info, Type pageType)
		=> info switch
		{
			FooterInfoPage infoPage => getFooterPageName(infoPage.PageClass),
			FooterInfoCurrentPage => getFooterPageName(pageType),
			FooterInfoGoBack => "戻る",
			FooterInfoDummy dummy => dummy.label,
			_ => throw new NotSupportedException("Unsupported FooterInfo")
		};
	public static string getFooterPageName(Type pageType)
	{
		var attr = pageType.GetCustomAttribute<FooterPageNameAttribute>();
		if (attr is not null)
			return attr.FooterPageName;
		return string.Empty;
	}


	public FooterArea(
		RootGrid rootGrid,
		IReadOnlyList<FooterInfo> footerInfoList,
		Type pageType,
		Type lastPageType,
		int maxPageIndex
	) : this(rootGrid, footerInfoList, pageType, lastPageType)
	{
		this.maxPageIndex = maxPageIndex;

		if (0 < maxPageIndex)
		{
			goNextPageButton = AddButton(true, "次画面", false, 0);
			goNextPageButton.Value.Item2.Click += (s, e) => SetPageIndex(currentPageIndex + 1);

			goPrevPageButton0 = AddButton(true, "前画面", false, 0, false);
			goPrevPageButton0.Value.Item2.Click += (s, e) => SetPageIndex(currentPageIndex - 1);
			goPrevPageButton1 = AddButton(true, "前画面", false, 1, false);
			goPrevPageButton1.Value.Item2.Click += (s, e) => SetPageIndex(currentPageIndex - 1);
		}
	}

	private (Image, Button) AddButton(
		bool isLeftAligned,
		string labelStr,
		bool isSelected,
		int index,
		bool addToChildren = true,
		bool isEnabled = true
	)
	{
		double imgX = (Constants.FOOTER_MENU_BUTTON_IMG_WIDTH + Constants.FOOTER_MENU_BUTTON_IMG_SPACING) * index;
		double imgXR = Constants.DISPLAY_WIDTH - Constants.FOOTER_MENU_BUTTON_IMG_WIDTH - imgX;
		Image btnImg = ResourceManager.GetResourceAsImage(
			isSelected ? ResourceManager.ResourceFiles.FooterSW_ON : ResourceManager.ResourceFiles.FooterSW_OFF
		);
		btnImg.Margin = new Thickness(
			isLeftAligned ? imgX : imgXR,
			FOOTER_AREA_TOP,
			isLeftAligned ? imgXR : imgX,
			0
		);
		btnImg.Height = Constants.FOOTER_MENU_BUTTON_IMG_HEIGHT;
		btnImg.Width = Constants.FOOTER_MENU_BUTTON_IMG_WIDTH;
		if (addToChildren)
		{
			Children.Add(btnImg);
		}

		double btnX = imgX + (Constants.FOOTER_MENU_BUTTON_IMG_WIDTH - Constants.FOOTER_MENU_BUTTON_WIDTH) / 2;
		double btnXR = imgXR + (Constants.FOOTER_MENU_BUTTON_IMG_WIDTH - Constants.FOOTER_MENU_BUTTON_WIDTH) / 2;
		Button btn = ComponentFactory.GetEmptyButton(
			new Thickness(
				isLeftAligned ? btnX : btnXR,
				FOOTER_AREA_TOP + Constants.FOOTER_LINE_HEIGHT,
				isLeftAligned ? btnXR : btnX,
				0
			),
			Constants.FOOTER_MENU_BUTTON_WIDTH,
			Constants.FOOTER_MENU_BUTTON_HEIGHT
		);

		Label label = ComponentFactory.GetBasicLabel();
		label.HorizontalContentAlignment = HorizontalAlignment.Center;
		label.VerticalContentAlignment = VerticalAlignment.Center;
		label.Height = Constants.FOOTER_MENU_BUTTON_HEIGHT;
		label.Width = Constants.FOOTER_MENU_BUTTON_WIDTH;
		label.FontSize = Constants.FONT_SIZE_FOOTER;
		label.Content = labelStr;
		btn.Content = label;
		btn.IsEnabled = isEnabled;
#if DEBUG
		if (!isEnabled)
		{
			label.Foreground = Brushes.Gray;
		}
#endif

		if (addToChildren)
		{
			Children.Add(btn);
		}

		return (btnImg, btn);
	}

	public void SetPageIndex(int index)
	{
		if (index < 0 || maxPageIndex < index)
			return;
		currentPageIndex = index;
		PageChanged?.Invoke(this, currentPageIndex);

		if (goNextPageButton is null || goPrevPageButton0 is null || goPrevPageButton1 is null)
			return;

		Children.Remove(goPrevPageButton0.Value.Item1);
		Children.Remove(goPrevPageButton0.Value.Item2);
		Children.Remove(goPrevPageButton1.Value.Item1);
		Children.Remove(goPrevPageButton1.Value.Item2);
		Children.Remove(goNextPageButton.Value.Item1);
		Children.Remove(goNextPageButton.Value.Item2);

		if (currentPageIndex != maxPageIndex)
		{
			Children.Add(goNextPageButton.Value.Item1);
			Children.Add(goNextPageButton.Value.Item2);
		}
		if (currentPageIndex != 0)
		{
			if (currentPageIndex == maxPageIndex)
			{
				Children.Add(goPrevPageButton0.Value.Item1);
				Children.Add(goPrevPageButton0.Value.Item2);
			}
			else
			{
				Children.Add(goPrevPageButton1.Value.Item1);
				Children.Add(goPrevPageButton1.Value.Item2);
			}
		}
	}
}
