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
    public partial class Insertar : System.Web.UI.Page
    {
        Conexion database = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Escritores> EscritoresList = new List<Escritores>();
                string querycount = "SELECT idEscritor,nombre FROM Escritores";
                database.conexion();
                var Values = database.EjecutarConsultas(querycount);
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
            }
        }

        protected void lnkAddEscritor_Click(object sender, EventArgs e)
        {
            string escritor = txtNameEscritor.Text;
            bool registroExitoso = false;
            if (escritor != "")
            {
                Guid idEcritor = Guid.NewGuid();

                var url = $"http://localhost:64370/api/InsertarEscritor";
                var request = (HttpWebRequest)WebRequest.Create(url);
                string json = $"{{\"idEscritor\":\"{idEcritor}\",\"nombre\":\"{escritor}\"}}";
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
                    lblMensjeEscritor.Text = "Resgistro Exitoso";
                }
                else
                {
                    lblMensjeEscritor.Text = "Resgistro Fallido";
                }
            }
        }

        protected void lnkAddLibro_Click(object sender, EventArgs e)
        {
            string NameLibro = txtNameLibro.Text;
            string Editorial = txtEditorial.Text;
            string AñoPublicacion = txtAñoPublicacion.Text;
            Guid idLibro = Guid.NewGuid();
            Guid idescritor = new Guid(ddlEscritores.SelectedValue);
            bool registroExitoso = false;
            if (NameLibro != "" && Editorial != "" && AñoPublicacion != "" && idescritor != Guid.Empty)
            {

                var url = $"http://localhost:64370/api/InsertarLibro";
                var request = (HttpWebRequest)WebRequest.Create(url);
                string json = $"{{\"idLibro\":\"{idLibro}\",\"nombre\":\"{NameLibro}\",\"editorial\":\"{Editorial}\",\"añoPublicado\":\"{AñoPublicacion}\",\"autor\":\"{idescritor}\"}}";
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
                                // Do something with responseBody
                                Console.WriteLine(responseBody);
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    // Handle error
                }

                if (registroExitoso)
                {
                    lblmensajeLibro.Text = "Resgistro Exitoso";
                }
                else
                {
                    lblmensajeLibro.Text = "Resgistro Fallido";
                }
            }
        }

        public class Escritores
        {
            public Guid idEscritor { get; set; }
            public string nombre { get; set; }
        }
    }
}