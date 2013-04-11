
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CAD.Default_;

namespace WenSharkGenNHibernate.CEN.Default_
{
public partial class AlbumCEN
{
public WenSharkGenNHibernate.EN.Default_.AlbumEN Create (string name, Nullable<DateTime> published, string image, int artist)
{
        /*PROTECTED REGION ID(WenSharkGenNHibernate.CEN.Default__Album_create) ENABLED START*/

        AlbumEN albumEN = new AlbumEN ();

        albumEN.Type = "Album";
        albumEN.Created = DateTime.Now;

        albumEN.Name = name;
        albumEN.Published = published;
        albumEN.Image = image;

        if (artist != -1) {
                albumEN.Artist = new ArtistEN ();
                albumEN.Artist.Id = artist;
        }

        albumEN.Id = _IAlbumCAD.New_ (albumEN);
        return albumEN;

        /*PROTECTED REGION END*/
}
}
}
