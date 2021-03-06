﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace Pac_man
{
    class Gameplay : StateTemplate
    {
        //Texture
        Texture2D texture_wall;
        Texture2D texture_gate;
        Texture2D texture_in_gate;
        Texture2D texture_portal;
        Texture2D texture_point;
        Texture2D texture_power_up;
        Texture2D texture_pac_up;
        Texture2D texture_pac_left;
        Texture2D texture_pac_right;
        Texture2D texture_pac_down;

        //LOCATION
        Rectangle location;
        Rectangle location_bounds;
        Vector2 pac_man_bounds;
        Rectangle pacman_bounds;
        Pacman_main pacman;
        Monster_cyan cyan;
        Monster_orange orange;
        Monster_red red;
        Monster_pink pink;
        Song start,stop,ghost;
        bool gamestart = true;

        //POSITION
        int position_X_pac = 480;
        int position_Y_pac = 480;
        const int velocity_X_pac = 3;
        const int velocity_Y_pac = 3;
      


        //LEVELS
        string levels = "Content/Levels/lvl1.txt";
        string levels_two = "Content/Levels/lvl2.txt";
        string[] line;

        public Gameplay()
        {

            Globals.graphics.GraphicsDevice.Clear(Color.Black);
            texture_point = Globals.contentManager.Load<Texture2D>("point");
            texture_wall = Globals.contentManager.Load<Texture2D>("wall");
            texture_gate = Globals.contentManager.Load<Texture2D>("gate");
            texture_in_gate = Globals.contentManager.Load<Texture2D>("in_gate");
            texture_portal = Globals.contentManager.Load<Texture2D>("portal");
            texture_power_up=Globals.contentManager.Load<Texture2D>("power_up");
            start = Globals.contentManager.Load<Song>("wstep");
            stop = Globals.contentManager.Load<Song>("dead");
            ghost = Globals.contentManager.Load<Song>("pacman_eatghost");
            pacman = new Pacman_main();
            cyan = new Monster_cyan();
            orange = new Monster_orange();
            red = new Monster_red();
            pink = new Monster_pink();
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
                        for (int column = 0; column < line.Length; column++)
                        {
                            try
                            {
                                Globals.tile[row, column] = Convert.ToInt32(line[column]);
                            }
                            catch (Exception e)
                            {
                                throw new FileLoadException("Blad wczytywania pliku", e);
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
            
            Draw();
            pacman.Update();
            cyan.Update();
            orange.Update();
            red.Update();
            pink.Update();
            check_colision();
            /*if (gamestart == true)
            {
                MediaPlayer.Play(start);
                Stopwatch s = new Stopwatch();
                s.Start();
                while (s.Elapsed < TimeSpan.FromSeconds(4))
                {

                }
                MediaPlayer.Stop();
                s.Stop();
                gamestart = false;
            }*/

        }
        public void check_colision()
        {
            if (pacman.Pacman_bounds.Intersects(cyan.Cyan_bounds)||
                pacman.Pacman_bounds.Intersects(orange.Orange_bounds)|| 
                pacman.Pacman_bounds.Intersects(red.Red_bounds)||
                pacman.Pacman_bounds.Intersects(pink.Pink_bounds))
            {
                if (Globals.powered_up_check == false)
                {
                    Globals.flaga_STOP = true;
                    MediaPlayer.Play(stop);
                }
                else
                {
                    if(pacman.Pacman_bounds.Intersects(cyan.Cyan_bounds))
                    {
                        MediaPlayer.Play(ghost);
                        cyan.position_X_pac =270;
                        cyan.position_Y_pac =210;
                        cyan.Update();
                        Globals.index_for_score += 100;
                    }
                    else
                    {
                        if (pacman.Pacman_bounds.Intersects(orange.Orange_bounds))
                        {
                            MediaPlayer.Play(ghost);
                            orange.position_X_pac = 270;
                            orange.position_Y_pac = 210;
                            orange.Update();
                            Globals.index_for_score += 100;
                        }
                        else
                        {
                            if (pacman.Pacman_bounds.Intersects(red.Red_bounds))
                            {
                                MediaPlayer.Play(ghost);
                                red.position_X_pac = 270;
                                red.position_Y_pac = 210;
                                red.Update();
                                Globals.index_for_score += 100;
                            }
                            else
                            {
                                if (pacman.Pacman_bounds.Intersects(pink.Pink_bounds))
                                {
                                    MediaPlayer.Play(ghost);
                                    pink.position_X_pac = 270;
                                    pink.position_Y_pac= 210;
                                    pink.Update();
                                    Globals.index_for_score += 100;
                                }
                            }
                        }
                    }
                    MediaPlayer.Play(ghost);
                }
            }    
                
            
           
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

                                Globals.spriteBatch.Draw(texture_wall, location, Color.White);
                                Globals.collisionList.Add(location);

                            }

                            break;
                        case 1:
                            location.Width = 15;
                            location.Height = 15;
                            location.X = location.X + 7;
                            location.Y = location.Y + 7;
                            location_bounds.Width = 1;
                            location_bounds.Height = 1;
                            location_bounds.X = location.X + 15;
                            location_bounds.Y = location.Y + 15;
                            if (Globals.mapdraw == false)
                            {
                                
                                int power = Globals.rnd.Next(1, 80);  
                                if (power==40)
                                {
                                    Globals.spriteBatch.Draw(texture_power_up, location, Color.White);
                                    Globals.powerupList.Add(location);

                                }
                                else
                                {
                                    Globals.spriteBatch.Draw(texture_point, location, Color.White);
                                    Globals.pointsList.Add(location);
                                    Globals.pointList_collision.Add(location_bounds);
                                }

                            }
                            else
                            {
                                foreach (Rectangle rect in Globals.pointsList)
                                {
                                    if (rect.Contains(location))
                                    {                                     
                                        Globals.spriteBatch.Draw(texture_point, location, Color.White);

                                        break;
                                    }
                                }
                                foreach (Rectangle rect in Globals.powerupList)
                                {
                                    if (rect.Contains(location))
                                    {
                                        Globals.spriteBatch.Draw(texture_power_up, location, Color.White);

                                        break;
                                    }
                                }


                            }
                            location.Width = 30;
                            location.Height = 30;
                            location.X = location.X - 7;
                            location.Y = location.Y - 7;
                            location_bounds.Width = 30;
                            location_bounds.Height = 30;
                            location_bounds.X = location_bounds.X - 15;
                            location_bounds.Y = location_bounds.Y - 15;
                            break;
                        case 2:
                            Globals.spriteBatch.Draw(texture_gate, location, Color.White);
                            break;
                        case 6:
                            Globals.spriteBatch.Draw(texture_in_gate, location, Color.White);
                            break;
                        case 7:
                            Globals.spriteBatch.Draw(texture_portal, location, Color.White);
                            Globals.portalsList.Add(location);
                            break;


                    }
                }
            }
            if (Globals.mapdraw == false)
            {
                Globals.mapdraw = true;
            }
            Globals.spriteBatch.DrawString(Globals.spriteFontMenu, "Score: " + Globals.index_for_score.ToString(), new Vector2(0, 0), Color.White);
            Globals.spriteBatch.End();

        }




    }

}
