using GridMvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BugTracker.Models
{
    public class ApplicationViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Тема заявки")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Тип заявки")]
        public DBClasses.types_enum Type { get; set; }

        [Required]
        [Display(Name = "Приоритет заявки")]
        public DBClasses.priorities_enum Priority { get; set; }

        [Required]
        [Display(Name = "Статус заявки")]
        public DBClasses.status_enum Status { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 10)]
        [Display(Name = "Комментарий пользователя")]
        public string Annotation { get; set; }

        [Display(Name = "Изображение неисправности")]
        public string Picture { get; set; }

        [Required]
        [Display(Name = "Дата создания")]
        public DateTime Created { get; set; }

        [Required]
        [Display(Name = "Дата обновления")]
        public DateTime Updated { get; set; }
    }

    public static class GridMvcExtension
    {
        public static string DisplayRangePages<T>(this GridMvc.Pagination.GridPager gridPager, IEnumerable<T> _collection, string _currentPage, int _pageSize)
        {
            if (_collection != null && _pageSize > 0)
            {
                var currentPage = (_currentPage != null) ? int.Parse(_currentPage) : 1;
                int itemsCount = _collection.Count(), rangeTo = 0, rangeFrom = 0;
                var countPages = (int)System.Math.Ceiling((double)itemsCount / _pageSize);
                if (countPages == currentPage && (itemsCount % _pageSize) != 0)
                {
                    rangeTo = (_pageSize * (currentPage - 1)) + (itemsCount % _pageSize);
                    rangeFrom = rangeTo - (rangeTo - _pageSize * (currentPage - 1)) + 1;
                }
                else
                {
                    rangeTo = _pageSize * currentPage;
                    rangeFrom = rangeTo - (_pageSize - 1);
                }
                return string.Format("<span class='label label-default'>{0}&nbsp;&ndash;&nbsp;{1}&nbsp;из&nbsp;{2}</span>&nbsp;&nbsp;<span class='label label-default'>&nbsp;Страница {3}&nbsp; из&nbsp;{4}</span>", rangeFrom, rangeTo, itemsCount, currentPage, countPages);

    }
            else return string.Empty;

        }
    }
}