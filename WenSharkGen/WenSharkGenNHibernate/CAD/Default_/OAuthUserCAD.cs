
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
public partial class OAuthUserCAD : BasicCAD, IOAuthUserCAD
{
public OAuthUserCAD() : base ()
{
}

public OAuthUserCAD(ISession sessionAux) : base (sessionAux)
{
}



public OAuthUserEN ReadOIDDefault (int id)
{
        OAuthUserEN oAuthUserEN = null;

        try
        {
                SessionInitializeTransaction ();
                oAuthUserEN = (OAuthUserEN)session.Get (typeof(OAuthUserEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in OAuthUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return oAuthUserEN;
}


public int New_ (OAuthUserEN oAuthUser)
{
        try
        {
                SessionInitializeTransaction ();
                if (oAuthUser.Provider != null) {
                        oAuthUser.Provider = (WenSharkGenNHibernate.EN.Default_.OAuthProviderEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.OAuthProviderEN), oAuthUser.Provider.Id);

                        oAuthUser.Provider.Users.Add (oAuthUser);
                }

                session.Save (oAuthUser);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in OAuthUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return oAuthUser.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                OAuthUserEN oAuthUserEN = (OAuthUserEN)session.Load (typeof(OAuthUserEN), id);
                session.Delete (oAuthUserEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in OAuthUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (OAuthUserEN oAuthUser)
{
        try
        {
                SessionInitializeTransaction ();
                OAuthUserEN oAuthUserEN = (OAuthUserEN)session.Load (typeof(OAuthUserEN), oAuthUser.Id);

                oAuthUserEN.Token_oauth = oAuthUser.Token_oauth;


                oAuthUserEN.Name = oAuthUser.Name;


                oAuthUserEN.Username = oAuthUser.Username;


                oAuthUserEN.Email = oAuthUser.Email;


                oAuthUserEN.Created = oAuthUser.Created;

                session.Update (oAuthUserEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in OAuthUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
