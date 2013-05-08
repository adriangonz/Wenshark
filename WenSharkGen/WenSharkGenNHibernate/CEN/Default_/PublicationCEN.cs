

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
public partial class PublicationCEN
{
private IPublicationCAD _IPublicationCAD;

public PublicationCEN()
{
        this._IPublicationCAD = new PublicationCAD ();
}

public PublicationCEN(IPublicationCAD _IPublicationCAD)
{
        this._IPublicationCAD = _IPublicationCAD;
}

public IPublicationCAD get_IPublicationCAD ()
{
        return this._IPublicationCAD;
}

public int New_ (string p_text)
{
        PublicationEN publicationEN = null;
        int oid;

        //Initialized PublicationEN
        publicationEN = new PublicationEN ();
        publicationEN.Text = p_text;

        //Call to PublicationCAD

        oid = _IPublicationCAD.New_ (publicationEN);
        return oid;
}

public void Destroy (int id)
{
        _IPublicationCAD.Destroy (id);
}

public void Modify (int p_oid, string p_text)
{
        PublicationEN publicationEN = null;

        //Initialized PublicationEN
        publicationEN = new PublicationEN ();
        publicationEN.Id = p_oid;
        publicationEN.Text = p_text;
        //Call to PublicationCAD

        _IPublicationCAD.Modify (publicationEN);
}
}
}
