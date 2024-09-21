namespace psyrdv.Data;

public interface IAccessRepo {
    void Save(string userId, DateTime timestamp);
    List<Access> GetAll();
}