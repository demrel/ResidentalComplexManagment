using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Filters
{
    public class PaginationList<T>
    {
        public List<T> List { get; init; }
      

        public PaginationList(List<T> list,int totalItems, int page, int pageSize = 30, int maxSeePage = 6)
        {
            List = list;
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page > totalPages ? totalPages - 1 : page;
            maxSeePage = maxSeePage > totalPages ? totalPages : maxSeePage;
            int maxSeePageCenter = maxSeePage / 2;

            int startPage = currentPage - maxSeePageCenter + 1;
            int endPage = currentPage + maxSeePageCenter;

            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;

                if (endPage > maxSeePage + 1)
                {
                    startPage = endPage - maxSeePage + 1;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            TotalPages = 1 > totalPages ? 0 : totalPages;
            StartPage = startPage;
            EndPage = endPage;
            PageSize = pageSize;
        }

        public int TotalItems { get; private set; }
        public int PageSize { get; private set; }

        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }



    }
}
