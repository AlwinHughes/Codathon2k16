using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

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

        List<ObjectToDrawBase>[] OBJECTS;

        Texture2D key;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            OBJECTS = new List<ObjectToDrawBase>[]
            {
            new List<ObjectToDrawBase>(),//title screen
            new List<ObjectToDrawBase>(),//game play view
            new List<ObjectToDrawBase>(),//game play code
            new List<ObjectToDrawBase>()// level select
            };
            Debug.WriteLine("in initialize");
            window_width = graphics.GraphicsDevice.DisplayMode.Width;
            window_height = graphics.GraphicsDevice.DisplayMode.Height;
            graphics.PreferredBackBufferHeight = window_height;
            graphics.PreferredBackBufferWidth = window_width;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Debug.WriteLine("in load content");
            GAMESTATE = GameState.TITLESCREEN;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fonts = new Dictionary<string, SpriteFont>();

            fonts.Add("font16", Content.Load<SpriteFont>("fonts/font16"));
            fonts.Add("font24", Content.Load<SpriteFont>("fonts/font24"));
            fonts.Add("font32", Content.Load<SpriteFont>("fonts/font32"));
            fonts.Add("font40", Content.Load<SpriteFont>("fonts/font40"));
            fonts.Add("fontText", Content.Load<SpriteFont>("fonts/fontText"));
           
            OBJECTS[(int)GAMESTATE].Add(new TextShow(new Vector2(window_width / 2, window_height / 2), 4, Color.Transparent, Color.CadetBlue, "font40", "TITLE!!!!!!!!", Color.Black, false));
            ((TextShow)OBJECTS[(int)GAMESTATE][0]).center();
            key = Content.Load<Texture2D>("images/key");
            
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(key, new Vector2(40, 40), Color.White);
            

            foreach (ObjectToDrawBase curObject in OBJECTS[(int)GAMESTATE])
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
