using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {
        private readonly ScreenSoundContext context;

        public ArtistaDAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        //Metodo para listar informações da Tabela Artista do Branco
        public IEnumerable<Artista> Listar()
        {
            return context.Artistas.ToList();
        }

        public void Adicionar(Artista artista)
        {
            //Começa a rastrear a entidade fornecida e quaisquer outras entidades alcançáveis ​​que ainda não estejam sendo rastreadas no estado
            //Microsoft.EntityFrameworkCore.EntityState.Added, de modo que elas serão inseridas no banco de dados quando
            //Microsoft.EntityFrameworkCore.DbContext.SaveChanges for chamado.
            context.Artistas.Add(artista);
            context.SaveChanges();
        }

        public void Atualizar(Artista artista)
        {
            context.Artistas.Update(artista);
            context.SaveChanges();
        }

        public void Deletar(Artista artista)
        {
            //Começa a rastrear a entidade fornecida no estado<see cref= "EntityState.Deleted" /> de forma que ela seja removida do banco de dados quando
            //<see cref = "DbContext.SaveChanges()" /> for chamado.
            context.Artistas.Remove(artista);
            context.SaveChanges();
        }

        public Artista? RecuperarPeloNome(string nome)
        {
            //Retorna o primeiro elemento de uma sequência que satisfaz uma condição especificada ou um valor padrão se nenhum elemento desse tipo for encontrado.
            return context.Artistas.FirstOrDefault(a  => a.Nome.Equals(nome));
        }
    }
}
