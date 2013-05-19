
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class PublicationEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string text;

/**
 *
 */

private WenSharkGenNHibernate.EN.Default_.UserEN user;

/**
 *
 */

private WenSharkGenNHibernate.EN.Default_.ItemEN item;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Text {
        get { return text; } set { text = value;  }
}


public virtual WenSharkGenNHibernate.EN.Default_.UserEN User {
        get { return user; } set { user = value;  }
}


public virtual WenSharkGenNHibernate.EN.Default_.ItemEN Item {
        get { return item; } set { item = value;  }
}





public PublicationEN()
{
}



public PublicationEN(int id, string text, WenSharkGenNHibernate.EN.Default_.UserEN user, WenSharkGenNHibernate.EN.Default_.ItemEN item)
{
        this.init (id, text, user, item);
}


public PublicationEN(PublicationEN publication)
{
        this.init (publication.Id, publication.Text, publication.User, publication.Item);
}

private void init (int id, string text, WenSharkGenNHibernate.EN.Default_.UserEN user, WenSharkGenNHibernate.EN.Default_.ItemEN item)
{
        this.Id = id;


        this.Text = text;

        this.User = user;

        this.Item = item;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PublicationEN t = obj as PublicationEN;
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
