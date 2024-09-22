namespace psyrdv.Data;

public interface IOfficeRepo
{
    IEnumerable<Office> GetAll();
    void Save(Office office);
    void Delete(Guid id);
}
