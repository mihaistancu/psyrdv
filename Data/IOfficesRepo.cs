namespace psyrdv.Data;

public interface IOfficesRepo
{
    IEnumerable<Office> GetAll();
    Office GetById(Guid id);
    void Save(Office office);
    void Delete(Guid id);
}