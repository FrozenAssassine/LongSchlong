using Julius.LongSchlong;
internal class Program
{
    private static void Main(string[] args)
    {
        var res = new LongSchlong("1000") - new LongSchlong("5000");
        Console.WriteLine(res);
        Console.Read();
    }
}