using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class SeasonService
    {
        public static List<string> CurrentSeason { get { return _CurrentSeason(); } }
        private static List<string> _CurrentSeason()
        {
            List<string> currentSeason = new List<string>();
            currentSeason.Add(_Seasons().LastOrDefault());
            return currentSeason;
        }

        public static List<string> Seasons { get { return _Seasons(); } }
        private static List<string> _Seasons()
        {
            List<string> seasons = new List<string>();
            //TO DO: uncomment after loading the remaining rosters
            seasons.Add("1984-85");
            seasons.Add("1985-86");
            seasons.Add("1986-87");
            seasons.Add("1987-88");
            seasons.Add("1988-89");
            seasons.Add("1989-90");
            seasons.Add("1990-91");
            seasons.Add("1991-92");
            seasons.Add("1992-93");
            seasons.Add("1993-94");
            seasons.Add("1994-95");
            seasons.Add("1995-96");
            seasons.Add("1996-97");
            seasons.Add("1997-98");
            seasons.Add("1998-99");
            seasons.Add("1999-00");
            seasons.Add("2000-01");
            seasons.Add("2001-02");
            seasons.Add("2002-03");
            seasons.Add("2003-04");
            seasons.Add("2004-05");
            seasons.Add("2005-06");
            seasons.Add("2006-07");
            seasons.Add("2007-08");
            seasons.Add("2008-09");
            seasons.Add("2009-10");
            seasons.Add("2010-11");
            seasons.Add("2011-12");
            seasons.Add("2012-13");
            seasons.Add("2013-14");
            seasons.Add("2014-15");
            seasons.Add("2015-16");
            seasons.Add("2016-17");
            seasons.Add("2017-18");
            seasons.Add("2018-19");
            seasons.Add("2019-20");
            seasons.Add("2020-21");
            seasons.Add("2021-22");
            return seasons;
        }
    }
}
