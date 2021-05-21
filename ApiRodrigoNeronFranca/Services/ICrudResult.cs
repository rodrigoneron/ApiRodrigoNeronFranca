using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRodrigoNeronFranca
{ 
    public interface ICrudResult
    {
        IEnumerable<Cadastro> Consulta();        
        Task Inclusao(Cadastro cadastro);
        Task Atualizacao(int id, Cadastro dados);
        Task Exclusao(int id);

    }
}
