using InControl;
using Modding;
using Stellar.Input;
using System;
using System.IO;
using UnityEngine;

namespace Stellar
{
    public class Stellar : Mod
    {
        internal static Stellar Instance;

        VirtualInputDevice vid;
        ActionPlayer ap;

        public Stellar() : base("Stellar") 
        {
        }

        public override void Initialize()
        {
            Instance = this;

            vid = new VirtualInputDevice(GameManager.instance.inputHandler);
            ap = new ActionPlayer(vid);

            var jump = new TimedAction()
            {
                ActionType = ActionType.JUMP,
                FrameStart = 0,
                FrameEnd = 50
            };

            var down = new TimedAction()
            {
                ActionType = ActionType.DOWN,
                FrameStart = 1,
                FrameEnd = 2
            };

            var attack = new TimedAction() 
            {
                ActionType = ActionType.ATTACK,
                FrameStart = 1,
                FrameEnd = 2
            };

            ap.AddAction(jump);
            ap.AddAction(down);
            ap.AddAction(attack);

            InputManager.AttachDevice(vid);

            On.HeroController.Update += HeroUpdateHook;
            On.HeroController.FixedUpdate += HeroFixedUpdateHook;
        }

        private void HeroFixedUpdateHook(On.HeroController.orig_FixedUpdate orig, HeroController self)
        {
            ap.OnPhysicsFrame();

            orig(self);
        }

        private void HeroUpdateHook(On.HeroController.orig_Update orig, HeroController self)
        {
            if (UnityEngine.Input.GetKey(KeyCode.P))
            {
                ap.Playing = true;
            }

            if (UnityEngine.Input.GetKey(KeyCode.O))
            {
                ap.Reset();
                Log("Reset!");
            }

            orig(self);
        }
    }
}
