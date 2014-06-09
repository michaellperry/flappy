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
        private readonly Texture2D _texture;
        private readonly double _paralax;
        
        public Strip(ContentManager content, string name, double paralax)
        {
            _texture = content.Load<Texture2D>(name);
            _paralax = paralax;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            int offset = (int)(_paralax * camera.Position.X);
            int top = camera.Bounds.Bottom - _texture.Height;
            int firstSegment = offset / _texture.Width;
            int lastSegment = firstSegment + camera.Bounds.Width / _texture.Width + 2;
            for (int segmentIndex = firstSegment; segmentIndex < lastSegment; segmentIndex++)
            {
                int x =
                    camera.Bounds.Left - offset +
                    segmentIndex * _texture.Width;
                spriteBatch.Draw(_texture,
                    position: new Vector2(x, top));
            }
        }
    }
}
