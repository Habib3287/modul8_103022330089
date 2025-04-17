// See https://aka.ms/new-console-template for more information
using System.Numerics;
using static BankTransferConfig;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig config = new BankTransferConfig();
        int transferAmount = 0, fee = 0;

        if (config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");
            transferAmount = int.Parse(Console.ReadLine());

            if (transferAmount < config.transfer.threshold)
            {
                fee = config.transfer.low_fee;
                Console.WriteLine("Transfer fee = " + fee);
                Console.WriteLine("Total amount = " + (transferAmount + fee));
            }

            else
            {
                fee = config.transfer.high_fee;
                Console.WriteLine("Transfer fee = " + fee);
                Console.WriteLine("Total amount = " + (transferAmount + fee));
            }

            Console.WriteLine("Select transfer method: ");
            for (int i = 1; i < config.methods.Count; i++)
            {
                Console.WriteLine(i + ". " + config.methods[i]);
            }
            String tfmethode = Console.ReadLine();

            Console.WriteLine("Please type yes to confirm the transaction: ");
            string confirmation = Console.ReadLine();
            if (confirmation == "yes")
            {
                Console.WriteLine("Transaction successful");
            }
            else
            {
                Console.WriteLine("Transaction cancelled");
            }
        }



        if (config.lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
            transferAmount = int.Parse(Console.ReadLine());

            if (transferAmount < config.transfer.threshold)
            {
                fee = config.transfer.low_fee;
                Console.WriteLine("Biaya Transfer = " + fee);
                Console.WriteLine("Total biaya = " + (transferAmount + fee));
            }

            else
            {
                fee = config.transfer.high_fee;
                Console.WriteLine("Biaya Transfer = " + fee);
                Console.WriteLine("Total biaya = " + (transferAmount + fee));
            }

            Console.WriteLine("Pilih metode transfer: ");
            for (int i = 1; i < config.methods.Count; i++)
            {
                Console.WriteLine(i + ". " + config.methods[i]);
            }
            String tfmethode = Console.ReadLine();

            Console.WriteLine("Ketik ya untuk mengkonfirmasi transaksi: ");
            string konfirmasi = Console.ReadLine();
            if (konfirmasi == "ya")
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }
    }
}    
 
