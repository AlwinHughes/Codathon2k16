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
    class Shape: ObjectToDraw
    {
        public Shape(Texture2D texture, Vector2 location)
            : base(texture, location)
        {

        }

        public Shape(GraphicsDevice d, Vector2 location, int width, int height)
            : base(d, location, width, height)
        {

        }
    }
}
