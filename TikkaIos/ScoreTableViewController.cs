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
        public static string TotalsCellId = "GameTotalsCell";
        
        public ScoreTableViewController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(ScoreTableViewCell), ScoreTableViewSource.CellIdentifier);
            TableView.RegisterClassForCellReuse(typeof(BidReceiveTableViewCell), BidReceiveCellId);
            TableView.RegisterClassForCellReuse(typeof(TeamNameTableViewCell), TeamNameCellId);
            TableView.RegisterClassForCellReuse(typeof(GameTotalsTableViewCell), TotalsCellId);

            
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Game game = new GameDatabase(DatabaseConsts.GetDbPath()).GetLastGame();

            TableView.SeparatorColor = UIColor.Red;
            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLineEtched;

            TableView.Source = new ScoreTableViewSource(this, game);

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