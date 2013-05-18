using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenSharkGenNHibernate.CAD.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkCP.WensharkCP
{
    public class UserCP  : BasicCP
    {
        public UserEN getUser(int oid)
        {
            UserEN user = null;

            try
            {
                SessionInitializeTransaction();

                UserCAD usercad = new UserCAD(session);
                UserCEN usercen = new UserCEN(usercad);

                user = usercen.GetByID(oid);

                if (user == null) throw new Exception();

                foreach (SongEN s in user.Favorites)
                {
                    nullSong(s);
                }

                user.Playlist = null;
                user.Seguidores = null;
                user.Sigues = null;
                user.Publication = null;
            }
            catch (Exception ex)
            {
                SessionRollBack();
            }
            finally
            {
                SessionClose();
            }


            return user;
        }

        public void changeName(int oid, string name)
        {
            try
            {
                SessionInitializeTransaction();

                UserCAD usercad = new UserCAD(session);
                UserCEN usercen = new UserCEN(usercad);
                UserEN user;

                user = usercen.GetByID(oid);

                //Si no existe nos salimos
                if (user == null) throw new Exception();

                user.Name = name;

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
            }
            finally
            {
                SessionClose();
            }
        }

        public void changeImage(int oid, string img)
        {
            try
            {
                SessionInitializeTransaction();

                UserCAD usercad = new UserCAD(session);
                UserCEN usercen = new UserCEN(usercad);
                UserEN user;

                user = usercen.GetByID(oid);

                //Si no existe nos salimos
                if (user == null) throw new Exception();

                user.Image = img;

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
            }
            finally
            {
                SessionClose();
            }
        }

        public Boolean setFollower(int idUser, int idFollower)
        {
            Boolean resul = false;
            try
            {
                SessionInitializeTransaction();

                UserCAD usercad = new UserCAD(session);
                UserCEN usercen = new UserCEN(usercad);
                UserEN user;

                user = usercen.GetByID(idUser);

                //Si no existe nos salimos
                if (user == null) throw new Exception();
                List<int> followers = new List<int>();
                followers.Add(idFollower);
                usercen.Relationer_sigues(idUser, followers);
                resul = true;

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
            }
            finally
            {
                SessionClose();
            }
            return resul;
        }

        public Boolean removeFollower(int idUser, int idFollower)
        {
            Boolean resul = false;
            try
            {
                SessionInitializeTransaction();

                UserCAD usercad = new UserCAD(session);
                UserCEN usercen = new UserCEN(usercad);
                UserEN user;

                user = usercen.GetByID(idUser);

                //Si no existe nos salimos
                if (user == null) throw new Exception();
                List<int> followers = new List<int>();
                followers.Add(idFollower);
               //Explota el relationer asi que lo hacemos a mano usercen.Unrelationer_sigues(idUser, followers);
                UserEN userDest = usercen.GetByID(idFollower);
                if (userDest == null) throw new Exception();

                user.Sigues.Remove(userDest);
                userDest.Seguidores.Remove(user);

                resul = true;

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
            }
            finally
            {
                SessionClose();
            }
            return resul;
        }
    }
}
