
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
public partial class ArtistCAD : BasicCAD, IArtistCAD
{
public ArtistCAD() : base ()
{
}

public ArtistCAD(ISession sessionAux) : base (sessionAux)
{
}



public ArtistEN ReadOIDDefault (int id)
{
        ArtistEN artistEN = null;

        try
        {
                SessionInitializeTransaction ();
                artistEN = (ArtistEN)session.Get (typeof(ArtistEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in ArtistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return artistEN;
}


public int New_ (ArtistEN artist)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (artist);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in ArtistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return artist.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                ArtistEN artistEN = (ArtistEN)session.Load (typeof(ArtistEN), id);
                session.Delete (artistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in ArtistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (ArtistEN artist)
{
        try
        {
                SessionInitializeTransaction ();
                ArtistEN artistEN = (ArtistEN)session.Load (typeof(ArtistEN), artist.Id);

                artistEN.Bio = artist.Bio;


                artistEN.Name = artist.Name;


                artistEN.Created = artist.Created;

                session.Update (artistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in ArtistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
