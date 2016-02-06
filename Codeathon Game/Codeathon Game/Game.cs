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

        List<ObjectToDrawBase>[] OBJECTS = new List<ObjectToDrawBase>[]
        {
            new List<ObjectToDrawBase>(),//title screen
            new List<ObjectToDrawBase>(),//game play view
            new List<ObjectToDrawBase>(),//game play code
            new List<ObjectToDrawBase>()// level select
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(key, new Vector2(40, 40), Color.White);
            spriteBatch.End();

            foreach (ObjectToDrawBase curObject in OBJECTS[(int)GAMESTATE])
            {
                curObject.Draw();
            }

            base.Draw(gameTime);
        }
    }

    public enum GameState
    {
        TITLESCREEN, GAMEPLAY_VIEW, GAMEPLAY_CODE, LEVEL_SELECT
    }
}
