
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IUserCAD
{
UserEN ReadOIDDefault (int id);

UserEN GetByID (int id);


System.Collections.Generic.IList<UserEN> GetAll (int first, int size);


System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> Search (string p_filter);


void AddNewPlayList (int p_user, System.Collections.Generic.IList<int> p_playlist);

void Relationer_sigues (int p_user, System.Collections.Generic.IList<int> p_user2);

void Unrelationer_sigues (int p_user, System.Collections.Generic.IList<int> p_user2);
}
}
