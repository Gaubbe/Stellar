using System;
using System.Collections.Generic;
using System.Text;

namespace Stellar.Input
{
    public struct TimedAction
    {
        public ActionType ActionType { get; set; }
        public int FrameStart { get; set; }
        public int FrameEnd { get; set; }
    }
}
