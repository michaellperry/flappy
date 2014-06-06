using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flappy.Sprites
{
    public class Sprite
    {
        private Texture2D _texture;

        public Sprite(ContentManager content, string name)
        {
            _texture = content.Load<Texture2D>(name);
            Position = Vector2.Zero;
            Origin = Vector2.Zero;
        }

        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public float Rotation { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,
                position: Position,
                rotation: Rotation,
                origin: Origin);
        }
    }
}
