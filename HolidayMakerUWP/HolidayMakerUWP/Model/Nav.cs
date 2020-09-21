using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Model
{
    public class Nav
    {
        public object Glyph { get; set; }
        public string Text { get; set; }
        public Type Page { get; set; }
        public Nav(object glyph = null, string text = "", Type page = null)
        {
            Glyph = glyph;
            Text = text;
            Page = page;
        }
    }
}
