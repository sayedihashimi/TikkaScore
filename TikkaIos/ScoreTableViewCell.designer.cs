// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TikkaIos
{
    [Register ("ScoreTableViewCell")]
    partial class ScoreTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelBidA { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelBidB { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelReceivedA { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelReceivedB { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelRound { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton scoreDetailsButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (labelBidA != null) {
                labelBidA.Dispose ();
                labelBidA = null;
            }

            if (labelBidB != null) {
                labelBidB.Dispose ();
                labelBidB = null;
            }

            if (labelReceivedA != null) {
                labelReceivedA.Dispose ();
                labelReceivedA = null;
            }

            if (labelReceivedB != null) {
                labelReceivedB.Dispose ();
                labelReceivedB = null;
            }

            if (labelRound != null) {
                labelRound.Dispose ();
                labelRound = null;
            }

            if (scoreDetailsButton != null) {
                scoreDetailsButton.Dispose ();
                scoreDetailsButton = null;
            }
        }
    }
}