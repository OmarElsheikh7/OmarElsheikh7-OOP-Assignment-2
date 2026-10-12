public class DVD : LibraryItem
{
    public DVD(string catalogNum, string title, decimal baseFee)
        : base(catalogNum, title, baseFee, 7, 2.0m) { }
}
