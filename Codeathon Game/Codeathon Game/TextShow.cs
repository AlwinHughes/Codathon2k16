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
    class TextShow : ObjectToDrawBase
    {
        string text;
        string font;

        int border_size;
        Color inside_color;
        Color border_color;
        Color text_color;

        int sprite_length;
        int sprite_height;

        Color[] data;
        Color[,] data_to_convert;

        Color[] border_colors;
        int[] border_widths;

        bool complex;

        public TextShow(Vector2 location, int border_size, Color inside_color, Color border_color, string font, string text, Color text_color, bool can_be_draged)
           : base(location, (int)Game.fonts[font].MeasureString(text).X + 8 + border_size, (int)Game.fonts[font].MeasureString(text).Y + 8 + border_size)
        {       
            complex = false;
            this.font = font;
            this.inside_color = inside_color;
            this.border_color = border_color;
            this.border_size = border_size;
            this.text_color = text_color;
            this.text = text;
            this.canBeDraged = can_be_draged;
            sprite_height = (int)Game.fonts[font].MeasureString(text).Y;
            sprite_length = (int)Game.fonts[font].MeasureString(text).X;

            data = new Color[width * height];
            data_to_convert = new Color[width, height];

            generateTexture(border_size, inside_color, border_color, text_color);
        }

        //constructur used for complex creation
        public TextShow(Vector2 location, Color inside_color, Color[] border_colors, int[] border_widths, string font, string text, Color text_color, bool canBeDraged)
            : base(location, (int)Game.fonts[font].MeasureString(text).X + 8 + border_widths[0] + border_widths[2], (int)Game.fonts[font].MeasureString(text).Y + 8 + border_widths[1] + border_widths[3])
        {
            complex = true;
            this.font = font;
            this.inside_color = inside_color;
            this.border_colors = border_colors;
            this.text_color = text_color;
            this.text = text;
            this.canBeDraged = canBeDraged;
            this.border_widths = border_widths;
            sprite_height = (int)Game.fonts[font].MeasureString(text).Y;
            sprite_length = (int)Game.fonts[font].MeasureString(text).X;

            border_size = border_widths[0];

            data = new Color[width * height];
            data_to_convert = new Color[width, height];

            generateTextureComplex(border_widths, border_colors, inside_color);
        }

        //public TextShow(Vector2 location, blockType type)
        //   : base(location, (int)Game1.title_font.MeasureString(BlockData.getName(type)).X + 8 + 4 + 4, (int)Game1.title_font.MeasureString(BlockData.getName(type)).Y + 8 + 4 + 4)
        //{
        //    blockData = new BlockData(type);
        //    is_text_show = true;
        //    font = "title";
        //    inside_color = Color.Yellow;
        //    border_colors = blockData.borderColours;
        //    text_color = blockData.textColour;
        //    text = blockData.name;
        //    canBeDraged = true;
        //    sprite_height = (int)Game1.fonts[font].MeasureString(text).Y;
        //    sprite_length = (int)Game1.fonts[font].MeasureString(text).X;

        //    data = new Color[width * height];
        //    data_to_convert = new Color[width, height];

        //    border_size = 8;

        //    generateTextureComplex(new int[4] { 4, 4, 4, 4 }, border_colors, inside_color);
        //}

        public void generateTextureComplex(int[] boder_sizes, Color[] border_colors, Color inside_color)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i <= boder_sizes[0])
                    {
                        if (j <= 6 || j >= height - 6)
                        {
                            data_to_convert[i, j] = inside_color;
                        }
                        else
                        {
                            data_to_convert[i, j] = border_colors[0];
                        }
                    }
                    else if (j <= boder_sizes[1])
                    {
                        if (i <= 6 || i >= width - 6)
                        {
                            data_to_convert[i, j] = inside_color;
                        }
                        else
                        {
                            data_to_convert[i, j] = border_colors[1];
                        }
                    }
                    else if (i >= width - boder_sizes[2])
                    {
                        if (j <= 6 || j >= height - 6)
                        {
                            data_to_convert[i, j] = inside_color;
                        }
                        else
                        {
                            data_to_convert[i, j] = border_colors[2];
                        }
                    }
                    else if (j >= height - boder_sizes[3])
                    {
                        if (i <= 6 || i >= width - 6)
                        {
                            data_to_convert[i, j] = inside_color;
                        }
                        else
                        {
                            data_to_convert[i, j] = border_colors[3];
                        }
                    }
                    else
                    {
                        data_to_convert[i, j] = inside_color;
                    }
                }
            }
            convertTo1DArray();
        }
        public void generateTexture(int border_size, Color inside, Color border, Color text_color)//only alows color change not size change 
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i < border_size || i > width - border_size || j < border_size || j > height - border_size)
                    {
                        data_to_convert[i, j] = border;
                    }
                    else
                    {
                        data_to_convert[i, j] = inside;
                    }
                }
            }
            convertTo1DArray();
        }

        private void convertTo1DArray()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    data[j * width + i] = data_to_convert[i, j];
                }
            }
            texture = new Texture2D(Game.graphics.GraphicsDevice, width, height);
            setData(data);
        }

        public override void Draw()
        {
            Game.spriteBatch.Draw(texture, new Rectangle((int)location.X, (int)location.Y, texture.Width, texture.Height), Color.White);
            Game.spriteBatch.DrawString(Game.fonts[font], text, new Vector2(location.X + border_size, location.Y + border_size), text_color);
        }

        public Vector2 getOffset()
        {
            return new Vector2(4 + border_size + sprite_length / 2, 4 + border_size + sprite_height / 2);
        }

       

    }
}
