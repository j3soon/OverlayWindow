using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace OverlayWindow
{
    public class FullScreenOverlayGame : OverlayGame
    {
        protected GraphicsDeviceManager graphics;

        public FullScreenOverlayGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = GetVirtualScreenAreaSize().Width;
            graphics.PreferredBackBufferHeight = GetVirtualScreenAreaSize().Height;
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, System.EventArgs e)
        {
            graphics.PreferredBackBufferWidth = GetVirtualScreenAreaSize().Width;
            graphics.PreferredBackBufferHeight = GetVirtualScreenAreaSize().Height;
            graphics.ApplyChanges();
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);
            SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // May cause impact on performance.
            // But it can force form size to change when changing projection mode (Win + P).
            Form frm = (Form)Control.FromHandle(Window.Handle);
            frm.Size = GetVirtualScreenArea().Size;
            base.Update(gameTime);
        }
    }
}
