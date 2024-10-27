using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages.Other;

[PageTypes.FullScreenPage]
public partial class CarDetectSimple : FullScreenPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public CarDetectSimple() : base(ResourceManager.ResourceFiles.CarDetect_1)
	{
	}
}
