
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
public partial class AlbumCAD : BasicCAD, IAlbumCAD
{
public AlbumCAD() : base ()
{
}

public AlbumCAD(ISession sessionAux) : base (sessionAux)
{
}



public AlbumEN ReadOIDDefault (int id)
{
        AlbumEN albumEN = null;

        try
        {
                SessionInitializeTransaction ();
                albumEN = (AlbumEN)session.Get (typeof(AlbumEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return albumEN;
}


public int New_ (AlbumEN album)
{
        try
        {
                SessionInitializeTransaction ();
                if (album.Artist != null) {
                        album.Artist = (WenSharkGenNHibernate.EN.Default_.ArtistEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.ArtistEN), album.Artist.Id);

                        album.Artist.Albums.Add (album);
                }

                session.Save (album);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return album.Id;
}

public AlbumEN ReadOID (int id)
{
        AlbumEN albumEN = null;

        try
        {
                SessionInitializeTransaction ();
                albumEN = (AlbumEN)session.Get (typeof(AlbumEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return albumEN;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                AlbumEN albumEN = (AlbumEN)session.Load (typeof(AlbumEN), id);
                session.Delete (albumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (AlbumEN album)
{
        try
        {
                SessionInitializeTransaction ();
                AlbumEN albumEN = (AlbumEN)session.Load (typeof(AlbumEN), album.Id);

                albumEN.Published = album.Published;


                albumEN.Name = album.Name;


                albumEN.Created = album.Created;


                albumEN.Image = album.Image;

                session.Update (albumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.AlbumEN> Search (string p_filter)
{
        System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.AlbumEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AlbumEN self where FROM AlbumEN WHERE name LIKE '%' || :p_filter || '%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AlbumENsearchHQL");
                query.SetParameter ("p_filter", p_filter);

                result = query.List<WenSharkGenNHibernate.EN.Default_.AlbumEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
