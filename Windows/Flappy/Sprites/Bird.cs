using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace Flappy.Sprites
{
    public class Bird : Sprite
    {
        public Bird(ContentManager content) :
            base(content.Load<Texture2D>("Bird"))
        {
        }
    }
}
