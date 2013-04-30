
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.CAD.Default_;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\SQLEXPRESS; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                //Creo el CEN
                AppUserCEN userCEN = new AppUserCEN ();

                //Creo algunos usuarios de ejemplo (para buscarlos)
                AppUserEN userEjemplo1 = new AppUserEN ();
                userEjemplo1.Email = "test@example.com";
                userEjemplo1.Name = "Señor de prueba";
                userEjemplo1.Username = "test1";
                userEjemplo1.Password = "test1";
                userEjemplo1.Created = DateTime.Now;
                int idUserEjemplo1 = userCEN.New_ (userEjemplo1.Password, userEjemplo1.Name, userEjemplo1.Username, userEjemplo1.Email, userEjemplo1.Created);


                PlayListCEN plCEN = new PlayListCEN();
                int pl1 = plCEN.New_("Lista test1 1");

                List<int> listaPlayList = new List<int>();
                listaPlayList.Add(pl1);
                UserCEN usCEN = new UserCEN();
                usCEN.AddNewPlayList(idUserEjemplo1, listaPlayList);


                AppUserEN userEjemplo2 = new AppUserEN ();
                userEjemplo2.Email = "test2@example.com";
                userEjemplo2.Name = "Otro señor";
                userEjemplo2.Username = "test2";
                userEjemplo2.Password = "test2";
                userEjemplo2.Created = DateTime.Now;
                userCEN.New_ (userEjemplo2.Password, userEjemplo2.Name, userEjemplo2.Username, userEjemplo2.Email, userEjemplo2.Created);

                //Creo algo de contenido
                ArtistCEN artistcen = new ArtistCEN ();
                AlbumCEN albumcen = new AlbumCEN ();
                SongCEN songcen = new SongCEN ();

                //Creamos algunos artistas
                ArtistEN unknown = artistcen.Create ("Unknown artist", "", "");
                ArtistEN linkin_park = artistcen.Create ("Linkin Park", "", "");
                ArtistEN limp_bizkit = artistcen.Create ("Limp Bizkit", "", "");
                ArtistEN fary = artistcen.Create ("El Fary", "", "");

                //Creamos algunos albums
                AlbumEN unknown_album = albumcen.Create ("Unknown album", DateTime.Now, "/Assets/img/albums/unknown.png", unknown.Id);
                AlbumEN reanimation = albumcen.Create ("Reanimation", DateTime.Now, "/Assets/img/albums/reanimation.jpg", linkin_park.Id);
                AlbumEN hybrid_theory = albumcen.Create ("Hybrid Theory", DateTime.Now, "/Assets/img/albums/hybrid_theory.jpg", linkin_park.Id);
                AlbumEN meteora = albumcen.Create ("Meteora", DateTime.Now, "/Assets/img/albums/meteora.jpg", linkin_park.Id);
                AlbumEN greatest_hits = albumcen.Create ("Greatest hits", DateTime.Now, "/Assets/img/albums/greatest_hits.jpg", limp_bizkit.Id);
                AlbumEN que_grande_eres = albumcen.Create ("Que grande eres!", DateTime.Now, "/Assets/img/albums/que_grande_eres.jpg", fary.Id);

                //Creo algunas canciones

                //Las de reanimation
                songcen.Create ("Opening", "lk_rm_01.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Points of authority", "lk_rm_02.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("In the end", "lk_rm_03.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Chali", "lk_rm_04.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Frgt", "lk_rm_05.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Pushing me away", "lk_rm_06.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Place my head", "lk_rm_07.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("X-ecutioner", "lk_rm_08.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("H! Vltg3", "lk_rm_09.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Riff raff", "lk_rm_10.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("With you", "lk_rm_11.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Intromission", "lk_rm_12.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Papercut", "lk_rm_13.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Runaway", "lk_rm_14.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("My december", "lk_rm_15.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Stef", "lk_rm_16.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("By myself", "lk_rm_17.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Kyur4 Th Ich", "lk_rm_18.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("One step closer", "lk_rm_19.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);
                songcen.Create ("Crawlin", "lk_rm_20.mp3", "audio/mp3", linkin_park.Id, reanimation.Id);

                //Las de hybrid
                songcen.Create ("Papercut", "lk_ht_01.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);
                songcen.Create ("One step closer", "lk_ht_02.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);
                songcen.Create ("With you", "lk_ht_03.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);
                songcen.Create ("Points of authority", "lk_ht_04.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);
                songcen.Create ("Crawlin", "lk_ht_05.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);
                songcen.Create ("Runaway", "lk_ht_06.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);
                songcen.Create ("By myself", "lk_ht_07.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);
                songcen.Create ("In the end", "lk_ht_08.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);
                songcen.Create ("A place for my head", "lk_ht_09.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);
                songcen.Create ("Forgotten", "lk_ht_10.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);
                songcen.Create ("Cure for the Itch", "lk_ht_11.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);
                songcen.Create ("Pushing me away", "lk_ht_12.mp3", "audio/mp3", linkin_park.Id, hybrid_theory.Id);

                //Alguna del fary
                songcen.Create ("Apatrullando la ciudad", "apatrullando.mp3", "audio/mp3", fary.Id, que_grande_eres.Id);

                /*
                 * ArtistCEN artistCEN = new ArtistCEN ();
                 * AlbumCEN albumCEN = new AlbumCEN ();
                 * SongCEN songCEN = new SongCEN ();
                 * for (int i = 0; i < 5; i++) {
                 *      ArtistEN newArtist = new ArtistEN ();
                 *      newArtist.Name = "Artista-" + i;
                 *      newArtist.Bio = "El señor " + i + " ha tenido una vida muy interesante...";
                 *      newArtist.Image = "Imagen-" + i;
                 *      newArtist.Created = DateTime.Now;
                 *      int a_id = artistCEN.Create (newArtist.Name, newArtist.Bio, newArtist.Image).Id;
                 *
                 *      //Creo algunos albumes para el caballero
                 *      for (int j = 0; j < 5; j++) {
                 *              AlbumEN newAlbum = new AlbumEN ();
                 *              newAlbum.Created = DateTime.Now;
                 *              newAlbum.Published = DateTime.Now;
                 *              newAlbum.Name = "Album-" + i + "," + j;
                 *              newAlbum.Image = "Image-" + i + "," + j;
                 *
                 *              int alb_id = albumCEN.Create (newAlbum.Name, newAlbum.Published, newAlbum.Image, a_id).Id;
                 *
                 *              //Y algunas canciones
                 *              for (int k = 0; k < 5; k++) {
                 *                      SongEN newSong = new SongEN ();
                 *                      newSong.Name = "Cancion muy bonita del señor " + a_id + " y el album " + alb_id;
                 *                      newSong.Fname = "music.mp3";
                 *                      newSong.Created = DateTime.Now;
                 *                      songCEN.Create (newSong.Name, newSong.Fname, "", a_id, alb_id);
                 *              }
                 *      }
                 * }
                 */
                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
