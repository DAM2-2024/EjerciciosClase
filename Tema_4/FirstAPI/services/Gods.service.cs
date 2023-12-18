namespace FirstAPI;

public class GodService: IData<God>{

    private static List<God> GodData = new List<God>()
    {
        new God{
        Id=1,
        Name="Zeus",
        Parejas= new List<string>(){
            "MartinoKing", "Carlos"
        },
        Fuerza=1,
        Protegee = new List<string>(){
            "Jesus","Manuelísimo"
        }
        },
        new God{
        Id=2,
        Name="Poseidon",
        Parejas= new List<string>(){
            "Jesus", "Silvia"
        },
        Fuerza=1,
        Protegee = new List<string>(){
            "Rafa","Gilgamesh"
        }
        }
    };


    public List<God> GetALL()
    {
        return GodData;
    }
    public God GetById(int id){
        return GodData.FirstOrDefault(x=>x.Id==id);
    }
    public God Add(God addObj){

        int maxId=GodData.Max(x=>x.Id);
        addObj.Id=maxId+1;
        GodData.Add(addObj);
        return addObj;
    }
    public God Put(God modifyObj){
        God data= GodData.FirstOrDefault(x=>x.Id==modifyObj.Id);
        if (data==null)
            return null;
        
        data.Name=modifyObj.Name;
        data.Parejas=modifyObj.Parejas;
        data.Fuerza=modifyObj.Fuerza;
        data.Protegee=modifyObj.Protegee;
        return data;
    }

    public bool Remove(int id){
        God data= GodData.FirstOrDefault(x=>x.Id==id);
        if (data==null)
            return false;

        return GodData.Remove(data);
    }

}