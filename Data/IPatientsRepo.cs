namespace psyrdv.Data;

public interface IPatientsRepo {
    void Save(Patient patient);
    List<Patient> getAll();
    void Delete(Guid id);
}