namespace psyrdv.Data;

public interface IPatientsRepo {
    void Save(Patient patient);
    List<Patient> GetAll();
    Patient GetById(Guid id);
    void Delete(Guid id);
}