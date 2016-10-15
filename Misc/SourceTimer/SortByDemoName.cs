using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SourceLiveTimer
{
	internal class SortByDemoName : IComparer
	{
		private Regex _regex = new Regex("_(\\d+)\\.dem");

		public SortByDemoName()
		{
		}

		public int Compare(object a, object b)
		{
			ListViewItem listViewItem = a as ListViewItem;
			ListViewItem listViewItem1 = b as ListViewItem;
			if (listViewItem == null || listViewItem1 == null)
			{
				return 0;
			}
			string text = listViewItem.SubItems[0].Text;
			string str = listViewItem1.SubItems[0].Text;
			Match match = this._regex.Match(text);
			Match match1 = this._regex.Match(str);
			if (!match.Success || !match1.Success)
			{
				if (text == "-- TOTAL --")
				{
					return 1;
				}
				return text.CompareTo(str);
			}
			return int.Parse(match.Groups[1].Value) - int.Parse(match1.Groups[1].Value);
		}
	}
}