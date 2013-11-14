using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Return_to_Lithium.UI.Screens;

namespace Return_to_Lithium.UI.Screen_Manager
{
    class GameEntity
    {
        //properties
        public Vector2 Position {get; set;}    //relative to root frame. (USE THIS ONE FOR GAME CODE)
        private Vector2 _Position;             //relative to current frame

        public Vector2 Length;      //x = width etc.
        public Texture2D Texture;

        public bool isCycleSelectable { get; set; }

        public event EventHandler<PlayerIndexEventArgs> Click;//inc tap
        public event EventHandler<PlayerIndexEventArgs> MouseOn;
        public event EventHandler<PlayerIndexEventArgs> MouseOff;

        public virtual void Initialize() { }
        public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void HandleInput(InputState input) { }
        public virtual void Draw(GameTime gameTime) { }
        public virtual void Dispose() { }
    }
}
