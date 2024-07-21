namespace TR.caMonPageMod.JRCMon.PageTypes;

[AttributeUsage(AttributeTargets.Class)]
internal class NormalPageAttribute(
	string pageName,
	ResourceManager.ResourceFiles iconImage
) : Attribute()
{
	public readonly string PageName = pageName;
	public readonly ResourceManager.ResourceFiles IconImage = iconImage;
}
