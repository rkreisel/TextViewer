namespace TextViewer.Utilities;

/// <summary>
/// A class containing utilities for workign with Rich Text Files.
/// </summary>
public static class RTFUtils
{
    /// <summary>
    /// Searches a RichTextBox for the given text.
    /// Note that the Silent parameter should only be used in unit tests.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="rtb"></param>
    /// <param name="searchText"></param>
    public static void SearchRTF<T>(this T rtb, string searchText) where T : RichTextBox
    {
        rtb.CheckForNull(nameof(rtb));

        if (string.IsNullOrEmpty(searchText))
        {
            MessageBox.Show("Please enter search text", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        rtb.SelectionBackColor = Color.White;
        int searchStart;
        var rc = rtb.RowColumn();
        if (rc.X == 0 && rc.Y == 0)
        {
            searchStart = rtb.SelectionLength > 0 ? rtb.SelectionLength : 0;
        }
        else
        {
            searchStart = rtb.SelectionStart == 0 ? 0 : ++rtb.SelectionStart;
        }
        var location = rtb.Find(searchText, searchStart, RichTextBoxFinds.None);
        if (location >= 0)
        {
            rtb.SelectionBackColor = Color.Yellow;
            rtb.Select(location, searchText.Length);
            rtb.ScrollToCaret();
        }
        else
        {
            if (MessageBox.Show($"The text {searchText} was not found.\r\n\r\nStart again from the top?", "Not Found",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                rtb.SelectionStart = 0;
                rtb.Select(0, 0);
                rtb.SearchRTF(searchText);
            }
        }
    }

    /// <summary>
    /// Get the row and column of the first selected character.
    /// </summary>
    /// <typeparam name="T">Must be a RichTextBox</typeparam>
    /// <param name="rtb">An instance of a RichTextBox</param>
    /// <returns></returns>
    public static Point RowColumn<T>(this T rtb) where T : RichTextBox
    {
        rtb.CheckForNull(nameof(rtb));
        // Get the line.
        int index = rtb.SelectionStart;
        int line = rtb.GetLineFromCharIndex(index);

        // Get the column.
        int firstChar = rtb.GetFirstCharIndexFromLine(line);
        int column = index - firstChar;
        return new Point(line, column);
    }

    /// <summary>
    /// Sets the row and column in the title of the window
    /// </summary>
    /// <param name="form">Must be a Form object.</param>
    /// <param name="title">The title to set.</param>
    /// <param name="rtb">The RichTextBox from which to extact the selected text.</param>
    public static void SetRCInTitle(this Form form, string title, RichTextBox rtb)
    {
        form.CheckForNull(nameof(form));
        rtb.CheckForNull(nameof(rtb));
        var lc = rtb.RowColumn();
        form.Text = $"{title} ({lc.X},{lc.Y})";
    }

    /// <summary>
    /// Handle for setting the cursor in a RichTextBox
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="rtb"></param>
    /// <param name="e"><cref>MouseEventArgs</cref></param>
    public static void SetCursor<T>(this T rtb, MouseEventArgs e) where T : RichTextBox
    {
        rtb.CheckForNull(nameof(rtb));
        e.CheckForNull(nameof(e));

        //Fixes bug wherein content selected with the mouse is unselected when the mouse button is released
        if (rtb.SelectedText.Length > 0)
            return;

        rtb.SelectionStart = rtb.GetCharIndexFromPosition(new Point(e.X, e.Y));
        rtb.SelectionLength = 0;
    }

#pragma warning disable IDE0060 // Remove unused parameter
    /// <summary>
    /// Opens a URL in the default browser.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="rtb"></param>
    /// <param name="e"></param>
    public static void OpenLink<T>(this T rtb, LinkClickedEventArgs e) where T : RichTextBox
#pragma warning restore IDE0060 // Remove unused parameter
    {
        if (e == null || string.IsNullOrWhiteSpace(e.LinkText))
            return;
        System.Diagnostics.Process.Start(e.LinkText);
    }

}