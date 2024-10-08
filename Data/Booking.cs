namespace psyrdv.Data;

public class Booking {
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid OfficeId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
    public String Details { get; set; }

}