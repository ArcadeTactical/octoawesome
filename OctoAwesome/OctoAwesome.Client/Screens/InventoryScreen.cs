﻿using Microsoft.Xna.Framework.Graphics;
using MonoGameUi;
using OctoAwesome.Client.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace OctoAwesome.Client.Screens
{
    internal sealed class InventoryScreen : Screen
    {
        private PlayerComponent player;

        public InventoryScreen(ScreenComponent manager) : base(manager)
        {
            player = manager.Player;
            IsOverlay = true;

            Texture2D panelBackground = manager.Content.Load<Texture2D>("Textures/panel");
            Background = NineTileBrush.FromSingleTexture(panelBackground, 30, 30);

            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
            Width = 600;
            Height = 400;

            Label headLine = new Label(manager);
            headLine.Text = "Inventory";
            headLine.Font = Skin.Current.HeadlineFont;
            headLine.HorizontalAlignment = HorizontalAlignment.Left;
            headLine.VerticalAlignment = VerticalAlignment.Top;
            Controls.Add(headLine);

            Button closeButton = Button.TextButton(Manager, "Close");
            closeButton.LeftMouseClick += (s, e) => { Manager.NavigateBack(); };
            Controls.Add(closeButton);


            //counter = new LabelControl(ScreenManager)
            //{
            //    Font = ScreenManager.NormalText,
            //    Color = Color.Black,
            //    Position = new Index2(((ScreenManager.ScreenSize.X - 600) / 2) + 100,
            //        ((ScreenManager.ScreenSize.Y - 400) / 2) + 140),
            //};
            //Controls.Add(counter);
        }

        protected override void OnKeyPress(KeyEventArgs args)
        {
            if (args.Key == Microsoft.Xna.Framework.Input.Keys.Escape)
            {
                args.Handled = true;
                Manager.NavigateBack();
            }
        }
    }
}
