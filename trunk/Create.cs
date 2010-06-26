using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myDb
{
    public partial class Create : MyForm
    {
        //== attribute text
        private class Attribute : System.Windows.Forms.GroupBox
        {
            protected System.Windows.Forms.CheckBox fill;
            protected System.Windows.Forms.Label fillLabel;
            protected System.Windows.Forms.TextBox name;
            protected System.Windows.Forms.Label nameLabel;
            protected System.Windows.Forms.TextBox def;
            protected System.Windows.Forms.Label defLabel;
            protected System.Windows.Forms.Button closeButton;

            public Attribute()
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                /* label defining */
                fill = new CheckBox();
                fill.AutoSize = true;
                fill.Name = "mustBeCheck";
                fill.Size = new System.Drawing.Size(15, 20);
                fill.TabIndex = 1;
                fill.Checked = false;
                fill.UseVisualStyleBackColor = true;
                fill.CheckStateChanged += new EventHandler(fill_CheckStateChanged);

                fillLabel = new Label();
                fillLabel.AutoSize = true;
                fillLabel.Text = "Must be";
                fillLabel.Name = "Must be filled";
                fillLabel.Size = new System.Drawing.Size(35, 20);

                this.Controls.Add(fillLabel);
                this.Controls.Add(fill);

                /* adding name */
                name = new TextBox();
                name.Name = "setAttributeName";
                name.Size = new System.Drawing.Size(100, 20);
                name.TabIndex = 2;

                nameLabel = new Label();
                nameLabel.AutoSize = true;
                nameLabel.Size = new System.Drawing.Size(35, 20);
                nameLabel.Text = "Attribute name";

                this.Controls.Add(nameLabel);
                this.Controls.Add(name);

                /* setting default value, not adding */
                defLabel = new Label();
                defLabel.AutoSize = true;
                defLabel.Size = new System.Drawing.Size(35, 20);
                defLabel.Text = "Default text value"; //not mandatory;)

                def = new TextBox();
                def.Name = "Default";
                def.Size = new System.Drawing.Size(100, 20);
                def.TabIndex = 3;

                /* close row button */
                closeButton = new Button();
                closeButton.Name = "Close";
                closeButton.AutoSize = true;
                closeButton.Size = new Size(20, 20);
                closeButton.Text = "X";
                closeButton.Click += new EventHandler(closeButton_Click);
            }

            void closeButton_Click(object sender, EventArgs e)
            {
                this.Parent.Controls.Remove(this);
                //zase TAK moc tam tych atributov nebude
                int actualX = 10;
                int actualY = 10;
                for (int i = 0; i < this.Parent.Controls.Count; i++)
                {
                    this.Parent.Controls[i].Location = new Point(actualX, actualY);
                    actualY += this.Parent.Controls[i].Height;
                }
                this.Parent.ResumeLayout();
            }
            void fill_CheckStateChanged(object sender, EventArgs e)
            {
                CheckBox ch = (CheckBox)sender;
                if (ch.Checked)
                {
                    this.Controls.Add(defLabel);
                    this.Controls.Add(def);
                }
                else
                {
                    this.Controls.Remove(defLabel);
                    this.Controls.Remove(def);
                }
                setPositions();
            }
            public void setPositions()
            {
                this.Controls.Remove(closeButton);
                int space = 20; //sprvu konstantna
                int actualX = 0, actualY = 0; //poradiie v ramci kontaineru, da sa rozsirit
                for (int i = 0; i < this.Controls.Count; i+=2) //label + component
                {
                    this.Controls[i].Location = new Point(actualX, actualY);
                    this.Controls[i+1].Location = new Point(actualX, actualY + 10 +this.Controls[i].Size.Height);
                    actualX += this.Controls[i + 1].Size.Width +space;
                }
                closeButton.Location = new Point(actualX, 10);
                this.Controls.Add(closeButton);
            }
            string getName()
            {
                return name.Text;
            }
            string getDefault()
            {
                return def.Text;
            }
            bool isMandatory()
            {
                return this.fill.Checked;
            }
        }

        private class AttributeInteger : Attribute
        {
            protected System.Windows.Forms.NumericUpDown min,max;
            public AttributeInteger()
            {
                min = new NumericUpDown();
                max = new NumericUpDown();
            }
        }

        private class AttributeReal : Attribute
        {
            protected System.Windows.Forms.TextBox min, max;
            protected bool setDotOrE;
            public AttributeReal()
            {
                setDotOrE = false;
                min = new TextBox();
                max = new TextBox();
                min.KeyPress += new KeyPressEventHandler(realBoundKeyPress);
                max.KeyPress += new KeyPressEventHandler(realBoundKeyPress);
            }

            void realBoundKeyPress(object sender, KeyPressEventArgs e)
            {
                if ( e.KeyChar == '.' || e.KeyChar == 'e' || e.KeyChar == 'E' )
                {
                    if (setDotOrE == true)
                        e.Handled = false;
                    else 
                        e.Handled = true;
                    setDotOrE = true;
                    return;
                }
                if (e.KeyChar > '0' && e.KeyChar < '9')
                    e.Handled = true;
                else e.Handled = false;
                //throw new NotImplementedException();
            }
        }
        private class AttributeEnum : Attribute
        {
            protected System.Windows.Forms.ComboBox enums; //ignore def value from ancestor
            protected System.Windows.Forms.ComboBox comboDef;
            public AttributeEnum(ComboBox b)
            {
                def = null; //never used;
                comboDef = b;
                comboDef.Hide();
                enums = b;
            }
        }
        public Create()
        {
            InitializeComponent();
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
            int x = 10, y = 10;
            for (int i = 0; i < this.definitionPanel.Controls.Count; i++)
            {
                y += this.definitionPanel.Controls[i].Size.Height + 10;
            }
            attribute.Parent = this;
            attribute.setPositions();
            attribute.Location = new Point(x, y);
            this.definitionPanel.Controls.Add(attribute);
            this.definitionPanel.ResumeLayout();
            this.ResumeLayout();
        }
    }
}
