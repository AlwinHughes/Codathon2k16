using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codeathon_Game.Screens
{
    public abstract class Screen
    {
        
        public List <ObjectToDraw> drawItems = new List<ObjectToDraw>();
       


        public void loadContent() { }
    }
}
