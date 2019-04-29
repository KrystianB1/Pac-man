using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pac_man
{
    class RetrySaveGame : StateTemplate
    {
       
        Vector2 position = new Vector2(250, 200);
        KeyboardState keyboardState;
        KeyboardState oldKeyboardState;
        int selectedIndex;
        float default_menu_spring_position = 0;

        public override void Draw()
        {
            Globals.spriteBatch.GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();
            default_menu_spring_position = position.Y;
            Color tint;
            foreach (Globals.Retry_State get_string_menu in (Globals.Retry_State[])Enum.GetValues(typeof(Globals.Retry_State)))
            {
                if ((int)get_string_menu == selectedIndex)
                {
                    tint = Globals.highLight;
                    Globals.retry_state = get_string_menu;
                }
                else
                {
                    tint = Globals.normal;
                }
                Globals.spriteBatch.DrawString(Globals.spriteFontMenu, get_string_menu.ToString(), position, tint);
                position.Y += Globals.spriteFontMenu.LineSpacing + 5;

            }
            position.Y = default_menu_spring_position;
            Globals.spriteBatch.End();
        }
        private bool CheckKey(Keys theKey)
        {
            return keyboardState.IsKeyUp(theKey) &&
                oldKeyboardState.IsKeyDown(theKey);
        }

        public override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (CheckKey(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex == Enum.GetNames(typeof(Globals.Retry_State)).Length)
                    selectedIndex = 0;
            }
            if (CheckKey(Keys.Up))
            {

                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = Enum.GetNames(typeof(Globals.Retry_State)).Length - 1;
            }

            if (CheckKey(Keys.Enter) || CheckKey(Keys.Space))
            {
                switch (Globals.retry_state)
                {
                    case Globals.Retry_State.RETRY:
                        Globals.currentState = Globals.EnStates.START;
                        break;
                    case Globals.Retry_State.SAVE:

                        break;
                    case Globals.Retry_State.QUIT:
                        Globals.currentState = Globals.EnStates.MENU;
                        break;
                }
            }

            oldKeyboardState = keyboardState;
            Draw();
            
        }
    }

   

}
