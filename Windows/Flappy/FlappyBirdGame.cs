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

namespace Flappy
{
    public class FlappyBirdGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Body _birdBody;
        private Sprite _birdSprite;

        private float _setting;

        public FlappyBirdGame()
            : base()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _birdBody = new Body()
            {
                InitialTime = 0.0f,
                InitialPosition = new Vector2(0.0f, 200.0f),
                InitialVelocity = new Vector2(435.0f, -600.0f),
                Gravity = new Vector2(0.0f, 810.0f)
            };
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _birdSprite = new Sprite(Content, "Bird");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                    ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _birdBody.InitialTime = (float)gameTime.TotalGameTime.TotalSeconds;

            //AdjustSetting();
            _birdSprite.Position = _birdBody.Position(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _birdSprite.Draw(_spriteBatch);
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
                _birdBody.InitialVelocity = new Vector2(_setting, -600.0f);
                Debug.WriteLine(String.Format("Initial velocity: {0}", _setting));
            }
        }
    }
}
