
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
public partial class PlayListCAD : BasicCAD, IPlayListCAD
{
public PlayListCAD() : base ()
{
}

public PlayListCAD(ISession sessionAux) : base (sessionAux)
{
}



public PlayListEN ReadOIDDefault (int id)
{
        PlayListEN playListEN = null;

        try
        {
                SessionInitializeTransaction ();
                playListEN = (PlayListEN)session.Get (typeof(PlayListEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in PlayListCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return playListEN;
}


public int New_ (PlayListEN playList)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (playList);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in PlayListCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return playList.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                PlayListEN playListEN = (PlayListEN)session.Load (typeof(PlayListEN), id);
                session.Delete (playListEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in PlayListCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (PlayListEN playList)
{
        try
        {
                SessionInitializeTransaction ();
                PlayListEN playListEN = (PlayListEN)session.Load (typeof(PlayListEN), playList.Id);

                playListEN.Name = playList.Name;

                session.Update (playListEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in PlayListCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public PlayListEN GetById (int id)
{
        PlayListEN playListEN = null;

        try
        {
                SessionInitializeTransaction ();
                playListEN = (PlayListEN)session.Get (typeof(PlayListEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in PlayListCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return playListEN;
}

public void Relationer_song (int p_playlist, System.Collections.Generic.IList<int> p_song)
{
        WenSharkGenNHibernate.EN.Default_.PlayListEN playListEN = null;
        try
        {
                SessionInitializeTransaction ();
                playListEN = (PlayListEN)session.Load (typeof(PlayListEN), p_playlist);
                WenSharkGenNHibernate.EN.Default_.SongEN songENAux = null;
                if (playListEN.Song == null) {
                        playListEN.Song = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.SongEN>();
                }

                foreach (int item in p_song) {
                        songENAux = new WenSharkGenNHibernate.EN.Default_.SongEN ();
                        songENAux = (WenSharkGenNHibernate.EN.Default_.SongEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.SongEN), item);
                        songENAux.Playlist.Add (playListEN);

                        playListEN.Song.Add (songENAux);
                }


                session.Update (playListEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in PlayListCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_user (int p_playlist, int p_user)
{
        WenSharkGenNHibernate.EN.Default_.PlayListEN playListEN = null;
        try
        {
                SessionInitializeTransaction ();
                playListEN = (PlayListEN)session.Load (typeof(PlayListEN), p_playlist);
                playListEN.User = (WenSharkGenNHibernate.EN.Default_.UserEN)session.Load (typeof(WenSharkGenNHibernate.EN.Default_.UserEN), p_user);

                playListEN.User.Playlist.Add (playListEN);



                session.Update (playListEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WenSharkGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WenSharkGenNHibernate.Exceptions.DataLayerException ("Error in PlayListCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
