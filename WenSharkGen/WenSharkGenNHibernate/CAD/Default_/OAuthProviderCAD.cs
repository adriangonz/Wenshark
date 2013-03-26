
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
public partial class OAuthProviderCAD : BasicCAD, IOAuthProviderCAD
{
public OAuthProviderCAD() : base ()
{
}

public OAuthProviderCAD(ISession sessionAux) : base (sessionAux)
{
}



public OAuthProviderEN ReadOIDDefault (int id)
{
        OAuthProviderEN oAuthProviderEN = null;

        try
        {
                SessionInitializeTransaction ();
                oAuthProviderEN = (OAuthProviderEN)session.Get (typeof(OAuthProviderEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in OAuthProviderCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return oAuthProviderEN;
}


public int New_ (OAuthProviderEN oAuthProvider)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (oAuthProvider);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in OAuthProviderCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return oAuthProvider.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                OAuthProviderEN oAuthProviderEN = (OAuthProviderEN)session.Load (typeof(OAuthProviderEN), id);
                session.Delete (oAuthProviderEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in OAuthProviderCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (OAuthProviderEN oAuthProvider)
{
        try
        {
                SessionInitializeTransaction ();
                OAuthProviderEN oAuthProviderEN = (OAuthProviderEN)session.Load (typeof(OAuthProviderEN), oAuthProvider.Id);

                oAuthProviderEN.Name = oAuthProvider.Name;


                oAuthProviderEN.Token_app = oAuthProvider.Token_app;

                session.Update (oAuthProviderEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in OAuthProviderCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public OAuthProviderEN GetByID (int id)
{
        OAuthProviderEN oAuthProviderEN = null;

        try
        {
                SessionInitializeTransaction ();
                oAuthProviderEN = (OAuthProviderEN)session.Get (typeof(OAuthProviderEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in OAuthProviderCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return oAuthProviderEN;
}

public System.Collections.Generic.IList<OAuthProviderEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<OAuthProviderEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(OAuthProviderEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<OAuthProviderEN>();
                else
                        result = session.CreateCriteria (typeof(OAuthProviderEN)).List<OAuthProviderEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in OAuthProviderCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
