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
        private float timer = 0.0f;
        private float actionStartTime = 0.0f;
        private float actionEndTime = 0.0f;

        public Stellar() : base("Stellar") 
        {
        }

        public override void Initialize()
        {
            Instance = this;

            vid = new VirtualInputDevice(GameManager.instance.inputHandler);

            InputManager.AttachDevice(vid);

            On.HeroController.Update += HeroUpdateHook;
        }

        private void HeroUpdateHook(On.HeroController.orig_Update orig, HeroController self)
        {
            timer += Time.deltaTime;

            if(timer >= actionEndTime)
            {
                vid.Dash = false;
                if (UnityEngine.Input.GetKey(KeyCode.P))
                {
                    actionStartTime = timer;
                    actionEndTime = timer + 1.0f;
                    vid.Dash = true;
                }
            }
            
            orig(self);
        }
    }
}
