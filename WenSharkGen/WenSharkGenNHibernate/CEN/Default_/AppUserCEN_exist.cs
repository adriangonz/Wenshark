
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CAD.Default_;

namespace WenSharkGenNHibernate.CEN.Default_
{
public partial class AppUserCEN
{
public bool Exist (string user)
{
        /*PROTECTED REGION ID(WenSharkGenNHibernate.CEN.Default__AppUser_exist) ENABLED START*/
    Boolean exist = false;
    var users = this.GetByUsername(user);

    if (users.Count == 1)
    {
        exist = true;    
    }
    return exist;
        /*PROTECTED REGION END*/
}
}
}
