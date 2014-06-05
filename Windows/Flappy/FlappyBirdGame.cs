using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Flappy.Sprites;
using Flappy.Physics;
using System.Diagnostics;
using Flappy.Logic.Controls;
using Flappy.Logic.Characters;

namespace Flappy
{
    public class FlappyBirdGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Bird _bird;

        private float _setting;

        public FlappyBirdGame()
            : base()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _bird = new Bird();
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _bird.Draw(_spriteBatch);
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
