public class Book : LibraryItem
{
    public Book(string catalogNum, string title, decimal baseFee)
        : base(catalogNum, title, baseFee, 21, 1.0m) { }
}
