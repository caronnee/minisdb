using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace myDb
{
	public abstract class AbstractAttribute : System.Windows.Forms.Panel 
	{
		public static class AttributeType
		{
			public const int AText = 0;
			public const int AInteger = 1;
			public const int APicture = 2;
			public const int ATime = 3;
			public const int AEnum = 4;
		}
		protected int aType;
		protected System.Windows.Forms.Label typeLabel;
		protected System.Windows.Forms.Label type;
		protected System.Windows.Forms.CheckBox fill;
		protected System.Windows.Forms.Label fillLabel;
		protected System.Windows.Forms.TextBox name;
		protected System.Windows.Forms.Label nameLabel;
		protected System.Windows.Forms.Control def; //to be overrden;)
		protected System.Windows.Forms.Label defLabel;
		protected System.Windows.Forms.Button closeButton;

		/* methods that are common */
		public AbstractAttribute()
		{
			this.BorderStyle = BorderStyle.FixedSingle;
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

			this.typeLabel = new Label();
			this.typeLabel.AutoSize = true;
			this.typeLabel.Text = "Type";
			this.typeLabel.Name = "Type";

			this.type = new Label();
			this.type.AutoSize = true;
			this.type.Text = "Text";
			this.type.Name = "Text";

			this.Controls.Add(typeLabel);
			this.Controls.Add(type);

			// label defining
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

        public delegate void Handler(AbstractAttribute a);
        public event Handler close;

        protected void onClose()
        {
            if (close == null)
                return;
            close(this);
        }
		void closeButton_Click(object sender, EventArgs e)
		{
            //on CLOSE, nech si to kazdy vymaze sam;)
            onClose();
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
				this.Controls[i + 1].Location = new System.Drawing.Point(actualX, actualY + 10 + this.Controls[i].Size.Height);
				space = Math.Max(this.Controls[i].Size.Width, this.Controls[i + 1].Size.Width);
				actualX += space + 20;
			}
			closeButton.Location = new System.Drawing.Point(actualX, 10);
			this.Controls.Add(closeButton);
		}
		/* returns name of the attribute */
		public string getAttributeName()
		{
			return name.Text;
		}
		public bool isMandatory()
		{
			return this.fill.Checked;
		}
		protected string getName()
		{
			return aType +"\t" + name.Text + "\t";
		}

		/* virtual methods */
        public virtual Control showControl(Value v)
        {
            TextBox t = new TextBox();
            t.Text = this.name.Text + "\r\n";
            if (v != null) 
                t.Text += v.ToString(); //alebo skor label?Label je lepsi..POTOM
            t.ReadOnly = true; //JOOOOOO!..ale je to skarede...chce to zmenit skin
            t.WordWrap = true;
            t.Multiline = true;
            t.Size = new System.Drawing.Size(100, 20);//minml size)
            ShowBox s = new ShowBox(t); //jaj, to je zvrhleeee
            return t; //alebo s.t
        }
     
		/* returns copy of control that should handle value */
		public abstract AbstractControl getControl();
		/* sets atrribute with defined values, how it should look like */
		public abstract void reconstruct(String s);
        
	}
	public interface AbstractControl 
	{
		Value getValue();
		Value getValue(string value);
        Type getType();
        void setValue(Value v);
	}

	class MTextBox : TextBox, AbstractControl
	{
		AttributeState state;

		public MTextBox(bool mandatory_)
		{
			state = new AttributeState(this, mandatory_);
			MenuItem i = new MenuItem("Copy");
			i.Click += new EventHandler(this.CopyToClipboard);
			this.ContextMenu.MenuItems.Add(i);
			i = new MenuItem("Paste");
			i.Click += new EventHandler(this.PasteFromClipBoard);
			this.ContextMenu.MenuItems.Add(i);
		}

		public void PasteFromClipBoard(object sender, EventArgs e)
		{
			//FIX otazka, pridat alebo uplne zmenit
			this.Text = Clipboard.GetText();
		}
		public void CopyToClipboard(object sender, EventArgs e)
		{
			if (this.Text.Equals(""))
				return;
			Clipboard.SetText(this.Text);
		}

        public Type getType()
        {
            return typeof(string);
        }
		public Value getValue()
		{
			if (this.Visible && (!this.Text.Equals("")) )
				return new ValueText(this.Text); //coz bude nuloce, ked neni mandatory;)
			return null;
		} 
		public Value getValue(string text)
		{
			return new ValueText(text);
		}
        public void setValue(Value v)
        {
            this.Text = v.ToString();
        }
	}
    class MNumeric : NumericUpDown, AbstractControl
    {
        private AttributeState state;

        public void setValue(Value v)
        {
            this.Value = System.Convert.ToInt32(v.ToString()); //Ale fuuuuuuuj! MNE to prejde, horsie to bude s nasledovatelmi, catch int?
        }
        public MNumeric(bool mandatory) //kontext menu na disable
        {
            state = new AttributeState(this, mandatory);
        }

        public Type getType()
        {
            return typeof(int);
        }
        public Value getValue()
        {
            if (this.Visible)
                return new ValueInteger((int)this.Value);
            return null;
        }
        public Value getValue(string text)
        {
            if (text.Equals(""))
                return null;
            return new ValueInteger(System.Convert.ToInt32(text));
        }
    }
    class MCombobox : ComboBox, AbstractControl
    {
        private AttributeState state;

        public MCombobox(ComboBox items, bool mandatory)
        {
            this.state = new AttributeState(this, mandatory);
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (object o in items.Items)
                this.Items.Add(o); //BREKEKE
            this.SelectedIndex = 0;
        }

        public Type getType()
        {
            return typeof(string);
        }
        public Value getValue()
        {
            if (this.Visible)
                return new ValueText(this.SelectedItem.ToString());
            return null;
        }
        public Value getValue(string name)
        {
            if (name.Equals(""))
                return null;
            for (int i = 0; i < this.Items.Count; i++)
                if (this.Items[i].Equals(name))
                    return new ValueText(name);
            return null;
        }
        public void setValue(Value v)
        {
            foreach (string s in this.Items)
                if (s.Equals(v.ToString()))
                {
                    this.SelectedItem = s;
                    return;
                }
            throw new Exception( "Omg , nieco je spatne a nechce sa mi pisat chybova hlaska;)");
        }
    }
    class MDate : DateTimePicker, AbstractControl
    {
        AttributeState state;

        public MDate(bool state_)
        {
            state = new AttributeState(this, state_);
        }

        public Type getType()
        {
            return typeof(DateTime);
        }
        public Value getValue()
        {
            if (this.Visible)
                return new ValueDate(this.Value);
            return null;
        }
        public Value getValue(string text)
        {
            if (text.Equals(""))
                return null;
            DateTime myDt = new DateTime(1984, 5, 18);
          
            return new ValueDate(DateTime.ParseExact(text,new string[]
            {Files.dateFormat,"dd.MM.yyyy","d.M.yyyy"},null, System.Globalization.DateTimeStyles.AllowWhiteSpaces));
        }
        public void setValue(Value v)
        {
            this.Value = DateTime.ParseExact(v.ToString(), Files.dateFormat, null);
        }
    }
    class MPanelFile : Panel, AbstractControl
    {
        MTextBox path;
        Button chooseButton;
        public MPanelFile(bool state_)
        {
            path = new MTextBox(state_);
            path.Size = new System.Drawing.Size(100, 20);
            path.AutoCompleteMode = AutoCompleteMode.Suggest;
            path.AutoCompleteSource = AutoCompleteSource.FileSystem;
            path.Location = new System.Drawing.Point(0, 0);

            chooseButton = new Button();
            chooseButton.Text = "...";
            chooseButton.Size = new System.Drawing.Size(30, path.Size.Height);
            chooseButton.Location = new System.Drawing.Point(path.Size.Width - 1, 0);
            chooseButton.Click += new EventHandler(b_Click);

            path.VisibleChanged += new EventHandler(path_VisibleChanged);
            path_VisibleChanged(null, null);

            this.Controls.Add(path);
            this.Controls.Add(chooseButton);

            this.Size = new System.Drawing.Size(10 + path.Size.Width + chooseButton.PreferredSize.Width, this.PreferredSize.Height+2);
        }
        void path_VisibleChanged(object sender, EventArgs e)
        {
            chooseButton.Visible = path.Visible;
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
            path.Text = f.FileName;
        }
        public void setText(string s)
        {
            path.Text = s;
        }
        public string getText()
        {
            return path.Text;
        }
        public Type getType()
        {
            return typeof(string);
        }
        public Value getValue()
        {
            if (this.Visible)
                return new ValuePicture(path.Text);
            return null;
        }
        public Value getValue(string text)
        {
            if (text.Equals(""))
                return null;
            return new ValuePicture(text); //mozno este check, co je to vazne adresa?
            //WHAT...EVER!..Jo, to by sa dalo, takto hej
        }
        public void setValue(Value v)
        {
            this.path.Text = v.ToString();
        }
    }

    class AttributeState
    {
        static public string disableMenu = "Disable";
        public readonly bool mandatory;
        private Control parent; //MEGAFUJ!
        private Label clickToEnableLabel;

        public AttributeState(Control control, bool mandatory_)
        {
            mandatory = mandatory_;
            clickToEnableLabel = null;
            parent = control;
            control.ContextMenu = new ContextMenu();
            if (mandatory)
                return;

            control.ParentChanged += new EventHandler(control_ParentChanged);
            control.LocationChanged += new EventHandler(control_LocationChanged);

            clickToEnableLabel = new Label();
            clickToEnableLabel.Hide();
            clickToEnableLabel.Size = new System.Drawing.Size(control.Width, control.Height);
            clickToEnableLabel.Text = "Click to enable";
            clickToEnableLabel.Click += new EventHandler(this.enable);

            MenuItem m = new MenuItem(disableMenu);
            control.ContextMenu.MenuItems.Add(m);
            m.Click += new EventHandler(this.disable);
            control.Hide();
            clickToEnableLabel.Show();
        }
        void control_LocationChanged(object sender, EventArgs e)
        {
            clickToEnableLabel.Location = new System.Drawing.Point(parent.Location.X, parent.Location.Y);
        }
        void control_ParentChanged(object sender, EventArgs e)
        {
            if (parent.Parent == null)
                return; //zistit, naco to tu vlastne je
            parent.Parent.Controls.Add(this.clickToEnableLabel);
        }
        void disable(object sender, EventArgs e)
        {
            parent.Hide();
            clickToEnableLabel.Show();
        }
        void enable(object sender, EventArgs e)
        {
            parent.Show();
            clickToEnableLabel.Hide();
        }
    }
	public class Attribute : AbstractAttribute
	{
		private MTextBox defVal;
		public Attribute()
		{
			aType = AttributeType.AText;
			defVal = new MTextBox(true);

			defVal.Name = "Default";
			defVal.Size = new System.Drawing.Size(100, 20);

			def = defVal;
		}
		public override AbstractControl getControl()
		{
			MTextBox mbox = new MTextBox(isMandatory());
			mbox.Text = defVal.Text;
			return mbox; 
		}     
		public override string ToString()
		{
			string s = getName();
			if (isMandatory())
				s += def.Text;
			return s;
		}       
		public override void reconstruct(String s) //fixme prepisat na reconstruct
		{
			string[] strs = s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
			this.name.Text = strs[0];
			if (strs.Length == 1)
				return;
			defVal.Text = strs[1];
			this.fill.Checked = true;
		}
	}
	public class AttributeInteger : AbstractAttribute
	{
		protected System.Windows.Forms.Label minLabel, maxLabel;
		protected System.Windows.Forms.NumericUpDown min, max, defValue;

		public AttributeInteger()
		{
			aType = AttributeType.AInteger;
			defLabel.Text = "Default integer value";
			type.Text = "Integer";
			defValue = new NumericUpDown();
			def = defValue;

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
			min.Maximum = max.Value;
		}
		void min_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown n = (NumericUpDown)def;
			n.Minimum = min.Value;
			max.Minimum = min.Value;
			n.Value = System.Math.Max(min.Value, n.Value);
		}
		public override string ToString()
		{
			string s = getName() + min.Value.ToString() + "\t" + max.Value;
			if (isMandatory())
				s += '\t' + defValue.Value.ToString();
			return s;
		}
		public override AbstractControl getControl()
		{
			MNumeric m = new MNumeric(isMandatory());
			m.Minimum = min.Value;
			m.Maximum = max.Value;
            if (!isMandatory())
                return m;
		    m.Value = defValue.Value;
			return m;
		}
		public override void reconstruct(string s)
		{
			string[] strs = s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
			this.name.Text = strs[0];
			min.Value = System.Convert.ToInt32(strs[1]);
			max.Value = System.Convert.ToInt32(strs[2]);
			defValue.Minimum = min.Value;
			defValue.Maximum = max.Value;
			if (strs.Length < 4)
				return;
			defValue.Value = System.Convert.ToInt32(strs[3]);
			this.fill.Checked = true; //mandatory
		}
	}
	public class AttributeEnum : AbstractAttribute
	{
		private string enumName;
		private ComboBox defVal;

        public void changeName(string name)
        {
            enumName = name;
        }
		public static ComboBox findEnum(string toFind) //pouzivame len pri loadovani
		{
			List<string> enums = null;
			ComboBox b = new ComboBox();
			if (enums == null)
				enums = Files.readEnum();

			foreach ( string s in enums )
				if ( s.StartsWith(toFind + '\t'))
				{
					b.Items.AddRange(s.Split(new char[]{ '\t'},StringSplitOptions.RemoveEmptyEntries));
					b.Items.Remove(toFind); //nemovneme meno ten jeci ( malo by byt prve, ale kto sa na to moze spolahnut, ze...
					return b;
				}
			throw new Exception ( "No such type defined");
		}
		public AttributeEnum(string name_, ComboBox b)
		{
			this.enumName = name_;
			this.aType = AttributeType.AEnum;
			this.typeLabel.Text = "Enum";
			defLabel.Text = "Choose enum";
			b.DropDownStyle = ComboBoxStyle.DropDownList;
			if (b.Items.Count!=0) 
				b.SelectedIndex = 0;
			defVal = b ; //mozno add rande?
			def = defVal; //inak sa to bude menit stale subezne
		}
		public override void reconstruct(string id)
		{
			string[] s = id.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
			//jaky enum z nasej kolekcie
			this.name.Text = s[0];
			enumName = s[1];
			this.defVal = findEnum(s[1]);
			//default value
            if (s.Length < 3)
                return;
            defVal.SelectedIndex = System.Convert.ToInt32(int.Parse(s[2]));
            this.fill.Checked = true;
		}
		public override string ToString()
		{
			string s  = getName()+ this.enumName + "\t";
			if (this.isMandatory())
				s += defVal.SelectedIndex.ToString();
            return s;
		}
		public override AbstractControl getControl()
		{
			MCombobox m = new MCombobox(this.defVal, isMandatory());
			if (isMandatory())
				m.Text = defVal.SelectedItem.ToString();
			return m;
		}
	}
	public class AttributeTime : AbstractAttribute
	{
        public static string todayString = "today";
		private MDate dateTimeTick;
		private Label todayText;
		private bool today;

        void m_Click(object sender, EventArgs e)
        {
            this.today = !this.today;
            todayText.Location = def.Location;
            def.Hide();
            int index = this.Controls.IndexOf(def);
            this.Controls.Remove(def);
            if (this.today)
                def = todayText;
            else
                def = dateTimeTick;
            this.Controls.Add(def);
            this.Controls.SetChildIndex(def, index);
            def.Show();
        }
		
        public AttributeTime()
		{
			this.today = false;
			this.aType = AttributeType.ATime;
			this.today = false;
			this.typeLabel.Text = "Time";
			dateTimeTick = new MDate(true);
			this.todayText = new Label();
			this.todayText.Text = "Today";
            todayText.Click +=new EventHandler(m_Click);
			MenuItem m = new MenuItem("Today()");
			m.Checked = false;
			m.Click += new EventHandler(m_Click);
			dateTimeTick.ContextMenu = new ContextMenu();
			dateTimeTick.ContextMenu.MenuItems.Add(m);
            this.todayText.Size = new System.Drawing.Size(dateTimeTick.Width, dateTimeTick.Height);
			this.def = dateTimeTick;
		}
		public override string ToString()
		{
			string s = getName();
			if (!isMandatory())
				return s;
			if (today)
				s += todayString;
			else
				s += dateTimeTick.Value.ToString(Files.dateFormat); 
			return s;
		}
		public override void reconstruct(string s)
		{
			string[] strs = s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
			this.name.Text = strs[0];
            if (strs.Length == 1)
                return;
            this.fill.Checked = true;
            if (strs[1].Equals(todayString))
                return;
		    dateTimeTick.Value = System.Convert.ToDateTime(strs[1]);//try catch?
		}
        public override AbstractControl getControl()
        {
            MDate dt = new MDate(isMandatory());
            if (isMandatory())
                dt.Value = dateTimeTick.Value;
            return dt;
        }
	}	
	public class AttributeImage : AbstractAttribute
	{
		private MPanelFile defaultValue;

		public AttributeImage()
		{
            this.aType = AttributeType.APicture;
			defaultValue = new MPanelFile(true);
			this.typeLabel.Text = "Image";
			this.defLabel.Text = "Default path";
			def = defaultValue;
		}
		public override string ToString()
		{
			string s = getName();
			//only if mandatry
			if (isMandatory())
				s += defaultValue.getText();
			return s;
		}
		public override void reconstruct(string s)
		{
            string[] str = s.Split(new char[]{'\t'}, StringSplitOptions.RemoveEmptyEntries);
            this.name.Text = str[0]; //TIEZ NA NEJAku common funkcicnku?
            if (str.Length == 1)
                return;
			defaultValue.setText(str[1]);
            this.fill.Checked = true;
		}
        public override AbstractControl getControl()
        {
            MPanelFile mp= new MPanelFile(isMandatory());
            if (!isMandatory())
                return mp;
            mp.setText(this.defaultValue.getText());
            return mp;
        }
      /*  public override Control showControl(Value v)
        {
            Value v2 = v;
            if (v == null)
                v2 = new ValuePicture(Files.noImagePath);
            PictureBox picture = new PictureBox();
            picture.ImageLocation = v2.ToString();
            //name, size
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            setContext(picture);
            picture.Size = new System.Drawing.Size(100, 100); //zakladna size
            return picture;
        } */
	}
}
