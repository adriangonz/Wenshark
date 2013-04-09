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

            if (sEN.Artist != null)
                artist = sEN.Artist.Id;
            
            if (sEN.Album != null)
                album = sEN.Album.Id;

       /*     
            genre = new List<int>();
            foreach (var item in sEN.Genre)
            {
                genre.Add(item.Id);
            }
        */ 
        }
        
        [DataMember]
        public int id;
        [DataMember]
        public String name = "";
        [DataMember]
        public DateTime? created = null;
        [DataMember]
        public int? artist = null;
        [DataMember]
        public int? album = null;
        [DataMember]
        List<int> genre = null;
    }
}