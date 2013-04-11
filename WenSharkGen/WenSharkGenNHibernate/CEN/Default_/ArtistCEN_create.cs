
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
public partial class ArtistCEN
{
public WenSharkGenNHibernate.EN.Default_.ArtistEN Create (string name, string bio, string image)
{
        /*PROTECTED REGION ID(WenSharkGenNHibernate.CEN.Default__Artist_create) ENABLED START*/

        // Write here your custom code...

        ArtistEN artistEN = new ArtistEN ();

        artistEN.Type = "Artist";

        artistEN.Name = name;
        artistEN.Image = image;
        artistEN.Bio = bio;

        artistEN.Created = DateTime.Now;

        artistEN.Id = _IArtistCAD.New_ (artistEN);
        return artistEN;

        /*PROTECTED REGION END*/
}
}
}
