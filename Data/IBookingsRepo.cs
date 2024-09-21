namespace psyrdv.Data;

public interface IBookingsRepo {
    void Save(Booking booking);
    List<Booking> getAll();
    void Delete(Guid id);
}