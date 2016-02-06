using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Codeathon_Game
{
    class Player : ObjectToDraw
    {
        Texture2D tracks;

        Vector2 moveGoal;
        bool canMove;

        int rotateGoal;
        bool canSpin;

        int cd; //input cooldown

        public Player(Vector2 location, Texture2D body, Texture2D tracks) : base(body, location)
        {
            this.tracks = tracks;

        }

        public override void Update()
        {
            if (cd == 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    TurnRight();
                    cd = 30;
                    canSpin = true;
                    if (rotateGoal == 360)
                    {
                        rotateGoal = 0;
                    }
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Q))
                {
                    TurnLeft();
                    cd = 30;
                    canSpin = true;
                    if (rotateGoal == 360)
                    {
                        rotateGoal = 0;
                    }
                }
            }
            else
            {
                cd--;
            }
            //rotate towards goal




            if (rotation < 0)
            {
                rotation += (float)Math.PI;
            }
            else if (rotation > 0)
            {
                rotation -= (float)Math.PI;
            }

            //move towards goal

            //move
        }

        public void TurnRight()
        {
            rotateGoal += 5;
        }

        public void TurnLeft()
        {
            rotateGoal -= 5;
        }

        public void MoveForward()
        {

        }

        public override void Draw()
        {
            Game.spriteBatch.Draw(tracks, location + new Vector2(7, 1), null, new Rectangle(0, 0, 7, 31), new Vector2(tracks.Width / 2 + 16, tracks.Height / 2), rotation, Vector2.One, Color.White, SpriteEffects.None, 0);
            Game.spriteBatch.Draw(tracks, location + new Vector2(33, 1), null, new Rectangle(0, 0, 7, 31), new Vector2(tracks.Width / 2 + 16, tracks.Height / 2), rotation, Vector2.One, Color.White, SpriteEffects.FlipHorizontally, 0);
            Game.spriteBatch.Draw(texture, location, null, null, new Vector2(texture.Width / 2, texture.Height / 2), rotation, Vector2.One, Color.White, SpriteEffects.None, 0);
        }
    }
}
