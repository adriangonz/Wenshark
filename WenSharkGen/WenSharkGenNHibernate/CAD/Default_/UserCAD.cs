
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
                //String sql = @"FROM UserEN self where FROM UserEN WHERE name LIKE '%' || :p_filter || '%'";
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
public void Relationer_favorites (int p_user, System.Collections.Generic.IList<int> p_song)
{
        WenSharkGenNHibernate.EN.Default_.UserEN userEN = null;
        try
        {
                SessionInitializeTransaction ();
                userEN = (UserEN)session.Load (typeof(UserEN), p_user);
                WenSharkGenNHibernate.EN.Default_.SongEN favoritesENAux = null;
                if (userEN.Favorites == null) {
                        userEN.Favorites = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.SongEN>();
                }

                foreach (int item in p_song) {
                        favoritesENAux = new WenSharkGenNHibernate.EN.Default_.SongEN ();
                        favoritesENAux = (WenSharkGenNHibernate.EN.Default_.SongEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.SongEN), item);
                        favoritesENAux.User.Add (userEN);

                        userEN.Favorites.Add (favoritesENAux);
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

public void Unrelationer_favorites (int p_user, System.Collections.Generic.IList<int> p_song)
{
        try
        {
                SessionInitializeTransaction ();
                WenSharkGenNHibernate.EN.Default_.UserEN userEN = null;
                userEN = (UserEN)session.Load (typeof(UserEN), p_user);

                WenSharkGenNHibernate.EN.Default_.SongEN favoritesENAux = null;
                if (userEN.Favorites != null) {
                        foreach (int item in p_song) {
                                favoritesENAux = (WenSharkGenNHibernate.EN.Default_.SongEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.SongEN), item);
                                if (userEN.Favorites.Contains (favoritesENAux) == true) {
                                        userEN.Favorites.Remove (favoritesENAux);
                                        favoritesENAux.User.Remove (userEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_song you are trying to unrelationer, doesn't exist in UserEN");
                        }
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

public void Relationer_sigues (int p_user, System.Collections.Generic.IList<int> p_user2)
{
        WenSharkGenNHibernate.EN.Default_.UserEN userEN = null;
        try
        {
                SessionInitializeTransaction ();
                userEN = (UserEN)session.Load (typeof(UserEN), p_user);
                WenSharkGenNHibernate.EN.Default_.UserEN siguesENAux = null;
                if (userEN.Sigues == null) {
                        userEN.Sigues = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.UserEN>();
                }

                foreach (int item in p_user2) {
                        siguesENAux = new WenSharkGenNHibernate.EN.Default_.UserEN ();
                        siguesENAux = (WenSharkGenNHibernate.EN.Default_.UserEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.UserEN), item);
                        siguesENAux.Seguidores.Add (userEN);

                        userEN.Sigues.Add (siguesENAux);
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

public void Unrelationer_sigues (int p_user, System.Collections.Generic.IList<int> p_user2)
{
        try
        {
                SessionInitializeTransaction ();
                WenSharkGenNHibernate.EN.Default_.UserEN userEN = null;
                userEN = (UserEN)session.Load (typeof(UserEN), p_user);

                WenSharkGenNHibernate.EN.Default_.UserEN siguesENAux = null;
                if (userEN.Sigues != null) {
                        foreach (int item in p_user2) {
                                siguesENAux = (WenSharkGenNHibernate.EN.Default_.UserEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.UserEN), item);
                                if (userEN.Sigues.Contains (siguesENAux) == true) {
                                        userEN.Sigues.Remove (siguesENAux);
                                        siguesENAux.Seguidores.Remove (userEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_user2 you are trying to unrelationer, doesn't exist in UserEN");
                        }
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
