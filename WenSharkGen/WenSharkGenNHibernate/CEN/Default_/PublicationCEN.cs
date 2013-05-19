

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

public void SetItem (int p_publication, int p_item)
{
        //Call to PublicationCAD

        _IPublicationCAD.SetItem (p_publication, p_item);
}
public void SetUser (int p_publication, int p_user)
{
        //Call to PublicationCAD

        _IPublicationCAD.SetUser (p_publication, p_user);
}
public void Unrelate_Item (int p_publication, int p_item)
{
        //Call to PublicationCAD

        _IPublicationCAD.Unrelate_Item (p_publication, p_item);
}
public void Unrelate_User (int p_publication, int p_user)
{
        //Call to PublicationCAD

        _IPublicationCAD.Unrelate_User (p_publication, p_user);
}
}
}
