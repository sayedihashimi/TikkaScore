using Foundation;
using System;
using UIKit;

namespace TikkaIos
{
    public partial class ScoreTableViewCell : UITableViewCell
    {
        public ScoreTableViewCell (IntPtr handle) : base (handle)
        {
        }
        public void SetValues(int round, int bidA, int receivedA, int bidB, int receivedB)
        {
            labelRound.Text = round.ToString();
            labelBidA.Text = bidA.ToString();
            labelReceivedA.Text = receivedA.ToString();
            labelBidB.Text = bidB.ToString();
            labelReceivedB.Text = receivedB.ToString();
        }
        public void SetValues(ScoreItem score)
        {
            labelRound.Text = score.Index.ToString();
            labelBidA.Text = score.BidTeamA.ToString();
            labelReceivedA.Text = score.WonTeamA.ToString();
            labelBidB.Text = score.BidTeamB.ToString();
            labelReceivedB.Text = score.WonTeamB.ToString();
        }
        public void SetHiddenForDetailsButton(bool hidden)
        {
            this.scoreDetailsButton.Hidden = hidden;
        }
    }
}