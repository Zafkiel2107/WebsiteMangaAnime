using Ninject;
using PagedList;
using System;
using System.Linq;
using WebsiteMangaAnime.Models.BaseClasses;
using WebsiteMangaAnime.Models.DatabaseControl;

namespace WebsiteMangaAnime.Models.DataSelection
{
    public class DataSelection<T> where T : Product
    {
        private IDatabase storage;
        private const int pageSize = 20;
        [Inject]
        public DataSelection(IDatabase storage)
        {
            this.storage = storage;
        }
        public IPagedList<T> Search(int? page, string searchValue)
        {
            IPagedList<T> products = storage.GetElements<T>()
                .OrderByDescending(x => x.RecommendationsNumber)
                .Where(x => x.Name.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToPagedList(page ?? 1, pageSize);
            return products;
        }
        public IPagedList<T> Filter(int? page, string filter)
        {
            Func<T, object> order = x =>
            {
                switch (filter)
                {
                    case "1":
                        return x.Name;
                    case "2":
                        return x.RecommendationsNumber;
                    case "3":
                        return x.Rating;
                    case "4":
                        return x.Year;
                }
                return null;
            };

            IPagedList<T> products = storage.GetElements<T>()
                .OrderByDescending(order)
                .ToPagedList(page ?? 1, pageSize);
            return products;
        }
    }
}