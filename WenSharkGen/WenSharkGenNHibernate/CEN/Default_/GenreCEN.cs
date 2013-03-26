

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
public partial class GenreCEN
{
private IGenreCAD _IGenreCAD;

public GenreCEN()
{
        this._IGenreCAD = new GenreCAD ();
}

public GenreCEN(IGenreCAD _IGenreCAD)
{
        this._IGenreCAD = _IGenreCAD;
}

public IGenreCAD get_IGenreCAD ()
{
        return this._IGenreCAD;
}

public int New_ (string p_name)
{
        GenreEN genreEN = null;
        int oid;

        //Initialized GenreEN
        genreEN = new GenreEN ();
        genreEN.Name = p_name;

        //Call to GenreCAD

        oid = _IGenreCAD.New_ (genreEN);
        return oid;
}

public void Destroy (int id)
{
        _IGenreCAD.Destroy (id);
}

public void Modify (int p_oid, string p_name)
{
        GenreEN genreEN = null;

        //Initialized GenreEN
        genreEN = new GenreEN ();
        genreEN.Id = p_oid;
        genreEN.Name = p_name;
        //Call to GenreCAD

        _IGenreCAD.Modify (genreEN);
}

public GenreEN GetByID (int id)
{
        GenreEN genreEN = null;

        genreEN = _IGenreCAD.GetByID (id);
        return genreEN;
}

public System.Collections.Generic.IList<GenreEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<GenreEN> list = null;

        list = _IGenreCAD.GetAll (first, size);
        return list;
}
}
}
