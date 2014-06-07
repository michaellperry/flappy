using Flappy.Logic.Characters;
using Flappy.Logic.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Flappy.Logic
{
    public class World
    {
        private Viewer _viewer;
        private Bird _bird;
        private PipeResources _pipeResources;
        private List<Pipe> _pipes = new List<Pipe>();

        public World(IControls controls)
        {
            _viewer = new Viewer();
            _bird = new Bird(controls);
            _pipeResources = new PipeResources();
        }

        public void LoadContent(ContentManager content)
        {
            _bird.LoadContent(content);
            _pipeResources.LoadContent(content);
        }

        public void Update(GraphicsDevice graphicsDevice, GameTime gameTime)
        {
            _viewer.Update(gameTime);
            _bird.Update(gameTime);

            Rectangle bounds = graphicsDevice.PresentationParameters.Bounds;

            var lastPipe = _pipes.LastOrDefault();
            if (lastPipe == null || lastPipe.Location - _viewer.Camera.Position.X + 200 < bounds.Right)
            {
                _pipes.Add(new Pipe(5, bounds.Right + _viewer.Camera.Position.X + 100.0f, _pipeResources));
            }

            var firstPipe = _pipes.FirstOrDefault();
            if (firstPipe != null && firstPipe.Location - _viewer.Camera.Position.X < -100.0f)
            {
                _pipes.Remove(firstPipe);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            Rectangle bounds = graphicsDevice.PresentationParameters.Bounds;

            foreach (var pipe in _pipes)
                pipe.Draw(spriteBatch, bounds, _viewer.Camera);
            _bird.Draw(spriteBatch, _viewer.Camera);
        }
    }
}
