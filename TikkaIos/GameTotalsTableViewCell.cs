using Foundation;
using System;
using TikkaIos.Data;
using UIKit;

namespace TikkaIos
{
    public partial class GameTotalsTableViewCell : UITableViewCell
    {
        public GameTotalsTableViewCell (IntPtr handle) : base (handle)
        {
        }

        public void UpdateValues(Game game)
        {
            if(game != null)
            {
                int teamATotal = 0;
                int teamBTotal = 0;
                foreach(var score in game.Scores)
                {
                    teamATotal += score.WonTeamA;
                    teamBTotal += score.WonTeamB;
                }
                labelTeamAWonTotal.Text = teamATotal.ToString();
                labelTeamBWonTotal.Text = teamBTotal.ToString();
            }
        }
    }
}