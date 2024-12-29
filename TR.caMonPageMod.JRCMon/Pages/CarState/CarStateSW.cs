using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon.Pages.CarState;

[PageTypes.NormalPage("運転詳細", ResourceManager.ResourceFiles.MaintenanceIcon, "ｽｲｯﾁ状態")]
public partial class CarStateSW : NormalPageBase, IMultiPageFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CAR_STATE;

	public int SelectedIndex { get; set; } = 0;

	public int MaxIndex { get; } = 2;

	public CarStateSW() : base(ResourceManager.ResourceFiles.CarStateSW)
	{
		Children.Add(new LocationLabel());
	}
}
