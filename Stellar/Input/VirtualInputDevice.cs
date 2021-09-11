using GlobalEnums;
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
        public InputControl inventoryControl;

        public VirtualInputDevice(InputHandler ih)
        {
            _ih = ih;

            if (_ih.activeGamepadType == GamepadType.NONE)
            {
                _ih.MapControllerButtons(GamepadType.XBOX_360);
                _ih.activeGamepadType = GamepadType.XBOX_360;
            }

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


            switch (_ih.activeGamepadType)
            {
                case GamepadType.XBOX_360:
                    inventoryControl = AddControl(InputControlType.Back, "Inventory");
                    break;
                case GamepadType.PS4:
                    inventoryControl = AddControl(InputControlType.TouchPadButton, "Inventory");
                    break;
                case GamepadType.XBOX_ONE:
                    inventoryControl = AddControl(InputControlType.View, "Inventory");
                    break;
                default:
                    inventoryControl = AddControl(InputControlType.Select, "Inventory");
                    break;
            }

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

        public void SetStateFromActionType(ActionType actionType, bool state)
        {
            switch (actionType)
            {
                case ActionType.LEFT:
                    Left = state;
                    break;

                case ActionType.RIGHT:
                    Right = state;
                    break;

                case ActionType.UP:
                    Up = state;
                    break;

                case ActionType.DOWN:
                    Down = state;
                    break;

                case ActionType.ATTACK:
                    Attack = state;
                    break;

                case ActionType.CAST:
                    Cast = state;
                    break;

                case ActionType.QUICK_CAST:
                    QuickCast = state;
                    break;

                case ActionType.DASH:
                    Dash = state;
                    break;

                case ActionType.SUPER_DASH:
                    SuperDash = state;
                    break;

                case ActionType.DREAM_NAIL:
                    DreamNail = state;
                    break;

                case ActionType.JUMP:
                    Jump = state;
                    break;

                case ActionType.INVENTORY:
                    Inventory = state;
                    break;
            }
        }

        public void ResetState()
        {
            foreach(ActionType a in Enum.GetValues(typeof(ActionType)))
            {
                SetStateFromActionType(a, false);
            }
        }
    }
}
