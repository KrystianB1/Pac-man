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

        Texture2D wall_1;
        string[] line = new string[20];
        string levels = "Content/Levels/lvl1.txt";
        public Gameplay( )
        {
            Globals.graphics.GraphicsDevice.Clear(Color.Black);
            wall_1 = Globals.contentManager.Load<Texture2D>("1");
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
            
            Globals.spriteBatch.Begin();
            for (int i=0;i<20;i++)
            {
                for(int j=0;j<20;j++)
                {
                    if (Globals.tile[i, j] == 1)
                    {
                        Globals.spriteBatch.Draw(wall_1,new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                }
            }
            Globals.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            Draw();
            Console.WriteLine(Globals.tile[1,1]);
        }
    }
}
