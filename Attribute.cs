using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace myDb
{
   //== attribute text
   class Attribute : System.Windows.Forms.Panel
    {
        protected System.Windows.Forms.Label typeLabel;
        protected System.Windows.Forms.Label type;
        protected System.Windows.Forms.CheckBox fill;
        protected System.Windows.Forms.Label fillLabel;
        protected System.Windows.Forms.TextBox name;
        protected System.Windows.Forms.Label nameLabel;
        protected System.Windows.Forms.Control def;
        protected System.Windows.Forms.Label defLabel;
        protected System.Windows.Forms.Button closeButton;


        public virtual Control valueControl()
        {
            return new TextBox();
        }
        public void visit(Visitor v) 
        {
            v.visited(this);
        }

        public Attribute()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            this.typeLabel = new Label();
            this.typeLabel.AutoSize = true;
            this.typeLabel.Text = "Type";
            this.typeLabel.Name = "Type"; ;

            this.type = new Label();
            this.type.AutoSize = true;
            this.type.Text = "Text";
            this.type.Name = "Text";

            this.Controls.Add(typeLabel);
            this.Controls.Add(type);

            // label defining /
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

            fill.CheckedChanged += new EventHandler(fill_CheckedChanged);
            this.Controls.Add(fillLabel);
            this.Controls.Add(fill);

            // adding name 
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

            // setting default value, not adding 
            defLabel = new Label();
            defLabel.AutoSize = true;
            defLabel.Size = new System.Drawing.Size(35, 20);
            defLabel.Text = "Default text value"; //not mandatory;)

            def = new TextBox();
            def.Name = "Default";
            def.Size = new System.Drawing.Size(100, 20);
            def.TabIndex = 3;

            // close row button 
            closeButton = new Button();
            closeButton.Name = "Close";
            closeButton.AutoSize = true;
            closeButton.Size = new System.Drawing.Size(20, 20);
            closeButton.Text = "X";
            closeButton.Click += new EventHandler(closeButton_Click);
        }

        void fill_CheckedChanged(object sender, EventArgs e)
        {
            this.Controls.Remove(defLabel);
            this.Controls.Remove(def);
            if (this.fill.Checked)
            {
                this.Controls.Add(defLabel);
                this.Controls.Add(def);
            }
            this.ResumeLayout();
        }

        void closeButton_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            this.Parent.Controls.Remove(this);
            //zase TAK moc tam tych atributov nebude
            int actualX = 10;
            int actualY = 10;
            for (int i = 0; i < parent.Controls.Count; i++)
            {
                parent.Controls[i].Location = new System.Drawing.Point(actualX, actualY);
                actualY += parent.Controls[i].Height;
            }
            parent.ResumeLayout();
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
            for (int i = 0; i < this.Controls.Count; i += 2) //label + component
            {
                this.Controls[i].Location = new System.Drawing.Point(actualX, actualY);
                this.Controls[i + 1].Location = new  System.Drawing.Point(actualX, actualY + 10 + this.Controls[i].Size.Height);
                space = Math.Max(this.Controls[i].Size.Width, this.Controls[i + 1].Size.Width);
                actualX += space + 20;
            }
            closeButton.Location = new  System.Drawing.Point(actualX, 10);
            this.Controls.Add(closeButton);
        }
        public string getName()
        {
            return name.Text;
        }
        virtual public string getDefault()
        {
            return def.Text;
        }
        public bool isMandatory()
        {
            return this.fill.Checked;
        }
    }

    class AttributeInteger : Attribute
    {
        protected System.Windows.Forms.Label minLabel, maxLabel;
        protected System.Windows.Forms.NumericUpDown min, max;
        public AttributeInteger()
        {
            defLabel.Text = "Default integer value";
            type.Text = "Integer";
            def = new NumericUpDown();

            minLabel = new Label();
            minLabel.AutoSize = true;
            minLabel.Size = new System.Drawing.Size(35, 20);
            minLabel.Text = "Minimum integer value";

            maxLabel = new Label();
            maxLabel.AutoSize = true;
            maxLabel.Size = new  System.Drawing.Size(35, 20);
            maxLabel.Text = "Maximum integer value";

            min = new NumericUpDown();
            min.Minimum = Int32.MinValue;
            min.Value = min.Minimum;
            min.Maximum = Int32.MaxValue;
            min.ValueChanged += new EventHandler(min_ValueChanged);

            max = new NumericUpDown();
            max.Minimum = Int32.MinValue;
            max.Maximum = Int32.MaxValue;
            max.Value = max.Maximum;
            max.ValueChanged += new EventHandler(max_ValueChanged);

            this.Controls.Add(minLabel);
            this.Controls.Add(min);
            this.Controls.Add(maxLabel);
            this.Controls.Add(max);
            max_ValueChanged(null, null);
            min_ValueChanged(null, null);
        }

        void max_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = (NumericUpDown)def;
            n.Maximum = max.Value;
        }

        void min_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = (NumericUpDown)def;
            n.Minimum = min.Value;
        }
    }

    class AttributeEnum : Attribute
    {
        public AttributeEnum(ComboBox b)
        {
            defLabel.Text = "Choose enum";
            b.DropDownStyle = ComboBoxStyle.DropDownList;
            b.SelectedIndex = 0;
            def = b;
        }
    }
    class AttributeTime : Attribute
    {
        private DateTimePicker dateTimeTick;
        public AttributeTime()
        {
            dateTimeTick = new DateTimePicker();
            this.def = dateTimeTick;
        }
    }
    class AttributeImage : Attribute
    {
        private TextBox t;

        public AttributeImage()
        {
            this.defLabel.Text = "Default path";

            t = new TextBox();
            t.Size = new System.Drawing.Size(100, 20);
            t.AutoCompleteMode = AutoCompleteMode.Suggest;
            t.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;
            t.Location = new System.Drawing.Point(0, 0);
            t.Size = new System.Drawing.Size(100, 20);

            Button b = new Button();
            b.Text = "...";
            b.Size = new System.Drawing.Size(10, 20);
            b.Location = new System.Drawing.Point(t.Size.Width - 1,0);
            b.Click += new EventHandler(b_Click);
            Panel p = new Panel();
            p.Size = new System.Drawing.Size(t.Size.Width + b.Size.Width, 20);
            p.Controls.Add(t);
            p.Controls.Add(b);
            def = p;
        }

        void b_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog f = new OpenFileDialog();
            f.Title = "Choose location of picture";
            f.Multiselect = false;
            f.InitialDirectory = "c:\\";
            DialogResult res = f.ShowDialog();
            if (res != DialogResult.OK)
                return;
            this.t.Text = f.FileName;
        }
    }
}