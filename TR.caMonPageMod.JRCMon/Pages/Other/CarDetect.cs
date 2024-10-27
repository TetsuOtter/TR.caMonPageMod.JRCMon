using System.Windows.Controls;

namespace TR.caMonPageMod.JRCMon.Pages.Other;

[PageTypes.FullScreenPage]
public partial class CarDetect : FullScreenPageBase, IHoldRootGridInstance
{
	public RootGrid? RootGrid { get; set; }

	public CarDetect() : base(ResourceManager.ResourceFiles.CarDetect)
	{
	}
}
