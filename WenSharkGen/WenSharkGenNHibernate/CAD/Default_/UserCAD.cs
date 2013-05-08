
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
public partial class UserCAD : BasicCAD, IUserCAD
{
public UserCAD() : base ()
{
}

public UserCAD(ISession sessionAux) : base (sessionAux)
{
}



public UserEN ReadOIDDefault (int id)
{
        UserEN userEN = null;

        try
        {
                SessionInitializeTransaction ();
                userEN = (UserEN)session.Get (typeof(UserEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userEN;
}


public UserEN GetByID (int id)
{
        UserEN userEN = null;

        try
        {
                SessionInitializeTransaction ();
                userEN = (UserEN)session.Get (typeof(UserEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userEN;
}

public System.Collections.Generic.IList<UserEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<UserEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UserEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UserEN>();
                else
                        result = session.CreateCriteria (typeof(UserEN)).List<UserEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> Search (string p_filter)
{
        System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UserEN self where FROM UserEN WHERE lower(:p_filter) LIKE %lower(username)%OR lower(:p_filter) LIKE %lower(name)%";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UserENsearchHQL");
                query.SetParameter ("p_filter", p_filter);

                result = query.List<WenSharkGenNHibernate.EN.Default_.UserEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AddNewPlayList (int p_user, System.Collections.Generic.IList<int> p_playlist)
{
        WenSharkGenNHibernate.EN.Default_.UserEN userEN = null;
        try
        {
                SessionInitializeTransaction ();
                userEN = (UserEN)session.Load (typeof(UserEN), p_user);
                WenSharkGenNHibernate.EN.Default_.PlayListEN playlistENAux = null;
                if (userEN.Playlist == null) {
                        userEN.Playlist = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.PlayListEN>();
                }

                foreach (int item in p_playlist) {
                        playlistENAux = new WenSharkGenNHibernate.EN.Default_.PlayListEN ();
                        playlistENAux = (WenSharkGenNHibernate.EN.Default_.PlayListEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.PlayListEN), item);
                        playlistENAux.User = userEN;

                        userEN.Playlist.Add (playlistENAux);
                }


                session.Update (userEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AddNewPublication (int p_user, System.Collections.Generic.IList<int> p_publication)
{
        WenSharkGenNHibernate.EN.Default_.UserEN userEN = null;
        try
        {
                SessionInitializeTransaction ();
                userEN = (UserEN)session.Load (typeof(UserEN), p_user);
                WenSharkGenNHibernate.EN.Default_.PublicationEN publicationENAux = null;
                if (userEN.Publication == null) {
                        userEN.Publication = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.PublicationEN>();
                }

                foreach (int item in p_publication) {
                        publicationENAux = new WenSharkGenNHibernate.EN.Default_.PublicationEN ();
                        publicationENAux = (WenSharkGenNHibernate.EN.Default_.PublicationEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.PublicationEN), item);
                        publicationENAux.User = userEN;

                        userEN.Publication.Add (publicationENAux);
                }


                session.Update (userEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
