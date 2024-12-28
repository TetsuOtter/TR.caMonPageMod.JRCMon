namespace TR.caMonPageMod.JRCMon.PageTypes;

[AttributeUsage(AttributeTargets.Class)]
internal class FooterPageNameAttribute(
	string footerPageName
) : Attribute
{
	public readonly string FooterPageName = footerPageName;
}
