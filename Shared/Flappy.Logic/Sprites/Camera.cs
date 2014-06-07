using Microsoft.Xna.Framework;

namespace Flappy.Logic.Sprites
{
    public class Camera
    {
        private Vector2 _position = Vector2.Zero;
        private Rectangle _bounds;
        
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Rectangle Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        public Rectangle Window
        {
            get
            {
                return new Rectangle(
                    _bounds.X + (int)_position.X,
                    _bounds.Y + (int)_position.Y,
                    _bounds.Width,
                    _bounds.Height);
            }
        }
    }
}
