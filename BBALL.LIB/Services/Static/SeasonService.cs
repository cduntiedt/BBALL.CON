using BBALL.LIB.Helpers;
using MongoDB.Bson;
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
            seasons.Add("2022-23");
            return seasons;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "1984-85" }, { "value", "1984-85" } },
                new BsonDocument { { "label", "1985-86" }, { "value", "1985-86" } },
                new BsonDocument { { "label", "1986-87" }, { "value", "1986-87" } },
                new BsonDocument { { "label", "1987-88" }, { "value", "1987-88" } },
                new BsonDocument { { "label", "1988-89" }, { "value", "1988-89" } },
                new BsonDocument { { "label", "1989-90" }, { "value", "1989-90" } },
                new BsonDocument { { "label", "1990-91" }, { "value", "1990-91" } },
                new BsonDocument { { "label", "1991-92" }, { "value", "1991-92" } },
                new BsonDocument { { "label", "1992-93" }, { "value", "1992-93" } },
                new BsonDocument { { "label", "1993-94" }, { "value", "1993-94" } },
                new BsonDocument { { "label", "1994-95" }, { "value", "1994-95" } },
                new BsonDocument { { "label", "1995-96" }, { "value", "1995-96" } },
                new BsonDocument { { "label", "1996-97" }, { "value", "1996-97" } },
                new BsonDocument { { "label", "1997-98" }, { "value", "1997-98" } },
                new BsonDocument { { "label", "1998-99" }, { "value", "1998-99" } },
                new BsonDocument { { "label", "1999-00" }, { "value", "1999-00" } },
                new BsonDocument { { "label", "2000-01" }, { "value", "2000-01" } },
                new BsonDocument { { "label", "2001-02" }, { "value", "2001-02" } },
                new BsonDocument { { "label", "2002-03" }, { "value", "2002-03" } },
                new BsonDocument { { "label", "2003-04" }, { "value", "2003-04" } },
                new BsonDocument { { "label", "2004-05" }, { "value", "2004-05" } },
                new BsonDocument { { "label", "2005-06" }, { "value", "2005-06" } },
                new BsonDocument { { "label", "2006-07" }, { "value", "2006-07" } },
                new BsonDocument { { "label", "2007-08" }, { "value", "2007-08" } },
                new BsonDocument { { "label", "2008-09" }, { "value", "2008-09" } },
                new BsonDocument { { "label", "2009-10" }, { "value", "2009-10" } },
                new BsonDocument { { "label", "2010-11" }, { "value", "2010-11" } },
                new BsonDocument { { "label", "2011-12" }, { "value", "2011-12" } },
                new BsonDocument { { "label", "2012-13" }, { "value", "2012-13" } },
                new BsonDocument { { "label", "2013-14" }, { "value", "2013-14" } },
                new BsonDocument { { "label", "2014-15" }, { "value", "2014-15" } },
                new BsonDocument { { "label", "2015-16" }, { "value", "2015-16" } },
                new BsonDocument { { "label", "2016-17" }, { "value", "2016-17" } },
                new BsonDocument { { "label", "2017-18" }, { "value", "2017-18" } },
                new BsonDocument { { "label", "2018-19" }, { "value", "2018-19" } },
                new BsonDocument { { "label", "2019-20" }, { "value", "2019-20" } },
                new BsonDocument { { "label", "2020-21" }, { "value", "2020-21" } },
                new BsonDocument { { "label", "2021-22" }, { "value", "2021-22" } },
                new BsonDocument { { "label", "2022-23" }, { "value", "2022-23" } },
            };

            DatabaseHelper.AddFilterCollection("seasons", array);
        }
    }
}
