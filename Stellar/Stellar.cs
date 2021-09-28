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

            ap.AddAction(ActionType.JUMP, 0, 7);
            ap.AddAction(ActionType.LEFT, 0, 99);
            ap.AddAction(ActionType.JUMP, 67, 110);
            ap.AddSingleFrameAction(ActionType.RIGHT, 99);
            ap.AddSingleFrameAction(ActionType.QUICK_CAST, 100);
            ap.AddSingleFrameAction(ActionType.QUICK_CAST, 121);
            //ap.AddAction(ActionType.LEFT, 160, 200);

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
            }

            orig(self);
        }
    }
}
