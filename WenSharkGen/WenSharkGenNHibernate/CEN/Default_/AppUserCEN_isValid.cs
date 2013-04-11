
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
public bool IsValid (string user, string pass)
{
        /*PROTECTED REGION ID(WenSharkGenNHibernate.CEN.Default__AppUser_isValid) ENABLED START*/
        Boolean valid = false;
        AppUserEN userEN = null;
        var users = this.GetByUsername (user);

        if (users.Count == 1) {
                userEN = users [0];
                if (userEN.Username == user && userEN.Password == pass) {
                        valid = true;
                }
        }

        return valid;
        /*PROTECTED REGION END*/
}
}
}
