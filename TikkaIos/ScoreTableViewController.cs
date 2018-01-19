using Foundation;
using System;
using TikkaIos.Data;
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
            TableView.Source = new ScoreTableViewSource(this);

            try
            {
                var gameDb = new GameDatabase(DatabaseConsts.GetDbPath());
                gameDb.InsertDummyDataIfNotExists();
            }
            catch(Exception ex)
            {
                string msg = ex.ToString();
                System.Console.WriteLine(msg);
            }
        }
    }
}