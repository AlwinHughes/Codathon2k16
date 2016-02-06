﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Codeathon_Game
{
    enum blockType
    {
        START, STOP, IF, FOR, WHILE, END, NOT, TRUE, FALSE, DATA, MOVEFORWARD,NONE,LEFT,RIGHT
    }

    class BlockData
    {
        blockType type;

        public string name { get; private set; }
        public bool[] canBeDockedTo { get; private set; }
        public Color insideColour { get; private set; }
        public Color[] borderColours { get; private set; }
        public Color textColour { get; private set; }

        public static string getName(blockType type)
        {
            
            BlockData t = new BlockData(type);
            
            return t.name;
        }

        public BlockData(blockType type)
        {
            this.type = type;
            switch (this.type)
            {
                case blockType.LEFT:
                    name = "TURN LEFT";
                    canBeDockedTo = new bool[] { true, false };
                    borderColours = new Color[4] { insideColour, insideColour, insideColour, Color.Green };
                    textColour = Color.CadetBlue;
                    break;
                case blockType.RIGHT:
                    name = "TURN RIGHT";
                    canBeDockedTo = new bool[] { true, false };
                    borderColours = new Color[4] { insideColour, insideColour, insideColour, Color.Green };
                    textColour = Color.CadetBlue;
                    break;
                case blockType.START:
                    name = "START";
                    canBeDockedTo = new bool[2] { true, false };
                    borderColours = new Color[4] { insideColour, insideColour, insideColour, Color.Green };
                    textColour = Color.CadetBlue;
                    break;
                case blockType.STOP:
                    name = "STOP";
                    canBeDockedTo = new bool[2] { false, false };
                    borderColours = new Color[4] { insideColour, Color.Green, insideColour, insideColour };
                    textColour = Color.CadetBlue;
                    break;
                case blockType.IF:
                    name = "IF";
                    canBeDockedTo = new bool[2] { true, true };
                    borderColours = new Color[4] { insideColour, Color.Green, Color.Red, Color.Green };
                    textColour = Color.CadetBlue;
                    break;
                case blockType.FOR:
                    name = "FOR";
                    canBeDockedTo = new bool[2] { true, true };
                    borderColours = new Color[4] { insideColour, Color.Green, Color.Red, Color.Green };
                    ; textColour = Color.CadetBlue;
                    break;
                case blockType.WHILE:
                    name = "WHILE";
                    canBeDockedTo = new bool[2] { true, true };
                    borderColours = new Color[4] { insideColour, Color.Green, Color.Red, Color.Green };
                    textColour = Color.CadetBlue;
                    break;
                case blockType.END:
                    name = "END";
                    canBeDockedTo = new bool[2] { true, false };
                    borderColours = new Color[4] { insideColour, Color.Green, insideColour, Color.Green };
                    textColour = Color.CadetBlue;
                    break;
                case blockType.NOT:
                    name = "NOT";
                    canBeDockedTo = new bool[2] { false, true };
                    borderColours = new Color[4] { Color.Red, insideColour, Color.Red, insideColour };
                    textColour = Color.CadetBlue;
                    break;
                case blockType.TRUE:
                    name = "True";
                    canBeDockedTo = new bool[2] { false, true };
                    borderColours = new Color[4] { Color.Red, insideColour, Color.Red, insideColour };
                    textColour = Color.CadetBlue;
                    break;
                case blockType.FALSE:
                    name = "False";
                    canBeDockedTo = new bool[2] { false, true };
                    borderColours = new Color[4] { Color.Red, insideColour, Color.Red, insideColour };
                    textColour = Color.CadetBlue;
                    break;
                case blockType.MOVEFORWARD:
                    name = "Forward";
                    canBeDockedTo = new bool[2] { true, false };
                    borderColours = new Color[4] { insideColour, Color.Green, insideColour, Color.Green };
                    textColour = Color.CadetBlue;
                    break;
            }
        }
    }
}
