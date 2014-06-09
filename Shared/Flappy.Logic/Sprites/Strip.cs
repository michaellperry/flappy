using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Flappy.Logic.Sprites
{
    public class Strip
    {
        private Texture2D _texture;

        public Strip(ContentManager content, string name)
        {
            _texture = content.Load<Texture2D>(name);
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            int top = camera.Bounds.Bottom - _texture.Height;
            int segmentCount = camera.Bounds.Width / _texture.Width + 1;
            for (int segmentIndex = 0; segmentIndex < segmentCount; segmentIndex++ )
            {
                int x = camera.Bounds.Left + segmentIndex * _texture.Width;
                spriteBatch.Draw(_texture,
                    position: new Vector2(x, top));
            }
        }
    }
}
