
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


                publicationEN.Created = publication.Created;

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
public void SetItem (int p_publication, int p_item)
{
        WenSharkGenNHibernate.EN.Default_.PublicationEN publicationEN = null;
        try
        {
                SessionInitializeTransaction ();
                publicationEN = (PublicationEN)session.Load (typeof(PublicationEN), p_publication);
                publicationEN.Item = (WenSharkGenNHibernate.EN.Default_.ItemEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.ItemEN), p_item);

                publicationEN.Item.Publication.Add (publicationEN);



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

public void SetUser (int p_publication, int p_user)
{
        WenSharkGenNHibernate.EN.Default_.PublicationEN publicationEN = null;
        try
        {
                SessionInitializeTransaction ();
                publicationEN = (PublicationEN)session.Load (typeof(PublicationEN), p_publication);
                publicationEN.User = (WenSharkGenNHibernate.EN.Default_.UserEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.UserEN), p_user);

                publicationEN.User.Publication.Add (publicationEN);



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

public void Unrelate_Item (int p_publication, int p_item)
{
        try
        {
                SessionInitializeTransaction ();
                WenSharkGenNHibernate.EN.Default_.PublicationEN publicationEN = null;
                publicationEN = (PublicationEN)session.Load (typeof(PublicationEN), p_publication);

                if (publicationEN.Item.Id == p_item) {
                        publicationEN.Item = null;
                }
                else
                        throw new ModelException ("The identifier " + p_item + " in p_item you are trying to unrelationer, doesn't exist in PublicationEN");

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
public void Unrelate_User (int p_publication, int p_user)
{
        try
        {
                SessionInitializeTransaction ();
                WenSharkGenNHibernate.EN.Default_.PublicationEN publicationEN = null;
                publicationEN = (PublicationEN)session.Load (typeof(PublicationEN), p_publication);

                if (publicationEN.User.Id == p_user) {
                        publicationEN.User = null;
                }
                else
                        throw new ModelException ("The identifier " + p_user + " in p_user you are trying to unrelationer, doesn't exist in PublicationEN");

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
