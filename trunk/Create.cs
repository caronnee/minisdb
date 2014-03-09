﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Minis
{
    public interface AttributeRegister
    {
        void RegisterAttribute(AbstractAttribute attr);
    };
    public partial class Create : Form
    {
        //bolo by pekne..vyzistit!
        private System.Windows.Forms.Label warn;
        private System.Windows.Forms.Label warnLabel;
        public Create()
        {
            InitializeComponent();
            //Create_Resize(null, null);
            //this.Resize += new EventHandler(Create_Resize);
            enums = new List<ComboBox>();
            warnLabel = new Label();
            warnLabel.Text = "";
            warnLabel.Size = new Size(0, 0); //hack!

            warn = new Label();
            warn.Text = "!";

            warn.ForeColor = Color.Red;
            warn.Size = new Size(10, 20);

            //inicializuj enumy
            loadEnums();
        }
        //void Create_Resize(object sender, EventArgs e)
        //{
        //    this.definitionPanel.Size = new Size(
        //        -this.definitionPanel.Location.X + this.addEnum.Location.X - 10,
        //        -this.definitionPanel.Location.Y + this.cancelButton.Location.Y - 10);
        //}
        //private void LoadFromFile_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog b = new OpenFileDialog();
        //    b.InitialDirectory = Environment.SpecialFolder.Recent.ToString();
        //    b.Multiselect = true;
        //    DialogResult res = b.ShowDialog();
        //    //  String s = "Subory";
        //    if (res.Equals(DialogResult.Cancel))
        //        return;
        //    chosen.Text = "";
        //    for (int i = 0; i < b.FileNames.Length; i++)
        //        chosen.Text += ";" + b.FileNames.GetValue(i);
        //    //   s += "\n" + b.FileNames.GetValue(i);
        //    //   MessageBox.Show(s + "\n boli vybrane");
        //}
        private void addTextAttribute_Click(object sender, EventArgs e)
        {
            Attribute attribute = new Attribute();
            addAtrribute(attribute);
        }
        public void remove(AbstractAttribute a)
        {
            this.definitionPanel.Controls.Remove((Control)a);

            //zase TAK moc tam tych atributov nebude
            int actualX = 10;
            int actualY = 10;
            for (int i = 0; i < this.definitionPanel.Controls.Count; i++)
            {
                this.definitionPanel.Controls[i].Location = new System.Drawing.Point(actualX, actualY);
                actualY += this.definitionPanel.Controls[i].Height;
            }
            this.ResumeLayout();
        }
        private void addAtrribute(AbstractAttribute att)
        {
            RecordsManager.AddToActive(att);
            att.close += new AbstractAttribute.Handler(this.remove);
            int x = 10, y = 10;
            if (this.definitionPanel.Controls.Count > 0)
            {
                y += this.definitionPanel.Controls[0].Size.Height * this.definitionPanel.Controls.Count;
            }
            att.Parent = this;
            att.setPositions();
            att.Location = new Point(x, y);
            this.definitionPanel.Controls.Add(att);
            this.definitionPanel.ResumeLayout();
        }

        private void loadEnums()
        {
            List<string> l = RecordsManager.FindEnumNames();
            if (l == null)
                return;
            foreach (string s in l)
            {
                string[] strs = s.Split(new char[] { Misc.Deliminer }, StringSplitOptions.RemoveEmptyEntries);
                this.definedEnums.Items.Add(strs[0]);
                ComboBox b = new ComboBox();
                b.Items.AddRange(strs);
                b.Items.Remove(strs[0]);
                this.enums.Add(b);
            }
            if (definedEnums.Items.Count > 0)
                definedEnums.SelectedIndex = 0;
            else
                definedEnums.Enabled = false;
        }
        private void addInteger_Click(object sender, EventArgs e)
        {
            AttributeInteger att = new AttributeInteger();
            addAtrribute(att);
        }
        private void createEnum_Click(object sender, EventArgs e)
        {
            //using (CreateEnum en = new CreateEnum())
            {
                //TODO change
                //en.ShowDialog();
                //if (en.endCode() == Forms.FormEnd)
                //    return;
                //this.definedEnums.Items.Add(en.getName());
                //ComboBox b = new ComboBox();
                //b.Items.AddRange(en.getValues());
                //enums.Add(b);
                //if (definedEnums.Items.Count > 0)
                //    definedEnums.SelectedIndex = 0;
            }
        }
        private void removeEnum_Click(object sender, EventArgs e) //TODO zkontrolovat ostatnee db, ci h pouzivaju/ask db to recreate
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
            AttributeEnum en = new AttributeEnum(definedEnums.SelectedText, enums[definedEnums.SelectedIndex]);
            en.changeName(definedEnums.Items[definedEnums.SelectedIndex].ToString());
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
            try
            {
                //check for all attributed to be correct
                if (this.definitionPanel.Controls.Count == 0)
                    throw new Exception("Record of no data! Please add some data");
                //check for name duplicity
                for (int i = 0; i < this.definitionPanel.Controls.Count; i++)
                {
                    AbstractAttribute a = this.definitionPanel.Controls[i] as AbstractAttribute;
                    if (a == null)
                        continue; // TODO some assert
                    string s = a.getAttributeName();
                    for (int j = i + 1; j < this.definitionPanel.Controls.Count; j++)
                    {
                        if (((AbstractAttribute)this.definitionPanel.Controls[j]).getAttributeName().Equals(s))
                            throw new Exception("Two attributes with same name! <" + s + ">");
                    }
                }
                foreach (AbstractAttribute a in this.definitionPanel.Controls)
                {
                    if (a.getAttributeName().Equals(""))
                        throw new Exception("Empty attribute name!");
                    if (a.isMandatory() && (a.getControl().getValue() == null))
                        throw new Exception("Error on attribute " + 
                            a.getAttributeName() + 
                            "should be set and it is not");
                }
                if (dbName.Text.Equals(""))
                    throw new Exception("No database name set!");
                string name = dbName.Text;
                if (File.Exists(name))
                    throw new Exception("File already exists!");

                ////vsetky regexpy
                //List<Regex> regExp = new List<Regex>();
                ////otvorenie suboro
                //string[] files = chosen.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                //foreach (string file in files)
                //{
                //    getRecords(file); //s je stream
                //}
                // already added when creating
                //foreach (AbstractAttribute a in this.definitionPanel.Controls)
                //{
                //    RecordsManager.AddToActive(a);
                //}
                RecordsManager.RenameActive(name);
                RecordsManager.SaveActive();
                //OnStateChanged(State.StateLoadDatabase, name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning!",MessageBoxButtons.OK);
            }
        }
        public void getRecords(string file)
        {
            try
            {
                StreamReader r = new StreamReader(file);
                string text = r.ReadToEnd();

                r.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private System.Collections.Generic.List<System.Windows.Forms.ComboBox> enums;
        private void cancelButton_Click(object sender, EventArgs e)
        {
            //TODO change
            ////ak existuju uz databaze, tak ok
            //DirectoryInfo d = new DirectoryInfo(".");
            //if (d.GetFiles("*.Minis", SearchOption.TopDirectoryOnly).Length == 0)
            //    this.endState = Forms.FormEnd;
            //else 
            //    this.endState = Forms.FormLoad;
            //this.Close();
            //OnStateChanged(State.StateIntro, "");
        }

        private void ClearInput(object sender, EventArgs e)
        {
            this.dbName.Clear();
            this.dbName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        }
    }
}
