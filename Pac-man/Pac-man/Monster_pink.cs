using Microsoft.Xna.Framework;
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

        Rectangle location;
        Vector2 pink_vector_bounds;
        Rectangle pink_bounds;

        int position_X_pac = 540;
        int position_Y_pac = 30;
        const int velocity_X_pac = 1;
        const int velocity_Y_pac = 1;

        public Monster_pink()
        {
            texture_pink_right = Globals.contentManager.Load<Texture2D>("monster/monster_pink_right");
            texture_pink_left = Globals.contentManager.Load<Texture2D>("monster/monster_pink_left");
            texture_pink_up = Globals.contentManager.Load<Texture2D>("monster/monster_pink_up");
            texture_pink_down = Globals.contentManager.Load<Texture2D>("monster/monster_pink_down");

            animated_pink = new AnimatedSprite(texture_pink_up, 1, 2);
            pink_bounds = new Rectangle();
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
            animated_pink.Update();
            pink_vector_bounds = new Vector2(position_X_pac, position_Y_pac);
            pink_bounds = new Rectangle(position_X_pac, position_Y_pac, 30, 30);

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
            Globals.spriteBatch.Begin();
            animated_pink.Draw_for_pacman(pink_vector_bounds);
            Globals.spriteBatch.End();
        }

        public void check_animated()
        {
            switch (Globals.Animated_sprite_pink)
            {
                case Globals.Animated_State.UP:
                    animated_pink = new AnimatedSprite(texture_pink_up, 1, 2);

                    break;
                case Globals.Animated_State.DOWN:
                    animated_pink = new AnimatedSprite(texture_pink_down, 1, 2);
                    break;
                case Globals.Animated_State.RIGHT:
                    animated_pink = new AnimatedSprite(texture_pink_right, 1, 2);
                    break;
                case Globals.Animated_State.LEFT:
                    animated_pink = new AnimatedSprite(texture_pink_left, 1, 2);
                    break;

            }
        }
    }
}
