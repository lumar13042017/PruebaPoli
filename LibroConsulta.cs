using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace libreriaOnline
{
    public class LibroConsulta
    {
        //public List<librosItem> LibrosItem { get; set; }
        //public class librosItem
        //{
        //    public string idLibro { get; set; }
        //    public string nombre { get; set; }
        //    public string editorial { get; set; }
        //    public string añoPublicado { get; set; }
        //    public string autor { get; set; }
        //}

        public class Sheet
        {
            public List<Row> Rows { get; set; }
        }

        public class Row
        {
            public string idLibro { get; set; }
            public string nombre { get; set; }
            public string editorial { get; set; }
            public string añoPublicado { get; set; }
            public string autor { get; set; }
        }


    }
}