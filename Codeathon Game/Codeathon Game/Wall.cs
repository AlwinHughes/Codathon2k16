using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Codeathon_Game
{
    class Wall: ObjectToDraw
    {

        public enum WallState
        {
            STRAIT,CORNER,T_JUNCTION,CROSS
        } 
        public enum WallRoation
        {
            ZERO = 0,ONE = 1,TWO = 2,THREE = 3,
        
        }
        
        public Wall(Vector2 location, WallRoation,WallState)
            :base(location, 64,64)
        {
            this.location = location;
        }
        public Wall(Vector2 location)
            :base(location, 64,64)
        {
            this.location = location;
        }
    }
}
