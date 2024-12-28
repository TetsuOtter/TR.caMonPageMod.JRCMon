namespace TR.caMonPageMod.JRCMon.PageTypes;

[AttributeUsage(AttributeTargets.Class)]
internal class NormalPageAttribute(
	string pageName,
	ResourceManager.ResourceFiles iconImage,
	string? footerPageName = null
) : FooterPageNameAttribute(footerPageName ?? pageName)
{
	public readonly string PageName = pageName;
	public readonly ResourceManager.ResourceFiles IconImage = iconImage;
}
