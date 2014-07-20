using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Return_to_Lithium.UI.Screen_Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Threading;
using Return_to_Lithium.UI.Components;

namespace Return_to_Lithium.UI.Screens
{
    class PrototypeShipDisplayScreen : GameScreen
    {//Properties
        private float pauseAlpha;
        private ContentManager content;
        private List<GameEntity> entities = new List<GameEntity>();


        //Entities
        private GameEntity testEntity;
        private GameEntity testEntity2;
        private GameFrame testFrame;


        //InputHandling
        private GameEntity selectedEntity = null;
        private Point mouse_downDelta = new Point(-1, -1);

        public PrototypeShipDisplayScreen()
        {
            //----------------------------------------------
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
            //----------------------------------------------

            testEntity = new GameEntity(this, "testEntity", 0, 0, 50, 50, "background1lowres");
            testEntity2 = new GameEntity(this, "testEntity2", 100, 0, 30, 30, "background1lowres");
            testFrame = new GameFrame(this);
            testFrame.XYWH = new Rectangle(200, 0, 50, 50);
            testFrame.AddEntity(testEntity);
            testFrame.AddEntity(testEntity2);
            entities.Add(testFrame);
            entities.Add(new GameEntity(this, "testEntity3", 0, 0, 50, 50, "background1lowres"));
        }

        


        #region Update and InputHandling
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            //------------------Do-not-edit-----------------
            base.Update(gameTime, otherScreenHasFocus, false);
            if (coveredByOtherScreen)
                pauseAlpha = Math.Min(pauseAlpha + 1f / 32, 1);
            else
                pauseAlpha = Math.Max(pauseAlpha - 1f / 32, 0);
            //----------------------------------------------

            if (IsActive)
            {
                //ADD UPDATE CODE HERE:
               // Rectangle newrec = new Rectangle(testFrame.getGlobalXYWH().X, testFrame.getGlobalXYWH().Y, 50, 50);
               // newrec.Offset(new Point(1, 0));
               // testFrame.XYWH = newrec;
            }
        }

        public override void HandleInput(InputState input)
        {
            //------------------Do-not-edit-----------------
            if (input == null)
                throw new ArgumentNullException("input");
            int playerIndex = (int)ControllingPlayer.Value;
            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];
            bool gamePadDisconnected = !gamePadState.IsConnected &&
                                       input.GamePadWasConnected[playerIndex];
            if (input.IsPauseGame(ControllingPlayer) || gamePadDisconnected)
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
            //----------------------------------------------
            else
            {
                /* Examples:
                 * if (keyboardState.IsKeyDown(Keys.Left)) movement.X--;
                 * Vector2 thumbstick = gamePadState.ThumbSticks.Left;
                 *      movement.X += thumbstick.X;
                 *      movement.Y -= thumbstick.Y; */

                //ADD HANDLE INPUT CODE HERE: 



                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Point curMousePos = new Point(Mouse.GetState().X, Mouse.GetState().Y);

                    if (selectedEntity == null)
                    {
                        foreach (GameEntity curEntity in entities)
                            if (curEntity.getGlobalXYWH().Contains(curMousePos))
                            {
                                selectedEntity = curEntity;
                                mouse_downDelta = GameEntity.SubractPoints(curEntity.XYWH.Location, curMousePos);
                            }
                    }

                    if (selectedEntity != null)
                        selectedEntity.XYWH.Location = GameEntity.AddPoints(curMousePos, mouse_downDelta);
                }
                else
                {
                    selectedEntity = null;
                }
            }
        }

        
        #endregion

        #region Draw and Load : Avoid editing

        public override void LoadContent()
        {
            //------------------Do-not-edit-----------------
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");
            //----------------------------------------------
            //gameFont = content.Load<SpriteFont>("gamefont");

            //ADD LOAD CONTENT CODE HERE:

            foreach (GameEntity curEntity in entities)
                curEntity.LoadContent();

            //------------------Do-not-edit-----------------
            Thread.Sleep(1000);//remove once you actually start loading stuff. this just makes the loading screen display for a sec
            ScreenManager.Game.ResetElapsedTime();
            //----------------------------------------------

        }

        public override void Draw(GameTime gameTime)
        {
            //------------------Do-not-edit-----------------
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target, Color.DarkSlateGray, 0, 0);
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            //----------------------------------------------

            spriteBatch.Begin();
            //ADD DRAW CODE HERE (only for entities not already in entities list):

            foreach (GameEntity curEntity in entities)
                curEntity.Draw(gameTime);

            spriteBatch.End();

            //------------------Do-not-edit-----------------
            if (TransitionPosition > 0 || pauseAlpha > 0)
            {
                float alpha = MathHelper.Lerp(1f - TransitionAlpha, 1f, pauseAlpha / 2);
                ScreenManager.FadeBackBufferToBlack(alpha);
            }
            //----------------------------------------------
        }

        #endregion
    }
}
