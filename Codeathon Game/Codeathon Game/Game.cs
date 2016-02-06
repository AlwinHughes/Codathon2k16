﻿using Microsoft.Xna.Framework;
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

        public static Dictionary<string,SpriteFont> fonts;        

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            

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

            spriteBatch.Begin();
            spriteBatch.DrawString(fonts["font16"], "HELLO BOSS 16", new Vector2(50, 50), Color.Black);
            spriteBatch.DrawString(fonts["font24"], "HELLO BOSS 24", new Vector2(50, 100), Color.Black);
            spriteBatch.DrawString(fonts["font32"], "HELLO BOSS 32", new Vector2(50, 150), Color.Black);
            spriteBatch.DrawString(fonts["font40"], "HELLO BOSS 40", new Vector2(50, 200), Color.Black);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
