﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man
{
    class Manager
    {
        private GameTime gameTime;
        Menu menu = new Menu();
        Splash splash = new Splash();
        Gameplay game = new Gameplay();

        public Manager()
        {
            gameTime = new GameTime();
        }

        public void Update()
        {
            switch (Globals.currentState)
            {
                case Globals.EnStates.SPLASH:
                    splash.Update(gameTime);
                    break;
                case Globals.EnStates.MENU:
                    menu.Update(gameTime);
                    break;
                case Globals.EnStates.START:
                    game.Update(gameTime);
                    break;
                case Globals.EnStates.EXIT:
                    Globals.exit = true;
                    break;

            }
        }
    }
}
