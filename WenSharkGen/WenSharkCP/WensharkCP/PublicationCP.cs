using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.CAD.Default_;

namespace WenSharkCP.WensharkCP
{
    public class PublicationCP : BasicCP
    {
        public List<PublicationEN> getByUser(int idUser)
        {
            List<PublicationEN> publications = new List<PublicationEN>();
            SessionInitializeTransaction();


            UserCAD userCAD = new UserCAD(session);
            UserCEN userCEN = new UserCEN(userCAD);

            UserEN user = userCEN.GetByID(idUser);

            if (user != null)
            {
                publications = user.Publication.ToList();
                
            }

            foreach (var item in publications)
            {
                nullItem(item.Item);
                item.User = null;
            }

            SessionClose();

            

            return publications;
        }
    }
}
