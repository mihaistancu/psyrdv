namespace psyrdv.Data;

public interface IOfficesRepo
{
    List<Office> GetAll();
    Office GetById(Guid id);
    void Save(Office office);
    void Delete(Guid id);
}