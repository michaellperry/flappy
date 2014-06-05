using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flappy.Logic.Controls
{
    public class TouchControls
    {
        public bool Flap
        {
            get
            {
                return TouchPanel.GetState().Any(touch =>
                    touch.State == TouchLocationState.Pressed);
            }
        }
    }
}
