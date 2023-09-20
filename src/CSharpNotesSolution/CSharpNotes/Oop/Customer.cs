namespace CSharpNotes.Oop;
public class Customer
{
    // State
    // class level variable - "field"
    // Do not create this class unless you can give me this thing.
    public Customer(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
    public string Name { get; set; } = string.Empty;
    public required string EmailAddress { get; init; } = string.Empty;

    public void MakePurchase(decimal amount)
    {
        AvailableCredit -= amount;
    }


    public void MakePurchase(decimal amount, int qty)
    {
        AvailableCredit -= (amount * qty);
    }
    public decimal AvailableCredit { get; private set; } = 5000;
    public string GetSummary()
    {
        return $"Customer {Name} has a credit Limit of {AvailableCredit:c}";
    }

}


//public record Student
//{
//    public string? Name { get; init; }
//    public string EmailAddress { get; init; } = string.Empty;


//}

public record Student(string? Name, string EmailAddress);


public static class StudentServices
{
    public static Student UpdateEmailAddress(Student student, string emailAddress)
    {
        // update just their email address in the database, 
        // and return them the updated student with the new email

        //var updatedStudent = new Student(student.Name, emailAddress);
        //return updatedStudent;
        return student with { EmailAddress = emailAddress };

    }
}