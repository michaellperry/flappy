﻿using Flappy.Logic.Characters;
using Flappy.Logic.Controls;
using Flappy.Physics;
using Flappy.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Flappy
{
    public class FlappyBirdGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Camera _camera;
        private Body _cameraBody;
        private Bird _bird;

        private float _setting;

        public FlappyBirdGame()
            : base()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _camera = new Camera();
            _cameraBody = new Body();
            _cameraBody.ChangeVelocity(new GameTime(), new Vector2(300.0f, 0.0f));
            _bird = new Bird(new KeyboardControls());
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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                    ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _bird.Update(gameTime);
            _camera.Position = _cameraBody.Position(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _bird.Draw(_spriteBatch, _camera);
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
