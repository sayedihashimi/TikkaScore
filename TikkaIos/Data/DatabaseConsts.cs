using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Foundation;
using UIKit;

namespace TikkaIos.Data
{
    public static class DatabaseConsts
    {
        public const string GameTableName = "Game";
        public const string GameScoreTableName = "GameScore";
        public const int MaxLengthTeamName = 100;

        public static string GetDbPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"tikkascorev01.db3");
        }
    }
}