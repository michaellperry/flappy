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

        public void Reset()
        {
            _pipes.Clear();
        }

        public void Update(Rectangle window)
        {
            var lastPipe = _pipes.LastOrDefault();
            if (lastPipe == null || lastPipe.Location < window.Right - 200)
            {
                _pipes.Add(new Pipe(5, window.Right + 100, _pipeResources));
            }

            var firstPipe = _pipes.FirstOrDefault();
            if (firstPipe != null && firstPipe.Location < window.Left - 100)
            {
                _pipes.Remove(firstPipe);
            }
        }

        public bool CollidesWith(Vector2 position, float radius)
        {
            return _pipes.Any(p => p.CollidesWith(position, radius));
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (var pipe in _pipes)
                pipe.Draw(spriteBatch, camera);
        }
    }
}
