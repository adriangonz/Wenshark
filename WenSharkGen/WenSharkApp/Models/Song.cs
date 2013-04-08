using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;
using WenSharkGenNHibernate.EN.Default_;


namespace WenSharkApp.Models
{

    [DataContract]
    public class Song
    {
        public Song(SongEN sEN)
        {
            id = sEN.Id;
            name = sEN.Name;
            created = sEN.Created;
            artist = null;//new Artist(sEN.Artist);
            album = null;// new Album(sEN.Album);
        }
        
        [DataMember]
        public int id;
        [DataMember]
        public String name;
        [DataMember]
        public DateTime? created;
        [DataMember]
        public Artist artist;
        [DataMember]
        public Album album;
    }
}