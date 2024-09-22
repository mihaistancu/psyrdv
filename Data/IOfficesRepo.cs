namespace psyrdv.Data;

public interface IOfficesRepo
{
    IEnumerable<Office> GetAll();
    void Save(Office office);
    void Delete(Guid id);
}