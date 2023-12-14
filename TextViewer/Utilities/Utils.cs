namespace TextViewer.Utilities;

/// <summary>
/// A class containing miscellaneous extension methods.
/// </summary>
public static class Utils
{
    /// <summary>
    /// Checks an object for being null. Note that this can be replaced with ArgumentNUllExpcetipn.ThrowIfNull
    /// </summary>
    /// <param name="o">The object.</param>
    /// <param name="paramName">The Name of the object.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void CheckForNull(this object o, string paramName)
    {
        if (o == null)
        {
            throw new ArgumentNullException(paramName);
        }
    }

    /// <summary>
    /// Evaluates a string as being an valid integer.
    /// </summary>
    /// <param name="source">A string</param>
    /// <returns>True or False</returns>
    public static bool IsNumeric(this string source) =>
        int.TryParse(source, out _);

    /// <summary>
    /// Uses Reflection to determine if an object contains the given property.
    /// </summary>
    /// <param name="obj">An instance of an object.</param>
    /// <param name="propertyName">The name of the property to find.</param>
    /// <returns>True or False</returns>
    public static bool HasProperty(this object obj, string propertyName)
    {
        obj.CheckForNull(nameof(obj));
        return obj.GetType().GetProperty(propertyName) != null;
    }

    /// <summary>
    /// Add the specified character to the end of a string if it is not already there.
    /// </summary>
    /// <param name="source">A string</param>
    /// <param name="finalChar">The character to evaluate.</param>
    /// <returns>A string with one instance of the specified character.</returns>
    public static string EnsureFinalChar(this string source, char finalChar)
    {
        if (source.EndsWith(finalChar))
            return source;
        else
            return $"{source}{finalChar}";

    }

    /// <summary>
    /// Removes the specified character from the string if it is teh last character.
    /// </summary>
    /// <param name="source">A string</param>
    /// <param name="finalChar">The character to remoove.</param>
    /// <returns>A string where the last character is NOT athe speficied one.</returns>
    public static string EnsureDoesNotEndWith(this string source, char finalChar)
    {
        if (source.EndsWith(finalChar))
            return source[0..^1];
        else
            return source;

    }

    /// <summary>
    /// Eliminates all special characters from a string. This is useful when a 'safe' string is needed. For instance to build a filename.
    /// </summary>
    /// <param name="str">A string</param>
    /// <returns>A string with only alphanumeric characters.</returns>
    public static string RemoveSpecialCharacters(this string str)
    {
        return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
    }
}
