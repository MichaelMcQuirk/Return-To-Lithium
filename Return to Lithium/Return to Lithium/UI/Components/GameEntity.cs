using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Return_to_Lithium.UI.Screens;
using Return_to_Lithium.UI.Screen_Manager;

namespace Return_to_Lithium.UI.Components
{
    class GameEntity
    {
        //properties
        public GameFrame ParentFrame;

        public Vector2 GlobalPosition        //relative to root frame. (USE THIS ONE FOR GAME CODE)
            { get { return ParentFrame.GlobalPosition + Position; } set { Position = value - ParentFrame.GlobalPosition; } }   
        
        public Vector2 Position;             //relative to current frame
        public Vector2 Length;      //x = width etc.
        public Texture2D Texture;

        private float selectionFade;
        public bool isSelected;

        public bool isCycleSelectable { get; set; }

        public event EventHandler<PlayerIndexEventArgs> Click;//inc tap
        public event EventHandler<PlayerIndexEventArgs> MouseOver;
        public event EventHandler<PlayerIndexEventArgs> MouseOff;
        public event EventHandler<PlayerIndexEventArgs> CycleSelect;
        public event EventHandler<PlayerIndexEventArgs> CycleDeselect;

        public virtual void Initialize() { }
        public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void HandleInput(InputState input) { }
        public virtual void Draw(GameTime gameTime) { }
        public virtual void Dispose() { }

        private void UpdateFadeParams(GameTime gameTime)
        {
            float fadeSpeed = (float)gameTime.ElapsedGameTime.TotalSeconds * 4;

            if (isSelected)
                selectionFade = Math.Min(selectionFade + fadeSpeed, 1);
            else
                selectionFade = Math.Max(selectionFade - fadeSpeed, 0);
        }
        public virtual void getDrawFadeParams(GameTime gameTime, GameScreen screen, out float scale, out Color color)
        {
            // Draw the selected entry in yellow, otherwise white.
            color = isSelected ? Color.Yellow : Color.White;

            // Pulsate the size of the selected menu entry.
            double time = gameTime.TotalGameTime.TotalSeconds;

            float pulsate = (float)Math.Sin(time * 6) + 1;

            scale = 1 + pulsate * 0.05f * selectionFade;

            // Modify the alpha to fade text out during transitions.
            color *= screen.TransitionAlpha;

            //// Draw text, centered on the middle of each line.
            //ScreenManager screenManager = screen.ScreenManager;
            //SpriteBatch spriteBatch = screenManager.SpriteBatch;
            //SpriteFont font = screenManager.Font;

            //Vector2 origin = new Vector2(0, font.LineSpacing / 2);

            //spriteBatch.DrawString(font, text, position, color, 0,
            //                       origin, scale, SpriteEffects.None, 0);
        }
    }
}
