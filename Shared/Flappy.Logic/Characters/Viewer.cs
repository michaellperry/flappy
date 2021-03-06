﻿using Flappy.Logic.Physics;
using Flappy.Logic.Sprites;
using Microsoft.Xna.Framework;

namespace Flappy.Logic.Characters
{
    public class Viewer
    {
        private Camera _camera;
        private Body _cameraBody;

        public Viewer()
        {
            _camera = new Camera();
            _cameraBody = new Body();
            _cameraBody.ChangeVelocity(new GameTime(), new Vector2(300.0f, 0.0f));
        }

        public Camera Camera
        {
            get { return _camera; }
        }

        public void Reset(GameTime gameTime)
        {
            _cameraBody.InitialTime = (float)gameTime.TotalGameTime.TotalSeconds;
        }

        public void Update(GameTime gameTime)
        {
            _camera.Position = _cameraBody.Position(gameTime);
        }
    }
}
