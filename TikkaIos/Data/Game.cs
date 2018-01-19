using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite;
using SQLitePCL;
using SQLiteNetExtensions.Attributes;

namespace TikkaIos.Data
{
    [Table("Game")]
    public class Game
    {
        public const int IdNotSavedInDb = int.MinValue;
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; } = IdNotSavedInDb;
        private DatabaseValueCleaner valueCleaner = new DatabaseValueCleaner();

        private string _teamAName;
        [Column("teamNameA"), MaxLength(DatabaseConsts.MaxLengthTeamName)]
        public string TeamAName {
            get => _teamAName;
            set => _teamAName = valueCleaner.GetStringWithMaxLength(value, DatabaseConsts.MaxLengthTeamName);
        }

        private string _teamBName;
        [Column("teamNameB"), MaxLength(DatabaseConsts.MaxLengthTeamName)]
        public string TeamBName {
            get => _teamBName;
            set => _teamBName = valueCleaner.GetStringWithMaxLength(value, DatabaseConsts.MaxLengthTeamName);
        }

        [Column("startDate")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<GameScore> Scores { get; set; } = new List<GameScore>();
    }
}