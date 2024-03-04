// Banka arayüzü
public interface IBank
{
    void ProcessTransaction();
}

// Halk Bankası
public class HalkBank : IBank
{
    private readonly string username;
    private readonly string password;
    private readonly double amount;
    private bool isConnect;

    public HalkBank(string username, string password)
    {
        Console.WriteLine($"{nameof(HalkBank)} - nesnesi oluşturuldu.");
        this.username = username;
        this.password = password;
        this.isConnect = false;
    }

    public void ProcessTransaction()
    {
        Console.WriteLine($"Halk Bankası işlemi yapılıyor.");
    }

    public void ConnectHalk()
    {
        if(username == "HalkBankAuth123" && password == "HalkBankPassword456")
        {
            Console.WriteLine($"{nameof(HalkBank)} - Bağlandı.");
            isConnect = true;
        }
    }
    public void SendMoney(double amount)
    {
        if (isConnect)
            Console.WriteLine($"{nameof(HalkBank)} {amount} TL gönderildi");
        else
            Console.WriteLine($"{nameof(HalkBank)} {amount} TL gönderilemedi, bağlantı yok");
    }
}

// Ziraat Bankası
public class ZiraatBank : IBank
{
    private readonly string statusInfo;

    public ZiraatBank(string statusInfo)
    {
        Console.WriteLine($"{nameof(ZiraatBank)} - nesnesi oluşturuldu.");
        this.statusInfo = statusInfo;
    }

    public void ProcessTransaction()
    {
        Console.WriteLine($"Ziraat Bankası işlemi yapılıyor. İşlem Bilgisi: {statusInfo}");
    }
}

// Vakıf Bankası
public class VakifBank : IBank
{
    private readonly string username;
    private readonly string password;
    private readonly string statusInfo;

    public VakifBank(string username, string password, string statusInfo)
    {
        Console.WriteLine($"{nameof(VakifBank)} - nesnesi oluşturuldu.");
        this.username = username;
        this.password = password;
        this.statusInfo = statusInfo;
    }

    public void ProcessTransaction()
    {
        Console.WriteLine($"Vakıf Bankası işlemi yapılıyor.  İşlem Bilgisi: {statusInfo}");
    }
}

// Banka Factory Interface
public interface IBankFactory
{
    IBank CreateInstance();
}

// Halk Bankası Factory
public class HalkBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        HalkBank halk =  new HalkBank("HalkBankAuth123", "HalkBankPassword456");
        halk.ProcessTransaction();
        halk.ConnectHalk();
        halk.SendMoney(1.500);
        return halk;
    }
}

// Ziraat Bankası Factory
public class ZiraatBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        return new ZiraatBank(Guid.NewGuid().ToString());
    }
}

// Vakıf Bankası Factory
public class VakifBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        return new VakifBank("VakifBankAuth789", "VakifBankPassword999", Guid.NewGuid().ToString());
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Halk Bankası işlemi
        IBankFactory halkBankFactory = new HalkBankFactory();
        IBank halkBank = halkBankFactory.CreateInstance();

        // Ziraat Bankası işlemi
        IBankFactory ziraatBankFactory = new ZiraatBankFactory();
        IBank ziraatBank = ziraatBankFactory.CreateInstance();
        ziraatBank.ProcessTransaction();

        // Vakıf Bankası işlemi
        IBankFactory vakifBankFactory = new VakifBankFactory();
        IBank vakifBank = vakifBankFactory.CreateInstance();
        vakifBank.ProcessTransaction();

        Console.ReadLine();
    }
}
