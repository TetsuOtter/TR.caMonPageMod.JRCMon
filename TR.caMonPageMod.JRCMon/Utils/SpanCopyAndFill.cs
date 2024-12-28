namespace TR.caMonPageMod.JRCMon.Utils;

public static partial class Util
{
	public static void CopyAndFill<T>(this ReadOnlySpan<T> src, Span<T> dest)
	{
		for (int i = 0; i < dest.Length; i += src.Length)
			src.CopyTo(dest[i..]);
	}
	public static void CopyAndFill<T>(this Span<T> src, Span<T> dest)
	{
		for (int i = 0; i < dest.Length; i += src.Length)
			src.CopyTo(dest[i..]);
	}
}
