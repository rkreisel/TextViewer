﻿using System.Text;
using System.Text.RegularExpressions;

namespace TextViewer.Utilities;

public static class Utils
{
    public static void CheckForNull(this object o, string paramName)
    {
        if (o == null)
        {
            throw new ArgumentNullException(paramName);
        }
    }

    public static bool IsNumeric(this string source) =>
        int.TryParse(source, out _);

    public static bool HasProperty(this object obj, string propertyName)
    {
        obj.CheckForNull(nameof(obj));
        return obj.GetType().GetProperty(propertyName) != null;
    }

    public static string EnsureFinalChar(this string source, char finalChar)
    {
        if (source.EndsWith(finalChar))
            return source;
        else
            return $"{source}{finalChar}";

    }
    public static string EnsureDoesNotEndWith(this string source, char finalChar)
    {
        if (source.EndsWith(finalChar))
            return source[0..^1];
        else
            return source;

    }

    public static string RemoveSpecialCharacters(this string str)
    {
        return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        //StringBuilder sb = new StringBuilder();
        //foreach (char c in str)
        //{
        //    if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
        //    {
        //        sb.Append(c);
        //    }
        //}
        //return sb.ToString();
    }
}
