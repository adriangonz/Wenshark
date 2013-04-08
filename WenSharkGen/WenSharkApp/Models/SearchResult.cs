using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WenSharkApp.Models
{
    [DataContract]
    public class SearchResult
    {
        public SearchResult()
        {
            songs = new List<Song>();
            artists = new List<Artist>();
            albums = new List<Album>();
        }
        
        [DataMember]
        public List<Song> songs;
        
        [DataMember]
        public List<Artist> artists;
        
        [DataMember]
        public List<Album> albums;

    }
}