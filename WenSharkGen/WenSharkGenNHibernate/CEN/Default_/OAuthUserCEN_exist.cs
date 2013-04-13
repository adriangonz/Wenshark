
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
public partial class OAuthUserCEN
{
public bool Exist (string idOAuth)
{
        /*PROTECTED REGION ID(WenSharkGenNHibernate.CEN.Default__OAuthUser_exist) ENABLED START*/

        // Write here your custom code...
    Boolean exist = false;
    var users = this.GetByidOAuth(idOAuth);

    if (users.Count == 1)
    {
        exist = true;
    }
    return exist;

        /*PROTECTED REGION END*/
}
}
}
