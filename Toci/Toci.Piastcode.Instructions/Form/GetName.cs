using System.Drawing;
using System.Windows.Forms;

namespace Toci.Piastcode.Instructions.Form
{
    public static class GetName
    {
        
        public static string GetStringFromForm()
        {
            System.Windows.Forms.Form _form;
            string text = "";
            using (_form = new System.Windows.Forms.Form() { Width = 300, Height = 125 })
            {
                _form.Text = "TOCI TeamCoding";
                _form.Controls.Add(new TextBox() { Text = "", Name = "tb", Width = 200, Location = new Point(50, 20) });
                _form.Controls.Add(new Button() { Name = "bt", Text = "OK", Width = 50, Location = new Point(125, 50) });

                _form.ShowDialog();

            }


            return text;
        }


    }
}