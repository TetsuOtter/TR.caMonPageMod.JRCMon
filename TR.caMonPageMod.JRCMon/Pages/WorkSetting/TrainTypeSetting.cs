namespace TR.caMonPageMod.JRCMon.Pages.Other;

[PageTypes.NormalPage("種別", ResourceManager.ResourceFiles.WorkSettingIcon)]
public partial class TrainTypeSetting : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public TrainTypeSetting() : base(ResourceManager.ResourceFiles.TrainTypeSetting)
	{
	}
}
