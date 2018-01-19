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
        private ScoreTableViewController Owner;

        public ScoreTableViewSource(ScoreTableViewController owner) : base()
        {
            Owner = owner;
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
                    var cell = tableView.DequeueReusableCell(ScoreTableViewController.TeamNameCellId, indexPath);
                    return cell;
                }
                else if(row == 2)
                {
                    var cell = tableView.DequeueReusableCell("bidReceiveCell", indexPath);
                    cell.UserInteractionEnabled = false;
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
                cell.SetValues(currentItem);
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

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // UIAlertController okAlertController = UIAlertController.Create("Row Selected", $"section={indexPath.Section} row={indexPath.Row}", UIAlertControllerStyle.Alert);
            // okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            // Owner.PresentViewController (okAlertController, true, null);
            // tableView.DeselectRow(indexPath, true);
            ScoreTableViewCell cell = tableView.CellAt(indexPath) as ScoreTableViewCell;
            if(cell != null)
            {
                cell.SetHiddenForDetailsButton(false);
            }
        }
        public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
        {
            ScoreTableViewCell cell = tableView.CellAt(indexPath) as ScoreTableViewCell;
            if (cell != null)
            {
                cell.SetHiddenForDetailsButton(true);
            }
        }
        /*
public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
{
    UIAlertController okAlertController = UIAlertController.Create ("Row Selected", tableItems[indexPath.Row], UIAlertControllerStyle.Alert);
    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
    ...

    tableView.DeselectRow (indexPath, true);
}
         */
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