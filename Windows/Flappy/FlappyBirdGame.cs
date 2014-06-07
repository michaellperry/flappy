using Flappy.Logic.Characters;
using Flappy.Logic.Controls;
using Flappy.Logic.Physics;
using Flappy.Logic.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Flappy
{
    public class FlappyBirdGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Viewer _viewer;
        private Bird _bird;
        private PipeResources _pipeResources;
        private List<Pipe> _pipes = new List<Pipe>();

        private float _setting;

        public FlappyBirdGame()
            : base()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _viewer = new Viewer();
            _bird = new Bird(new KeyboardControls());
            _pipeResources = new PipeResources();
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _bird.LoadContent(Content);
            _pipeResources.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                    ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _viewer.Update(gameTime);
            _bird.Update(gameTime);

            Rectangle bounds = GraphicsDevice.PresentationParameters.Bounds;

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Rectangle bounds = GraphicsDevice.PresentationParameters.Bounds;

            _spriteBatch.Begin();
            foreach (var pipe in _pipes)
                pipe.Draw(_spriteBatch, bounds, _viewer.Camera);
            _bird.Draw(_spriteBatch, _viewer.Camera);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void AdjustSetting()
        {
            var mousePosition = Mouse.GetState().Position;
            float setting = 5.0f * mousePosition.Y;
            if (setting != _setting)
            {
                _setting = setting;
                _bird.AdjustSetting(_setting);
                Debug.WriteLine(String.Format("Initial velocity: {0}", _setting));
            }
        }
    }
}
