namespace TR.caMonPageMod.JRCMon.Footer;

public interface IFooterInfo
{
	IReadOnlyList<FooterInfo> FooterInfoList { get; }
}

public interface IMultiPageFooterInfo : IFooterInfo
{
	/// <summary>
	/// 選択中のページインデックス (0から始まる)
	/// </summary>
	int SelectedIndex { get; set; }
	int MaxIndex { get; }
}
