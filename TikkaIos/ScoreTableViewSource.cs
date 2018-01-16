using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TikkaIos
{
    public class ScoreTableViewSource : UITableViewSource
    {
        string CellIdentifier = "ScoreTableViewCell";

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            //string item = TableItems[indexPath.Row];

            ////---- if there are no cells to reuse, create a new one
            //if (cell == null)
            //{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

            //cell.TextLabel.Text = item;

            //return cell;

            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            cell.TextLabel.Text = $"index: {indexPath.Row}";

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 2;
        }
    }
}