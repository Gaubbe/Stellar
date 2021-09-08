﻿using GlobalEnums;
using InControl;
using Modding;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stellar.Input
{
    public class VirtualInputDevice : InputDevice
    {
        private readonly InputHandler _ih;

        public bool Left { get; set; }
        private InputControl leftControl;
        public bool Right { get; set; }
        private InputControl rightControl;
        public bool Up { get; set; }
        private InputControl upControl;
        public bool Down { get; set; }
        private InputControl downControl;
        public bool Attack { get; set; }
        private InputControl attackControl;
        public bool Cast { get; set; }
        private InputControl castControl;
        public bool QuickCast { get; set; }
        private InputControl quickCastControl;
        public bool Dash { get; set; }
        private InputControl dashControl;
        public bool SuperDash { get; set; }
        private InputControl superDashControl;
        public bool DreamNail { get; set; }
        private InputControl dreamNailControl;
        public bool Jump { get; set; }
        private InputControl jumpControl;
        public bool Inventory { get; set; }
        private InputControl inventoryControl;

        public VirtualInputDevice(InputHandler ih)
        {
            _ih = ih;

            if (_ih.activeGamepadType == GamepadType.NONE)
                _ih.MapControllerButtons(GamepadType.XBOX_360);

            leftControl = AddControl(InputControlType.DPadLeft, "Left");
            rightControl = AddControl(InputControlType.DPadRight, "Right");
            upControl = AddControl(InputControlType.DPadUp, "Up");
            downControl = AddControl(InputControlType.DPadDown, "Down");

            attackControl = AddControl(GameManager.instance.gameSettings.controllerMapping.attack, "Attack");
            castControl = AddControl(GameManager.instance.gameSettings.controllerMapping.cast, "Cast");
            quickCastControl = AddControl(GameManager.instance.gameSettings.controllerMapping.quickCast, "Quick Cast");
            dashControl = AddControl(GameManager.instance.gameSettings.controllerMapping.dash, "Dash");
            superDashControl = AddControl(GameManager.instance.gameSettings.controllerMapping.superDash, "Super Dash");
            dreamNailControl = AddControl(GameManager.instance.gameSettings.controllerMapping.dreamNail, "Dream Nail");
            jumpControl = AddControl(GameManager.instance.gameSettings.controllerMapping.jump, "Jump");
            inventoryControl = AddControl(GameManager.instance.gameSettings.controllerMapping.quickMap, "Inventory");
        }

        public override void Update(ulong updateTick, float deltaTime)
        {
            leftControl.UpdateWithState(Left, updateTick, deltaTime);
            rightControl.UpdateWithState(Right, updateTick, deltaTime);
            upControl.UpdateWithState(Up, updateTick, deltaTime);
            downControl.UpdateWithState(Down, updateTick, deltaTime);

            attackControl.UpdateWithState(Attack, updateTick, deltaTime);
            castControl.UpdateWithState(Cast, updateTick, deltaTime);
            quickCastControl.UpdateWithState(QuickCast, updateTick, deltaTime);
            dashControl.UpdateWithState(Dash, updateTick, deltaTime);
            superDashControl.UpdateWithState(SuperDash, updateTick, deltaTime);
            dreamNailControl.UpdateWithState(DreamNail, updateTick, deltaTime);
            jumpControl.UpdateWithState(Jump, updateTick, deltaTime);
            inventoryControl.UpdateWithState(Inventory, updateTick, deltaTime);

            Commit(updateTick, deltaTime);
        }
    }
}
