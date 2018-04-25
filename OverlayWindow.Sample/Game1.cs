using Microsoft.Win32;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OverlayWindow.Sample
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : OverlayGame
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D icon;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = GetScreenBounds().Width;
            graphics.PreferredBackBufferHeight = GetScreenBounds().Height;
            graphics.ApplyChanges();
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, System.EventArgs e)
        {
            graphics.PreferredBackBufferWidth = GetScreenBounds().Width;
            graphics.PreferredBackBufferHeight = GetScreenBounds().Height;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            icon = Content.Load<Texture2D>("Icon");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            EnsureTopMost();
            GraphicsDevice.Clear(Color.Transparent);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            Vector2 center = new Vector2(Window.ClientBounds.Width / 2f, Window.ClientBounds.Height / 2f);
            Vector2 origin = new Vector2(icon.Width / 2f, icon.Height / 2f);
            spriteBatch.Draw(icon, center, null, new Color(Color.White, 128), 0, origin, 1, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
