using System;
using System.Collections.Generic;
using System.Text;

namespace ezalak.DBIntractionClasses
{
    public partial class PagerObject
    {
        public int CurrentPage;
        public int TotalPage;
        public bool IsRefresh;
        public bool IsSearching;
        public PagerObject()
        {
            CurrentPage = TotalPage = 0;
            IsRefresh= IsSearching = false;
        }
    }
}
