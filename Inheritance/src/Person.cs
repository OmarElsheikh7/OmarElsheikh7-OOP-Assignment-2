public class Person
{
    public string PersonId { get; }
    public string FullName { get; }
    public string Phone { get; }

    protected Person(string id, string name, string phone)
    {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID is required");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");
        if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentException("Phone is required");

        PersonId = id;
        FullName = name;
        Phone = phone;
    }
}
