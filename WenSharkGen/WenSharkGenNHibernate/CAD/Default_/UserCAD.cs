
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
public void Relationer_favorites (int p_user, System.Collections.Generic.IList<int> p_item)
{
        WenSharkGenNHibernate.EN.Default_.UserEN userEN = null;
        try
        {
                SessionInitializeTransaction ();
                userEN = (UserEN)session.Load (typeof(UserEN), p_user);
                WenSharkGenNHibernate.EN.Default_.ItemEN favoritesENAux = null;
                if (userEN.Favorites == null) {
                        userEN.Favorites = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.ItemEN>();
                }

                foreach (int item in p_item) {
                        favoritesENAux = new WenSharkGenNHibernate.EN.Default_.ItemEN ();
                        favoritesENAux = (WenSharkGenNHibernate.EN.Default_.ItemEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.ItemEN), item);
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
}
}
