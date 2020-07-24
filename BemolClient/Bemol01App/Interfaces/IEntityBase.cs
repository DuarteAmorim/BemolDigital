
using Microsoft.EntityFrameworkCore;

namespace Bemol01App.Interfaces
{
    public interface IEntityBase<T> where T : class
    {
        //public BemolContext _bemolContext { get;  set; }
        int Incluir(T obj);
        T Consultar(string a);
        T Alterar(T obj);
        int Remover(string a);
    }
}
