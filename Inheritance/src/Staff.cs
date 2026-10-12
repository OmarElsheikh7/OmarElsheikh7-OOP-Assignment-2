public class Staff : Person
{
    public DateOnly HireDate { get; }
    public decimal MonthlySalary { get; private set; }
    private decimal _allowance;

    protected Staff(string id, string name, string phone, DateOnly hireDate, decimal salary, decimal allowance)
        : base(id, name, phone)
    {
        if (salary <= 0) throw new ArgumentException("Salary must be positive");
        HireDate = hireDate;
        MonthlySalary = salary;
        _allowance = allowance;
    }

    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0) throw new ArgumentException("Raise percentage must be positive");
        MonthlySalary += MonthlySalary * percentage;
    }

    // Handles the salary + allowance calculation for everyone, including the Head Librarian
    public decimal GetMonthlyPay() => MonthlySalary + _allowance;
}
