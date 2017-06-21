using System;
using System.Drawing;
using System.Windows.Forms;

namespace TeamCoding.Toci.Implementations
{
	public class VrPluginForm : Form
	{
		public Button ListeningButton = new Button();
		public Button ConnectButton = new Button();
		public Button DisconnectButton = new Button();
		public new Button CancelButton = new Button();
		private const string FormName = "TOCI TeamCoding";
		private VrCommandsManager vrCommandsManager;


		public VrPluginForm()
		{
			ConnectButton.Click += ConnectButton_Click;
			ListeningButton.Click += ListeningButton_Click;
			CancelButton.Click += CancelButton_Click;
			DisconnectButton.Click += DisconnectButton_Click;

			ConnectButton.Size = new Size(80, 25);
			ConnectButton.ClientSize = ConnectButton.Size;
			ConnectButton.Location = new Point(10, 10);
			ConnectButton.Text = "Connect";

			ListeningButton.Size = new Size(80, 25);
			ListeningButton.ClientSize = ListeningButton.Size;
			ListeningButton.Location = new Point(100, 10);
			ListeningButton.Text = "Listening";

			DisconnectButton.Size = new Size(80, 25);
			DisconnectButton.ClientSize = DisconnectButton.Size;
			DisconnectButton.Location = new Point(190, 10);
			DisconnectButton.Text = "Disconnect";

			CancelButton.Size = new Size(80, 25);
			CancelButton.ClientSize = CancelButton.Size;
			CancelButton.Location = new Point(100, 40);
			CancelButton.Text = "Cancel";

			this.Text = FormName;
			this.Size = new Size(282, 72);
			this.StartPosition = FormStartPosition.CenterScreen;
			this.ClientSize = this.Size;
			this.Controls.Add(ConnectButton);
			this.Controls.Add(ListeningButton);
			this.Controls.Add(CancelButton);
			this.Controls.Add(DisconnectButton);

		}

		private void DisconnectButton_Click(object sender, EventArgs e)
		{
			BroadcastManager.StopSCMClient();
			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ListeningButton_Click(object sender, EventArgs e)
		{
			vrCommandsManager = new VrCommandsManager();
			vrCommandsManager.Register();
			this.Close();
		}

		private void ConnectButton_Click(object sender, EventArgs e)
		{
			BroadcastManager.StartSCMClient();
			this.Close();
		}
	}
}