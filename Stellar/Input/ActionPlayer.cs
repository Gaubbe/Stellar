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

        private List<ActionEvent> actions;

        public bool Playing { get; set; }

        public ActionPlayer(VirtualInputDevice vid)
        {
            _vid = vid;
            _pft = new PhysicsFrameTimer();

            actions = new List<ActionEvent>();
        }

        public void AddAction(ActionEvent action)
        {
            actions.Add(action);
        }

        public void AddAction(ActionType type, int frameStart, int frameEnd)
        {
            ActionEvent pressed = new ActionEvent()
            {
                ActionType = type,
                ActionState = ActionState.PRESSED,
                Frame = frameStart
            };

            ActionEvent unpressed = new ActionEvent()
            {
                ActionType = type,
                ActionState = ActionState.UNPRESSED,
                Frame = frameEnd
            };

            actions.Add(pressed);
            actions.Add(unpressed);
        }

        public void AddAction(ActionType type, ActionState state, int frame)
        {
            ActionEvent action = new ActionEvent()
            {
                ActionType = type,
                ActionState = state,
                Frame = frame
            };

            actions.Add(action);
        }

        public void AddSingleFrameAction(ActionType type, int frame)
        {
            ActionEvent pressed = new ActionEvent()
            {
                ActionType = type,
                ActionState = ActionState.PRESSED,
                Frame = frame
            };

            ActionEvent unpressed = new ActionEvent()
            {
                ActionType = type,
                ActionState = ActionState.UNPRESSED,
                Frame = frame + 1
            };

            actions.Add(pressed);
            actions.Add(unpressed);
        }

        public void OnPhysicsFrame()
        {
            if (Playing)
            {
                foreach (var a in actions)
                {
                    if(a.Frame == _pft.FrameCount)
                    {
                        if(a.ActionState == ActionState.PRESSED)
                        {
                            _vid.SetStateFromActionType(a.ActionType, true);
                        }
                        else
                        {
                            _vid.SetStateFromActionType(a.ActionType, false);
                        }
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
