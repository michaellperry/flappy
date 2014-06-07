using Flappy.Logic.Sprites;
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
        private const float SegmentWidth = 55.0f;
        private const float SegmentHeight = 25.0f;
        private const float SegmentHorizontalCenter = SegmentWidth / 2.0f;
        private const float SegmentVerticalCenter = SegmentHeight / 2.0f;
        private static readonly Vector2 Origin = new Vector2(SegmentHorizontalCenter, SegmentVerticalCenter);
        private const int GapSize = 7;

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
            int gapEnd = gapStart + GapSize;

            int segmentCount = (int)Math.Ceiling(bounds.Height / SegmentHeight);
            for (int segmentIndex = 0; segmentIndex < gapStart; ++segmentIndex)
            {
                DrawSegment(spriteBatch, camera, segmentIndex, _segment);
            }
            DrawSegment(spriteBatch, camera, gapStart, _capBottom);
            DrawSegment(spriteBatch, camera, gapEnd, _capTop);
            for (int segmentIndex = gapEnd + 1; segmentIndex < segmentCount; ++segmentIndex)
            {
                DrawSegment(spriteBatch, camera, segmentIndex, _segment);
            }
        }

        private static void DrawSegment(
            SpriteBatch spriteBatch,
            Camera camera,
            int segmentIndex,
            Texture2D image)
        {
            Vector2 position = new Vector2(800.0f,
                SegmentVerticalCenter + segmentIndex * SegmentHeight);

            spriteBatch.Draw(image,
                position: position - camera.Position,
                origin: Origin);
        }
    }
}
