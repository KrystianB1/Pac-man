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
        Texture2D packman_right;
        Texture2D monster_red;
        Texture2D monster_orange;
        Texture2D monster_cyan;
        Texture2D monster_pink;

        AnimatedSprite animated_packman_right;
        AnimatedSprite animated_monster_red;
        AnimatedSprite animated_monster_orange;
        AnimatedSprite animated_monster_cyan;
        AnimatedSprite animated_monster_pink;
        Vector2 position = new Vector2(100,100);
        private bool load;
        public Menu()
        {
            load = true;
            menutexture= Globals.contentManager.Load<Texture2D>("menuback");
            packman_right = Globals.contentManager.Load<Texture2D>("pac");

            monster_red = Globals.contentManager.Load<Texture2D>("monster_red");
            monster_pink = Globals.contentManager.Load<Texture2D>("monster_pink");
            monster_orange = Globals.contentManager.Load<Texture2D>("monster_orange");
            monster_cyan = Globals.contentManager.Load<Texture2D>("monster_cyan");

            animated_packman_right = new AnimatedSprite(packman_right, 1, 3);
            animated_monster_red = new AnimatedSprite(monster_red, 1, 2);
            animated_monster_pink = new AnimatedSprite(monster_pink, 1, 2);
            animated_monster_orange = new AnimatedSprite(monster_orange, 1, 2);
            animated_monster_cyan = new AnimatedSprite(monster_cyan, 1, 2);
            
        }
        private enum menu_state  {
            PLAY_GAME,
            SCORE
       
            }

        public override void Update(GameTime gameTime)
        {
            animated_packman_right.Update();
            animated_monster_red.Update();
            animated_monster_orange.Update();
            animated_monster_pink.Update();
            animated_monster_cyan.Update();
            Draw();  
        }
        public override void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(menutexture, new Rectangle(0, 0, 600, 600), Color.White);
            animated_packman_right.Draw(new Vector2(190, 100));
            animated_monster_red.Draw(new Vector2(220, 100));
            animated_monster_orange.Draw(new Vector2(260, 100));
            animated_monster_pink.Draw(new Vector2(300, 100));
            animated_monster_cyan.Draw(new Vector2(340, 100));
       
                foreach (menu_state get_string_menu in (menu_state[])Enum.GetValues(typeof(menu_state))) // to do poprawki jest bo dodaje cały czas z enuma a dziś juz nie myśle xd
                {
               
                    Globals.spriteBatch.DrawString(Globals.spriteFontMenu, get_string_menu.ToString(), position, Color.Red);
                    position.Y += Globals.spriteFontMenu.LineSpacing + 2;
                    
                }
                
                
               
            
            Globals.spriteBatch.End();
            


        }

        
    }
}
