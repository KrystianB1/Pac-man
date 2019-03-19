﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Pac_man
{
    static public class Globals
    {

        public static bool exit = false;

        public static SpriteFont spriteFontMenu = null;
        public static SpriteFont spriteFontScore = null;
        public static SpriteBatch spriteBatch = null;
        public static ContentManager contentManager = null;
        public static GraphicsDeviceManager graphics = null;

        public static int test_variable = 1;

        public static EnStates currentState;
        public enum EnStates
        {
            SPLASH,
            MENU,
            START,
            SCORE,
            EXIT
        }


        public enum enPowerUpType
        {
            
            BONUS_POINT_GET_BALL
        }


        public static int[,] tile = new int[20, 20];  

    }
}
