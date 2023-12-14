namespace TextViewer.Utilities;
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

    public static void SetRCInTitle(this Form form, string title, RichTextBox rtb)
    {
        form.CheckForNull(nameof(form));
        rtb.CheckForNull(nameof(rtb));
        var lc = rtb.RowColumn();
        form.Text = $"{title} ({lc.X},{lc.Y})";
    }

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
    public static void OpenLink<T>(this T rtb, LinkClickedEventArgs e) where T : RichTextBox
#pragma warning restore IDE0060 // Remove unused parameter
    {
        if (e == null || string.IsNullOrWhiteSpace(e.LinkText))
            return;
        System.Diagnostics.Process.Start(e.LinkText);
    }

}