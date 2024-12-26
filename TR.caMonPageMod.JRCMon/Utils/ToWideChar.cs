namespace TR.caMonPageMod.JRCMon.Utils;

public static partial class Util
{
	public static string ToWide(this string str)
	{
		char[] result = str.ToCharArray();
		for (int i = 0; i < result.Length; ++i)
		{
			result[i] += result[i] switch
			{
				>= '!' and <= '~' => (char)0xFEE0,
				' ' => (char)0x2FE0,
				_ => (char)0,
			};
		}
		return new(result);
	}
}
