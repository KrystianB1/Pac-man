using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man
{
  public class Monster_orange
    {
        AnimatedSprite animated_orange;

        Texture2D texture_orange_up;
        Texture2D texture_orange_left;
        Texture2D texture_orange_right;
        Texture2D texture_orange_down;

        Texture2D texture_blue_up;
        Texture2D texture_blue_left;
        Texture2D texture_blue_right;
        Texture2D texture_blue_down;

        Rectangle location;
        Vector2 orange_vector_bounds;
        Rectangle orange_bounds;

        int position_X_pac = 540;
        int position_Y_pac = 480;
        const int velocity_X_pac = 1;
        const int velocity_Y_pac = 1;

        

        public Monster_orange()
        {
            texture_orange_right = Globals.contentManager.Load<Texture2D>("monster/monster_orange_right");
            texture_orange_left = Globals.contentManager.Load<Texture2D>("monster/monster_orange_left");
            texture_orange_up = Globals.contentManager.Load<Texture2D>("monster/monster_orange_up");
            texture_orange_down = Globals.contentManager.Load<Texture2D>("monster/monster_orange_down");

            texture_blue_right = Globals.contentManager.Load<Texture2D>("monster/monster_blue_right");
            texture_blue_left = Globals.contentManager.Load<Texture2D>("monster/monster_blue_left");
            texture_blue_up = Globals.contentManager.Load<Texture2D>("monster/monster_blue_up");
            texture_blue_down = Globals.contentManager.Load<Texture2D>("monster/monster_blue_down");

            animated_orange = new AnimatedSprite(texture_orange_up, 1, 2);
            orange_bounds = new Rectangle();
            location = new Rectangle();
        }
        public Rectangle Orange_bounds
        {
            get
            {
                return orange_bounds;
            }

            set
            {
                orange_bounds = value;
            }
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
            animated_orange.Update();
            orange_vector_bounds = new Vector2(position_X_pac, position_Y_pac);
            orange_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);
            check_animated();
            if (Globals.flaga_STOP == false)
            {


                switch (Globals.orange_movement_dir)
                {
                    case 0:
                        //up
                        if (Globals.Animated_sprite_orange != Globals.Animated_State.UP)
                        {
                            Globals.Animated_sprite_orange = Globals.Animated_State.UP;
                            check_animated();
                        }
                        position_Y_pac -= velocity_Y_pac;
                        orange_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(orange_bounds))
                            {
                                Random rnd = new Random();
                                Globals.orange_movement_dir = rnd.Next(0, 4);
                                position_Y_pac += velocity_Y_pac;
                                break;
                            }
                        }
                        break;
                    case 1:
                        //down
                        if (Globals.Animated_sprite_orange != Globals.Animated_State.DOWN)
                        {
                            Globals.Animated_sprite_orange = Globals.Animated_State.DOWN;
                            check_animated();
                        }

                        position_Y_pac += velocity_Y_pac;
                        orange_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(orange_bounds))
                            {
                                Random rnd = new Random();
                                Globals.orange_movement_dir = rnd.Next(0, 4);
                                position_Y_pac -= velocity_Y_pac;
                                break;
                            }
                        }

                        break;
                    case 2:
                        //left
                        if (Globals.Animated_sprite_orange != Globals.Animated_State.LEFT)
                        {
                            Globals.Animated_sprite_orange = Globals.Animated_State.LEFT;
                            check_animated();
                        }

                        position_X_pac -= velocity_X_pac;
                        orange_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(orange_bounds))
                            {
                                Random rnd = new Random();
                                Globals.orange_movement_dir = rnd.Next(0, 4);
                                position_X_pac += velocity_X_pac;
                                break;
                            }
                        }
                        break;
                    case 3:
                        //right
                        if (Globals.Animated_sprite_orange != Globals.Animated_State.RIGHT)
                        {
                            Globals.Animated_sprite_orange = Globals.Animated_State.RIGHT;
                            check_animated();
                        }

                        position_X_pac += velocity_X_pac;
                        orange_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(orange_bounds))
                            {
                                Random rnd = new Random();
                                Globals.orange_movement_dir = rnd.Next(0, 4);
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
            animated_orange.Draw_for_pacman(orange_vector_bounds);
            Globals.spriteBatch.End();
        }

        public void check_animated()
        {
            switch (Globals.Animated_sprite_orange)
            {
                case Globals.Animated_State.UP:
                    if (Globals.powered_up_check == false)
                    {
                        animated_orange = new AnimatedSprite(texture_orange_up, 1, 2);
                    }
                    else
                    {
                        animated_orange = new AnimatedSprite(texture_blue_up, 1, 2);
                    }

                    break;
                case Globals.Animated_State.DOWN:
                    if (Globals.powered_up_check == false)
                    {
                        animated_orange = new AnimatedSprite(texture_orange_down, 1, 2);
                    }
                    else
                    {
                        animated_orange = new AnimatedSprite(texture_blue_down, 1, 2);
                    }
                    break;
                case Globals.Animated_State.RIGHT:
                    if (Globals.powered_up_check == false)
                    {
                        animated_orange = new AnimatedSprite(texture_orange_right, 1, 2);
                    }
                    else
                    {
                        animated_orange = new AnimatedSprite(texture_blue_right, 1, 2);
                    }
                    break;
                case Globals.Animated_State.LEFT:
                    if (Globals.powered_up_check == false)
                    {
                        animated_orange = new AnimatedSprite(texture_orange_left, 1, 2);
                    }
                    else
                    {
                        animated_orange = new AnimatedSprite(texture_blue_left, 1, 2);
                    }
                    break;

            }
        }

    }
}
