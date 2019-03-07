using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pac_man
{
    class Menu : StateTemplate
    {

        Texture2D menutexture;

        public Menu()
        {
            menutexture= Globals.contentManager.Load<Texture2D>("menuback");
        }
        private enum menu_state  {
            PLAY_GAME,
            CREDITS,
            EXIT

            }

        public override void Update(GameTime gameTime)
        {
            
            Draw();  
        }
        public override void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(menutexture, new Rectangle(0, 0, 600, 600), Color.White);
            Globals.spriteBatch.End();


        }
    }
}
