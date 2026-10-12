public class HeadLibrarian : Staff
{
    public HeadLibrarian(string id, string name, string phone, DateOnly hireDate, decimal salary)
        : base(id, name, phone, hireDate, salary, 400) { } // Passes the 400 allowance
}
