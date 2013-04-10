
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
                userCEN.New_ (userEjemplo1.Password, userEjemplo1.Name, userEjemplo1.Username, userEjemplo1.Email, userEjemplo1.Created);

                AppUserEN userEjemplo2 = new AppUserEN ();
                userEjemplo2.Email = "test2@example.com";
                userEjemplo2.Name = "Otro señor";
                userEjemplo2.Username = "test2";
                userEjemplo2.Password = "test2";
                userEjemplo2.Created = DateTime.Now;
                userCEN.New_ (userEjemplo2.Password, userEjemplo2.Name, userEjemplo2.Username, userEjemplo2.Email, userEjemplo2.Created);

                //Creo algo de contenido
                ArtistCEN artistCEN = new ArtistCEN ();
                AlbumCEN albumCEN = new AlbumCEN ();
                SongCEN songCEN = new SongCEN ();
                for (int i = 0; i < 5; i++) {
                        ArtistEN newArtist = new ArtistEN ();
                        newArtist.Name = "Artista-" + i;
                        newArtist.Bio = "El señor " + i + " ha tenido una vida muy interesante...";
                        newArtist.Image = "Imagen-" + i;
                        newArtist.Created = DateTime.Now;
                        int a_id = artistCEN.Create (newArtist.Name, newArtist.Bio, newArtist.Image).Id;

                        //Creo algunos albumes para el caballero
                        for (int j = 0; j < 5; j++) {
                                AlbumEN newAlbum = new AlbumEN ();
                                newAlbum.Created = DateTime.Now;
                                newAlbum.Published = DateTime.Now;
                                newAlbum.Name = "Album-" + i + "," + j;
                                newAlbum.Image = "Image-" + i + "," + j;

                                int alb_id = albumCEN.Create (newAlbum.Name, newAlbum.Published, newAlbum.Image, a_id).Id;

                                //Y algunas canciones
                                for (int k = 0; k < 5; k++) {
                                        SongEN newSong = new SongEN ();
                                        newSong.Name = "Cancion muy bonita del señor " + a_id + " y el album " + alb_id;
                                        newSong.Fname = "music.mp3";
                                        newSong.Created = DateTime.Now;
                                        songCEN.Create (newSong.Name, newSong.Fname, a_id, alb_id);
                                }
                        }
                }

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
