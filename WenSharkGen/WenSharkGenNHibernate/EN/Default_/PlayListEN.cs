
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class PlayListEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string name;

/**
 *
 */

private WenSharkGenNHibernate.EN.Default_.UserEN user;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> song;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Name {
        get { return name; } set { name = value;  }
}


public virtual WenSharkGenNHibernate.EN.Default_.UserEN User {
        get { return user; } set { user = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> Song {
        get { return song; } set { song = value;  }
}





public PlayListEN()
{
        song = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.SongEN>();
}



public PlayListEN(int id, string name, WenSharkGenNHibernate.EN.Default_.UserEN user, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> song)
{
        this.init (id, name, user, song);
}


public PlayListEN(PlayListEN playList)
{
        this.init (playList.Id, playList.Name, playList.User, playList.Song);
}

private void init (int id, string name, WenSharkGenNHibernate.EN.Default_.UserEN user, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> song)
{
        this.Id = id;


        this.Name = name;

        this.User = user;

        this.Song = song;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PlayListEN t = obj as PlayListEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
