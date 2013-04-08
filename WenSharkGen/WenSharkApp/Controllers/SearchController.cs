﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using NHibernate;
using WenSharkApp.Models;

namespace WenSharkApp.Controllers
{
    public class SearchController : ApiController
    {
        public SearchResult getSearch(string name)
        {
            ItemCEN itemCEN = new ItemCEN();
            SearchResult result = new SearchResult();

            //TODO: Preguntar como arreglar esto!!!
            List<ItemEN> searchElement = itemCEN.Search(name).ToList();
            foreach (var item in searchElement)
            {
                if (item.GetType() == typeof(SongEN))
                {
                    result.songs.Add(new Song((SongEN)item));
                }
                else if (item.GetType() == typeof(AlbumEN))
                {
                    result.albums.Add(new Album((AlbumEN)item));
                }
                else if (item.GetType() == typeof(ArtistEN))
                {
                    result.artists.Add(new Artist((ArtistEN)item));
                }
            }
            

            return result;
        }

        /*
                public List<Song> getSongs(string cancion)
                {
                    ItemCEN itemCEN = new ItemCEN();
                    List<Song> result = new List<Song>();

                    List<ItemEN> searchElement = itemCEN.Search(cancion).ToList();
                    foreach (var item in searchElement)
                    {
                        if (item.GetType() == typeof(SongEN))
                        {
                           // Song s = new Song();
                           // s.id = item.Id;
                           // s.name = item.Name;
                           // result.Add(s);
                            result.Add(new Song((SongEN)item));
                        }
                    }

        
                    return result;
                }
          */
    }


}
