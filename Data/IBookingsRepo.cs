namespace psyrdv.Data;

public interface IBookingsRepo {
    void Save(Booking booking);
    List<Booking> GetAll();
    Booking GetById(Guid id);
    void Delete(Guid id);
}