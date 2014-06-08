using Flappy.Logic.Characters;
using Flappy.Logic.Controls;
using Flappy.Logic.Sprites;
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

        private readonly IControls _controls;
        private State _state;
        private Viewer _viewer;
        private Bird _bird;
        private PipeCollection _pipeCollection;
        private Sprite _getReadySprite;
        private Sprite _instructionsSprite;
        private Sprite _gameOverSprite;

        public World(IControls controls)
        {
            _controls = controls;

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

            _state = _start;
            _viewer = new Viewer();
            _bird = new Bird(controls);
            _pipeCollection = new PipeCollection();
        }

        public void LoadContent(ContentManager content)
        {
            _bird.LoadContent(content);
            _pipeCollection.LoadContent(content);

            _getReadySprite = new Sprite(content, "GetReady")
            {
                Origin = new Vector2(102.0f, 26.0f)
            };
            _instructionsSprite = new Sprite(content, "Instructions")
            {
                Origin = new Vector2(88.0f, 70.0f)
            };
            _gameOverSprite = new Sprite(content, "GameOver")
            {
                Origin = new Vector2(110.0f, 23.0f)
            };
        }

        public void SetBounds(Rectangle bounds)
        {
            _viewer.Camera.Bounds = bounds;

            _getReadySprite.Position = new Vector2(
                bounds.Left * 0.5f + bounds.Right * 0.5f,
                bounds.Top * 0.7f + bounds.Bottom * 0.3f);
            _instructionsSprite.Position = new Vector2(
                bounds.Left * 0.5f + bounds.Right * 0.5f,
                bounds.Top * 0.5f + bounds.Bottom * 0.5f);
            _gameOverSprite.Position = new Vector2(
                bounds.Left * 0.5f + bounds.Right * 0.5f,
                bounds.Top * 0.5f + bounds.Bottom * 0.5f);
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
            HandleStart(gameTime);
        }

        private void StartDraw(SpriteBatch spriteBatch)
        {
            DrawGameObjects(spriteBatch);
            _getReadySprite.Draw(spriteBatch);
            _instructionsSprite.Draw(spriteBatch);
        }

        private void AliveUpdate(GameTime gameTime)
        {
            _viewer.Update(gameTime);
            _bird.AliveUpdate(gameTime);
            _pipeCollection.Update(_viewer.Camera.Window);

            HandleHitGround();
            HandleHitPipes(gameTime);
        }

        private void AliveDraw(SpriteBatch spriteBatch)
        {
            DrawGameObjects(spriteBatch);
        }

        private void DeadUpdate(GameTime gameTime)
        {
            _bird.DeadUpdate(gameTime);

            HandleHitGround();
        }

        private void DeadDraw(SpriteBatch spriteBatch)
        {
            DrawGameObjects(spriteBatch);
            _gameOverSprite.Draw(spriteBatch);
        }

        private void GameOverUpdate(GameTime gameTime)
        {
            HandleStart(gameTime);
        }

        private void GameOverDraw(SpriteBatch spriteBatch)
        {
            DrawGameObjects(spriteBatch);
            _gameOverSprite.Draw(spriteBatch);
        }

        private void HandleStart(GameTime gameTime)
        {
            if (_controls.ReadFlap())
            {
                _viewer.Reset(gameTime);
                _bird.Reset(gameTime);
                _pipeCollection.Reset();
                _state = _alive;
            }
        }

        private void HandleHitGround()
        {
            if (_bird.Position.Y + Bird.Radius > _viewer.Camera.Bounds.Bottom)
            {
                _state = _gameOver;
            }
        }

        private void HandleHitPipes(GameTime gameTime)
        {
            if (_pipeCollection.CollidesWith(_bird.Position, Bird.Radius))
            {
                _bird.Die(gameTime);
                _state = _dead;
            }
        }

        private void DrawGameObjects(SpriteBatch spriteBatch)
        {
            _pipeCollection.Draw(spriteBatch, _viewer.Camera);
            _bird.Draw(spriteBatch, _viewer.Camera);
        }
    }
}
