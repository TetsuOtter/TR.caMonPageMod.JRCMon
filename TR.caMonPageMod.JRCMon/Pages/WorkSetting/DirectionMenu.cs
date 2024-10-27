namespace TR.caMonPageMod.JRCMon.Pages.Other;

[PageTypes.NormalPage("行先メニュ", ResourceManager.ResourceFiles.WorkSettingIcon)]
public partial class DirectionMenu : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public DirectionMenu() : base(ResourceManager.ResourceFiles.DirectionMenu)
	{
	}
}
