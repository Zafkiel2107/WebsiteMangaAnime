using System.ComponentModel.DataAnnotations;

namespace WebsiteMangaAnime.Models.DataSelection
{
    public enum FilterType : byte
    {
        [Display(Name = "По названию")]
        ПоНазванию = 1,
        [Display(Name = "По количеству рекомендаций")]
        ПоКоличествуРекомендаций = 2,
        [Display(Name = "По рейтингу")]
        ПоРейтингу = 3,
        [Display(Name = "По году выпуска")]
        ПоГодуВыпуска = 4,
    }
}