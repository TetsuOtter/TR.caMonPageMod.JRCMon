namespace TR.caMonPageMod.JRCMon.Pages.Other;

[PageTypes.NormalPage("行先設定", ResourceManager.ResourceFiles.WorkSettingIcon)]
public partial class DirectionSetting : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public DirectionSetting() : base(ResourceManager.ResourceFiles.DirectionSetting_1)
	{
	}
}
