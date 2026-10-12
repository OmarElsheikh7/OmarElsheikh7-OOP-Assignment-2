public class Student : Member
{
    public Student(string id, string name, string phone)
        : base(id, name, phone, 3, 0) { } // 3 max items, 0 discount
}
