
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IPlayListCAD
{
PlayListEN ReadOIDDefault (int id);

int New_ (PlayListEN playList);

void Destroy (int id);


void Modify (PlayListEN playList);


PlayListEN GetById (int id);
}
}
