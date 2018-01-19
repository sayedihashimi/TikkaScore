using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TikkaIos.Data
{
    [Table("GameScore")]
    public class GameScore
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        [ForeignKey(typeof(Game))]        
        public int GameId { get; set; }
        [ManyToOne]
        public Game Game { get; set; }
        [Column("scoreIndex")]
        public int ScoreIndex { get; set; }
        [Column("bidTeamA")]
        public int BidTeamA { get; set; }
        [Column("wonTeamA")]
        public int WonTeamA { get; set; }
        [Column("bidTeamB")]
        public int BidTeamB { get; set; }
        [Column("wonTeamB")]
        public int WonTeamB { get; set; }
    }
}