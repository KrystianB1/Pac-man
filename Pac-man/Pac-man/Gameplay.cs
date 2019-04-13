using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pac_man
{
    class Gameplay : StateTemplate
    {
        //Texture
        Texture2D texture_wall;
        Texture2D texture_gate;
        Texture2D texture_in_gate;
        Texture2D texture_portal;
        Texture2D texture_pac_right;
        Texture2D texture_point;
        Texture2D texture_pac_up;
        Texture2D texture_pac_left;
        Texture2D texture_pac_down;

        //LOCATION
        Rectangle location;
        Vector2 pac_man_bounds;
        Rectangle pacman_bounds;
        //POSITION
        int position_X_pac = 480;
        int position_Y_pac = 480;
        AnimatedSprite animated_packman;

        //KEYBOARD
        KeyboardState keyboardState;
        Keys keyRight = Keys.Right;
        Keys keyLeft = Keys.Left;
        Keys keyUp = Keys.Up;
        Keys keyDown = Keys.Down;
        Boolean block_key;

        //LEVELS
        string levels = "Content/Levels/lvl1.txt";
        string levels_two = "Content/Levels/lvl2.txt";
        string[] line;

        public Gameplay( )
        {
            
            Globals.graphics.GraphicsDevice.Clear(Color.Black);
            texture_point = Globals.contentManager.Load<Texture2D>("point");
            texture_wall = Globals.contentManager.Load<Texture2D>("wall");
            texture_gate = Globals.contentManager.Load<Texture2D>("gate");
            texture_in_gate = Globals.contentManager.Load<Texture2D>("in_gate");
            texture_portal = Globals.contentManager.Load<Texture2D>("portal");
            texture_pac_right = Globals.contentManager.Load<Texture2D>("monster/pac_right");
            texture_pac_left = Globals.contentManager.Load<Texture2D>("monster/pac_left");
            texture_pac_up = Globals.contentManager.Load<Texture2D>("monster/pac_up");
            texture_pac_down = Globals.contentManager.Load<Texture2D>("monster/pac_down");
            animated_packman = new AnimatedSprite(texture_pac_right, 1, 3);
            pacman_bounds = new Rectangle();
            location = new Rectangle();
            
            line = new string[20];
            loadlevels(levels_two);
        }
        public void loadlevels(string url_levels)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader reader = new StreamReader(url_levels))
                {
                    int row = 0;
                    
                    while (!reader.EndOfStream)
                    {
                        
                        line = reader.ReadLine().Split(' ');
                        for(int column = 0; column < line.Length; column++)
                        {
                            try
                            {
                             Globals.tile[row, column] = Convert.ToInt32(line[column]);
                            }catch(Exception e)
                            {
                                throw new FileLoadException("Blad wczytywania pliku",e); 
                            }
                          
                        }
                       
                        row++;

                    }
                   
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
       
        public override void Update(GameTime gameTime)
        {
            controll();
           
            
  
            Draw();
        }
        public override void Draw()
        {

            Globals.spriteBatch.GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();
            location.Height = 30;
            location.Width = 30;

                for (int i = 0; i < 28; i++)
                {
                    for (int j = 0; j < 31; j++)
                    {
                        location.X = i * 30;
                        location.Y = j * 30;
                        switch (Globals.tile[j, i])
                        {
                            case 0:
                                Globals.spriteBatch.Draw(texture_wall, location, Color.White);
                            if (Globals.mapdraw == false)
                            {
                                Globals.collisionList.Add(location);
                            }
                                break;
                            case 1:
                                Globals.spriteBatch.Draw(texture_point, location, Color.White);
                            if (Globals.mapdraw == false)
                            {
                                Globals.pointsList.Add(location);
                            }
                                break;
                            case 2:
                                Globals.spriteBatch.Draw(texture_gate, location, Color.White);
                                break;
                            case 6:
                                Globals.spriteBatch.Draw(texture_in_gate, location, Color.White);
                                break;
                            case 7:
                                Globals.spriteBatch.Draw(texture_portal, location, Color.White);
                                break;


                        }
                    }
                }
            if (Globals.mapdraw == false)
            {
                Globals.mapdraw = true;
            }
            animated_packman.Draw(pac_man_bounds);
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
        public void controll()
        {
            block_key = true;
            animated_packman.Update();
            pac_man_bounds = new Vector2(position_X_pac, position_Y_pac);
            pacman_bounds = new Rectangle(position_X_pac,position_Y_pac, 28, 28);
            
            keyboardState = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(keyUp)&& block_key == true)
            {
                block_key = false;
                if (Globals.Animated_sprite != Globals.Animated_State.UP)
                {
                    Globals.Animated_sprite = Globals.Animated_State.UP;
                    check_animated();
                }
                position_Y_pac--;
                pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 28, 28);
                foreach (Rectangle r in Globals.collisionList)
                {
                   if(r.Intersects(pacman_bounds))
                    {
                        position_Y_pac++;
                        pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 28, 28);
                        break;
                    }
                   
                }
                

            }
            if (Keyboard.GetState().IsKeyDown(keyDown) && block_key == true)
            {
                block_key = false;
                if (Globals.Animated_sprite != Globals.Animated_State.DOWN)
                {
                    Globals.Animated_sprite = Globals.Animated_State.DOWN;
                    check_animated();
                }
                position_Y_pac++;
               
                foreach (Rectangle r in Globals.collisionList)
                {
                    if (r.Intersects(pacman_bounds))
                    {
                        position_Y_pac--;
                        pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 28, 28);
                        break;
                    }
                }

            }
            if (Keyboard.GetState().IsKeyDown(keyRight) && block_key == true)
            {
                block_key = false;
                if (Globals.Animated_sprite != Globals.Animated_State.RIGHT)
                {
                    Globals.Animated_sprite = Globals.Animated_State.RIGHT;
                    check_animated();
                }

                position_X_pac++;
                pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 28, 28);
                foreach (Rectangle r in Globals.collisionList)
                {
                    if (r.Intersects(pacman_bounds))
                    {
                        position_X_pac--;
                        pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 28, 28);
                        break;
                    }
                }


            }
            if (Keyboard.GetState().IsKeyDown(keyLeft) && block_key == true)
            {
                block_key = false;
                if (Globals.Animated_sprite != Globals.Animated_State.LEFT)
                {
                    Globals.Animated_sprite = Globals.Animated_State.LEFT;
                    check_animated();
                }
                position_X_pac--;
                pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 28, 28);
                foreach (Rectangle r in Globals.collisionList)
                {
                    if (r.Intersects(pacman_bounds))
                    {
                        position_X_pac++;
                        pacman_bounds = new Rectangle(position_X_pac, position_Y_pac, 28, 28);
                        break;
                    }
                }

            }
            
        }

    }
    
}
