namespace TR.caMonPageMod.JRCMon.Pages.Correction;

[PageTypes.NormalPage("時刻", ResourceManager.ResourceFiles.CorrectionIcon)]
public partial class ClockCorrection : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public ClockCorrection() : base(ResourceManager.ResourceFiles.ClockCorrection)
	{
	}
}
