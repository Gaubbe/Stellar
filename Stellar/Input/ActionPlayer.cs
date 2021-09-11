using Stellar.Timer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stellar.Input
{
    public class ActionPlayer
    {
        private readonly VirtualInputDevice _vid;
        private readonly PhysicsFrameTimer _pft;

        private List<TimedAction> actions;

        public bool Playing { get; set; }

        public ActionPlayer(VirtualInputDevice vid)
        {
            _vid = vid;
            _pft = new PhysicsFrameTimer();

            actions = new List<TimedAction>();
        }

        public void AddAction(TimedAction action)
        {
            // Eventually, the list is going to have to be sorted so it's more efficient
            actions.Add(action);
        }

        public void OnPhysicsFrame()
        {
            if (Playing)
            {
                foreach (var a in actions)
                {
                    if (a.FrameStart <= _pft.FrameCount && a.FrameEnd >= _pft.FrameCount)
                    {
                        _vid.SetStateFromActionType(a.ActionType, true);
                    }
                    else
                    {
                        _vid.SetStateFromActionType(a.ActionType, false);
                    }
                }

                _pft.OnPhysicsFrame();
            }
        }

        public void Reset()
        {
            _pft.Reset();
            _vid.ResetState();
            Playing = false;
        }
    }
}
