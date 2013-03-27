
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IGenreCAD
{
GenreEN ReadOIDDefault (int id);

int New_ (GenreEN genre);

void Destroy (int id);


void Modify (GenreEN genre);


GenreEN GetByID (int id);


System.Collections.Generic.IList<GenreEN> GetAll (int first, int size);
}
}
