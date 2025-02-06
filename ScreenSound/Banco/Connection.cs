using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class Connection
    {
        //String de conexão, responsavel por conter as informações necessáras para ter acesso ao banco de dados
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        //Método responsavel por utiliza a string de conexão para abrir a conexão
        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }

    }
}

