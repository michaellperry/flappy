using Microsoft.Xna.Framework.Input;

namespace Flappy.Logic.Controls
{
    public class KeyboardControls : IControls
    {
        private bool _priorSpaceState;

        public bool ReadFlap()
        {
            bool spaceState = Keyboard.GetState().IsKeyDown(Keys.Space);
            bool flap = spaceState && !_priorSpaceState;
            _priorSpaceState = spaceState;
            return flap;
        }
    }
}
