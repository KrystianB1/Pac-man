﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man
{
    public class Monster_pink
    {
        AnimatedSprite animated_pink;

        Texture2D texture_pink_up;
        Texture2D texture_pink_left;
        Texture2D texture_pink_right;
        Texture2D texture_pink_down;

        Texture2D texture_blue_up;
        Texture2D texture_blue_left;
        Texture2D texture_blue_right;
        Texture2D texture_blue_down;

        public Rectangle location;
        Vector2 pink_vector_bounds;
        Rectangle pink_bounds;

        bool check_change = false;
        public int position_X_pac = 540;
        public int position_Y_pac = 30;
        const int velocity_X_pac = 1;
        const int velocity_Y_pac = 1;

       
        public Monster_pink()
        {
            texture_pink_right = Globals.contentManager.Load<Texture2D>("monster/monster_pink_right");
            texture_pink_left = Globals.contentManager.Load<Texture2D>("monster/monster_pink_left");
            texture_pink_up = Globals.contentManager.Load<Texture2D>("monster/monster_pink_up");
            texture_pink_down = Globals.contentManager.Load<Texture2D>("monster/monster_pink_down");

            texture_blue_right = Globals.contentManager.Load<Texture2D>("monster/monster_blue_right");
            texture_blue_left = Globals.contentManager.Load<Texture2D>("monster/monster_blue_left");
            texture_blue_up = Globals.contentManager.Load<Texture2D>("monster/monster_blue_up");
            texture_blue_down = Globals.contentManager.Load<Texture2D>("monster/monster_blue_down");

            animated_pink = new AnimatedSprite(texture_pink_up, 1, 2);
            pink_bounds = new Rectangle();
            location = new Rectangle();
        }
        public Rectangle Pink_bounds
        {
            get
            {
                return pink_bounds;
            }

            set
            {
                pink_bounds = value;
            }
        }


        public void Update()
        {
            if (Globals.powered_up_check == true && check_change == false)
            {
                check_animated();
                check_change = true;
            }
            else
            {
                if (Globals.powered_up_check == false && check_change == true)
                {
                    check_change = false;
                    check_animated();
                }
            }
            Draw();
        }

        public void Draw()
        {
            controll();
        }

        public void controll()
        {
            animated_pink.Update();
            pink_vector_bounds = new Vector2(position_X_pac, position_Y_pac);
            pink_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);
            LoadCheckAnimated();

            if (Globals.flaga_STOP == false)
            {


                switch (Globals.pink_movement_dir)
                {
                    case 0:
                        //up
                        if (Globals.Animated_sprite_pink != Globals.Animated_State.UP)
                        {
                            Globals.Animated_sprite_pink = Globals.Animated_State.UP;
                            check_animated();
                        }
                        position_Y_pac -= velocity_Y_pac;
                        pink_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(pink_bounds))
                            {
                                Random rnd = new Random();
                                Globals.pink_movement_dir = rnd.Next(0, 4);
                                position_Y_pac += velocity_Y_pac;
                                break;
                            }
                        }
                        break;
                    case 1:
                        //down
                        if (Globals.Animated_sprite_pink != Globals.Animated_State.DOWN)
                        {
                            Globals.Animated_sprite_pink = Globals.Animated_State.DOWN;
                            check_animated();
                        }

                        position_Y_pac += velocity_Y_pac;
                        pink_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(pink_bounds))
                            {
                                Random rnd = new Random();
                                Globals.pink_movement_dir = rnd.Next(0, 4);
                                position_Y_pac -= velocity_Y_pac;
                                break;
                            }
                        }

                        break;
                    case 2:
                        //left
                        if (Globals.Animated_sprite_pink != Globals.Animated_State.LEFT)
                        {
                            Globals.Animated_sprite_pink = Globals.Animated_State.LEFT;
                            check_animated();
                        }

                        position_X_pac -= velocity_X_pac;
                        pink_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(pink_bounds))
                            {
                                Random rnd = new Random();
                                Globals.pink_movement_dir = rnd.Next(0, 4);
                                position_X_pac += velocity_X_pac;
                                break;
                            }
                        }
                        break;
                    case 3:
                        //right
                        if (Globals.Animated_sprite_pink != Globals.Animated_State.RIGHT)
                        {
                            Globals.Animated_sprite_pink = Globals.Animated_State.RIGHT;
                            check_animated();
                        }

                        position_X_pac += velocity_X_pac;
                        pink_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(pink_bounds))
                            {
                                Random rnd = new Random();
                                Globals.pink_movement_dir = rnd.Next(0, 4);
                                position_X_pac -= velocity_X_pac;
                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            Globals.spriteBatch.Begin();
            animated_pink.Draw_for_pacman(pink_vector_bounds);
            Globals.spriteBatch.End();
        }
        public void LoadCheckAnimated()
        {
            if (Globals.powered_up_check == true)
            {
                if (Globals.flaga_change_color == true)
                {
                    check_animated();
                    Globals.flaga_change_color = false;
                }

            }
        }


        public void check_animated()
        {
            switch (Globals.Animated_sprite_pink)
            {
                case Globals.Animated_State.UP:
                    if (Globals.powered_up_check == false)
                    {
                        animated_pink = new AnimatedSprite(texture_pink_up, 1, 2);
                    }
                    else
                    {
                        animated_pink = new AnimatedSprite(texture_blue_up, 1, 2);
                    }

                    break;
                case Globals.Animated_State.DOWN:
                    if (Globals.powered_up_check == false)
                    {
                        animated_pink = new AnimatedSprite(texture_pink_down, 1, 2);
                    }
                    else
                    {
                        animated_pink = new AnimatedSprite(texture_blue_down, 1, 2);
                    }
                    break;
                case Globals.Animated_State.RIGHT:
                    if (Globals.powered_up_check == false)
                    {
                        animated_pink = new AnimatedSprite(texture_pink_right, 1, 2);
                    }
                    else
                    {
                        animated_pink = new AnimatedSprite(texture_blue_right, 1, 2);
                    }
                    break;
                case Globals.Animated_State.LEFT:
                    if (Globals.powered_up_check == false)
                    {
                        animated_pink = new AnimatedSprite(texture_pink_left, 1, 2);
                    }
                    else
                    {
                        animated_pink = new AnimatedSprite(texture_blue_left, 1, 2);
                    }
                    break;

            }
        }
    }
}
