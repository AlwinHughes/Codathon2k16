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
    class ObjectToDraw
    {
        public Texture2D texture;
        public Vector2 location;
        public float rotation;
        public int width { get; private set; }
        public int height { get; private set; }
        public bool canBeDraged;

        public ObjectToDrawBase dock;
        public Vector2 dockOffset;
        public bool is_text_show = false;

    }
}
