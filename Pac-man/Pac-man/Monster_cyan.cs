using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man
{
    public class Monster_cyan
    {
        AnimatedSprite animated_cyan;

        Texture2D texture_cyan_up;
        Texture2D texture_cyan_left;
        Texture2D texture_cyan_right;
        Texture2D texture_cyan_down;


        Texture2D texture_blue_up;
        Texture2D texture_blue_left;
        Texture2D texture_blue_right;
        Texture2D texture_blue_down;

        public Rectangle location;
        Vector2 cyan_vector_bounds;
        Rectangle cyan_bounds;

       public  int position_X_pac = 480;
       public  int position_Y_pac = 480;
        const int velocity_X_pac = 1;
        const int velocity_Y_pac = 1;
        bool check_change = false;

        public Monster_cyan()
        {
            texture_cyan_right = Globals.contentManager.Load<Texture2D>("monster/monster_cyan_right");
            texture_cyan_left = Globals.contentManager.Load<Texture2D>("monster/monster_cyan_left");
            texture_cyan_up = Globals.contentManager.Load<Texture2D>("monster/monster_cyan_up");
            texture_cyan_down = Globals.contentManager.Load<Texture2D>("monster/monster_cyan_down");

            texture_blue_right = Globals.contentManager.Load<Texture2D>("monster/monster_blue_right");
            texture_blue_left = Globals.contentManager.Load<Texture2D>("monster/monster_blue_left");
            texture_blue_up = Globals.contentManager.Load<Texture2D>("monster/monster_blue_up");
            texture_blue_down = Globals.contentManager.Load<Texture2D>("monster/monster_blue_down");
            animated_cyan = new AnimatedSprite(texture_cyan_up, 1, 2);
            cyan_bounds = new Rectangle();
            location = new Rectangle();
            Globals.flaga_change_color = true;
            
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
        public Rectangle Cyan_bounds
        {
            get
            {
                return cyan_bounds;
            }

            set
            {
                cyan_bounds = value;
            }
        }


        public void controll()
        {
            animated_cyan.Update();
            cyan_vector_bounds = new Vector2(position_X_pac, position_Y_pac);
            cyan_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);
            LoadCheckAnimated();
            if (Globals.flaga_STOP == false)
            {


                switch (Globals.cyan_movement_dir)
                {
                    case 0:
                        //up
                        if (Globals.Animated_sprite_cyan != Globals.Animated_State.UP)
                        {
                            Globals.Animated_sprite_cyan = Globals.Animated_State.UP;
                            check_animated();
                        }
                        position_Y_pac -= velocity_Y_pac;
                        cyan_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(cyan_bounds))
                            {
                                Random rnd = new Random();
                                Globals.cyan_movement_dir = rnd.Next(0, 4);
                                position_Y_pac += velocity_Y_pac;
                                break;
                            }
                        }
                        break;
                    case 1:
                        //down
                        if (Globals.Animated_sprite_cyan != Globals.Animated_State.DOWN)
                        {
                            Globals.Animated_sprite_cyan = Globals.Animated_State.DOWN;
                            check_animated();
                        }

                        position_Y_pac += velocity_Y_pac;
                        cyan_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(cyan_bounds))
                            {
                                Random rnd = new Random();
                                Globals.cyan_movement_dir = rnd.Next(0, 4);
                                position_Y_pac -= velocity_Y_pac;
                                break;
                            }
                        }

                        break;
                    case 2:
                        //left
                        if (Globals.Animated_sprite_cyan != Globals.Animated_State.LEFT)
                        {
                            Globals.Animated_sprite_cyan = Globals.Animated_State.LEFT;
                            check_animated();
                        }

                        position_X_pac -= velocity_X_pac;
                        cyan_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(cyan_bounds))
                            {
                                Random rnd = new Random();
                                Globals.cyan_movement_dir = rnd.Next(0, 4);
                                position_X_pac += velocity_X_pac;
                                break;
                            }
                        }
                        break;
                    case 3:
                        //right
                        if (Globals.Animated_sprite_cyan != Globals.Animated_State.RIGHT)
                        {
                            Globals.Animated_sprite_cyan = Globals.Animated_State.RIGHT;
                            check_animated();
                        }

                        position_X_pac += velocity_X_pac;
                        cyan_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

                        foreach (Rectangle r in Globals.collisionList)
                        {
                            if (r.Intersects(cyan_bounds))
                            {
                                Random rnd = new Random();
                                Globals.cyan_movement_dir = rnd.Next(0, 4);
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
            animated_cyan.Draw_for_pacman(cyan_vector_bounds);
            Globals.spriteBatch.End();
        }

        public void LoadCheckAnimated()
        {
            if (Globals.powered_up_check == true) {
                if (Globals.flaga_change_color == true)
                {
                    check_animated();
                    Globals.flaga_change_color = false;
                }
                
            }
        }

       

        public void check_animated()
        {
            switch (Globals.Animated_sprite_cyan)
            {
                case Globals.Animated_State.UP:
                    if (Globals.powered_up_check == false)
                    {
                        animated_cyan = new AnimatedSprite(texture_cyan_up, 1, 2);
                    }
                    else 
                    {
                        animated_cyan = new AnimatedSprite(texture_blue_up, 1, 2);
                    }

                    break;
                case Globals.Animated_State.DOWN:
                    if (Globals.powered_up_check == false)
                    {
                        animated_cyan = new AnimatedSprite(texture_cyan_down, 1, 2);
                    }
                    else
                    {
                        animated_cyan = new AnimatedSprite(texture_blue_down, 1, 2);
                    }
                    break;
                case Globals.Animated_State.RIGHT:
                    if (Globals.powered_up_check == false)
                    {
                        animated_cyan = new AnimatedSprite(texture_cyan_right, 1, 2);
                    }
                    else
                    {
                        animated_cyan = new AnimatedSprite(texture_blue_right, 1, 2);
                    }
                    break;
                case Globals.Animated_State.LEFT:
                    if (Globals.powered_up_check == false)
                    {
                        animated_cyan = new AnimatedSprite(texture_cyan_left, 1, 2);
                    }
                    else
                    {
                        animated_cyan = new AnimatedSprite(texture_blue_left, 1, 2);
                    }
                    break;

            }
        }

    }
}
