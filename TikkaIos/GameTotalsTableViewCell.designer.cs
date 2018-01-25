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
    [Register ("GameTotalsTableViewCell")]
    partial class GameTotalsTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelTeamAWonTotal { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelTeamBWonTotal { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (labelTeamAWonTotal != null) {
                labelTeamAWonTotal.Dispose ();
                labelTeamAWonTotal = null;
            }

            if (labelTeamBWonTotal != null) {
                labelTeamBWonTotal.Dispose ();
                labelTeamBWonTotal = null;
            }
        }
    }
}