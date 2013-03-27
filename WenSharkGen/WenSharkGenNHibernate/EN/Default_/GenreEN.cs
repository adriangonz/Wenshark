
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class GenreEN
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

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ItemEN> item;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Name {
        get { return name; } set { name = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ItemEN> Item {
        get { return item; } set { item = value;  }
}





public GenreEN()
{
        item = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.ItemEN>();
}



public GenreEN(int id, string name, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ItemEN> item)
{
        this.init (id, name, item);
}


public GenreEN(GenreEN genre)
{
        this.init (genre.Id, genre.Name, genre.Item);
}

private void init (int id, string name, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ItemEN> item)
{
        this.Id = id;


        this.Name = name;

        this.Item = item;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GenreEN t = obj as GenreEN;
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
