using System;

public interface IEntityBase<T> where T: class
{
    int Incluir(T obj);
    int Consultar(string a);
    int Alterar(T obj);
    int Remover(string a);
}
