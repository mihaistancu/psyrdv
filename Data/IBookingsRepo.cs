namespace psyrdv.Data;

public interface IBookingsRepo {
    void Save(Booking booking);
    List<Booking> GetAll();
    void Delete(Guid id);
}