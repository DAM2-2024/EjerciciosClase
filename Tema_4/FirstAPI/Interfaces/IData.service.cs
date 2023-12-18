namespace FirstAPI;

public interface IData<T>
{
    public List<T> GetALL();
    public T GetById(int id);
    public T Add(T addObj);
    public T Put(T modifyObj);
    public bool Remove(int id);
}