namespace TR.caMonPageMod.JRCMon.PageTypes;

[AttributeUsage(AttributeTargets.Class)]
internal class FullScreenPageAttribute(string footerPageName = "") : FooterPageNameAttribute(footerPageName)
{
}
