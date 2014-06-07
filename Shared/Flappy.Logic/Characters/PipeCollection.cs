using Flappy.Logic.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Flappy.Logic.Characters
{
    public class PipeCollection
    {
        private PipeResources _pipeResources;
        private List<Pipe> _pipes = new List<Pipe>();

        public PipeCollection()
        {
            _pipeResources = new PipeResources();
        }

        public void LoadContent(ContentManager content)
        {
            _pipeResources.LoadContent(content);
        }

        public void Update(Rectangle window)
        {
            var lastPipe = _pipes.LastOrDefault();
            if (lastPipe == null || lastPipe.Location + 200 < window.Right)
            {
                _pipes.Add(new Pipe(5, window.Right + 100.0f, _pipeResources));
            }

            var firstPipe = _pipes.FirstOrDefault();
            if (firstPipe != null && firstPipe.Location < -100.0f + window.Left)
            {
                _pipes.Remove(firstPipe);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (var pipe in _pipes)
                pipe.Draw(spriteBatch, camera);
        }
    }
}
