using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Return_to_Lithium.UI.Screens
{
    class PrototypeMenuScreen : MenuScreen
    {
         #region Initialization
        public PrototypeMenuScreen()
            : base("Prototype Screens")
        {
            // Create our menu entries.
            MenuEntry shipDisplayMenuEntry = new MenuEntry("Ship Display");
            MenuEntry exitMenuEntry = new MenuEntry("Back");

            // Hook up menu event handlers.
            shipDisplayMenuEntry.Selected += ShipDisplayMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(shipDisplayMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }
        #endregion

        #region Handle Input
        void ShipDisplayMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            //LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,  new PrototypeShipDisplayScreen());
            ScreenManager.AddScreen(new PrototypeShipDisplayScreen(), e.PlayerIndex);
        }

        protected override void OnCancel(PlayerIndex playerIndex)
        {
            LoadingScreen.Load(ScreenManager, false, null, new BackgroundScreen(),
                                                           new MainMenuScreen());
        }
        #endregion
    }
}
