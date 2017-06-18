﻿//------------------------------------------------------------------------------
// <copyright file="TeamCodingToolbarSCMDisconnectButton.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Drawing;
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
        public Button ListeningButton = new Button();
        public Button ConnectButton = new Button();
        public Button DisconnectButton = new Button();
	    public new Button CancelButton = new Button();
        private VrCommandsManager vrCommandsManager;
        private const string FormName = "TOCI TeamCoding";
	    public Form _form;

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
	        _form = new Form();
			var instruction = new DevHandledInstruction(){FileType = "interface",FileName = "oleoleole", FileContent = ""};
            var form = new VrAddNewItemForm(instruction);
            form.Show();

            ConnectButton.Click += ConnectButton_Click;
            ListeningButton.Click += ListeningButton_Click;
            CancelButton.Click += CancelButton_Click;
            DisconnectButton.Click += DisconnectButton_Click;  

            ConnectButton.Size = new Size(80,25);
            ConnectButton.ClientSize = ConnectButton.Size;
            ConnectButton.Location = new Point(10,10);
            ConnectButton.Text = "Connect";

            ListeningButton.Size = new Size(80,25);
            ListeningButton.ClientSize = ListeningButton.Size;
            ListeningButton.Location = new Point(100,10);
            ListeningButton.Text = "Listening";
            
            DisconnectButton.Size = new Size(80,25);
            DisconnectButton.ClientSize = DisconnectButton.Size;
            DisconnectButton.Location = new Point(190,10);
            DisconnectButton.Text = "Disconnect";

            CancelButton.Size = new Size(80,25);
            CancelButton.ClientSize = CancelButton.Size;
            CancelButton.Location = new Point(100,40);
            CancelButton.Text = "Cancel";
            
            _form.Text = FormName;
			_form.Size = new Size(282,72);
			_form.StartPosition = FormStartPosition.CenterScreen;
			_form.ClientSize = _form.Size;
			_form.Controls.Add(ConnectButton);
			_form.Controls.Add(ListeningButton);
			_form.Controls.Add(CancelButton);
			_form.Controls.Add(DisconnectButton);

			_form.Show();
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            BroadcastManager.StopSCMClient();
			_form.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
			_form.Close();
        }

        private void ListeningButton_Click(object sender, EventArgs e)
        {
            vrCommandsManager = new VrCommandsManager();
            vrCommandsManager.Register();
			_form.Close();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            BroadcastManager.StartSCMClient();
			_form.Close();
        }
    }
}
