using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace libreriaOnline
{
    public partial class Eliminar : System.Web.UI.Page
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


                List<Libros> LibrosList = new List<Libros>();
                string queryLibro = "SELECT idLibro,nombre FROM Libros";
                database.conexion();
                var ValuesLibro = database.EjecutarConsultas(queryLibro);
                for (int i = 0; i < ValuesLibro.Rows.Count; i++)
                {
                    var value = ValuesLibro.Rows[i];
                    Libros LibroItem = new Libros();
                    LibroItem.idLibro = new Guid(value.ItemArray[0].ToString());
                    LibroItem.nombre = value.ItemArray[1].ToString();
                    LibrosList.Add(LibroItem);
                }

                var Libros = from sc in LibrosList
                             select new
                             {
                                 idLibro = sc.idLibro,
                                 nombre = sc.nombre,
                             };

                ddllibros.DataSource = Libros.OrderBy(u => u.nombre);
                ddllibros.DataTextField = "nombre";
                ddllibros.DataValueField = "idLibro";
                ddllibros.DataBind();
                ddllibros.Items.Insert(0, new ListItem("<Select>", Guid.Empty.ToString()));



            }
        }

        protected void ddlLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddllibros.SelectedValue != Guid.Empty.ToString())
            {
                Guid idLibro = new Guid(ddllibros.SelectedValue);
                string queryLibro = "SELECT nombre, editorial, añoPublicado, autor FROM Libros where idLibro='" + idLibro + "'";
                database.conexion();
                var ValuesLibro = database.EjecutarConsultas(queryLibro);
                var value = ValuesLibro.Rows[0];

                string queryEscritor = "SELECT nombre FROM Escritores where idEscritor='" + value.ItemArray[3].ToString() + "'";
                database.conexion();
                var ValuesEscritor = database.EjecutarConsultas(queryEscritor);
                var valueEscritor = ValuesEscritor.Rows[0];

                lblNombreLibro.Text = value.ItemArray[0].ToString();
                lblEditorial.Text = value.ItemArray[1].ToString();
                lblPublicacion.Text = value.ItemArray[2].ToString();
                lblAutor.Text = valueEscritor.ItemArray[0].ToString();
            }

        }

        protected void ddlEscritores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEscritores.SelectedValue != Guid.Empty.ToString())
            {
                Guid idEscritores = new Guid(ddlEscritores.SelectedValue);
                string queryEscritor = "SELECT nombre FROM Escritores where idEscritor='" + idEscritores + "'";
                database.conexion();
                var ValuesEscritor = database.EjecutarConsultas(queryEscritor);
                var valueEscritor = ValuesEscritor.Rows[0];

                lblEscritor.Text = valueEscritor.ItemArray[0].ToString();
            }

        }

        protected void lnkEliminatEscritor_Click(object sender, EventArgs e)
        {
            Guid idEcritor = new Guid(ddlEscritores.SelectedValue);
            bool registroExitoso = false;
            if (idEcritor.ToString() != Guid.Empty.ToString())
            {

                var url = $"http://localhost:64370/api/EliminarEscritor";
                var request = (HttpWebRequest)WebRequest.Create(url);
                string json = $"{{\"idEscritor\":\"{idEcritor}\"}}";
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
                                string responseBody = objReader.ReadToEnd();
                                lblMensjeEscritor.Text = "El Resgistro no se pudo Eliminar";
                                if (responseBody.Contains("exitoso"))
                                {
                                    registroExitoso = true;
                                    lblMensjeEscritor.Text = "El Resgistro se elimino exitosamente";
                                }
                                if (responseBody.Contains("No se puede eliminar"))
                                {
                                    lblMensjeEscritor.Text = "No se puede eliminar el escritor porque tiene libros asociados.";
                                }
                                Console.WriteLine(responseBody);
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                }
                
            }
        }

        protected void lnkModificarLibro_Click(object sender, EventArgs e)
        {
            Guid idLibro = new Guid(ddllibros.SelectedValue);
            bool registroExitoso = false;
            if (idLibro.ToString() != Guid.Empty.ToString())
            {
                var url = $"http://localhost:64370/api/EliminarLibro";
                var request = (HttpWebRequest)WebRequest.Create(url);
                string json = $"{{\"idLibro\":\"{idLibro}\"}}";
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
                                string responseBody = objReader.ReadToEnd();
                                if (responseBody.Contains("exitoso"))
                                {
                                    registroExitoso = true;
                                }
                                Console.WriteLine(responseBody);
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                }
                if (registroExitoso)
                {
                    lblmensajeLibro.Text = "El Resgistro se Elimino Exitosamente";
                }
                else
                {
                    lblmensajeLibro.Text = "El Resgistro no se pudo Eliminar";
                }
            }
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
            public Guid autor { get; set; }

        }

        
    }
}