namespace TR.caMonPageMod.JRCMon.Pages.Correction;

[PageTypes.NormalPage("地点補正", ResourceManager.ResourceFiles.CorrectionIcon)]
public partial class LocationCorrectionPage : NormalPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public LocationCorrectionPage() : base(ResourceManager.ResourceFiles.LocationCorrection_1)
	{
	}
}
