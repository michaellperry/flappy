using Flappy.Logic.Characters;
using Flappy.Logic.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Flappy.Logic
{
    public class World
    {
        private Viewer _viewer;
        private Bird _bird;
        private PipeCollection _pipeCollection;

        public World(IControls controls)
        {
            _viewer = new Viewer();
            _bird = new Bird(controls);
            _pipeCollection = new PipeCollection();
        }

        public void LoadContent(ContentManager content)
        {
            _bird.LoadContent(content);
            _pipeCollection.LoadContent(content);
        }

        public void SetBounds(Rectangle bounds)
        {
            _viewer.Camera.Bounds = bounds;
        }

        public void Update(GameTime gameTime)
        {
            _viewer.Update(gameTime);
            _bird.Update(gameTime);
            _pipeCollection.Update(_viewer.Camera.Window);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _pipeCollection.Draw(spriteBatch, _viewer.Camera);
            _bird.Draw(spriteBatch, _viewer.Camera);
        }
    }
}
