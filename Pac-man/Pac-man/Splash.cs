using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pac_man
{
    class Splash : StateTemplate
    {
        Texture2D splash,load;
        private int full = 0;
        private double procent = 0.0;
        private int speed = 10;
        private int dark = 0;
        public Splash()
        {
            
            splash = Globals.contentManager.Load<Texture2D>("splash");
            load = Globals.contentManager.Load<Texture2D>("progess_bar");


        }


        public override void Update(GameTime gameTime)
        {
            

            if (full >= 402)
            {
                dark += 10;
                if (dark >= 255)
                {
                    Globals.currentState = Globals.EnStates.MENU;
                }

               
            }
            else
            {
                procent = full / 400.0 * 100;
                full += speed;
            }
            
            Draw();
        }
        public override void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(splash, new Rectangle(0, 0, 600, 600), Color.White);
            Globals.spriteBatch.Draw(load, new Rectangle(100, 400, full, 10), Color.White);
            Globals.spriteBatch.DrawString(Globals.spriteFontMenu, Convert.ToInt32(procent) + " %", new Vector2(260,420),Color.White);
            if(dark>0) Globals.spriteBatch.Draw(splash, new Rectangle(0, 0, 600, 600), new Color(Color.Black, dark));

            Globals.spriteBatch.End();
        }
    }
}
