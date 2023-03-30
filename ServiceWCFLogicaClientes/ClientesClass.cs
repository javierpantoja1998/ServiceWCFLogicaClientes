using ServiceWCFLogicaClientes.Models;
using ServiceWCFLogicaClientes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWCFLogicaClientes
{
    public class ClientesClass : ICliente
    {
        private RepositoryClientes repo;

        public ClientesClass()
        {
            this.repo = new RepositoryClientes();
        }

        public Cliente FindCliente(int idcoche)
        {
            return repo.FindCliente(idcoche);
        }

        public List<Cliente> GetClientes()
        {
            return this.repo.GetClientes();
        }
    }
}
