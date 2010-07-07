using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace myDb
{
    public partial class Create : MyForm
    {
        private System.Collections.Generic.List<System.Windows.Forms.ComboBox> enums;

        //bolo by pekne..vyzistit!
        private System.Windows.Forms.Label warn;
        private System.Windows.Forms.Label warnLabel;

        public Create()
        {
            InitializeComponent();
            enums = new List<ComboBox>();
            warnLabel = new Label();
            warnLabel.Text = "";
            warnLabel.Size = new Size(0,0); //hack!

            warn = new Label();
            warn.Text = "!";

            warn.ForeColor = Color.Red;
            warn.Size = new Size(10, 20);
        }

       private void LoadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog b = new OpenFileDialog();
            b.InitialDirectory = Environment.SpecialFolder.Recent.ToString();
            b.Multiselect = true;
            b.ShowDialog();
            String s = "Subory";
            for (int i =0; i < b.FileNames.Length; i++)
                s+= "\n" + b.FileNames.GetValue(i);
            MessageBox.Show(s + "\n boli vybrane");
        }
        private void addTextAttribute_Click(object sender, EventArgs e)
        {
            Attribute attribute = new Attribute();
            addAtrribute(attribute);
        }

        void addAtrribute(Attribute att)
        {
            int x = 10, y = 10;
            if (this.definitionPanel.Controls.Count >0)
            {
                y += this.definitionPanel.Controls[0].Size.Height*this.definitionPanel.Controls.Count;
            }
            att.Parent = this;
            att.setPositions();
            att.Location = new Point(x, y);
            this.definitionPanel.Controls.Add(att);
            this.definitionPanel.ResumeLayout();
        }
        private void addInteger_Click(object sender, EventArgs e)
        {
            AttributeInteger att = new AttributeInteger();
            addAtrribute(att);
        }

        private void createEnum_Click(object sender, EventArgs e)
        {
            using (CreateEnum en = new CreateEnum())
            {
                en.ShowDialog();
                if (en.endCode() == 0)
                    return;
                this.definedEnums.Items.Add(en.getName());
                ComboBox b = new ComboBox();
                b.Items.AddRange(en.getValues());
                enums.Add(b);
                if (definedEnums.Items.Count > 0)
                    definedEnums.SelectedIndex = 0;
            }
        }

        private void removeEnum_Click(object sender, EventArgs e)
        {
            if (definedEnums.Items.Count == 0)
                return;
            int index = definedEnums.SelectedIndex;
            definedEnums.Items.RemoveAt(index);
            enums.RemoveAt(index);
            if (definedEnums.Items.Count > 0)
                definedEnums.SelectedIndex = 1;
        }

        private void addEnum_Click(object sender, EventArgs e)
        {
            if (definedEnums.Items.Count == 0)
                return;
            AttributeEnum en = new AttributeEnum(enums[definedEnums.SelectedIndex]);
            en.Name = (string) definedEnums.Items[definedEnums.SelectedIndex];
            addAtrribute(en);
        }

        private void addImage_Click(object sender, EventArgs e)
        {
            AttributeImage im = new AttributeImage();
            addAtrribute(im);
        }

        private void addTime_Click(object sender, EventArgs e)
        {
            AttributeTime t = new AttributeTime();
            addAtrribute(t);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            //check for all attributed to be correct
            if (this.definitionPanel.Controls.Count == 0)
                return; //new meesage - warning!
            //check for name duplicity
            for (int i = 0; i < this.definitionPanel.Controls.Count; i++)
            {
                Attribute a = (Attribute)this.definitionPanel.Controls[i];
                string s = a.getName();
                for (int j = i + 1; j < this.definitionPanel.Controls.Count; j++)
                {
                    if (((Attribute)this.definitionPanel.Controls[j]).getName().Equals(s))
                    {
                        MessageBox.Show("Two attributes with same name! <"+ s +">");
                        return;
                    }
                }
            }
            bool ok = true;
            for (int i = 0; i < this.definitionPanel.Controls.Count; i++)
            {
                Attribute a = (Attribute) this.definitionPanel.Controls[i];
                //a.Controls.Remove(warnLabel);
                //a.Controls.Remove(warn);
                a.ForeColor = Color.Empty;
                if (a.isMandatory() && a.getDefault().Equals(""))
                {
                    ok = false;
                    a.ForeColor = Color.Firebrick;
                }
            }
            if (!ok)
                return;
            string name = dbName.Text + ".mydb";
            if (dbName.Equals("") || File.Exists(name))
            {
                MessageBox.Show("File already exists!");
                return;
            }

            StreamWriter stream = new StreamWriter(name);
            foreach (Attribute att in this.definitionPanel.Controls)
            {
                att.save(stream);
            }
            stream.Close();
            TextWriter tw = new StreamWriter(this.dbName.Text+".mydb");
            foreach (Attribute a in this.definitionPanel.Controls)
                a.save(tw);
            this.Close();
        }
    }
}
