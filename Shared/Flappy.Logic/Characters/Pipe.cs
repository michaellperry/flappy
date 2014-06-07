﻿using Flappy.Logic.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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

        private readonly int _gapStart;
        private readonly float _location;
        private readonly PipeResources _resources;

        public Pipe(int gapStart, float location, PipeResources resources)
        {
            _gapStart = gapStart;
            _location = location;
            _resources = resources;
        }

        public static int GetSegmentCount(Rectangle bounds)
        {
            return (int)Math.Ceiling(bounds.Height / SegmentHeight);
        }

        public float Location
        {
            get { return _location; }
        }

        public bool CollidesWith(Vector2 position)
        {
            return position.X > _location;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            int gapEnd = _gapStart + GapSize;

            int segmentCount = GetSegmentCount(camera.Bounds);
            for (int segmentIndex = 0; segmentIndex < _gapStart; ++segmentIndex)
            {
                DrawSegment(spriteBatch, camera, segmentIndex, _resources.Segment);
            }
            DrawSegment(spriteBatch, camera, _gapStart, _resources.CapBottom);
            DrawSegment(spriteBatch, camera, gapEnd, _resources.CapTop);
            for (int segmentIndex = gapEnd + 1; segmentIndex < segmentCount; ++segmentIndex)
            {
                DrawSegment(spriteBatch, camera, segmentIndex, _resources.Segment);
            }
        }

        private void DrawSegment(
            SpriteBatch spriteBatch,
            Camera camera,
            int segmentIndex,
            Texture2D image)
        {
            Vector2 position = new Vector2(_location,
                SegmentVerticalCenter + segmentIndex * SegmentHeight);

            spriteBatch.Draw(image,
                position: position - camera.Position,
                origin: Origin);
        }
    }
}
