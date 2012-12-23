using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Minis
{
    public partial class InsertContent : TabPage
    {
        public InsertContent()
        {
            InitializeComponent();
            InitUserControls();
        }
        private int heigthToAdd;
        private int numberOfValues;
        private List<Label> labels;
        private List<AbstractControl> controls; //tie, o krote nam ide
        private List<AbstractControl> toAddRecords;

        /* events */
        /* event no adding values */
        public delegate void addRecordsHandler(object sender, RecordEventArgs rea);
        public event addRecordsHandler addRecord;

        /* event on adding rows */
        public delegate void addRowHandler(InsertContent sender);
        public event addRowHandler addRow;

        /* event on setting labels */
        public delegate void AddLabelsHandler(InsertContent sender);
        public event AddLabelsHandler addLabels;

        protected virtual void onAddLabels()
        {
            if (addLabels == null)
                return;
            addLabels(this);
        }
        protected virtual void onAddRow()
        {
            if (addRow == null)
                return;
            addRow(this);
        }
        protected virtual void onAddRecord(RecordEventArgs args)
        {
            if (addRecord == null)
                return;
            addRecord(this, args);
            //internal_clean(null, null); //no neni toto fuj?
        }
        public void setNames(List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                Label l = new Label();
                l.Text = names[i];
                labels.Add(l);
            }
        }
        public void InitUserControls()
        {
            this.labels = new List<Label>();
            this.toAddRecords = new List<AbstractControl>();
            this.controls = new List<AbstractControl>();
            this.heigthToAdd = 0;

            this.MouseUp += new MouseEventHandler(internal_clean);
            //this.getTab().MouseUp += new MouseEventHandler(tabActive);

        }
        /* sets the tab to be active */
        //void tabActive(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Middle)
        //    {
        //        //		getTab().Parent.Controls.Remove(this.getTab()); //TEST!
        //        //		toto bude platne pre vsetky taby
        //    }
        //}
        /* sets labels according to labels */
        private void internal_clean(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            recordPanel.Controls.Clear();
            controls.Clear();
            labels.Clear();
            heigthToAdd = 0;
            onAddRow(); //getSize..getLayout
          //  onAddLabels();
            if (this.Parent == null) //nevidim dovod..?
                return;
            if (labels.Count != this.controls.Count-1)
                throw new Exception("Labels and boxes have different dimensions ");
            //a to je uplne jedno kde to tam je...
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Location = new System.Drawing.Point(((Control)controls[i]).Location.X, 0);
                ((Control)controls[i]).Location = new System.Drawing.Point(labels[i].Location.X, labels[i].PreferredHeight + 10);
            }
            for (int i = 0; i < labels.Count; i++)
                recordPanel.Controls.Add(labels[i]);
        }
        private void setLabels()
        {
            onAddLabels();
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Location = new System.Drawing.Point(((Control)controls[i]).Location.X, 0);
                ((Control)controls[i]).Location = new System.Drawing.Point(labels[i].Location.X, labels[i].PreferredHeight + 10);
            }
            for (int i = 0; i < labels.Count; i++)
                recordPanel.Controls.Add(labels[i]);
            this.heigthToAdd += labels[0].PreferredHeight + 10;
        }
        //void InsertContent_Resize(object sender, EventArgs e)
        //{
        //    recordPanel.Location = new System.Drawing.Point(0, 0);
        //    recordPanel.Size = new System.Drawing.Size(getTab().Width,
        //        getTab().Height - buttonPanel.PreferredSize.Height);
        //    buttonPanel.Location = new System.Drawing.Point(0,
        //        recordPanel.Height - recordPanel.Location.X);
        //}
        /* add row to */
        public void add(List<AbstractControl> ctrls) 
        {
            if (ctrls.Count == 0)
                throw new Exception("Zero attributes, not legal database!");
            
            this.numberOfValues = ctrls.Count;
            this.controls.AddRange(ctrls);
          
            Button removeRowButton = new Button();
            removeRowButton.Text = "Cancel";
            removeRowButton.Click += new EventHandler(removeRowButton_Click);
            removeRowButton.Name = ctrls[ctrls.Count - 1].getValue().ToString();//unikat

            Control c = (Control)ctrls[0];
            c.Name = removeRowButton.Name;
            System.Drawing.Point point = new System.Drawing.Point(0, this.heigthToAdd);
            c.Location = new System.Drawing.Point(0, this.heigthToAdd);
            this.recordPanel.Controls.Add(c);
            
            for (int i = 1; i < ctrls.Count; i++)
            {
                c = (Control)ctrls[i];
                c.Name = removeRowButton.Name;
                point = new System.Drawing.Point(point.X + ((Control)ctrls[i - 1]).Width + 10, point.Y);// FIXME UPRAVIT
                c.Location = point;
                this.recordPanel.Controls.Add(c);
            }
            removeRowButton.Location = new System.Drawing.Point(point.X + ((Control)ctrls[ctrls.Count-1]).Width + 10, ((Control) ctrls[0]).Location.Y);
            this.toAddRecords.AddRange(ctrls);
            this.recordPanel.Controls.Add(removeRowButton);
            this.heigthToAdd += c.Height + 10;
            if (labels.Count == 0)
                setLabels();
        }
        public void removeRows()
        {
            if (labels.Count == 0)
                return;
            foreach (Control c in toAddRecords)
            {
                while (this.recordPanel.Controls.IndexOfKey(c.Name) >=0)
                    this.recordPanel.Controls.RemoveByKey(c.Name);
            }
            toAddRecords.Clear();
            heigthToAdd = labels[0].PreferredHeight + 10;
        }
        void removeRowButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            //a vsetky usporiadaj
            int lower = this.recordPanel.Controls[0].Height +10;
            this.heigthToAdd -= lower;
 
            foreach (Control c in this.recordPanel.Controls)
            {
                if (c.Name.Equals(b.Name))
                    this.toAddRecords.Remove(c as AbstractControl);
            }
            //OMG FUJ!
            while (this.recordPanel.Controls.IndexOfKey(b.Name) >= 0)
                this.recordPanel.Controls.RemoveByKey(b.Name);
            foreach (Control c in this.recordPanel.Controls)
            {
                if (c.Location.Y > b.Location.Y)
                {
                    c.Location = new System.Drawing.Point(c.Location.X, c.Location.Y - lower);
                }
            }
        }
        /* sender calls for filling boxes */
        void addRows_click(object sender, EventArgs e)
        {
            for (int i = 0; i < howMany.Value; i++)
            {
                this.onAddRow();
            }
        }
        void addButton_Click(object sender, System.EventArgs args)
        {
            //zistime vsetky recordy, ktore na uzibvatel zadal..ZAJTRA/VECER
            List<Record> r = new List<Record>();
            for (int i = 0; i < toAddRecords.Count; i += this.numberOfValues)
            {
                Record record = new Record();
                for (int j = 0; j < this.numberOfValues; j++)
                    record.add(toAddRecords[i + j].getValue());
                r.Add(record);
            }
            RecordEventArgs e = new RecordEventArgs(r);
            onAddRecord(e);
        }
    }
}
