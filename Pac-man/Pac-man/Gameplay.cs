using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Pac_man
{
    class Gameplay : StateTemplate
    {

        Texture2D texture_0,texture_1,texture_2,texture_5,texture_6,texture_7,texture_pac;
        string[] line = new string[20];
        string levels = "Content/Levels/lvl1.txt";
        public Gameplay( )
        {
            Globals.graphics.GraphicsDevice.Clear(Color.Black);
            texture_0 = Globals.contentManager.Load<Texture2D>("0");
            texture_1 = Globals.contentManager.Load<Texture2D>("1");
            texture_2 = Globals.contentManager.Load<Texture2D>("2");
            texture_6 = Globals.contentManager.Load<Texture2D>("6");
            texture_7 = Globals.contentManager.Load<Texture2D>("7");
            texture_pac = Globals.contentManager.Load<Texture2D>("monster/pac");
            loadlevels(levels);
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
                        
                        line = reader.ReadLine().Split(',');
                        for(int column = 0; column < line.Length; column++)
                        {
                            try
                            {
                             Globals.tile[row, column] = Convert.ToInt32(line[column]);
                            }catch(Exception e)
                            {
                                // pusty catch xddddd NIE MA ŻADNEGO BŁĘDU :p 
                            }
                          
                        }
                       
                        row++;

                    }
                    // Read the stream to a string, and write the string tile array.
                   
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public override void Draw()
        {
            Globals.spriteBatch.GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();
            for (int i=0;i<20;i++)
            {
                for(int j=0;j<20;j++)
                {
                 switch(Globals.tile[j,i])
                  {
                   case 0:
                            Globals.spriteBatch.Draw(texture_0, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                            break;
                   case 1:
                            Globals.spriteBatch.Draw(texture_1,new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                            break;
                   case 2:
                            Globals.spriteBatch.Draw(texture_2, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                            break;
                   case 4:
                            Globals.spriteBatch.Draw(texture_1, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                            break;
                   case 5:
                            //Globals.spriteBatch.Draw(texture_pac, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                            break;
                   case 6:
                            Globals.spriteBatch.Draw(texture_6,new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                            break;
                   case 7:
                            Globals.spriteBatch.Draw(texture_7, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                            break;
                            break;

                                       }
                }
            }
            Globals.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            Draw();
            
        }
    }
}
