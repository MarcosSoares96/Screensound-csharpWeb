using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    public class DAL<T> where T : class
    {
        private readonly ScreenSoundContext context;

        public DAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        //Expõe o enumerador, que suporta uma iteração simples sobre uma coleção de um tipo especificado.
        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }

        public void Adicionar(T objeto)
        {
            //Começa a rastrear a entidade fornecida e quaisquer outras entidades alcançáveis ​​que ainda não estejam sendo rastreadas no estado
            //Microsoft.EntityFrameworkCore.EntityState.Added, de modo que elas serão inseridas no banco de dados quando
            //Microsoft.EntityFrameworkCore.DbContext.SaveChanges for chamado.
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }

        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }

        public void Deletar(T objeto)
        {
            //Começa a rastrear a entidade fornecida no estado<see cref= "EntityState.Deleted" /> de forma que ela seja removida do banco de dados quando
            //<see cref = "DbContext.SaveChanges()" /> for chamado.
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }

        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().Where(condicao);
        }

    }
}
