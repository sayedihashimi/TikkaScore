using Foundation;
using System;
using UIKit;

namespace TikkaIos
{
    public partial class ScoreTableViewController : UITableViewController
    {
        public static string BidReceiveCellId = "bidReceiveCell";
        public static string TeamNameCellId = "teamNameCell";
        
        public ScoreTableViewController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(ScoreTableViewCell), ScoreTableViewSource.CellIdentifier);
            TableView.RegisterClassForCellReuse(typeof(BidReceiveTableViewCell), BidReceiveCellId);
            TableView.RegisterClassForCellReuse(typeof(TeamNameTableViewCell), TeamNameCellId);
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // table = new UITableView(View.Bounds); // defaults to Plain style
            TableView.Source = new ScoreTableViewSource(this);
            // Add(table);
        }
    }
}