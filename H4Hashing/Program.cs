using System.Text;

namespace H4Hashing
{
    public class Program
    {
        static void Main(string[] args)
        {
            //HMAC
            Console.WriteLine("Select method: ");
            CryptoServiceHmac hmacservice = new CryptoServiceHmac(Console.ReadLine());
            Console.Write("Enter Text: ");
            byte[] hmacencrypted = hmacservice.ComputeMac(Encoding.ASCII.GetBytes(Console.ReadLine()));
            Console.WriteLine($"Plain text: {Convert.ToBase64String(hmacencrypted)}");
            Console.WriteLine($"Hex: {BitConverter.ToString(hmacencrypted)}");
            Console.WriteLine($"Key: {Convert.ToBase64String(hmacservice.Key)}");
            Console.ReadLine();

            //Hash
            Console.WriteLine("Select method: ");
            CryptoService service = new CryptoService(Console.ReadLine());
            Console.Write("Enter Text: ");
            byte[] encrypted = service.ComputeHash(Encoding.ASCII.GetBytes(Console.ReadLine()));
            Console.WriteLine($"Plain text: {Convert.ToBase64String(encrypted)}");
            Console.WriteLine($"Hex: {BitConverter.ToString(encrypted)}");


        }
    }
}