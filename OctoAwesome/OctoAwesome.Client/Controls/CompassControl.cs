﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameUi;
using OctoAwesome.Client.Components;
using System;

namespace OctoAwesome.Client.Controls
{
    internal class CompassControl : Control
    {
        private Texture2D compassTexture;

        public PlayerComponent Player { get; set; }

        public CompassControl(ScreenComponent screenManager) : base(screenManager)
        {
            Player = screenManager.Player;

            compassTexture = ScreenManager.Content.Load<Texture2D>("Textures/compass");
        }

        protected override void OnDrawContent(SpriteBatch batch, Rectangle contentArea, GameTime gameTime, float alpha)
        {
            float compassValue = Player.ActorHost.Angle / (float)(2 * Math.PI);
            compassValue %= 1f;
            if (compassValue < 0)
                compassValue += 1f;

            int offset = (int)(compassTexture.Width * compassValue);
            offset -= contentArea.Width / 2;
            int offsetY = (-compassTexture.Height - contentArea.Height) / 2;

            batch.Draw(compassTexture, contentArea, new Rectangle(offset, offsetY, contentArea.Width, contentArea.Height), Color.White);
        }
    }
}
