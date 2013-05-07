

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
public partial class PlayListCEN
{
private IPlayListCAD _IPlayListCAD;

public PlayListCEN()
{
        this._IPlayListCAD = new PlayListCAD ();
}

public PlayListCEN(IPlayListCAD _IPlayListCAD)
{
        this._IPlayListCAD = _IPlayListCAD;
}

public IPlayListCAD get_IPlayListCAD ()
{
        return this._IPlayListCAD;
}

public int New_ (string p_name)
{
        PlayListEN playListEN = null;
        int oid;

        //Initialized PlayListEN
        playListEN = new PlayListEN ();
        playListEN.Name = p_name;

        //Call to PlayListCAD

        oid = _IPlayListCAD.New_ (playListEN);
        return oid;
}

public void Destroy (int id)
{
        _IPlayListCAD.Destroy (id);
}

public void Modify (int p_oid, string p_name)
{
        PlayListEN playListEN = null;

        //Initialized PlayListEN
        playListEN = new PlayListEN ();
        playListEN.Id = p_oid;
        playListEN.Name = p_name;
        //Call to PlayListCAD

        _IPlayListCAD.Modify (playListEN);
}

public PlayListEN GetById (int id)
{
        PlayListEN playListEN = null;

        playListEN = _IPlayListCAD.GetById (id);
        return playListEN;
}

public void Relationer_song (int p_playlist, System.Collections.Generic.IList<int> p_song)
{
        //Call to PlayListCAD

        _IPlayListCAD.Relationer_song (p_playlist, p_song);
}
public void Relationer_user (int p_playlist, int p_user)
{
        //Call to PlayListCAD

        _IPlayListCAD.Relationer_user (p_playlist, p_user);
}
public void Unrelationer_song (int p_playlist, System.Collections.Generic.IList<int> p_song)
{
        //Call to PlayListCAD

        _IPlayListCAD.Unrelationer_song (p_playlist, p_song);
}
public void Unrelationer_user (int p_playlist, int p_user)
{
        //Call to PlayListCAD

        _IPlayListCAD.Unrelationer_user (p_playlist, p_user);
}
}
}
