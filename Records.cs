using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace Minis
{    
        public void Filter( String query)
        {
            if (query == "")
                onInfoHandler("Refreshing database...");
            else 
                onInfoHandler("Selecting records by query " + query + "\r\n..");
            List<Condition> conditions = this.parseQuery(query);
            //regexp = '*'
            if (conditions == null)
                return; //+ nejake warning? Myslim, ze netreba

            data.Rows.Clear();
            for (int i = 0; i < records.Count; i++)
            {
                int index;
                foreach (Condition c in conditions)
                {
                    index = pattern.IndexOf(this.find(c.getName()));
                    Value v1 = records[i].getValues()[index];
                    if (!c.compareTo(v1))
                        goto Next; //goTO!!..ale brekeke!..FUUUUUUUJ
                }
                index = data.Rows.Add();
                //mozem sa spolahnut na poeradie?..vlastne musim;)..vlastne nie:D TODO dat do columns
                for (int j = 0; j < pattern.Count; j++)
                    data.Rows[index].Cells[j].Value = records[i].getValues()[j];
                data.Rows[index].Cells[pattern.Count].Value = records[i].getIdValue();
                data.Rows[index].HeaderCell.Value = (index + 1).ToString();
            Next:
                ;
            }
            onInfoHandler("Completed.\r\n");
        }
        
        private Condition ConvertToCondition(string s)
        {
            Condition c = null;
            try
            {
                string[] strs = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (strs.Length != 3)
                    throw new Exception(" Syntax error on " + s + "\r\n"+ Misc.help);
                AbstractAttribute a;
                a = find(strs[0]);
                if (a == null)
                    throw new Exception("Name " + strs[0] + " is not recognized.");
                if ((strs[1].Equals("misses")) && (strs[2].Equals("data")))
                    return new ConditionIsNull(strs[0], null);
                Value v = a.getControl().getValue(strs[2]);
                switch (strs[1].ToLower())
                {// genericFactory
                    case "contains": //check name!
                        {
                            c = new ConditionContains(strs[0], v);
                            break;
                        }
                    case "misses":
                        {
                            c = new ConditionNot(new ConditionContains(strs[0], v));
                            break;
                        }
                    case "=":
                        {
                            c = new ConditionEqual(strs[0], v);
                            break;
                        }
                    case "<=":
                        {
                            c = new ConditionLessEqual(strs[0], v);
                            break;
                        }
                    case "<":
                        {
                            c = new ConditionLess(strs[0], v);
                            break;
                        }
                    case ">=":
                        {
                            c = new ConditionNot(new ConditionLess(strs[0], v));
                            break;
                        }
                    case ">":
                        {
                            c = new ConditionNot(new ConditionLessEqual(strs[0], v));
                            break;
                        }
                    default:
                        throw new Exception("Syntax error at condition '" + strs[1] + "'- no such condition implemented\r\n" + Misc.help); 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error found!", MessageBoxButtons.OK);
            }
            return c;
        }
        private List<Condition> ParseQuery(string s)
        {
            List<Condition> result = new List<Condition>();
            string[] lines = s.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                Condition c = getCondition(line);
                if (c == null)
                    return null;
                result.Add(c);
            }
            return result;
        }

        

    }
}
