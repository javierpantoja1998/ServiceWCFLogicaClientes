using ServiceWCFLogicaClientes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServiceWCFLogicaClientes.Repositories
{
    
    public class RepositoryClientes
    {
        private XDocument document;

        public RepositoryClientes()
        {
            string resourceName = "ServiceWCFLogicaClientes.clientes.xml";
            //PARA RECUPERAR UN RECURSO SE UTILIZA Stream
            Stream stream =
                this.GetType().Assembly.GetManifestResourceStream(resourceName);
            this.document = XDocument.Load(stream);
        }

        public List<Cliente> GetClientes()
        {
            //VAMOS A EXTRAER LOS DATOS DE CADA ELEMENT DENTRO
            //DEL DOCUMENTO XML Y CREAR LA COLECCION DIRECTAMENTE
            var consulta = from datos in this.document.Descendants("CLIENTE")
                           select new Cliente
                           {
                               IdCliente = int.Parse(datos.Element("IDCLIENTE").Value),
                               Nombre = datos.Element("NOMBRE").Value,
                               Direccion = datos.Element("DIRECCION").Value,
                               Email = datos.Element("EMAIL").Value,
                               Imagen = datos.Element("IMAGENCLIENTE").Value
                           };
            return consulta.ToList();
        }


        public Cliente FindCliente(int idcliente)
        {
            return this.GetClientes().FirstOrDefault(x => x.IdCliente == idcliente);
        }
    }
}
