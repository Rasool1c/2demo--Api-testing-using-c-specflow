using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2demo.Models;
using NPOI.SS.Formula.Functions;
using ICSharpCode.SharpZipLib.Encryption;
using _2demo.Steps;

namespace _2demo
{
    public class Prop
    {
        postMethods obj = new postMethods();


        public string pName;
        public string pClass
        {
            get { return pName; }
            set { pName = value; }
        }
        public string pvalue()
        {
            var valu = pClass;
            return valu;
        }
        

    }



}

