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
            if(section == 0)
            {
                if (row == 0)
                {
                    var titleCell = tableView.DequeueReusableCell("titleCell", indexPath);
                    if (titleCell == null)
                    {
                        titleCell = new UITableViewCell();
                    }

                    titleCell.TextLabel.Text = "Tikka Score";
                    titleCell.UserInteractionEnabled = false;
                    return titleCell;
                }
                else if(row == 1)
                {
                    var cell = new UITableViewCell();
                    cell.TextLabel.Text = "Team A              Team B";
                    return cell;
                }
                else if(row == 2)
                {
                    var cell = new UITableViewCell();
                    cell.TextLabel.Text = "Bid     Received     Bid Receive";
                    return cell;
                }
                else
                {
                    throw new IndexOutOfRangeException($"title row:[{row}] is invalid");
                }
            }
            if (section == 1)
            {
                var cell = tableView.DequeueReusableCell(ScoreTableViewSource.CellIdentifier, indexPath) as ScoreTableViewCell;
        
                var currentItem = items.ElementAt(indexPath.Row);
                cell.SetValues(indexPath.Row, 100 + indexPath.Row, 200 + indexPath.Row, 300 + indexPath.Row, 400 + indexPath.Row);
                // cell.TextLabel.Text = $"index: {currentItem.Index}, bid={currentItem.Bid}, recvd={currentItem.Received}";

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
            if(section == 0)
            {
                return 3;
            }
            else if(section == 1)
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