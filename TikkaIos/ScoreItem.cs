using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TikkaIos
{
    public class ScoreItem
    {
        public int Index { get; set; }
        public int Bid { get; set; }
        public int Received { get; set; }

        public static List<ScoreItem> GetTestData(int numItems = 5)
        {
            List<ScoreItem> items = new List<ScoreItem>();

            if(numItems <= 0)
            {
                numItems = 5;
            }

            for(int i = 0; i < numItems; i++)
            {
                items.Add(new ScoreItem
                {
                    Index = i,
                    Bid = 1,
                    Received = 2
                });
            }

            return items;
        }
    }
}