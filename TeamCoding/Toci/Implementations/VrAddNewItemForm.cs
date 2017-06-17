using System.Drawing;
using System.Windows.Forms;
using Toci.Piascode.Instructions.Interfacces.Entities;

namespace TeamCoding.Toci.Implementations
{
    public class VrAddNewItemForm : Form
    {
        public TextBox InputName = new TextBox();
        public Button ConfirmButton = new Button();
        protected IDevHandledInstruction Instruction;

        public VrAddNewItemForm(IDevHandledInstruction instruction)
        {
            ConfirmButton.Click += ConfirmButton_Click;

            InputName.Location = new Point(20,12);
            ConfirmButton.Location = new Point(20,120);
            InputName.Size = new Size(50, 20);
            ConfirmButton.Size = new Size(50, 20);

            this.Controls.Add(InputName);
            Controls.Add(ConfirmButton);

            Instruction = instruction;
            InputName.Text = instruction.FileName;
        }

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            string type = "Code\\class";
            if (Instruction.FileType == "interface")
            {
                type = "Code\\class";
            }

            ProjectManager.Dte.ItemOperations.AddNewItem(type, InputName.Text + ".cs");
            Close();
        }
    }
}