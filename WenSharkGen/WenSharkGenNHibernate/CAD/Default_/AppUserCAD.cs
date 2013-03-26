
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
public partial class AppUserCAD : BasicCAD, IAppUserCAD
{
public AppUserCAD() : base ()
{
}

public AppUserCAD(ISession sessionAux) : base (sessionAux)
{
}



public AppUserEN ReadOIDDefault (int id)
{
        AppUserEN appUserEN = null;

        try
        {
                SessionInitializeTransaction ();
                appUserEN = (AppUserEN)session.Get (typeof(AppUserEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in AppUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return appUserEN;
}


public int New_ (AppUserEN appUser)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (appUser);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in AppUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return appUser.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                AppUserEN appUserEN = (AppUserEN)session.Load (typeof(AppUserEN), id);
                session.Delete (appUserEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in AppUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (AppUserEN appUser)
{
        try
        {
                SessionInitializeTransaction ();
                AppUserEN appUserEN = (AppUserEN)session.Load (typeof(AppUserEN), appUser.Id);

                appUserEN.Password = appUser.Password;


                appUserEN.Name = appUser.Name;


                appUserEN.Username = appUser.Username;


                appUserEN.Email = appUser.Email;


                appUserEN.Created = appUser.Created;

                session.Update (appUserEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in AppUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
