using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. MUST NOT COMPILE: 
        // Person p = new Person("1", "Bob", "555");
        // Member m = new Member("2", "Alice", "555", 3, 0);
        // Staff s = new Staff("3", "Tom", "555", DateOnly.FromDateTime(DateTime.Now), 1000, 0);
        // LibraryItem item = new LibraryItem("A1", "Title", 1m, 7, 1m);
        // Student st = new Student("S1", "Sarah", "555"); 
        // st.FullName = "New Name"; 
        // st.Loans.Add(new Loan(...)); 
        // Book b1 = new Book("B1", "Book", 1m); 
        // b1.IsOnLoan = true; 

        var student = new Student("S1", "Omar", "0100000");
        var premium = new Premium("P1", "Ahmed", "0110000", 0.10m); // 10% discount

        var book1 = new Book("B1", "C# Basics", 2m);
        var book2 = new Book("B2", "Design Patterns", 2m);
        var book3 = new Book("B3", "Algorithms", 2m);
        var book4 = new Book("B4", "Database Systems", 2m);
        var dvd = new DVD("D1", "Clean Code Video", 3m); // Fee = 3 * 2 = 6/day
        var mag = new Magazine("M1", "Tech Monthly", 2m);

        Console.WriteLine("--- Testing Failures ---");

        // Fail 1: Borrow withdrawn item
        try
        {
            book1.Withdraw();
            student.Borrow(book1, new DateOnly(2026, 1, 1));
        }
        catch (Exception ex) { Console.WriteLine($"Expected Fail: {ex.Message}"); }
        book1.Restore();

        // Fail 2: Borrow item already on loan
        student.Borrow(book1, new DateOnly(2026, 1, 1));
        try
        {
            premium.Borrow(book1, new DateOnly(2026, 1, 1));
        }
        catch (Exception ex) { Console.WriteLine($"Expected Fail: {ex.Message}"); }

        // Fail 3: Student 4th item
        student.Borrow(book2, new DateOnly(2026, 1, 1));
        student.Borrow(book3, new DateOnly(2026, 1, 1));
        try
        {
            student.Borrow(book4, new DateOnly(2026, 1, 1));
        }
        catch (Exception ex) { Console.WriteLine($"Expected Fail: {ex.Message}"); }

        Console.WriteLine("\n--- Testing Polymorphism (Staff) ---");
        var lib = new Librarian("E1", "Alice", "123", new DateOnly(2020, 1, 1), 5000);
        var shelver = new Shelver("E2", "Bob", "123", new DateOnly(2021, 1, 1), 3000, "Fiction");
        var head = new HeadLibrarian("E3", "Carol", "123", new DateOnly(2015, 1, 1), 8000);

        List<Staff> staffList = new List<Staff> { lib, shelver, head };
        foreach (var s in staffList)
        {
            Console.WriteLine($"{s.FullName} Pay: {s.GetMonthlyPay()}"); // Head Librarian will show 8400
        }

        Console.WriteLine("\n--- Testing Polymorphism (Items) ---");
        List<LibraryItem> items = new List<LibraryItem> { book1, dvd, mag };
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Title} - Period: {item.LoanPeriodDays} days, Daily Fee: {item.DailyLateFee}");
        }

        Console.WriteLine("\n--- Testing Premium Member (Late Return) ---");
        var borrowDate = new DateOnly(2026, 10, 1);
        var pLoan = premium.Borrow(dvd, borrowDate);
        Console.WriteLine($"Borrow Date: {borrowDate}");
        Console.WriteLine($"Due Date: {pLoan.DueDate} (7 days for DVD)");

        // Return 5 days late (Due 10/8, Returned 10/13)
        pLoan.ReturnItem(new DateOnly(2026, 10, 13));
        Console.WriteLine($"Returned on: 10/13. Late Fee: {pLoan.LateFee}"); // Base = 5 days * 6 = 30. 10% discount = 27.
        Console.WriteLine($"Premium Points: {premium.ReadingPoints}"); // Should be 5

        Console.WriteLine("\n--- Testing Status Failures ---");
        try
        {
            pLoan.ReturnItem(new DateOnly(2026, 10, 14));
        }
        catch (Exception ex) { Console.WriteLine($"Expected Fail (Double return): {ex.Message}"); }

        try
        {
            pLoan.MarkAsLost();
        }
        catch (Exception ex) { Console.WriteLine($"Expected Fail (Lost after return): {ex.Message}"); }
    }
}
