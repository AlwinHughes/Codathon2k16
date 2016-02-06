using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeathon_Game
{
    class Levels
    {
        public static ObjectToDraw[] loadLevel(Texture2D wall)
        {
            ObjectToDraw[] newObjects = new ObjectToDraw[64];
            int i = 0;
            Tile.WallState[] tings = new Tile.WallState[64] 
            {
                Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,
                Tile.WallState.ALL,Tile.WallState.END,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,
                Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,
                Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,
                Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,
                Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,
                Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,
                Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,Tile.WallState.ALL,
            };
            int x = 64, y = 64;
            for (int k = 0; k < 8; k++)
            {
                for (int j = 0; j < 8; j++)
                {
                    newObjects[i] = new Tile(new Vector2(x , y) + new Vector2((int)tings[i] * 64,0), tings[i],0, wall);
                    i++;
                    x += 64;
                }
                x = 64;
                y += 64;
            }

            return newObjects;
        }
    }
}
