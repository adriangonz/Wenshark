
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class UserEN
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

private string username;

/**
 *
 */

private string email;

/**
 *
 */

private Nullable<DateTime> created;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Name {
        get { return name; } set { name = value;  }
}


public virtual string Username {
        get { return username; } set { username = value;  }
}


public virtual string Email {
        get { return email; } set { email = value;  }
}


public virtual Nullable<DateTime> Created {
        get { return created; } set { created = value;  }
}





public UserEN()
{
}



public UserEN(int id, string name, string username, string email, Nullable<DateTime> created)
{
        this.init (id, name, username, email, created);
}


public UserEN(UserEN user)
{
        this.init (user.Id, user.Name, user.Username, user.Email, user.Created);
}

private void init (int id, string name, string username, string email, Nullable<DateTime> created)
{
        this.Id = id;


        this.Name = name;

        this.Username = username;

        this.Email = email;

        this.Created = created;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UserEN t = obj as UserEN;
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
