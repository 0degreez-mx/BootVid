using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootVid
{
    public static class GamepadInputHandler
    {
        public static bool IsButtonPressed(Controller controller, GamepadButtonFlags button)
        {
            if (controller == null || !controller.IsConnected)
            {
                return false;
            }

            // Obtener el estado del control
            var state = controller.GetState();
            return (state.Gamepad.Buttons & button) == button;
        }
    }
}
