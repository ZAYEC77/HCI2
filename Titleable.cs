using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPlayer
{
    public class Titleable
    {
        public string Title { get; set; }
        public override String ToString()
        {
            return this.Title;
        }
    }
}
