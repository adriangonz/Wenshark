

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
private IArtistCAD _IArtistCAD;

public ArtistCEN()
{
        this._IArtistCAD = new ArtistCAD ();
}

public ArtistCEN(IArtistCAD _IArtistCAD)
{
        this._IArtistCAD = _IArtistCAD;
}

public IArtistCAD get_IArtistCAD ()
{
        return this._IArtistCAD;
}

public int New_ (string p_bio, string p_image, string p_name, Nullable<DateTime> p_created, string p_type)
{
        ArtistEN artistEN = null;
        int oid;

        //Initialized ArtistEN
        artistEN = new ArtistEN ();
        artistEN.Bio = p_bio;

        artistEN.Image = p_image;

        artistEN.Name = p_name;

        artistEN.Created = p_created;

        artistEN.Type = p_type;

        //Call to ArtistCAD

        oid = _IArtistCAD.New_ (artistEN);
        return oid;
}

public ArtistEN ReadOID (int id)
{
        ArtistEN artistEN = null;

        artistEN = _IArtistCAD.ReadOID (id);
        return artistEN;
}

public void Destroy (int id)
{
        _IArtistCAD.Destroy (id);
}

public void Modify (int p_oid, string p_bio, string p_name, Nullable<DateTime> p_created)
{
        ArtistEN artistEN = null;

        //Initialized ArtistEN
        artistEN = new ArtistEN ();
        artistEN.Id = p_oid;
        artistEN.Bio = p_bio;
        artistEN.Name = p_name;
        artistEN.Created = p_created;
        //Call to ArtistCAD

        _IArtistCAD.Modify (artistEN);
}

public System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ArtistEN> Search (string p_filter)
{
        return _IArtistCAD.Search (p_filter);
}
}
}
