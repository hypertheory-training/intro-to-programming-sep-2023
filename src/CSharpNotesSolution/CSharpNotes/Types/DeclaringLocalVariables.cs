namespace CSharpNotes.Types;
public class DeclaringLocalVariables
{
    [Fact]
    public void ExplicitlyTypedLocalVariable()
    {
        // Type identifier [= value]
        int a = 0;
        int b = 2;

        string dogName = "Rover";

        Assert.Equal("Rover", dogName);

        Assert.Equal(0, a);
        Assert.Equal(2, b);
    }

    [Fact]
    public void ImplicitlyTypedLocalVariablesWithVar()
    {
        // If you are going to initialize the variable, C# already knows the type. You can have it infer the type.
        var a = 0; // if there is a literal number with no decimal point, it is an int.
        var b = 1.0; // A number with a decimal point is inferred to be a double precision floating point number.
        var c = "Cat"; // This is a string.
        var d = 'A'; // this is a char
        var e = true;
        decimal salary = 80123.23M;

        var rover = new Dog();
    }

    [Fact]
    public void ImplicitlyTypedLocalVariablesWithNew()
    {
        // .NET 5
        Dog rover = new();
    }
}


public class Dog { }