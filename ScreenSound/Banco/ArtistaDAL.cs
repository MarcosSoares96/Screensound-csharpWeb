using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {
        //Metodo para listar informações da Tabela Artista do Branco
        public IEnumerable<Artista> Listar()
        {
            //Criamos uma lista de Artista para armazenar dos dados que virem do banco
            var lista = new List<Artista>();
            // Aqui chamamos o Metodo Obter Conexão para que este método possa acessar o banco.
            //A instrução using tem como objetivo principal garantir que objetos descartáveis sejam utilizados corretamente.
            //Quando declaramos uma variável local como using, ela é descartada no final do escopo em que ela foi declarada
            using var connection = new Connection().ObterConexao();
            // Sempre que precisarmos de acesso ao Banco, deveremos chamar connection.Open() para abrir a conexão.
            connection.Open();
            // Criamos a Query SQL que desejamos obter os dados
            string sql = "SELECT * FROM Artistas";
            // Inicializa uma nova instância da classe Microsoft.Data.SqlClient.SqlCommand com o texto da query e um Microsoft.Data.SqlClient.SqlConnection como parâmetros.
            SqlCommand command = new SqlCommand(sql, connection);
            // Envia o Microsoft.Data.SqlClient.SqlCommand.CommandText para o Microsoft.Data.SqlClient.SqlCommand.Connection e cria um Microsoft.Data.SqlClient.SqlDataReader
            // que fornecerá uma maneira de ler um fluxo somente para encaminhamento de linhas de um banco de dados do SQL Server.
            using SqlDataReader dataReader = command.ExecuteReader();
            // Avança o Microsoft.Data.SqlClient.SqlDataReader para o próximo registro.
            while (dataReader.Read())
            {
                //Passa as informações do Data reader para variaveis locais utilizando o nome da coluna como indice
                string nomeArtista = Convert.ToString(dataReader["Nome"]);
                string bioArtista = Convert.ToString(dataReader["Bio"]);
                int idArtista = Convert.ToInt32(dataReader["Id"]);

                //Cria um novo objeto artista já preenchendo os atributos do objeto com as informações contidas nas variáveis locais criadas acima
                Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };

                //Por fim, adiciona o objeto a lista criada no começo deste metodo;
                lista.Add(artista);
            }

            //Retorna a lista para o local em que o método foi chamado.
            return lista;
        }

        //Metodo para adicionar um novo artista ao Branco
        public void Adicionar(Artista artista)
        {
            using var connection = new Connection().ObterConexao();
            
            connection.Open();
            
            string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";

            SqlCommand command = new SqlCommand(sql, connection);

            //Parameters: Obtém o Microsoft.Data.SqlClient.SqlParameterCollection.
            //SqlParameterCollectionRepresenta uma coleção de parâmetros associados a um Microsoft.Data.SqlClient.SqlCommand e seus respectivos mapeamentos para colunas em um System.Data.DataSet.
            //AddWithValue: Adiciona um valor ao final do Microsoft.Data.SqlClient.SqlParameterCollection. O metodo recece 2 parametros, o primeiro o nome dacoluna no banco e o segundo é objeto que contem o valor a ser adicionado
            command.Parameters.AddWithValue("@nome", artista.Nome);
            command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
            command.Parameters.AddWithValue("@bio", artista.Bio);

            //Executa uma instrução Transact-SQL (o comando sql) na conexão e retorna o número de linhas afetadas.
            int retorno = command.ExecuteNonQuery();

            //Apenas uma Mensagem para demostar a quantidade de linhas afetadas
            Console.WriteLine($"Linhas afetadas: {retorno}");
        }

        //Metodo para Atualizar um artista no banco
        public void Atualizar(Artista artista)
        {
            using var connection = new Connection().ObterConexao();

            connection.Open();

            string sql = $"UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@nome", artista.Nome);
            command.Parameters.AddWithValue("@bio", artista.Bio);
            command.Parameters.AddWithValue("id", artista.Id);

            int retorno = command.ExecuteNonQuery();

            Console.WriteLine($"Linhas afetadas: {retorno}");
        }

        //Método para Deletar Artistas
        public void Deletar(Artista artista)
        {
            using var connection = new Connection().ObterConexao();

            connection.Open();

            string sql = $"DELETE FROM Artistas WHERE Id = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("id", artista.Id);

            int retorno = command.ExecuteNonQuery();

            Console.WriteLine($"Linhas afetadas: {retorno}");
        }
    }
}
