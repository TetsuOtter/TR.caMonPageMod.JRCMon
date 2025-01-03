using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Header;
using TR.caMonPageMod.JRCMon.PageTypes;

namespace TR.caMonPageMod.JRCMon;

public class RootGrid : Grid
{
	public event EventHandler? BackToHome;
	public event EventHandler? CloseApp;

	private readonly AppState State;

	private readonly HeaderArea HeaderArea;
	public RootGrid()
	{
		State = new();
		HeaderArea = new(State);

		Height = Constants.DISPLAY_HEIGHT;
		Width = Constants.DISPLAY_WIDTH;
		Background = Brushes.Black;

		RowDefinitions.Add(new RowDefinition { Height = new GridLength(Constants.HEADER_HEIGHT) });
		RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
		RowDefinitions.Add(new RowDefinition { Height = new GridLength(Constants.FOOTER_HEIGHT) });

		SetPageType<Pages.SystemControl.MenuPage>();
	}

	Type lastPageType = typeof(Pages.SystemControl.MenuPage);
	public Type CurrentPageType { get; private set; } = typeof(Pages.SystemControl.MenuPage);
	public void SetPageType<T>(params object[] args) where T : FrameworkElement
		=> SetPageTypeWithArgs(typeof(T), args);
	public void SetPageTypeWithArgs<T>(object[] args) where T : FrameworkElement
		=> SetPageTypeWithArgs(typeof(T), args);

	public void SetPageType(Type pageType, params object[] args)
		=> SetPageTypeWithArgs(pageType, args);
	public void SetPageTypeWithArgs(Type pageType, object[] args)
	{
		Children.Clear();

		FrameworkElement cc = CreateElement(pageType, args) as FrameworkElement ?? throw new InvalidOperationException("Invalid Page Type");
		cc.Width = Constants.DISPLAY_WIDTH;

		bool hasFooter = false;
		if (cc is IFooterInfo footerInfo)
		{
			hasFooter = true;
			FooterArea footerArea;
			if (cc is IMultiPageFooterInfo multiPageFooterInfo)
			{
				footerArea = new(
					this,
					footerInfo.FooterInfoList,
					pageType,
					lastPageType,
					multiPageFooterInfo.MaxIndex
				);
				footerArea.SetPageIndex(multiPageFooterInfo.SelectedIndex);
				footerArea.PageChanged += (sender, e) =>
				{
					multiPageFooterInfo.SelectedIndex = e;
				};
			}
			else
			{
				footerArea = new(
					this,
					footerInfo.FooterInfoList,
					pageType,
					lastPageType
				);
			}
			SetRow(footerArea, 2);
			Children.Add(footerArea);

			if (!footerInfo.FooterInfoList.Contains(new FooterInfoGoBack()))
			{
				lastPageType = pageType;
			}
		}
		else
		{
			lastPageType = pageType;
		}
		CurrentPageType = pageType;

		if (pageType.GetCustomAttribute<FullScreenPageAttribute>() is not null)
		{
			SetRowSpan(cc, hasFooter ? 2 : 3);
			cc.Height = Constants.DISPLAY_HEIGHT - (hasFooter ? Constants.FOOTER_HEIGHT : 0);
			Children.Add(cc);
		}
		else if (pageType.GetCustomAttribute<NormalPageAttribute>() is NormalPageAttribute pageAttribute)
		{
			SetRow(HeaderArea, 0);
			SetRow(cc, 1);
			if (!hasFooter)
			{
				SetRowSpan(cc, 2);
			}
			cc.Height = Constants.BODY_HEIGHT + (hasFooter ? 0 : Constants.FOOTER_HEIGHT);
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
		if (cc is IHeaderOverride headerOverride)
		{
			HeaderArea.OnChangePage(new(headerOverride.HeaderTitle, headerOverride.HeaderIcon));
		}
	}
	object? CreateElement(Type pageType)
	{
		if (pageType.GetConstructor([typeof(AppState)]) is ConstructorInfo ctorWithState)
		{
			return ctorWithState.Invoke([State]);
		}
		else if (pageType.GetConstructor(Type.EmptyTypes) is ConstructorInfo defaultCtor)
		{
			return defaultCtor.Invoke(null);
		}
		else
		{
			throw new InvalidOperationException("Invalid Page Type");
		}
	}
	object? CreateElement(Type pageType, object[] args)
	{
		if (args.Length == 0)
		{
			return CreateElement(pageType);
		}

		Type[] argTypeArray = args.Select(a => a.GetType()).ToArray();
		if (pageType.GetConstructor([typeof(AppState), .. argTypeArray]) is ConstructorInfo ctorWithState)
		{
			return ctorWithState.Invoke([State, .. args]);
		}
		else if (pageType.GetConstructor(argTypeArray) is ConstructorInfo defaultCtor)
		{
			return defaultCtor.Invoke(args);
		}
		else
		{
			throw new InvalidOperationException("Invalid Page Type");
		}
	}

	public void BackToHomeInvoke() => BackToHome?.Invoke(this, EventArgs.Empty);
	public void CloseAppInvoke() => CloseApp?.Invoke(this, EventArgs.Empty);
}
