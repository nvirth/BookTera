package com.booktera;

public class Utils {

	public static String join(String glue, String... s) {
		if (s == null)
			return null;
        if (s.length == 0)
			return "";

		StringBuilder out = new StringBuilder();
		out.append(s[0]);
		for (int x = 1; x < s.length; ++x) {
			out.append(glue).append(s[x]);
		}
		return out.toString();
	}
}
