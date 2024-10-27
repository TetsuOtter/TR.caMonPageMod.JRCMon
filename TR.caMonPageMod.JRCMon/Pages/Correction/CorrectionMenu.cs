namespace TR.caMonPageMod.JRCMon.Pages.Correction;

[PageTypes.NormalPage("補正メニュ", ResourceManager.ResourceFiles.CorrectionIcon)]
public partial class CorrectionMenu : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public CorrectionMenu() : base(ResourceManager.ResourceFiles.CorrectionMenu)
	{
	}
}
