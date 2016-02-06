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
    class Tile : ObjectToDraw
    {

        public enum WallState
        {
            CORNER_E,CORNER_I,T_JUNCTION, STRAIGHT,CROSS,END,THIN,ALL,FLOOR
        }
        
        WallState state;

        public Tile(Vector2 location,  WallState state, int wall_roation,Texture2D wall)
            : base(wall, new Vector2(64,64))
        {
            this.state = state;
            this.location = location;
            rotation = wall_roation * 90;
        }

        public override void Draw()
        {
            Game.spriteBatch.Draw(texture, location, null,new Rectangle(a,0,64,64), new Vector2(texture.Width / 2, texture.Height / 2), rotation, Vector2.One, Color.White, SpriteEffects.None, 0);
        }

        public override void Update()
        {

        }


    }
}
