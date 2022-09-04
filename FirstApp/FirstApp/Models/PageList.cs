using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp.Models
{
    public class PageList<T> where T : class
    {
        private int currentPage;
        public int CurrentPage 
        { 
            get
            {
                return currentPage;
            }
            private set 
            {
                if(value<=0)
                    throw new ArgumentOutOfRangeException("Номер страницы должен начинаться с 1");

                currentPage = value;
            }
        }
        private int pageSize;
        public int TotalPages { get; }
        public int PageSize 
        {
            get
            {
                return pageSize;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Количество элементов страницы должно быть больше 0");

                pageSize = value;
            }
        }
        public List<T> Items { get; set; }
        public bool HasNext => CurrentPage < TotalPages;
        public bool HasPrevious => CurrentPage > 1;
        public PageList(List<T> items, int curPage, int pageSize)
        {
            CurrentPage = curPage;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(items.Count()/(double)pageSize);
            Items = items.Skip(curPage*pageSize).Take(pageSize).ToList();
        }
    }
}
