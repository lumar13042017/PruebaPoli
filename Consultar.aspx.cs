using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace libreriaOnline
{
    public partial class Consultar : System.Web.UI.Page
    {
        Conexion database = new Conexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Escritores> EscritoresList = new List<Escritores>();
                string queryEscritor = "SELECT idEscritor,nombre FROM Escritores";
                database.conexion();
                var Values = database.EjecutarConsultas(queryEscritor);
                for (int i = 0; i < Values.Rows.Count; i++)
                {
                    var value = Values.Rows[i];
                    Escritores EscritoresItem = new Escritores();
                    EscritoresItem.idEscritor = new Guid(value.ItemArray[0].ToString());
                    EscritoresItem.nombre = value.ItemArray[1].ToString();
                    EscritoresList.Add(EscritoresItem);
                }

                var Escritores = from sc in EscritoresList
                                 select new
                                 {
                                     Name = sc.nombre,
                                     IdEscritor = sc.idEscritor,
                                 };

                ddlEscritores.DataSource = Escritores.OrderBy(u => u.Name);
                ddlEscritores.DataTextField = "Name";
                ddlEscritores.DataValueField = "IdEscritor";
                ddlEscritores.DataBind();
                ddlEscritores.Items.Insert(0, new ListItem("<Select>", Guid.Empty.ToString()));
            }
        }

        protected void lnkLoadReport_Click(object sender, EventArgs e)
        {
            List<Libros> LibrosList = new List<Libros>();
            string json = "";

            if (txtAño.Text == "" && ddlEscritores.SelectedValue == Guid.Empty.ToString())
            {
                int Date = 0;
                Guid IdEscritor = Guid.Empty;
                json = $"{{\"añoPublicado\":\"{Date}\",\"autor\":\"{IdEscritor}\"}}";
            }
            else if (txtAño.Text != "" && ddlEscritores.SelectedValue == Guid.Empty.ToString())
            {
                int Date = Convert.ToInt32(txtAño.Text.Replace(" ", ""));
                Guid IdEscritor = Guid.Empty;
                json = $"{{\"añoPublicado\":\"{Date}\",\"autor\":\"{IdEscritor}\"}}";
            }
            else if (txtAño.Text == "" && ddlEscritores.SelectedValue != Guid.Empty.ToString())
            {
                int Date = 0;
                Guid IdEscritor = new Guid(ddlEscritores.SelectedValue);
                json = $"{{\"añoPublicado\":\"{Date}\",\"autor\":\"{IdEscritor}\"}}";
            }
            else
            {
                int Date = Convert.ToInt32(txtAño.Text.Replace(" ", ""));
                Guid IdEscritor = new Guid(ddlEscritores.SelectedValue);
                json = $"{{\"añoPublicado\":\"{Date}\",\"autor\":\"{IdEscritor}\"}}";
            }

            if (json != "")
            {
                var url = $"http://localhost:64370/api/ConsultarLibros";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return;
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                var responseBody = objReader.ReadToEnd();
                                DataTable libroitem = JsonConvert.DeserializeObject<DataTable>(responseBody);

                                for (int i = 0; i < libroitem.Rows.Count; i++)
                                {
                                    var value = libroitem.Rows[i];
                                    Libros LibroItem = new Libros();
                                    LibroItem.idLibro = new Guid(value.ItemArray[0].ToString());
                                    LibroItem.nombre = value.ItemArray[1].ToString();
                                    LibroItem.editorial = value.ItemArray[2].ToString();
                                    LibroItem.añoPublicado = Convert.ToInt32(value.ItemArray[3].ToString());

                                    string queryEscritor = "SELECT nombre FROM Escritores where idEscritor='" + value.ItemArray[4].ToString() + "'";
                                    database.conexion();
                                    var ValuesEscritor = database.EjecutarConsultas(queryEscritor);
                                    var valueEscritor = ValuesEscritor.Rows[0];

                                    LibroItem.autor = valueEscritor.ItemArray[0].ToString();
                                    LibrosList.Add(LibroItem);
                                }
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    // Handle error
                }
            }



            var Libros = from sc in LibrosList
                         select new
                         {
                             Name = sc.nombre,
                             Editorial = sc.editorial,
                             publicacion = sc.añoPublicado,
                             Autor = sc.autor,
                         };

            rptLibros.DataSource = Libros.OrderBy(u => u.Name);
            rptLibros.DataBind();
        }
        public class Escritores
        {
            public Guid idEscritor { get; set; }
            public string nombre { get; set; }
        }

        public class Libros
        {
            public Guid idLibro { get; set; }
            public string nombre { get; set; }
            public string editorial { get; set; }
            public int añoPublicado { get; set; }
            public string autor { get; set; }

        }
    }
}