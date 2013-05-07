
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


void Relationer_song (int p_playlist, System.Collections.Generic.IList<int> p_song);

void Relationer_user (int p_playlist, int p_user);
}
}
