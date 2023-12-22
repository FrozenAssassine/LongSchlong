using Julius.LongSchlong;
internal class Program
{
    private static void Main(string[] args)
    {
        var res = new LongSchlong("1234123123123123") + new LongSchlong("1234452343245");
        Console.WriteLine(res);
        Console.Read();
    }
}