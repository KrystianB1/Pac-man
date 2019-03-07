using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pac_man
{
   
    public class Game1 : Game
    {
        Manager manger;
        public Game1()
        {
            Globals.currentState = Globals.EnStates.SPLASH;
            Globals.contentManager = Content;
            Globals.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals.graphics.PreferredBackBufferHeight = 600;
            Globals.graphics.PreferredBackBufferWidth = 600;
            Globals.graphics.ApplyChanges();
            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.spriteFontMenu= Content.Load<SpriteFont>("font");
            manger = new Manager();
            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            if(Globals.exit)
            {
                Exit();

            }
            manger.Update();


            base.Update(gameTime);
        }

      
    }
}
