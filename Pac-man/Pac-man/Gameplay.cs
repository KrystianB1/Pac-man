using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;

namespace Pac_man
{
    class Gameplay : StateTemplate
    {
        string[] line = new string[20];
        string levels = "Content/Levels/lvl1.txt";
        public Gameplay( )
        {
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
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            Console.WriteLine(Globals.tile[1,1]);
        }
    }
}
