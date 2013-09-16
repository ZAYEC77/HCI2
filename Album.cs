using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPlayer
{
    class Album : Titleable
    {
        protected Artist artist;
        public Artist Artist
        {
            get { return this.Artist; }
            set { this.artist = value; }
        }
        public Outputable Tracks { get; set; }

        public Album()
        {
            this.Tracks = new Outputable();
        }
    }
}
