using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenSharkGenNHibernate.CAD.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkCP.DTO;

namespace WenSharkCP.WensharkCP
{
    public class SearchCP : BasicCP
    {
        public const int PAGESIZE = 5; 

        public List<SongEN> searchSong(string name,int offset=0)
        {
            SessionInitializeTransaction();
            SongCAD songCAD = new SongCAD(session);
            SongCEN songCEN = new SongCEN(songCAD);

            List<SongEN> all = songCEN.Search(name).ToList();
            List<SongEN> resul = new List<SongEN>();

            for (int i = offset; i < all.Count && i < offset+PAGESIZE; i++)
			{
                SongEN song = all[i];
                nullSong(song);
                resul.Add(song);
			}
            

            SessionClose();
            return resul;
        }

        public List<ArtistEN> searchArtist(string name, int offset = 0)
        {
            SessionInitializeTransaction();
            ArtistCAD artistCAD = new ArtistCAD(session);
            ArtistCEN artistCEN = new ArtistCEN(artistCAD);

            List<ArtistEN> all = artistCEN.Search(name).ToList();
            List<ArtistEN> resul = new List<ArtistEN>();

            for (int i = offset; i < all.Count && i < offset + PAGESIZE; i++)
            {
                ArtistEN artista = all[i];
                nullArtist(artista);
                resul.Add(artista);
            }

            SessionClose();
            return resul;
        }

        public List<AlbumEN> searchAlbum(string name, int offset = 0)
        {
            SessionInitializeTransaction();
            List<AlbumEN> all;
            AlbumCAD albumCAD = new AlbumCAD(session);
            AlbumCEN albumCEN = new AlbumCEN(albumCAD);

            all = albumCEN.Search(name).ToList();
            List<AlbumEN> resul = new List<AlbumEN>();

            for (int i = offset; i < all.Count && i < offset + PAGESIZE; i++)
            {
                AlbumEN album = all[i];
                nullAlbum(album);
                resul.Add(album);
            }

            SessionClose();
            return resul;
        }

        public List<UserDTO> searchUsers(int idUser, string name, int offset = 0)
        {
            SessionInitializeTransaction();
            List<UserDTO> resulDTO = new List<UserDTO>();
            List<UserEN> resulEN = new List<UserEN>();
            UserCAD userCAD = new UserCAD(session);
            UserCEN userCEN = new UserCEN(userCAD);

            UserEN user = userCEN.GetByID(idUser);

            resulEN = userCEN.Search(name).ToList();

            for (int i = offset; i < resulEN.Count && i < offset + PAGESIZE; i++)
            {
                UserEN item = resulEN[i];
                UserDTO u = new UserDTO();
                u.Name = item.Name;
                u.Id = item.Id;
                u.Image = item.Image;
                u.Follow = false;

                //Esto es un poco ineficiente... hay que mejorarlo
                for (int j = 0; j < user.Sigues.Count; j++)
                {
                    if (item.Id == user.Sigues[j].Id)
                    {
                        u.Follow = true;
                        break;
                    }
                }
                resulDTO.Add(u);
            }
            SessionClose();
            return resulDTO;
        }
 
    }
}
