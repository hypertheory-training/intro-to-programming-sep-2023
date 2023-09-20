namespace CSharpNotes.Oop;
public class CustomerTests
{

    [Fact]
    public void Noodling()
    {
        var customer = new Customer(Guid.NewGuid())
        {
            Name = "Joe",
            EmailAddress = "joe@aol.com"
        };


        //customer.EmailAddress = "joe@aol.com";


    }
    [Fact]
    public void Noodling2()
    {
        var brad = new Student("Brad", "brad@aol.com");


        var brad2 = new Student("Brad", "brad@aol.com");



        Assert.Equal(brad, brad2);


        var myName = "Jeff";

        myName = myName.ToUpper();

        Assert.Equal("JEFF", myName);

        var sue = new Student("Susan", "sue@aol.com");


        var newSue = StudentServices.UpdateEmailAddress(sue, "sue@compuserve.com");

        Assert.Equal("sue@aol.com", sue.EmailAddress);
        Assert.Equal("sue@compuserve.com", newSue.EmailAddress);


    }
}
