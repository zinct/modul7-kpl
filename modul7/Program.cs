using System.Text.Json;

BankTransferConfig bankTransferConfig = new BankTransferConfig();
bankTransferConfig.READJSON();
class BankTransferConfig
{
    public class BankTrasfer
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public string[] methods { get; set; }
        public Confirmation confirmation { get; set; }
    }

    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }

    public void READJSON()
    {
        String configPath = "../../../BankTransferConfig.json";
        string jsonString = File.ReadAllText(configPath);
        var banktransferconfig = JsonSerializer.Deserialize<BankTrasfer>(jsonString);
        int jumlahTransfer = 0;
        if (banktransferconfig.lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            string input = Console.ReadLine();
            jumlahTransfer = Convert.ToInt32(input);
        }
        else
        {
            Console.WriteLine("Pelase insert the amount of money to transfer:");
            String input = Console.ReadLine();
            jumlahTransfer = Convert.ToInt32(input);
        }

        int biayaTransfer = 0;
        if (jumlahTransfer == banktransferconfig.transfer.threshold)
        {
            biayaTransfer = banktransferconfig.transfer.low_fee;

        }
        else if (jumlahTransfer > banktransferconfig.transfer.threshold)
        {
            biayaTransfer = banktransferconfig.transfer.high_fee;

        }


        if (biayaTransfer > 0 && banktransferconfig.lang == "id")
        {
            Console.WriteLine($"Biaya Transfer = {biayaTransfer} dan Total biaya =  {jumlahTransfer + biayaTransfer}");

        }
        else if (biayaTransfer > 0 && banktransferconfig.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {biayaTransfer} dan Total amount =  {jumlahTransfer + biayaTransfer}");

        }
        else
        {
            Console.WriteLine("Ada kesalahan pada biaya transfer");
        }

        if (banktransferconfig.lang == "id")
        {
            Console.WriteLine("Pilih Metode Pembayaran: ");
        }
        else
        {
            Console.WriteLine("Select transfer method: ");
        }

        Console.WriteLine($" 1. {banktransferconfig.methods[0]} \n 2. {banktransferconfig.methods[1]} \n 3. {banktransferconfig.methods[2]} \n 4. {banktransferconfig.methods[3]}");
        string inputMoethod = Console.ReadLine();

        if (banktransferconfig.lang == "id")
        {
            Console.WriteLine($"ketik {banktransferconfig.confirmation.id} unutk mengkonfirmasi transaksi: ");
            String confirm = Console.ReadLine();
            if (confirm == banktransferconfig.confirmation.id)
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");

            }
        }
        else
        {
            Console.WriteLine($"Please Type {banktransferconfig.confirmation.en} to confirm the transaction: ");
            String confirm = Console.ReadLine();
            if (confirm == banktransferconfig.confirmation.en)
            {
                Console.WriteLine("The transfer id completed");
            }
            else
            {
                Console.WriteLine("TTransfer cancelled");

            }
        }


    }


}