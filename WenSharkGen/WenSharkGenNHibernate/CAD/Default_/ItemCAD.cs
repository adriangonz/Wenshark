
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
public partial class ItemCAD : BasicCAD, IItemCAD
{
public ItemCAD() : base ()
{
}

public ItemCAD(ISession sessionAux) : base (sessionAux)
{
}



public ItemEN ReadOIDDefault (int id)
{
        ItemEN itemEN = null;

        try
        {
                SessionInitializeTransaction ();
                itemEN = (ItemEN)session.Get (typeof(ItemEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return itemEN;
}


public int New_ (ItemEN item)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (item);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return item.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                ItemEN itemEN = (ItemEN)session.Load (typeof(ItemEN), id);
                session.Delete (itemEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (ItemEN item)
{
        try
        {
                SessionInitializeTransaction ();
                ItemEN itemEN = (ItemEN)session.Load (typeof(ItemEN), item.Id);

                itemEN.Name = item.Name;


                itemEN.Created = item.Created;

                session.Update (itemEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public ItemEN GetByID (int id)
{
        ItemEN itemEN = null;

        try
        {
                SessionInitializeTransaction ();
                itemEN = (ItemEN)session.Get (typeof(ItemEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return itemEN;
}

public System.Collections.Generic.IList<ItemEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<ItemEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ItemEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ItemEN>();
                else
                        result = session.CreateCriteria (typeof(ItemEN)).List<ItemEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ItemEN> Search (string p_filter)
{
        System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ItemEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ItemEN self where FROM ItemEN WHERE lower(:p_filter) LIKE %lower(name)%";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ItemENsearchHQL");
                query.SetParameter ("p_filter", p_filter);

                result = query.List<WenSharkGenNHibernate.EN.Default_.ItemEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
