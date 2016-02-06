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
            graphics.IsFullScreen = true;
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

            foreach (ObjectToDraw curObject in OBJECTS[(int)GAMESTATE])
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
