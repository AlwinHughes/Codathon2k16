using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Codeathon_Game
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        static public GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        int window_height;
        int window_width;
        GameState GAMESTATE;

        public static Dictionary<string, SpriteFont> fonts;

        List<ObjectToDraw>[] OBJECTS = new List<ObjectToDraw>[]
        {
            new List<ObjectToDraw>(),//title screen
            new List<ObjectToDraw>(),//game play view
            new List<ObjectToDraw>(),//game play code
            new List<ObjectToDraw>()// level select
        };

        Texture2D key, Lock;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            GAMESTATE = GameState.TITLESCREEN;
            window_width = graphics.GraphicsDevice.DisplayMode.Width;
            window_height = graphics.GraphicsDevice.DisplayMode.Height;
            graphics.PreferredBackBufferHeight = window_height;
            graphics.PreferredBackBufferWidth = window_width;
            graphics.IsFullScreen = false;
            
            var form = (System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(Window.Handle);
            form.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            Window.IsBorderless = true;


            graphics.ApplyChanges();
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fonts = new Dictionary<string, SpriteFont>();

            fonts.Add("font16", Content.Load<SpriteFont>("fonts/font16"));
            fonts.Add("font24", Content.Load<SpriteFont>("fonts/font24"));
            fonts.Add("font32", Content.Load<SpriteFont>("fonts/font32"));
            fonts.Add("font40", Content.Load<SpriteFont>("fonts/font40"));
            fonts.Add("fontText", Content.Load<SpriteFont>("fonts/fontText"));

            OBJECTS[(int)GameState.TITLESCREEN].Add(new TextShow(new Vector2(window_width / 2, window_height / 2), 4, Color.Transparent, Color.CadetBlue, "font40", "TITLE!!!!!!!!", Color.Black, false));
            ((TextShow)OBJECTS[(int)GameState.TITLESCREEN][0]).center();

            OBJECTS[(int)GameState.TITLESCREEN].Add(new TextShow(new Vector2(window_width / 2, window_height / 2), 4, Color.Transparent, Color.CadetBlue, "font24", "Press Space", Color.Black, false));
            ((TextShow)OBJECTS[(int)GameState.TITLESCREEN][1]).center();
            ((TextShow)OBJECTS[(int)GameState.TITLESCREEN][1]).location.Y += 100;

            OBJECTS[(int)GameState.GAMEPLAY_VIEW].Add(new TextShow(new Vector2(window_width / 2, window_height / 2), 4, Color.Transparent, Color.CadetBlue, "font24", "Play Level", Color.Black, false));
            ((TextShow)OBJECTS[(int)GameState.GAMEPLAY_VIEW][0]).center();
            ((TextShow)OBJECTS[(int)GameState.GAMEPLAY_VIEW][0]).location.Y = 5;
            

            OBJECTS[(int)GameState.GAMEPLAY_CODE].Add(new TextShow(new Vector2(window_width / 2, window_height / 2), 4, Color.Transparent, Color.CadetBlue, "font24", "Play Level", Color.Black, false));
            ((TextShow)OBJECTS[(int)GameState.GAMEPLAY_CODE][0]).center();
            ((TextShow)OBJECTS[(int)GameState.GAMEPLAY_CODE][0]).location.Y = 5;



            key = Content.Load<Texture2D>("images/key");
            Lock = Content.Load<Texture2D>("images/LockedBlock");
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                GAMESTATE = GameState.GAMEPLAY_VIEW;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(key, new Vector2(40, 40), Color.White);
            
       
            foreach (ObjectToDraw curObject in OBJECTS[(int)GAMESTATE])
            {
                curObject.Draw();
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }

    public enum GameState
    {
        TITLESCREEN, GAMEPLAY_VIEW, GAMEPLAY_CODE, LEVEL_SELECT
    }
}
