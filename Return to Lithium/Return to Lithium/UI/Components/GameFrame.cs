using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Return_to_Lithium.UI.Screen_Manager;

namespace Return_to_Lithium.UI.Components
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
    class GameFrame : GameEntity
    {
        private List<GameFrame> Children = new List<GameFrame>();
        private List<GameEntity> Entities = new List<GameEntity>();

        public string Name;//must be unique - used for accessing frames by name
        public new Vector2 GlobalPosition //overrides inherited GlobalPosition Code
        {
            get
            {
                if (ParentFrame != null) return Position + ParentFrame.GlobalPosition;
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

            ParentFrame.Children.Remove(this);
        }
        
        private bool DoesFrameContainGPos(Vector2 value)//alows for partial overlapping when left is just smaller than right edge.
        {
            Vector2 difference = value - GlobalPosition;
            return (difference.X >= 0 && difference.X <= Length.X && difference.Y >= 0 && difference.Y <= Length.Y);
        }

        public void MoveToFrame(GameFrame newHost)
        {
            this.ParentFrame.Children.Remove(this);
            this.ParentFrame = newHost;
            newHost.Children.Add(this);
        }

        public void MoveToFrame(string frameName)
        {
            MoveToFrame(getFrame(frameName));
        }

        public GameFrame getFrame(string frameName)
        {
            List<GameFrame> list = new List<GameFrame>(); //an entire list of all subframes (for partial matching with levestein distancing)

            GameFrame root = this;
            while (root.ParentFrame != null)
                root = root.ParentFrame;
            GameFrame result = recFindFrame(root, frameName, ref list);

            if (result == null)
            {
                result = getClosestNameMatch(list, frameName, 3);
                //if (result != null)
                //    log("GameFrame.getFrame()","Identical match for '" + frameName + "' not found. Closest match returned: '" + result.Name + "'");
            }

            if (result == null)
                throw new Exception("There is no frame by the name of '" + frameName + "'!");
            else
                return result;
        }

        private GameFrame getClosestNameMatch(List<GameFrame> list, string target, int minTollerance)
        {
            if (list.Count == 0) return null;
            GameFrame minFrame = list[0];
            int minDist = ComputeLevenshtein(target.ToLower(), minFrame.Name.ToLower());

            foreach (GameFrame GF in list.GetRange(1,list.Count - 1))
            {
                int curDist = ComputeLevenshtein(target.ToLower(), GF.Name.ToLower());
                if (curDist < minDist)
                {
                    minDist = curDist;
                    minFrame = GF;
                }
            }

            if (minDist <= minTollerance)
                return minFrame;
            else
                return null;
        }

        private GameFrame recFindFrame(GameFrame parent, string framename, ref List<GameFrame> list)
        {
            list.Add(parent);
            if (parent.Name == framename)
                return parent;
            else
                foreach (GameFrame child in Children)
                {
                    GameFrame searchResult = recFindFrame(child, framename, ref list);
                    if (searchResult != null) return searchResult;
                }
            return null;
        }

        private int ComputeLevenshtein(string s, string t)
        {
            //http ://www.dotnetperls.com/levenshtein
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }


        #endregion

        #region StandardMethods
        public override void Initialize() //why would need to initialize a frame?
        {
            foreach (GameEntity entity in Entities)
                entity.Initialize();
            foreach (GameFrame child in Children)
                child.Initialize();  
        }

        public override void LoadContent() 
        {
            foreach (GameEntity entity in Entities)
                entity.LoadContent();
            foreach (GameFrame child in Children)
                child.LoadContent();
        }

        public override void Update(GameTime gameTime) 
        {
            foreach (GameEntity entity in Entities)
                entity.Update(gameTime);
            foreach (GameFrame child in Children)
                child.Update(gameTime);
        }

        public override void HandleInput(InputState input) 
        {
            foreach (GameEntity entity in Entities)
                entity.HandleInput(input);
            foreach (GameFrame child in Children)
                child.HandleInput(input);
        }

        public override void Draw(GameTime gameTime) 
        { 
            foreach (GameEntity entity in Entities)
                entity.Draw(gameTime);
            foreach (GameFrame child in Children)
                child.Draw(gameTime);
        }

        public override void Dispose()
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
