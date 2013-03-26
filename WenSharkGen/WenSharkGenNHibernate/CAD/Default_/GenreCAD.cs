
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
public partial class GenreCAD : BasicCAD, IGenreCAD
{
public GenreCAD() : base ()
{
}

public GenreCAD(ISession sessionAux) : base (sessionAux)
{
}



public GenreEN ReadOIDDefault (int id)
{
        GenreEN genreEN = null;

        try
        {
                SessionInitializeTransaction ();
                genreEN = (GenreEN)session.Get (typeof(GenreEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in GenreCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return genreEN;
}


public int New_ (GenreEN genre)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (genre);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in GenreCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return genre.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                GenreEN genreEN = (GenreEN)session.Load (typeof(GenreEN), id);
                session.Delete (genreEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in GenreCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (GenreEN genre)
{
        try
        {
                SessionInitializeTransaction ();
                GenreEN genreEN = (GenreEN)session.Load (typeof(GenreEN), genre.Id);

                genreEN.Name = genre.Name;

                session.Update (genreEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in GenreCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public GenreEN GetByID (int id)
{
        GenreEN genreEN = null;

        try
        {
                SessionInitializeTransaction ();
                genreEN = (GenreEN)session.Get (typeof(GenreEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in GenreCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return genreEN;
}

public System.Collections.Generic.IList<GenreEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<GenreEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GenreEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GenreEN>();
                else
                        result = session.CreateCriteria (typeof(GenreEN)).List<GenreEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in GenreCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
