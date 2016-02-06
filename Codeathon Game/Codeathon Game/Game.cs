using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Codeathon_Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    
    
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        int window_height;
        int wnidow_width;
        GameState GAMESTATE;

        List<ObjectToDraw>[] OBJECTS = new List<ObjectToDraw>[]
        {
            new List<ObjectToDraw>(),//title screen
            new List<ObjectToDraw>(),//game play view
            new List<ObjectToDraw>(),//game play code
            new List<ObjectToDraw>()// level select
        };
        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            GAMESTATE = GameState.TITLESCREEN;
            wnidow_width = graphics.GraphicsDevice.DisplayMode.Width;
            window_height = graphics.GraphicsDevice.DisplayMode.Height;
            graphics.PreferredBackBufferHeight = window_height;
            graphics.PreferredBackBufferWidth = wnidow_width;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;


            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

           
        }

        
        protected override void UnloadContent(){}

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }



    public enum GameState
    {
        TITLESCREEN, GAMEPLAY_VIEW, GAMEPLAY_CODE, LEVEL_SELECT
    }
}
