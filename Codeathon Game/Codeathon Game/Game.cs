using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.InputListeners;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Codeathon_Game
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        static public GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;


        private InputListenerManager _inputManager;
        MouseDrag mouse = new MouseDrag();
        public static MouseState current;
        MouseState previous;


        Screens.TitleScreen titlescreen = new Screens.TitleScreen();
        Screens.GamePlay gameplay = new Screens.GamePlay();
        Screens.GameView gameview = new Screens.GameView();
        Screens.GameCode gamecode = new Screens.GameCode();
        Screens.LevelSelect levelselect = new Screens.LevelSelect();

        int window_height;
        int window_width;
        GameState GAMESTATE;
        int last_time_switch = 0;

        public static Dictionary<string, SpriteFont> fonts;

        List<ObjectToDraw>[] Screens;

        Texture2D key, Lock;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Screens = new List<ObjectToDraw>[] { titlescreen.drawItems, gameview.drawItems, gamecode.drawItems, levelselect.drawItems };
            _inputManager = new InputListenerManager();

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

            var keyboardListener = _inputManager.AddListener(new KeyboardListenerSettings());

            //HERE BE BOOTY
            keyboardListener.KeyPressed += (sender, args) => KeyPress("{0} key pressed", args.Key);


            base.Initialize();
        }

        private void KeyPress(string v, Keys key)
        {
            throw new NotImplementedException();
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

            titlescreen.drawItems.Add(new TextShow(new Vector2(window_width / 2, window_height / 2), 4, Color.Transparent, Color.CadetBlue, "font40", "TITLE!!!!!!!!", Color.Black, false));
            ((TextShow)Screens[(int)GameState.TITLESCREEN][0]).center();
            titlescreen.drawItems.Add(new TextShow(new Vector2(window_width / 2, window_height / 2), 4, Color.Transparent, Color.CadetBlue, "font24", "Press Space", Color.Black, false));
            ((TextShow)Screens[(int)GameState.TITLESCREEN][1]).center();
            ((TextShow)Screens[(int)GameState.TITLESCREEN][1]).location.Y += 100;

            gameview.drawItems.Add(new TextShow(new Vector2(window_width / 2, window_height / 2), 4, Color.Transparent, Color.CadetBlue, "font24", "Play Level", Color.Black, false));
            gameview.drawItems.Add(new TextShow(new Vector2(window_width / 2, window_height / 2), 4, Color.Transparent, Color.CadetBlue, "font24", "Progarm Level", Color.Black, false));
            ((TextShow)Screens[(int)GameState.GAMEPLAY_VIEW][0]).center();
            ((TextShow)Screens[(int)GameState.GAMEPLAY_VIEW][0]).location.Y = 5;

            gamecode.drawItems.Add(new TextShow(new Vector2(window_width / 2, window_height / 2), 4, Color.Transparent, Color.CadetBlue, "font24", "Progarm Level", Color.Black, false));
            ((TextShow)Screens[(int)GameState.GAMEPLAY_CODE][0]).center();
            ((TextShow)Screens[(int)GameState.GAMEPLAY_CODE][0]).location.Y = 5;



            key = Content.Load<Texture2D>("images/key");
            Lock = Content.Load<Texture2D>("images/LockedBlock");
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            current = Mouse.GetState();
            if (current.LeftButton == ButtonState.Pressed)
            {
                if (previous.LeftButton != ButtonState.Pressed)
                {
                    mouse.CheckClick(Screens[(int)GAMESTATE]);
                }
            }
            else
            {
                if (mouse.draggedObject != null)
                {
                    ((TextShow)mouse.draggedObject).Dock(Screens[(int)GameState.GAMEPLAY_VIEW]);

                    mouse.draggedObject = null;
                }
            }
            mouse.Update();
            previous = current;

            _inputManager.Update(gameTime);

            if (GAMESTATE == GameState.TITLESCREEN)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    GAMESTATE = GameState.GAMEPLAY_VIEW;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Exit();
                }
            }
            else if (GAMESTATE == GameState.GAMEPLAY_CODE)
            {
                //TODO fill in code here
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {

                    if (DateTime.Now.Millisecond - last_time_switch > 500)
                    {
                        GAMESTATE = GameState.GAMEPLAY_VIEW;
                        last_time_switch = DateTime.Now.Millisecond;
                    }

                }

                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    GAMESTATE = GameState.TITLESCREEN;
                }
            }
            else if (GAMESTATE == GameState.GAMEPLAY_VIEW)
            {

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    if (DateTime.Now.Millisecond - last_time_switch > 500)
                    {
                        GAMESTATE = GameState.GAMEPLAY_CODE;
                        last_time_switch = DateTime.Now.Millisecond;
                    }

                }

                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    GAMESTATE = GameState.TITLESCREEN;
                }
            }
            else if (GAMESTATE == GameState.LEVEL_SELECT)
            {
                //TODO fill in code here
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    GAMESTATE = GameState.TITLESCREEN;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(key, new Vector2(40, 40), Color.White);





            foreach (ObjectToDraw curObject in Screens[(int)GAMESTATE])
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