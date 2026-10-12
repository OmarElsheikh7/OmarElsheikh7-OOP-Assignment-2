public class Shelver : Staff
{
    public string Section { get; private set; }

    public Shelver(string id, string name, string phone, DateOnly hireDate, decimal salary, string section)
        : base(id, name, phone, hireDate, salary, 0)
    {
        Section = section;
    }

    public void Reassign(string newSection) => Section = newSection;
}
