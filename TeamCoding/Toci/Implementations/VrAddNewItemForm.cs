﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Mime;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Toci.Piascode.Instructions.Interfacces.Entities;

namespace TeamCoding.Toci.Implementations
{
    public class VrAddNewItemForm : Form
    {
        public TextBox InputName = new TextBox();
        public Button ConfirmButton = new Button();
        public new Button CancelButton = new Button();
        public Label TextLabel = new Label();
        private const string FormName = "TOCI TeamCoding";
        protected IDevHandledInstruction Instruction;
        protected Tuple<string, string> ItemOperation;
        
        protected  Dictionary<string, Tuple<string, string>> ItemOperationsMap = new Dictionary<string, Tuple<string, string>>()
        {
            { "class", new Tuple<string, string>("Code\\Class", ".cs")},
            { "interface", new Tuple<string, string>("Code\\Interface", ".cs")},
            { "XML File", new Tuple<string, string>("Data\\XML File", ".xml")},
            { "Text File", new Tuple<string, string>("General\\Text File", ".txt")}
        };

        public VrAddNewItemForm(IDevHandledInstruction instruction)
        {
            ConfirmButton.Click += ConfirmButton_Click;
            CancelButton.Click += CancelButton_Click;

            TextLabel.Location = new Point(5, 5);
            TextLabel.Text = "Enter " + instruction.FileType + " name:";
            TextLabel.Show();

            InputName.Location = new Point(5,20);
            InputName.Size = new Size(335, 20);

            CancelButton.Location = new Point(260, 45);
            CancelButton.Size = new Size(80, 20);

            ConfirmButton.Location = new Point(175, 45);
            ConfirmButton.Size = new Size(80, 20);

            ConfirmButton.Text = "Create";
            CancelButton.Text = "Cancel";
            
            this.Size = new Size(360,113);
            this.Text = FormName;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(InputName);
            this.Controls.Add(ConfirmButton);
            this.Controls.Add(CancelButton);
            this.Controls.Add(TextLabel);

            Instruction = instruction;
            //InputName.Text = instruction.FileName;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            ItemOperation = ItemOperationsMap[Instruction.FileType];
            try
            {
                ProjectManager.Dte.ItemOperations.AddNewItem(ItemOperation.Item1,
                    Instruction.FileName + ItemOperation.Item2);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("File exist", "Error", MessageBoxButtons.OK);
                Close();
            }
            finally
            {
                Close();
            }
        }
    }
}