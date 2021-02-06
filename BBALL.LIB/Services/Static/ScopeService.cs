using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class ScopeService
    {
        public static List<string> Scopes { get { return _Scopes(); } }
        private static List<string> _Scopes()
        {
            List<string> scopes = new List<string>();
            scopes.Add("RS");
            scopes.Add("S");
            scopes.Add("Rookies");
            return scopes;
        }
    }
}
