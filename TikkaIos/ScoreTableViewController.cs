using Foundation;
using System;
using UIKit;

namespace TikkaIos
{
    public partial class ScoreTableViewController : UITableViewController
    {

        public ScoreTableViewController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(ScoreTableViewCell), ScoreTableViewSource.CellIdentifier);
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // table = new UITableView(View.Bounds); // defaults to Plain style
            TableView.Source = new ScoreTableViewSource();
            // Add(table);
        }
    }
}