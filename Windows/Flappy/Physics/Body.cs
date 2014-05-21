using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flappy.Physics
{
    public class Body
    {
        public float InitialTime { get; set; }
        public Vector2 InitialPosition { get; set; }
        public Vector2 InitialVelocity { get; set; }

        public Vector2 Position(GameTime time)
        {
            float t = (float)time.TotalGameTime.TotalSeconds - InitialTime;
            return InitialPosition + t * InitialVelocity;
        }
    }
}
