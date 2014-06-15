using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flappy.Logic.Sprites
{
    public class Sprite
    {
        private Texture2D[] _texture;

        public Sprite(ContentManager content, params string[] names)
        {
            _texture = names
                .Select(name => content.Load<Texture2D>(name))
                .ToArray();
            Position = Vector2.Zero;
            Origin = Vector2.Zero;
        }

        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public float Rotation { get; set; }
        public int ImageIndex { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture[ImageIndex],
                position: Position,
                rotation: Rotation,
                origin: Origin);
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Draw(_texture[ImageIndex],
                position: Position - camera.Position,
                rotation: Rotation,
                origin: Origin);
        }
    }
}
