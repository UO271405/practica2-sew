using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sew_tranformacion_xml_html
{
    class Program
    {
        private static StreamWriter file = new System.IO.StreamWriter(@"C:\Users\2000l\Desktop\pag_web_rutas\index.html");

        static void Main(string[] args)
        {
            file.WriteLine("<!DOCTYPE HTML>");
            file.WriteLine("<html lang=\"es\">");
            file.WriteLine("<head>");
            file.WriteLine("<meta charset=\"UTF - 8\">");
            file.WriteLine("<title>Rutas de avión</title>");
            file.WriteLine("<meta name=\"description\" content=\"Web diseñada para mostrar diferentes rutas aéreas.\">");
            file.WriteLine("<meta name=\"author\" content=\"Luis Fernández Suárez\">");
            file.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"estilo.css\" />");
            file.WriteLine("</head>");
            file.WriteLine("<body>");

            String nombreArchivoXML = @"C:\Users\2000l\Desktop\3rd_course\SEW\lab\lab2_xml\practica2\aviones.xml";

            // XmlReader
            XmlReader lector = XmlReader.Create(nombreArchivoXML);

            while (lector.Read())
            {
                switch (lector.NodeType)
                {
                    case XmlNodeType.Element:
                        if (lector.Name.Equals("rutas"))
                        {
                            toH1(lector.Name);
                        }
                        else if (lector.Name.Equals("ruta"))
                        {
                            while (lector.MoveToNextAttribute())
                            {
                                if (lector.Name.Equals("nombre"))
                                {
                                    file.WriteLine("<h2>" + lector.Value + "</h2>");
                                }
                                else if (lector.Name.Equals("tipo_de_ruta"))
                                {
                                    file.WriteLine("<p>Tipo de ruta:" + lector.Value +  "</p>");
                                }
                                else if (lector.Name.Equals("dificultad"))
                                {
                                    file.WriteLine("<p>Dificultad:" + lector.Value + "</p>");
                                }
                                else if (lector.Name.Equals("fecha_inicio"))
                                {
                                    file.WriteLine("<p>Fecha de inicio: " + lector.Value + "</p>");
                                }
                                else if (lector.Name.Equals("hora_inicio"))
                                {
                                    file.WriteLine("<p>Hora de inicio: " + lector.Value + "</p>");
                                }
                                else if (lector.Name.Equals("descripcion_ruta"))
                                {
                                    file.WriteLine("<p>Descripción de la ruta: " + lector.Value + "</p>");
                                }
                                else if (lector.Name.Equals("personas_adecuadas"))
                                {
                                    file.WriteLine("<p>Personas adecuadas para la ruta: " + lector.Value + "</p>");
                                }
                            }
                        }
                        else if (lector.Name.Equals("duracion"))
                        {
                            lector.MoveToNextAttribute();
                            file.Write("<p>Duración de la ruta en " + lector.Value + ": ");
                        }
                        else if (lector.Name.Equals("agencia"))
                        {
                            file.Write("<p>Agencia: ");
                        }
                        else if (lector.Name.Equals("lugar_inicio"))
                        {
                            file.Write("<p>Lugar de inicio: ");
                        }
                        else if (lector.Name.Equals("direccion_inicio"))
                        {
                            file.Write("<p>Dirección de inicio: ");
                        }
                        else if (lector.Name.Equals("referencia"))
                        {
                            file.Write("<p>Enlace recomendado: <a href=");
                        }
                        else if (lector.Name.Equals("recomendacion_ruta"))
                        {
                            file.Write("<p>Recomendación de la ruta: ");
                        }
                        else if (lector.Name.Equals("coordenadas_inicio"))
                        {
                            file.Write("<p>Coordenadas de inicio: ");
                        }
                        else if (lector.Name.Equals("hitos"))
                        {
                            file.WriteLine("<h3>Hitos</h3>");
                            file.WriteLine("<ul>");
                        }
                        else if (lector.Name.Equals("hito"))
                        {
                            lector.MoveToNextAttribute();
                            file.WriteLine("<li>" + lector.Value + "</li>");
                        }
                        else if (lector.Name.Equals("descripcion_hito"))
                        {
                            file.Write("<p>Descripción: ");
                        }
                        else if (lector.Name.Equals("distancia_hito_anterior"))
                        {
                            lector.MoveToNextAttribute();
                            file.Write("<p>Distancia respecto al hito anterior en " +lector.Value + ": ");
                        }
                        else if (lector.Name.Equals("tiempo_hito_anterior"))
                        {
                            lector.MoveToNextAttribute();
                            file.Write("<p>Tiempo respecto al hito anterior en " + lector.Value + ": ");
                        }
                        else if (lector.Name.Equals("img"))
                        {
                            lector.MoveToNextAttribute();
                            file.Write("<img src=\"" + lector.Value + "\">");
                        }
                        else if (lector.Name.Equals("video"))
                        {
                            lector.MoveToNextAttribute();
                            file.Write("<p>Enlace a video: <a href=\"" + lector.Value + "\">");
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (lector.Name.Equals("hitos"))
                        {
                            file.WriteLine("</ul>");
                        }
                        else if (lector.Name.Equals("referencia"))
                        {
                            file.WriteLine(lector.Value + "></a></p>");
                        }
                        else if (lector.Name.Equals("duracion"))
                        {
                            lector.MoveToNextAttribute();
                            file.WriteLine("</p>");
                        }
                        else if (lector.Name.Equals("agencia"))
                        {
                            file.WriteLine("</p>");
                        }
                        else if (lector.Name.Equals("lugar_inicio"))
                        {
                            file.WriteLine("</p>");
                        }
                        else if (lector.Name.Equals("direccion_inicio"))
                        {
                            file.WriteLine("</p>");
                        }
                        else if (lector.Name.Equals("recomendacion_ruta"))
                        {
                            file.WriteLine("</p>");
                        }
                        else if (lector.Name.Equals("coordenadas_inicio"))
                        {
                            file.WriteLine("</p>");
                        }
                        else if (lector.Name.Equals("descripcion_hito"))
                        {
                            file.WriteLine("</p>");
                        }
                        else if (lector.Name.Equals("distancia_hito_anterior"))
                        {
                            file.WriteLine("</p>");
                        }
                        else if (lector.Name.Equals("tiempo_hito_anterior"))
                        {
                            file.WriteLine("</p>");
                        }
                        else if (lector.Name.Equals("img"))
                        {
                            file.WriteLine(lector.Value + "</img>");
                        }
                        else if (lector.Name.Equals("video"))
                        {
                            file.WriteLine(lector.Value + "</a></p>");
                        }
                        break;
                    case XmlNodeType.Text:
                            file.Write(lector.Value);
                        break;
                }

                
            }
            file.WriteLine("</body>");
            file.WriteLine("</html>");
            file.Close();
            
        }

        private static void toP(string name, String value)
        {
            file.WriteLine("<h1>" + name + ": " +  value + "</h1>");
        }

        public static void toH1(String text)
        {
            file.WriteLine("<h1>" + text + "</h1>");
        }

        
    }
}
