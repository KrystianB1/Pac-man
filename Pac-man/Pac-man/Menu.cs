using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        Vector2 position = new Vector2(200, 150);


        

        KeyboardState keyboardState;
        KeyboardState oldKeyboardState;

        float default_menu_spring_position = 0;
        int selectedIndex;

        private bool CheckKey(Keys theKey)
        {
            return keyboardState.IsKeyUp(theKey) &&
                oldKeyboardState.IsKeyDown(theKey);
        }

        public Menu()
        {
            menutexture = Globals.contentManager.Load<Texture2D>("menuback");
            packman_right = Globals.contentManager.Load<Texture2D>("monster/pac_right");

            monster_red = Globals.contentManager.Load<Texture2D>("monster/monster_red_right");
            monster_pink = Globals.contentManager.Load<Texture2D>("monster/monster_pink_right");
            monster_orange = Globals.contentManager.Load<Texture2D>("monster/monster_orange_right");
            monster_cyan = Globals.contentManager.Load<Texture2D>("monster/monster_cyan_right");

            animated_packman_right = new AnimatedSprite(packman_right, 1, 3);
            animated_monster_red = new AnimatedSprite(monster_red, 1, 2);
            animated_monster_pink = new AnimatedSprite(monster_pink, 1, 2);
            animated_monster_orange = new AnimatedSprite(monster_orange, 1, 2);
            animated_monster_cyan = new AnimatedSprite(monster_cyan, 1, 2);

        }
        

        public override void Update(GameTime gameTime)
        {
            animated_packman_right.Update();
            animated_monster_red.Update();
            animated_monster_orange.Update();
            animated_monster_pink.Update();
            animated_monster_cyan.Update();

            keyboardState = Keyboard.GetState();

            if (CheckKey(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex == Enum.GetNames(typeof(Globals.menu_state)).Length)
                    selectedIndex = 0;
            }
            if (CheckKey(Keys.Up))
            {

                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = Enum.GetNames(typeof(Globals.menu_state)).Length - 1;
            }

            if (CheckKey(Keys.Enter) || CheckKey(Keys.Space))
            {
                switch (Globals.selectedItem)
                {
                    case Globals.menu_state.PLAY_GAME:
                        Globals.currentState = Globals.EnStates.START;
                        break;
                    case Globals.menu_state.SCORE:
                        Globals.currentState = Globals.EnStates.SCORE;
                        break;
                    case Globals.menu_state.QUIT:
                        Globals.currentState = Globals.EnStates.EXIT;
                        break;
                }
            }

            oldKeyboardState = keyboardState;
            Draw();
        }
        public override void Draw()
        {
            Globals.spriteBatch.GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();
            default_menu_spring_position = position.Y;
            Globals.spriteBatch.Draw(menutexture, new Rectangle(0, 0, 600, 600), Color.White);
            animated_packman_right.Draw(new Vector2(190, 100));
            animated_monster_red.Draw(new Vector2(220, 100));
            animated_monster_orange.Draw(new Vector2(260, 100));
            animated_monster_pink.Draw(new Vector2(300, 100));
            animated_monster_cyan.Draw(new Vector2(340, 100));
            Color tint;
            foreach (Globals.menu_state get_string_menu in (Globals.menu_state[])Enum.GetValues(typeof(Globals.menu_state)))
            {
                if ((int)get_string_menu == selectedIndex)
                {
                    tint = Globals.highLight;
                    Globals.selectedItem = get_string_menu;
                }
                else
                {
                    tint = Globals.normal;
                }
                Globals.spriteBatch.DrawString(Globals.spriteFontMenu, get_string_menu.ToString(), position, tint);
                position.Y += Globals.spriteFontMenu.LineSpacing + 2;

            }
            position.Y = default_menu_spring_position;
            Globals.spriteBatch.End();
        }
    }
}
