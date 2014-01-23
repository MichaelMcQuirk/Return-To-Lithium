using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Return_to_Lithium.UI.Screen_Manager;

namespace Return_to_Lithium.UI.Components
{
    class GE_Label : GameEntity
    {
        string Text
        {
            get { return Text; }
            set { Text = value; }
        }

        public override void Update(GameTime gameTime) { base.Update(gameTime); }
        
        public override void Draw(GameTime gameTime) 
        { 
            base.Draw(gameTime);


            //// Draw the selected entry in yellow, otherwise white.
            //Color color = isSelected ? Color.Yellow : Color.White;

            //// Pulsate the size of the selected menu entry.
            //double time = gameTime.TotalGameTime.TotalSeconds;

            //float pulsate = (float)Math.Sin(time * 6) + 1;

            //float scale = 1 + pulsate * 0.05f * selectionFade;

            //// Modify the alpha to fade text out during transitions.
            //color *= screen.TransitionAlpha;

            //// Draw text, centered on the middle of each line.
            //ScreenManager screenManager = screen.ScreenManager;
            //SpriteBatch spriteBatch = screenManager.SpriteBatch;
            //SpriteFont font = screenManager.Font;

            //Vector2 origin = new Vector2(0, font.LineSpacing / 2);
            //spriteBatch.DrawString(font, text, position, color, 0,
            //                       origin, scale, SpriteEffects.None, 0);
        
        }

        public GE_Label(GameScreen screen, string text):
            base(screen,"",0,0,0,0,"","")
        {
            Text = text;
        }
        
        //ublic GE_Label 
    }
}
