using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Return_to_Lithium.UI.Screen_Manager
{
    /* What is a GameFrame?
     * A game frame is simply a collection of GameEntities.
     * All coordiantes of entities within are relatve to the parent frame. (So if you move the frame 2 units right, everything moves 2 units right, but their coordenates remain unchanged [relative]).
     * Manages the efficient calling of updates,draws and handleInputs for all entities within.
     * You can have multiple frames within a frame (eg a character, his health bar and his name would all be contained within a seperate frame, if you move the character frame you move all those elements).
     * Each child frame MUST be smaller than the parent.
     * Preferebly, you should have only ONE root frame per page.
     * Frames cannot rotate.
     * When drawing your frames, tell the dimenions of what you want drawn to the root frame, and it will manage the rest of the drawing process'.
     * GameEntities have a method that can return their position relative to the 
     */
    class GameFrame
    {
        private GameFrame Parent;
        private List<GameFrame> Children = new List<GameFrame>();
        private List<GameEntity> Entities = new List<GameEntity>();

        public string Name;//must be unique
        public Vector2 Position;
        public Vector2 Length;
        public Vector2 GlobalPosition
        {
            get
            {
                if (Parent != null) return Position + Parent.GlobalPosition;
                else
                    return Position;
            }
            set
            {
                Vector2 difference = value - GlobalPosition;
                if (DoesFrameContainGPos(value))
                    Position = difference;//if it is still contained within current frame
                else
                    throw new Exception("Newly assigned global position out of current frame's bounds!");
            }
        }

        #region FrameManagement
        public void Delete(bool dispose = true)
        {
            foreach (GameEntity entity in Entities)
                if (dispose)
                    entity.Dispose();
            Entities.Clear();

            foreach (GameFrame child in Children)
                child.Delete(dispose);

            if (dispose)
                Dispose();

            Parent.Children.Remove(this);
        }
        
        private bool DoesFrameContainGPos(Vector2 value)//alows for partial overlapping when left is just smaller than right edge.
        {
            Vector2 difference = value - GlobalPosition;
            return (difference.X >= 0 && difference.X <= Length.X && difference.Y >= 0 && difference.Y <= Length.Y);
        }

        public void MoveToFrame(GameFrame newHost)
        {
            this.Parent.Children.Remove(this);
            this.Parent = newHost;
            newHost.Children.Add(this);
        }

        public void MoveToFrame(string frameName)
        {
            MoveToFrame(getFrame(frameName));
        }

        private GameFrame getFrame(string frameName)
        {
            GameFrame root = this;
            while (root.Parent != null)
                root = root.Parent;
            GameFrame result = recFindFrame(root, frameName);
            if (result == null)
                throw new Exception("There is no frame by the name of '" + frameName + "'!");
            else
                return result;
        }

        private GameFrame recFindFrame(GameFrame parent, string framename)
        {
            if (parent.Name == framename)
                return parent;
            else
                foreach (GameFrame child in Children)
                {
                    GameFrame searchResult = recFindFrame(child, framename);
                    if (searchResult != null) return searchResult;
                }
            return null;
        }
        #endregion

        #region StandardMethods
        public virtual void Initialize() //why would need to initialize a frame?
        {
            foreach (GameEntity entity in Entities)
                entity.Initialize();
            foreach (GameFrame child in Children)
                child.Initialize();  
        }

        public virtual void LoadContent() 
        {
            foreach (GameEntity entity in Entities)
                entity.LoadContent();
            foreach (GameFrame child in Children)
                child.LoadContent();
        }

        public virtual void Update(GameTime gameTime) 
        {
            foreach (GameEntity entity in Entities)
                entity.Update(gameTime);
            foreach (GameFrame child in Children)
                child.Update(gameTime);
        }

        public virtual void HandleInput(InputState input) 
        {
            foreach (GameEntity entity in Entities)
                entity.HandleInput(input);
            foreach (GameFrame child in Children)
                child.HandleInput(input);
        }

        public virtual void Draw(GameTime gameTime) 
        { 
            foreach (GameEntity entity in Entities)
                entity.Draw(gameTime);
            foreach (GameFrame child in Children)
                child.Draw(gameTime);
        }

        public virtual void Dispose()
        {
            foreach (GameEntity entity in Entities)
                entity.Dispose();
            foreach (GameFrame child in Children)
                child.Dispose();
        }
        #endregion

        #region Saving&Loading
        #endregion

        #region Optomization
        //combine multiple non/partially intractable images into one to cut down on looping.
        #endregion

    }
}
