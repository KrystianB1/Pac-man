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
        public static Color highLight = new Color(255, 211, 5);
        public static Color normal = Color.Red;
        public static List<Rectangle> collisionList = new List<Rectangle>();
        public static List<Rectangle> pointsList = new List<Rectangle>();
        public static List<Rectangle> portalsList = new List<Rectangle>();
        public static int index_for_score = 0;
        public static bool mapdraw = false;
        public static EnStates currentState;
        public static Animated_State Animated_sprite;
        public static Retry_State retry_state;
        public static menu_state selectedItem;
        public static int test_left = 0;
        public static int test_right = 0;
        public static int test_up = 0;
        public static int test_down = 0;
        public enum EnStates
        {
            SPLASH,
            MENU,
            START,
            SCORE,
            RETRY,
            EXIT
        }

        public enum Animated_State
        {
            RIGHT,
            LEFT,
            UP,
            DOWN
        }

        public enum Retry_State
        {
            RETRY,
            SAVE,
            QUIT
        }
        public enum menu_state
        {
            PLAY_GAME,
            SCORE,
            QUIT
        }
        public enum enPowerUpType
        {

            BONUS_POINT_GET_BALL
        }


        public static int[,] tile = new int[34, 29];

    }
}

