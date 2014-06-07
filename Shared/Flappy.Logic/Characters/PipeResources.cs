using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Flappy.Logic.Characters
{
    public class PipeResources
    {
        public Texture2D _capTop;
        public Texture2D _capBottom;
        public Texture2D _segment;

        public void LoadContent(ContentManager contentManager)
        {
            _capTop = contentManager.Load<Texture2D>("CapTop");
            _capBottom = contentManager.Load<Texture2D>("CapBottom");
            _segment = contentManager.Load<Texture2D>("Segment");
        }

        public Texture2D CapTop
        {
            get { return _capTop; }
        }

        public Texture2D CapBottom
        {
            get { return _capBottom; }
        }

        public Texture2D Segment
        {
            get { return _segment; }
        }
    }
}
