using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Codeathon_Game
{
    class Player : ObjectToDraw
    {
        Texture2D tracks;

        public Player(Texture2D body, Vector2 location,Texture2D tracks) : base(body, location)
        {
            this.tracks = tracks;

        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            
        }
    }
}
