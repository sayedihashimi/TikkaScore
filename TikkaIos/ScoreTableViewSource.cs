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
        public static string CellIdentifier = "ScoreTableViewCell";
        List<ScoreItem> items = new List<ScoreItem>();

        public ScoreTableViewSource() : base()
        {
            items = ScoreItem.GetTestData(10);
        }


        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath) as ScoreTableViewCell;
            cell.TextLabel.Text = $"index: {indexPath.Row}";

            var currentItem = items.ElementAt(indexPath.Row);
            cell.TextLabel.Text = $"index: {currentItem.Index}, bid={currentItem.Bid}, recvd={currentItem.Received}";

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return items.Count;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return "Tikka Score";
        }
    }
}