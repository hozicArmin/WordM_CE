using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordManager
{
    internal class Editing
    {
        protected string context = "";

        public string RegexSelector(string inputFile)
        {
            this.context = inputFile;
            Regex rgx2 = new Regex("\t|\\s+");
            string holderRegex = rgx2.Replace(context, " ");
            return holderRegex;
        }
    }
}
