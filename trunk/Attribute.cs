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
			this.typeLabel.Name = "Type"; ;

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
		protected void saveName(TextWriter stream)
		{
			stream.Write(aType);
			stream.Write("\t" + name.Text + "\t");
		}

		/* virtual methods */
		/* returns copy of control that should handle value */
		public abstract AbstractControl getControl();

		/* how an attribute should be saved */
		public abstract void save(TextWriter stream);

		/* sets atrribute with defined values, how it should look like */
		public abstract void reconstruct(String s);
	}
	//== attribute text
	public interface AbstractControl 
	{
		Value getValue();
		Value getValue(string value);
	}

	public class AttributeState
	{
		public readonly bool mandatory;
		public readonly ContextMenu context; //co ma ukazovat na to controle...jaj tu sa da vyhrat!;)

		public AttributeState(Control control, bool mandatory_)
		{
			mandatory = mandatory_;
			control.Click += new EventHandler(this.enable);
			context = null;
			if (mandatory)
				return;
			context = new ContextMenu();
			MenuItem m = new MenuItem("Disable");
			m.Checked = true;
			this.context.MenuItems.Add(m);
			m.Checked = false;
			m.Click += new EventHandler(this.disable);
		}

		void disable(object sender, EventArgs e)
		{
			Control snd = (Control) sender;
			snd.Enabled = false;
		}

		void enable(object sender, EventArgs e)
		{
			Control snd = (Control) sender;
			snd.Enabled = true;
		}
	}

	class MTextBox : TextBox, AbstractControl
	{
		AttributeState state;

		public MTextBox(bool mandatory_)
		{
			state = new AttributeState(this, mandatory_);
			this.ContextMenu = new ContextMenu();
			MenuItem i = new MenuItem("copy");
			i.Click += new EventHandler(this.CopyToClipboard);
			this.ContextMenu.MenuItems.Add(i);
			i = new MenuItem("Paste");
			i.Click += new EventHandler(this.PasteFromClipBoard);
			this.ContextMenu.MenuItems.Add(i);
            this.Enabled = state.mandatory;
            if (state.context == null)
                return;
            foreach (MenuItem m in state.context.MenuItems)
			    this.ContextMenu.MenuItems.Add(m); //MERGE, skontrolovat
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
		public Value getValue()
		{
			if (this.Enabled)
				return new ValueText(this.Text); //coz bude nuloce, ked neni mandatory;)
			return null;
		} 
		public Value getValue(string text)
		{
			if (this.Enabled)
				return new ValueText(text);
			return null;
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
		public override void save(TextWriter stream)
		{
			saveName(stream);
			if (isMandatory())
				stream.Write(def.Text);
			stream.WriteLine();
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

	class MNumeric : NumericUpDown, AbstractControl
	{
		private AttributeState state;

		public MNumeric(bool mandatory) //kontext menu na disable
		{
			state = new AttributeState(this, mandatory);
			this.ContextMenu = state.context;
			this.Enabled = mandatory;
		}

		public Value getValue()
		{
			if (this.Enabled)
				return new ValueInteger((int)this.Value);
			return null;
		}

		public Value getValue(string text)
		{
			if (this.Enabled)
				return new ValueInteger(System.Convert.ToInt32(text));
			return null;
		}
	}
	public class  MCombobox : ComboBox, AbstractControl
	{
		private AttributeState state;

		public MCombobox( ComboBox items, bool mandatory )
		{
			this.state = new AttributeState(this, mandatory);
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (object o in items.Items)
                this.Items.Add(o); //BREKEKE
			this.SelectedIndex = 0;
		}
		public Value getValue()
		{
			if (this.Enabled)
				return new ValueText(this.SelectedItem.ToString());
			return null;
		}
		public Value getValue(string name)
		{
			for (int i =0;i<this.Items.Count; i++)
				if (this.Items[i].Equals(name))
					return new ValueText(name);
			return null;
		}
	}

	public class MDateTimePicker :  DateTimePicker, AbstractControl
	{
		public Value getValue()
		{
			if (this.Enabled)
				return new ValueDate(this.Value); //slected date
			return null;
		}
		public Value getValue(string name)
		{
			if (this.Enabled)
				return new ValueDate(System.Convert.ToDateTime(name));
			return null;
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

		public override void save(TextWriter stream)
		{
			saveName(stream);
			stream.Write(min.Value.ToString() + "\t" + max.Value );
			if (isMandatory())
				stream.Write('\t' + defValue.Value.ToString());
			stream.WriteLine();
		}
		public override AbstractControl getControl()
		{
			MNumeric m = new MNumeric(isMandatory());
			m.Minimum = min.Value;
			m.Maximum = max.Value;
			if (isMandatory())
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
			if (s.Length > 2)
				((ComboBox)(def)).SelectedIndex = System.Convert.ToInt32(int.Parse(s[2]));
		}
		public override void save(TextWriter stream)
		{
			saveName(stream);
			stream.Write(this.Name + "\t");
			if (this.isMandatory())
				stream.Write(defVal.SelectedItem.ToString());
			stream.WriteLine();
		}
		public override AbstractControl getControl()
		{
			MCombobox m = new MCombobox(this.defVal, isMandatory());
			if (isMandatory())
				m.Text = defVal.SelectedItem.ToString();
			return m;
		}
	}
	public class MDate : DateTimePicker, AbstractControl
	{
		public Value getValue()
		{
			return new ValueDate(this.Value);
		}
		public Value getValue(string text)
		{
			return new ValueDate(System.Convert.ToDateTime(text));
		}
	}
	public class AttributeTime : Attribute
	{
		private MDate dateTimeTick;
		private Label todayText;
		private bool today;

		public AttributeTime()
		{
			this.today = false;
			this.aType = AttributeType.ATime;
			this.today = false;
			this.typeLabel.Text = "Time";
			dateTimeTick = new MDate();
			this.todayText = new Label();
			this.todayText.Text = "Today";
			todayText.AutoSize = true;
			MenuItem m = new MenuItem("today");
			m.Checked = false;
			m.Click +=new EventHandler(m_Click);
			this.ContextMenu = new ContextMenu();
			this.ContextMenu.MenuItems.Add(m);
			this.def = dateTimeTick;
		}

		void m_Click(object sender, EventArgs e)
		{
			this.today = !this.today;
			todayText.Location = def.Location;
			((MenuItem)sender).Checked = this.today;
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

		public override void save(TextWriter stream)
		{
			saveName(stream);
			stream.WriteLine( dateTimeTick.Value.ToString()); //kontrola, tot je nebezpecne..radsej int
		}
		public override void reconstruct(string s)
		{
			string[] strs = s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
			this.name.Text = strs[0];
			if (s.Length >1)
				dateTimeTick.Value = System.Convert.ToDateTime(strs[1]);
		}
	}
	public class MPanelFile : Panel, AbstractControl
	{
		AttributeState state;
		TextBox path;
		Button chooseButton;
		public MPanelFile(bool state_)
		{
			state = new AttributeState(this, state_);

			path = new TextBox();
			path.Size = new System.Drawing.Size(100, 20);
			path.AutoCompleteMode = AutoCompleteMode.Suggest;
			path.AutoCompleteSource = AutoCompleteSource.FileSystem;
			path.Location = new System.Drawing.Point(0, 0);

			chooseButton = new Button();
			chooseButton.Text = "...";
			chooseButton.AutoSize = true; ;
			chooseButton.Size = new System.Drawing.Size(10, 10);
			chooseButton.Location = new System.Drawing.Point(path.Size.Width - 1, 0);
			chooseButton.Click += new EventHandler(b_Click);

			this.AutoSize = true;
			this.Size = new System.Drawing.Size(10, 10);
			this.Controls.Add(path);
			this.Controls.Add(chooseButton);
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

		public string getText()
		{
			return path.Text;
		}
		public Value getValue()
		{
			return new ValueText(path.Text);
		}
		public Value getValue(string text)
		{
			this.path.Text = text;
			return getValue();
		}
	}
	public class AttributeImage : Attribute
	{
		private MPanelFile defaultValue;

		public AttributeImage()
		{
			defaultValue = new MPanelFile(true);
			this.typeLabel.Text = "Image";
			this.defLabel.Text = "Default path";
			def = defaultValue;
		}

		public override void save(TextWriter stream)
		{
			stream.Write(AttributeType.APicture);
			//only if mandatry
			if (isMandatory())
				stream.Write(defaultValue.getText());
			stream.WriteLine();
		}

		public override void reconstruct(string s)
		{
			defaultValue.Text = s;
		}
	}
}
