using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flappy.Sprites
{
    public class Camera
    {
        public Camera()
        {
            Position = Vector2.Zero;
        }

        public Vector2 Position { get; set; }
    }
}
