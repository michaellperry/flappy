﻿using Flappy.Logic.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flappy.Logic.Characters
{
    public class Pipe
    {
        private static readonly Vector2 Origin = new Vector2(27.0f, 12.0f);

        private Texture2D _capTop;
        private Texture2D _capBottom;
        private Texture2D _segment;

        public void LoadContent(ContentManager contentManager)
        {
            _capTop = contentManager.Load<Texture2D>("CapTop");
            _capBottom = contentManager.Load<Texture2D>("CapBottom");
            _segment = contentManager.Load<Texture2D>("Segment");
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle bounds, Camera camera)
        {
            int gapStart = 5;
            int gapEnd = 12;

            int segmentCount = (int)Math.Ceiling(bounds.Height / 25.0f);
            for (int segmentIndex = 0; segmentIndex < segmentCount; ++segmentIndex)
            {
                if (gapStart < segmentIndex && segmentIndex < gapEnd)
                    continue;

                Vector2 position = new Vector2(800.0f, 12.0f + segmentIndex * 25.0f);

                Texture2D image;
                if (segmentIndex == gapStart)
                    image = _capBottom;
                else if (segmentIndex == gapEnd)
                    image = _capTop;
                else
                    image = _segment;
                spriteBatch.Draw(image,
                    position: position - camera.Position,
                    origin: Origin);
            }
        }
    }
}
