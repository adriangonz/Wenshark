
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class ItemEN
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

private Nullable<DateTime> created;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Name {
        get { return name; } set { name = value;  }
}


public virtual Nullable<DateTime> Created {
        get { return created; } set { created = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> Genre {
        get { return genre; } set { genre = value;  }
}





public ItemEN()
{
        genre = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.GenreEN>();
}



public ItemEN(int id, string name, Nullable<DateTime> created, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre)
{
        this.init (id, name, created, genre);
}


public ItemEN(ItemEN item)
{
        this.init (item.Id, item.Name, item.Created, item.Genre);
}

private void init (int id, string name, Nullable<DateTime> created, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre)
{
        this.Id = id;


        this.Name = name;

        this.Created = created;

        this.Genre = genre;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ItemEN t = obj as ItemEN;
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
