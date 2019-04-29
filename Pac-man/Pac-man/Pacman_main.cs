using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man
{
    public class Pacman_main
    {
        AnimatedSprite animated_packman;

        Texture2D texture_pac_up;
        Texture2D texture_pac_left;
        Texture2D texture_pac_right;
        Texture2D texture_pac_down;

        Rectangle location;
        Vector2 pac_man_bounds;
        Rectangle pacman_bounds;

        int position_X_pac = 480;
        int position_Y_pac = 480;
        const int velocity_X_pac = 3;
        const int velocity_Y_pac = 3;


        KeyboardState keyboardState;
        
        volatile Boolean block_key;


        public Pacman_main()
        {
            texture_pac_right = Globals.contentManager.Load<Texture2D>("monster/pac_right");
            texture_pac_left = Globals.contentManager.Load<Texture2D>("monster/pac_left");
            texture_pac_up = Globals.contentManager.Load<Texture2D>("monster/pac_up");
            texture_pac_down = Globals.contentManager.Load<Texture2D>("monster/pac_down");

            animated_packman = new AnimatedSprite(texture_pac_right, 1, 3);
            pacman_bounds = new Rectangle();
            location = new Rectangle();
        }

        public void Update()
        {
            Draw();
        }

        public void Draw()
        {
            controll();
        }

        public void controll()
        {


            block_key = true;
            animated_packman.Update();
            pac_man_bounds = new Vector2(position_X_pac, position_Y_pac);
            pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

            keyboardState = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && block_key == true)
            {
                block_key = false;
                if (Globals.Animated_sprite != Globals.Animated_State.UP)
                {
                    Globals.Animated_sprite = Globals.Animated_State.UP;
                    check_animated();
                }
                position_Y_pac -= velocity_Y_pac;
                pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);
                foreach (Rectangle r in Globals.collisionList)
                {
                    if (r.Intersects(pacman_bounds))
                    {
                        pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);
                        position_Y_pac += velocity_Y_pac;

                        break;
                    }
                }
                foreach (Rectangle r in Globals.pointsList)
                {
                    if (pacman_bounds.Intersects(r))
                    {
                        Globals.index_for_score += 10;
                        Globals.pointsList.Remove(r);

                        break;
                    }
                }


            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && block_key == true)
            {
                block_key = false;
                if (Globals.Animated_sprite != Globals.Animated_State.DOWN)
                {
                    Globals.Animated_sprite = Globals.Animated_State.DOWN;
                    check_animated();
                }
                position_Y_pac += velocity_Y_pac;
                pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                foreach (Rectangle r in Globals.collisionList)
                {
                    if (r.Intersects(pacman_bounds))
                    {
                        position_Y_pac -= velocity_Y_pac;
                        pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);
                        break;
                    }
                }
                foreach (Rectangle r in Globals.pointsList)
                {
                    if (pacman_bounds.Intersects(r))
                    {
                        Globals.index_for_score += 10;
                        Globals.pointsList.Remove(r);

                        break;
                    }
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && block_key == true)
            {
                block_key = false;
                if (Globals.Animated_sprite != Globals.Animated_State.RIGHT)
                {
                    Globals.Animated_sprite = Globals.Animated_State.RIGHT;
                    check_animated();
                }

                position_X_pac += velocity_X_pac;
                pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);
                foreach (Rectangle r in Globals.collisionList)
                {
                    if (r.Intersects(pacman_bounds))
                    {
                        position_X_pac -= velocity_X_pac;
                        pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);
                        break;
                    }
                }
                foreach (Rectangle r in Globals.pointsList)
                {
                    if (pacman_bounds.Intersects(r))
                    {
                        Globals.index_for_score += 10;
                        Globals.pointsList.Remove(r);

                        break;
                    }
                }

                foreach (Rectangle r in Globals.portalsList)
                {
                    if (pacman_bounds.Intersects(r))
                    {
                        position_X_pac = 30;
                        break;
                    }
                }

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && block_key == true)
            {
                block_key = false;
                if (Globals.Animated_sprite != Globals.Animated_State.LEFT)
                {
                    Globals.Animated_sprite = Globals.Animated_State.LEFT;
                    check_animated();
                }
                position_X_pac -= velocity_X_pac;
                pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);
                foreach (Rectangle r in Globals.collisionList)
                {
                    if (r.Intersects(pacman_bounds))
                    {
                        position_X_pac += velocity_X_pac;
                        pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);
                        break;
                    }
                }
                foreach (Rectangle r in Globals.pointsList)
                {
                    if (pacman_bounds.Intersects(r))
                    {
                        Globals.index_for_score += 10;
                        Globals.pointsList.Remove(r);
                        break;
                    }
                }
                foreach (Rectangle r in Globals.portalsList)
                {
                    if (pacman_bounds.Intersects(r))
                    {
                        position_X_pac = 540;
                        break;
                    }
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Globals.currentState = Globals.EnStates.RETRY;
            }
                Globals.spriteBatch.Begin();
            animated_packman.Draw_for_pacman(pac_man_bounds);
            Globals.spriteBatch.End();
        }
       

        public void check_animated()
        {
            switch (Globals.Animated_sprite)
            {
                case Globals.Animated_State.UP:
                    animated_packman = new AnimatedSprite(texture_pac_up, 1, 3);

                    break;
                case Globals.Animated_State.DOWN:
                    animated_packman = new AnimatedSprite(texture_pac_down, 1, 3);
                    break;
                case Globals.Animated_State.RIGHT:
                    animated_packman = new AnimatedSprite(texture_pac_right, 1, 3);
                    break;
                case Globals.Animated_State.LEFT:
                    animated_packman = new AnimatedSprite(texture_pac_left, 1, 3);
                    break;

            }
        }
    }
}
