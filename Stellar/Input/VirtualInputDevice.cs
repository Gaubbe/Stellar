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

        public bool Dash { get; set; }
        public VirtualInputDevice(InputHandler ih)
        {
            _ih = ih;

            if (_ih.activeGamepadType == GamepadType.NONE)
                _ih.MapControllerButtons(GamepadType.XBOX_360);

            Stellar.Instance.Log(_ih.activeGamepadType);

            AddControl(GameManager.instance.gameSettings.controllerMapping.dash, "Dash");
            AddControl(GameManager.instance.gameSettings.controllerMapping.attack, "Attack");
            AddControl(GameManager.instance.gameSettings.controllerMapping.cast, "Cast");
            AddControl(GameManager.instance.gameSettings.controllerMapping.dreamNail, "Dream Nail");
            AddControl(GameManager.instance.gameSettings.controllerMapping.jump, "Jump");
            AddControl(GameManager.instance.gameSettings.controllerMapping.quickCast, "Quick Cast");
            AddControl(GameManager.instance.gameSettings.controllerMapping.quickMap, "Quick Map");
            AddControl(GameManager.instance.gameSettings.controllerMapping.superDash, "Super Dash");
        }

        public override void Update(ulong updateTick, float deltaTime)
        {
            GetControl(GameManager.instance.gameSettings.controllerMapping.dash).UpdateWithState(Dash, updateTick, deltaTime);

            Commit(updateTick, deltaTime);
        }
    }
}
