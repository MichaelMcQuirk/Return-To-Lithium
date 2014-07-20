using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Return_to_Lithium.UI.Screens;
using Return_to_Lithium.UI.Screen_Manager;
using Microsoft.Xna.Framework.Content;

namespace Return_to_Lithium.UI.Components
{
    class GameEntity
    {
        //properties
        public GameFrame ParentFrame;

        public string Name;
        private static int EntityCount = 0;
        public bool Visible = true;

        public Rectangle getGlobalXYWH()
        {
                if (ParentFrame != null)
                {
                    Rectangle result = new Rectangle(XYWH.X, XYWH.Y, XYWH.Width, XYWH.Height);
                    result.Offset(ParentFrame.getGlobalXYWH().Location);
                    return result;
                }
                else
                    return XYWH;
        } 
        
        public Rectangle XYWH;
        public Texture2D Texture;
        public Texture2D Texture_Selected;
        private string Texture_Loci;
        private string Texture_Selected_Loci;

        private GameScreen Screen;
        private static ContentManager Content;

        private float selectionFade;
        public bool isSelected;

        public bool isCycleSelectable;

        public event EventHandler<PlayerIndexEventArgs> Click;//inc tap
        public event EventHandler<PlayerIndexEventArgs> MouseOver;
        public event EventHandler<PlayerIndexEventArgs> MouseOff;
        public event EventHandler<PlayerIndexEventArgs> CycleSelect;
        public event EventHandler<PlayerIndexEventArgs> CycleDeselect;

        public GameEntity(GameScreen screen, string name, int PosX, int PosY, int Width, int Height, string textureLoci, string textureSelectedLoci = "")
        {
            EntityCount++;

            Name = name;
            if (Name == "") Name = EntityCount.ToString();

            Screen = screen;
            Texture_Loci = textureLoci;
            Texture_Selected_Loci = textureSelectedLoci;

            if (Texture_Selected_Loci != "")
                isCycleSelectable = true;
            else
                isCycleSelectable = false;

            XYWH = new Rectangle(PosX, PosY, Width, Height);
            selectionFade = 0;
            isSelected = false;
        }

        public virtual void Initialize() { }

        public virtual void LoadContent()
        {
            if (Content == null)
                Content = new ContentManager(Screen.ScreenManager.Game.Services, "Content");

            if (Texture == null && Texture_Loci != "") Texture = Content.Load<Texture2D>(Texture_Loci);
            if (Texture_Selected == null && Texture_Selected_Loci != "") Texture_Selected = Content.Load<Texture2D>(Texture_Selected_Loci);
        }

        public virtual void Update(GameTime gameTime) { }

        public virtual void HandleInput(InputState input) { }

        public virtual void Draw(GameTime gameTime) 
        {
            ScreenManager screenManager = Screen.ScreenManager;
            SpriteBatch spriteBatch = screenManager.SpriteBatch;

            if (Texture_Selected != null) spriteBatch.Draw(Texture_Selected, new Rectangle(getGlobalXYWH().X, getGlobalXYWH().Y, XYWH.Width, XYWH.Height), Color.Red);
            else
                if (Texture != null) spriteBatch.Draw(Texture, new Rectangle(getGlobalXYWH().X, getGlobalXYWH().Y, XYWH.Width, XYWH.Height), Color.Red);
        }     

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

        public static Point SubractPoints(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Point AddPoints(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
    }
}
