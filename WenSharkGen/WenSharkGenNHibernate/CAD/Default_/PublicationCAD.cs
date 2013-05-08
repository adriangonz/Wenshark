
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
public partial class PublicationCAD : BasicCAD, IPublicationCAD
{
public PublicationCAD() : base ()
{
}

public PublicationCAD(ISession sessionAux) : base (sessionAux)
{
}



public PublicationEN ReadOIDDefault (int id)
{
        PublicationEN publicationEN = null;

        try
        {
                SessionInitializeTransaction ();
                publicationEN = (PublicationEN)session.Get (typeof(PublicationEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in PublicationCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return publicationEN;
}


public int New_ (PublicationEN publication)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (publication);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in PublicationCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return publication.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                PublicationEN publicationEN = (PublicationEN)session.Load (typeof(PublicationEN), id);
                session.Delete (publicationEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in PublicationCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (PublicationEN publication)
{
        try
        {
                SessionInitializeTransaction ();
                PublicationEN publicationEN = (PublicationEN)session.Load (typeof(PublicationEN), publication.Id);

                publicationEN.Text = publication.Text;

                session.Update (publicationEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in PublicationCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
