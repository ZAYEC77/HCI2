using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPlayer
{
    enum Style { rock, pop, electronic }
    class Track : Titleable
    {
        protected Album album;
        public Style Style { get; set; }
        public Album Album
        {
            get { return this.album; }
            set { this.album = value; }
        }
        public Artist Artist
        {
            get { return this.album.Artist; }
        }
        public Track(String title, Album album)
        {
            this.Title = title;
            this.album = album;
        }

        public Track()
        {
            
        }
    }
    

}
