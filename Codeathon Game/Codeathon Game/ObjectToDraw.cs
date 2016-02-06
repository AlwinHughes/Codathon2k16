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

        public ObjectToDraw dock;
        public Vector2 dockOffset;
        public bool is_text_show = false;


        public ObjectToDraw(Texture2D texture, Vector2 location, int width, int height)
        {
            this.location = location;
            this.texture = texture;
            this.width = width;
            this.height = height;

        }

        public ObjectToDraw(GraphicsDevice d, Vector2 location, int width, int height)
        {
            this.location = location;
            texture = new Texture2D(d, width, height);
            this.width = width;
            this.height = height;
        }

        public ObjectToDraw(Vector2 location, int width, int height)
        {
            this.location = location;
            this.width = width;
            this.height = height;

        }

        public virtual void draw()
        {

        }

        public virtual void update()
        {

        }

        public virtual void checkEdges()
        {

        }

    }
}
