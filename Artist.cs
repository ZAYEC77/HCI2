using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPlayer
{
    class Artist : Titleable
    {
        public Outputable Albums { get; set; }

        public Artist()
        {
            this.Albums = new Outputable();
        }
    }
}
