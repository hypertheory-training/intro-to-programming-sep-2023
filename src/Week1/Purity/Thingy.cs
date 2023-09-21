namespace Purity;
public static class Thingy
{
    public static int Foo(int a, int b)
    {
        return a + b;
    }
    public static int Bar(int a, int b)
    {
        var doubleIt = DateTime.Now.Microsecond % 2 == 0; // The hidden variable. Impure.

        if (doubleIt)
        {
            return (a * 2) + (b * 2);
        }
        else
        {
            return a + b;
        }
    }
}
