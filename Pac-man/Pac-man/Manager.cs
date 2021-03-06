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
        Score score = new Score();
        RetrySaveGame retry =new RetrySaveGame();


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
                    check_colision_for_new_game();
                    game.Update(gameTime);
                    break;
                case Globals.EnStates.SCORE:
                    score.Update(gameTime);
                    break;
                case Globals.EnStates.EXIT:
                    Globals.exit = true;
                    break;
                case Globals.EnStates.RETRY:
                    retry.Update(gameTime); 
                    break;

            }



        }

        private void check_colision_for_new_game()
        {
            if (Globals.flaga_DEAD == true)
            {
                Globals.pointsList.Clear();
                Globals.pointList_collision.Clear();
                Globals.powerupList.Clear();
                Globals.powered_up_check = false;
                Globals.mapdraw = false;
                Globals.index_for_score = 0;
                game = new Gameplay();
                Globals.flaga_DEAD = false;
                Globals.flaga_STOP = false;

            }

        }
    }
}
