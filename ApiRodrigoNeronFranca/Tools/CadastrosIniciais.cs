/***********************************************************************
 * Data     : 20/05/2021
 * Autor    : Rodrigo Neron França
 ***********************************************************************/

#region Bibliotecas
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace ApiRodrigoNeronFranca
{
    public class CadastrosIniciais
    {

        private readonly ApplicationDbContext _context;

        public CadastrosIniciais(ApplicationDbContext aplicationDbContext)
        {
            _context = aplicationDbContext;
        }

        public void AddCadastrosIniciais()
        {
            List<Cadastro> Usuarios = new List<Cadastro>
            {
                new Cadastro { Id = 1, Nome = "Rodrigo", CPF = "12414134235", Email = "rodrigo@teste.com.br", Telefone = "1212349876", Sexo = "M", DataNascimento = new DateTime(1986, 6, 26) },
                new Cadastro { Id = 2, Nome = "Bruna", CPF = "24141342351", Email = "bruna@teste.com.br", Telefone = "2349876461", Sexo = "F", DataNascimento = new DateTime(1988, 12, 29) },
                new Cadastro { Id = 3, Nome = "Marcos", CPF = "41413423513", Email = "marcos@teste.com.br", Telefone = "6542349876", Sexo = "M", DataNascimento = new DateTime(1985, 2, 14) },
                new Cadastro { Id = 4, Nome = "Ana Lucia", CPF = "14134235423", Email = "analucia@teste.com.br", Telefone = "7912349876", Sexo = "F", DataNascimento = new DateTime(1987, 5, 17) }
            };

            _context.Cadastros.AddRange(Usuarios);
            _context.SaveChanges();
        }

    }
}
