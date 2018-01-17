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
            int section = indexPath.Section;
            int row = indexPath.Row;
            if(section == 0 && row == 0)
            {
                var titleCell = tableView.DequeueReusableCell("titleCell", indexPath);
                if(titleCell == null)
                {
                    titleCell = new UITableViewCell();
                }

                titleCell.TextLabel.Text = "Tikka Score";
                titleCell.UserInteractionEnabled = false;
                return titleCell;
            }
            if (section == 1)
            {
                var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath) as ScoreTableViewCell;
                cell.TextLabel.Text = $"index: {indexPath.Row}";

                var currentItem = items.ElementAt(indexPath.Row);
                cell.TextLabel.Text = $"index: {currentItem.Index}, bid={currentItem.Bid}, recvd={currentItem.Received}";

                return cell;
            }
            else
            {
                // TODO
                return new UITableViewCell();
            }
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if(section == 1)
            {
                return items.Count;
            }
            else
            {
                return 1;
            }
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 4;
        }
        //public override string[] SectionIndexTitles(UITableView tableView)
        //{
        //    return new string [] { "One","Two","Three","Four" };
        //}

        //public override string TitleForHeader(UITableView tableView, nint section)
        //{
        //    if(section == 1)
        //    {
        //        return "Score";
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}