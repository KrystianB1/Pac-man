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

        Texture2D texture_0,texture_1,texture_2,texture_5,texture_6,texture_7, texture_pac_right, texture_point, texture_pac_up, texture_pac_left;
        string[] line;
        Rectangle location;
        Vector2 pac_man_bounds;
        int x = 500;
        int y=500;
        AnimatedSprite animated_packman;
        KeyboardState keyboardState;
        KeyboardState oldKeyboardState;
        Keys keyRight = Keys.Right;
        Keys keyLeft = Keys.Left;
        Keys keyUp = Keys.Up;
        Keys keyDown = Keys.Down;
        string levels = "Content/Levels/lvl1.txt";
        string levels_two = "Content/Levels/lvl2.txt";

        public Gameplay( )
        {
            
            Globals.graphics.GraphicsDevice.Clear(Color.Black);
            texture_point = Globals.contentManager.Load<Texture2D>("point");
            texture_0 = Globals.contentManager.Load<Texture2D>("0");
            texture_1 = Globals.contentManager.Load<Texture2D>("1");
            texture_2 = Globals.contentManager.Load<Texture2D>("2");
            texture_6 = Globals.contentManager.Load<Texture2D>("6");
            texture_7 = Globals.contentManager.Load<Texture2D>("7");
            texture_pac_right = Globals.contentManager.Load<Texture2D>("monster/pac_right");
            texture_pac_left = Globals.contentManager.Load<Texture2D>("monster/pac_left");
            texture_pac_up = Globals.contentManager.Load<Texture2D>("monster/pac_up");
            
            animated_packman = new AnimatedSprite(texture_pac_right, 1, 3);
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
                        Console.WriteLine(line.Length);
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
           
            animated_packman.Update();
            pac_man_bounds = new Vector2(x,y);
            keyboardState = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(keyUp))
            {
               if(Globals.Animated_sprite!=Globals.Animated_State.UP)
                {
                    Globals.Animated_sprite = Globals.Animated_State.UP;
                    check_animated();
                }

                y--;

            }
            if (Keyboard.GetState().IsKeyDown(keyDown))
            {
                if (Globals.Animated_sprite != Globals.Animated_State.DOWN)
                {
                    Globals.Animated_sprite = Globals.Animated_State.DOWN;
                    check_animated();
                }
                y++;

            }
            if (Keyboard.GetState().IsKeyDown(keyRight))
            {
                if (Globals.Animated_sprite != Globals.Animated_State.RIGHT)
                {
                    Globals.Animated_sprite = Globals.Animated_State.RIGHT;
                    check_animated();
                }

                x++;
                
            }
            if (Keyboard.GetState().IsKeyDown(keyLeft))
            {
                if (Globals.Animated_sprite != Globals.Animated_State.LEFT)
                {
                    Globals.Animated_sprite = Globals.Animated_State.LEFT;
                    check_animated();
                }
                x--;

            }

            foreach (Rectangle r in Globals.pointsList)
            {

                // do dopisania
            }
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
                            Globals.spriteBatch.Draw(texture_1, location, Color.White);
                            Globals.collisionList.Add(location);
                            break;
                        case 1:
                            Globals.spriteBatch.Draw(texture_point, location, Color.White);
                            Globals.pointsList.Add(location);
                            break;
                        case 2:
                            Globals.spriteBatch.Draw(texture_2, location, Color.White);
                            break;
                        case 5:
                            //Globals.spriteBatch.Draw(texture_pac, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                            break;
                        case 6:
                            Globals.spriteBatch.Draw(texture_6, location, Color.White);
                            break;
                        case 7:
                            Globals.spriteBatch.Draw(texture_7, location, Color.White);
                            break;
                            break;

                    }
                }
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
                   animated_packman = new AnimatedSprite(texture_pac_up, 1, 3);
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
