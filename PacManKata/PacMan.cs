using System;

namespace PacManKataTest
{
    public class PacMan
    {
        public PacManFacingEnum Facing { get; private set; }

        public PacMan()
        {
        }

        public void FacePacmanRight()
        {
            
        }

        public void FacePacmanUp()
        {
            Facing = PacManFacingEnum.Up;
        }

        public void FacePacmanLeft()
        {
            Facing = PacManFacingEnum.Left;
        }

        public void FacePacmanDown()
        {
            Facing = PacManFacingEnum.Down;
        }
    }
}