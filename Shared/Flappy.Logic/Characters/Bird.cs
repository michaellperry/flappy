using Flappy.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flappy.Sprites;
using Flappy.Logic.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Flappy.Logic.Characters
{
    public class Bird
    {
        private Body _body;
        private Sprite _sprite;
        private IControls _controls;

        public Bird()
        {
            _body = new Body()
            {
                InitialTime = 0.0f,
                InitialPosition = new Vector2(400.0f, 200.0f),
                InitialVelocity = new Vector2(0.0f, 0.0f),
                Acceleration = new Vector2(0.0f, 810.0f)
            };
            _controls = new KeyboardControls();
        }

        public void LoadContent(ContentManager contentManager)
        {
            _sprite = new Sprite(contentManager, "Bird");
        }

        public void Update(GameTime gameTime)
        {
            if (_controls.ReadFlap())
            {
                _body.ChangeVelocity(gameTime, new Vector2(0.0f, -400.0f));
            }

            _sprite.Position = _body.Position(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }

        public void AdjustSetting(float setting1)
        {
            _body.InitialVelocity = new Vector2(setting1, -600.0f);
        }
    }
}
