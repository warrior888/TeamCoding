//------------------------------------------------------------------------------
// <copyright file="TeamCodingToolbarSCMDisconnectButton.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using TeamCoding.Toci.Implementations;
using Toci.Piastcode.Instructions.Entities;

namespace TeamCoding
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class TeamCodingToolbarSCMConnectButton
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 256;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("62aae97c-b7dd-41ba-bc5d-6d2901aa3852");
        //62aae97c-b7dd-41ba-bc5d-6d2901aa3852
        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamCodingToolbarSCMConnectButton"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private TeamCodingToolbarSCMConnectButton(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static TeamCodingToolbarSCMConnectButton Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new TeamCodingToolbarSCMConnectButton(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            VrAddNewItemForm form = new VrAddNewItemForm(new DevHandledInstruction());

            if (BroadcastManager.IsRunning)
            {
                VsShellUtilities.ShowMessageBox(this.ServiceProvider, "Broadcast Manager is already running", "", OLEMSGICON.OLEMSGICON_INFO,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
                return;
            }

            var response = VsShellUtilities.ShowMessageBox(this.ServiceProvider, "Do you want to start Broadcast Manager?", "", OLEMSGICON.OLEMSGICON_QUERY,
                  OLEMSGBUTTON.OLEMSGBUTTON_YESNO, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            // response values  =>  6 = yes,  7 = no, 
            if (!response.Equals(6)) return;
            BroadcastManager.StartSCMClient();
        }
    }
}
