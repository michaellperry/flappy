using Flappy.Logic.Characters;
using Flappy.Logic.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Flappy.Logic
{
    public class World
    {
        private delegate void UpdateDelegate(GameTime gameTime);
        private delegate void DrawDelegate(SpriteBatch spriteBatch);

        class State
        {
            public UpdateDelegate Update;
            public DrawDelegate Draw;
        };

        private readonly State _start;
        private readonly State _alive;
        private readonly State _dead;
        private readonly State _gameOver;

        private State _state;
        private Viewer _viewer;
        private Bird _bird;
        private PipeCollection _pipeCollection;

        public World(IControls controls)
        {
            _start = new State
            {
                Update = StartUpdate,
                Draw = StartDraw
            };
            _alive = new State
            {
                Update = AliveUpdate,
                Draw = AliveDraw
            };
            _dead = new State
            {
                Update = DeadUpdate,
                Draw = DeadDraw
            };
            _gameOver = new State
            {
                Update = GameOverUpdate,
                Draw = GameOverDraw
            };

            _state = _alive;
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
            _state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _state.Draw(spriteBatch);
        }

        private void StartUpdate(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        private void StartDraw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        private void AliveUpdate(GameTime gameTime)
        {
            _viewer.Update(gameTime);
            _bird.AliveUpdate(gameTime);
            _pipeCollection.Update(_viewer.Camera.Window);

            if (_pipeCollection.CollidesWith(_bird.Position))
            {
                _bird.Die(gameTime);
                _state = _dead;
            }
        }

        private void AliveDraw(SpriteBatch spriteBatch)
        {
            DrawGameObjects(spriteBatch);
        }

        private void DeadUpdate(GameTime gameTime)
        {
            _bird.DeadUpdate(gameTime);
        }

        private void DeadDraw(SpriteBatch spriteBatch)
        {
            DrawGameObjects(spriteBatch);
        }

        private void GameOverUpdate(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        private void GameOverDraw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        private void DrawGameObjects(SpriteBatch spriteBatch)
        {
            _pipeCollection.Draw(spriteBatch, _viewer.Camera);
            _bird.Draw(spriteBatch, _viewer.Camera);
        }
    }
}
