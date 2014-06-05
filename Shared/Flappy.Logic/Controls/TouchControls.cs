using Microsoft.Xna.Framework.Input.Touch;
using System.Linq;

namespace Flappy.Logic.Controls
{
    public class TouchControls : IControls
    {
        public bool ReadFlap()
        {
            return TouchPanel.GetState().Any(touch =>
                touch.State == TouchLocationState.Pressed);
        }
    }
}
