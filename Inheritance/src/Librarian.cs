public class Librarian : Staff
{
    public Librarian(string id, string name, string phone, DateOnly hireDate, decimal salary)
        : base(id, name, phone, hireDate, salary, 0) { }
}
