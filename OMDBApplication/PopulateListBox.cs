using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;

namespace OMDBApplication
{
    public class PopulateListBox
    {
        // populate
        public static void Populate(ListBox lb)
        {
            string space = "\u00a0";
            lb.Items.Add(new ListItem("Select movie", "0"));
            lb.Items.Add(new ListItem(space + space + space + "The little Mermaid", "tt0097757"));
            lb.Items.Add(new ListItem(space + space + space + "Van Helsing", "tt0338526"));
            lb.Items.Add(new ListItem(space + space + space + "High Noon", "tt0044706"));
            lb.Items.Add(new ListItem(space + space + space + "Goldfinger", "tt0058150"));
        }
    }
}