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

        Texture2D menutexture,packman;
        AnimatedSprite animated;

        public Menu()
        {
            menutexture= Globals.contentManager.Load<Texture2D>("menuback");
            packman = Globals.contentManager.Load<Texture2D>("pac");
            animated = new AnimatedSprite(packman, 1, 3);
        }
        private enum menu_state  {
            PLAY_GAME,
            CREDITS,
            EXIT

            }

        public override void Update(GameTime gameTime)
        {
            animated.Update();
            Draw();  
        }
        public override void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(menutexture, new Rectangle(0, 0, 600, 600), Color.White);
            animated.Draw(new Vector2(300, 300));
            Globals.spriteBatch.End();


        }
    }
}
