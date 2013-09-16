using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DPlayer
{
    public class Outputable : List<Object>
    {
        protected List<Object> items;

        public void OutputInListBox(ListBox list)
        {
            list.Items.Clear();
            foreach(object o in this)
            {
                list.Items.Add(o);
            }
        }

        public void OutputInComboBox(ComboBox combo)
        {
            combo.Items.Clear();
            foreach (object o in this)
            {
                combo.Items.Add(o);
            }
        }
    }
}
