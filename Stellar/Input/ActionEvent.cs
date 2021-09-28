using System;
using System.Collections.Generic;
using System.Text;

namespace Stellar.Input
{

    public class ActionEvent
    {
        public ActionType ActionType { get; set; }
        public ActionState ActionState { get; set; }
        public int Frame { get; set; }
    }
}
