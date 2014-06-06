using Microsoft.Xna.Framework;

namespace Flappy.Logic.Physics
{
    public class Body
    {
        public float InitialTime { get; set; }
        public Vector2 InitialPosition { get; set; }
        public Vector2 InitialVelocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public Vector2 Position(GameTime time)
        {
            float t = (float)time.TotalGameTime.TotalSeconds - InitialTime;
            return
                InitialPosition +
                t * InitialVelocity +
                t * t * 0.5f * Acceleration;
        }

        public Vector2 Velocity(GameTime time)
        {
            float t = (float)time.TotalGameTime.TotalSeconds - InitialTime;
            return
                InitialVelocity +
                t * Acceleration;
        }

        public void ChangeVelocity(GameTime gameTime, Vector2 newVelocity)
        {
            InitialPosition = Position(gameTime);
            InitialVelocity = newVelocity;
            InitialTime = (float)gameTime.TotalGameTime.TotalSeconds;
        }
    }
}
