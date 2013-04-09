using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WenSharkGenNHibernate.EN.Default_;
using System.Runtime.Serialization;

namespace WenSharkApp.Models
{
    [DataContract]   
    public class Album
    {
        public Album(AlbumEN aEN)
        {
            id = aEN.Id;
            name = aEN.Name;
            image = aEN.Image;


        }

        [DataMember]
        int id;

        [DataMember]
        String name;

        [DataMember]
        String image;


    }
}