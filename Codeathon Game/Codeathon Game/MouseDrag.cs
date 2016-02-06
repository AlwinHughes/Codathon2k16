﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Codeathon_Game
{
    class MouseDrag
    {
        public static MouseState current;
        public ObjectToDraw draggedObject;
        Vector2 offset;

        public void CheckClick(List< ObjectToDraw> shapes)
        {
            foreach ( ObjectToDraw pair in shapes)
            {
                ObjectToDraw shape = pair;
                if (shape.canBeDraged)
                {
                    if (Game.current.X > shape.location.X && Game.current.X < shape.location.X + shape.width && Game.current.Y > shape.location.Y && Game.current.Y < shape.location.Y + shape.height)
                    {
                        draggedObject = shape;
                        draggedObject.dock = null;
                        offset = new Vector2(Game.current.X - shape.location.X, Game.current.Y - shape.location.Y);
                        //why alwin why shapes.Remove(pair.Key);
                        //shapes.Add(pair.Key, pair.Value);
                        return;
                    }
                }else if (((TextShow)shape).can_spawn)
                {
                    
                }
                
            }
        }

        public void Update()
        {
            if (draggedObject != null)
            {
                draggedObject.location = Game.current.Position.ToVector2() - offset;
            }
        }

    }
}
