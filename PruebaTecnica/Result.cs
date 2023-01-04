using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica
{
    public class Result
    {
        public int Id { set; get; }
        public bool Correct { set; get; }
        public string Message { get; set; }
        public Exception Ex { get; set; }
        public object Object { get; set; }
        public List<object> Objects { get; set; }
        private static Result result;
        //Prueba de singleton

    }
}
