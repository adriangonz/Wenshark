
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

public void Modify (OAuthUserEN oAuthUser)
{
        try
        {
                SessionInitializeTransaction ();
                OAuthUserEN oAuthUserEN = (OAuthUserEN)session.Load (typeof(OAuthUserEN), oAuthUser.Id);

                oAuthUserEN.IdOAuth = oAuthUser.IdOAuth;


                oAuthUserEN.Token_oauth = oAuthUser.Token_oauth;


                oAuthUserEN.Name = oAuthUser.Name;


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

public System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.OAuthUserEN> GetByidOAuth (string p_filter)
{
        System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.OAuthUserEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM OAuthUserEN self where FROM OAuthUserEN WHERE idOAuth = :p_filter";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("OAuthUserENgetByidOAuthHQL");
                query.SetParameter ("p_filter", p_filter);

                result = query.List<WenSharkGenNHibernate.EN.Default_.OAuthUserEN>();
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

        return result;
}
}
}
