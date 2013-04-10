
using System;
using System.Text;
using WenSharkGenNHibernate.CEN.Default_;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.Exceptions;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial class SongCAD : BasicCAD, ISongCAD
{
public SongCAD() : base ()
{
}

public SongCAD(ISession sessionAux) : base (sessionAux)
{
}



public SongEN ReadOIDDefault (int id)
{
        SongEN songEN = null;

        try
        {
                SessionInitializeTransaction ();
                songEN = (SongEN)session.Get (typeof(SongEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in SongCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return songEN;
}


public int New_ (SongEN song)
{
        try
        {
                SessionInitializeTransaction ();
                if (song.Artist != null) {
                        song.Artist = (WenSharkGenNHibernate.EN.Default_.ArtistEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.ArtistEN), song.Artist.Id);

                        song.Artist.Songs.Add (song);
                }
                if (song.Album != null) {
                        song.Album = (WenSharkGenNHibernate.EN.Default_.AlbumEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.AlbumEN), song.Album.Id);

                        song.Album.Songs.Add (song);
                }

                session.Save (song);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in SongCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return song.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                SongEN songEN = (SongEN)session.Load (typeof(SongEN), id);
                session.Delete (songEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in SongCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (SongEN song)
{
        try
        {
                SessionInitializeTransaction ();
                SongEN songEN = (SongEN)session.Load (typeof(SongEN), song.Id);

                songEN.Fname = song.Fname;


                songEN.Name = song.Name;


                songEN.Created = song.Created;

                session.Update (songEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in SongCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<SongEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<SongEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SongEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SongEN>();
                else
                        result = session.CreateCriteria (typeof(SongEN)).List<SongEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in SongCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
