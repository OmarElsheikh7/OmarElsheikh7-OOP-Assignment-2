
public class Magazine : LibraryItem
{
    public Magazine(string catalogNum, string title, decimal baseFee)
        : base(catalogNum, title, baseFee, 3, 0.5m) { }
}