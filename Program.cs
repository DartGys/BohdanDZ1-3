
class Converter
{
    decimal USDcurrency;
    decimal EURcurrency;

    public Converter(decimal EUR, decimal USD)
    {
        USDcurrency = USD;
        EURcurrency = EUR;
    }

    public decimal Convert(decimal UAH, decimal USD, decimal EUR)
    {
        Console.WriteLine("Введiть USD,щоб конвертувати в долари\nВведiть EUR,щоб конвертувати в евро\nВведiть UAH, щоб конвертувати в гривнi ");
        string currency = Console.ReadLine();
        while (currency != "USD" && currency != "EUR" && currency != "UAH")
        {
            Console.WriteLine("Спробуйте ще раз!");
            currency = Console.ReadLine();
        }
        if (EUR == 0 && USD == 0)
        {
            if (currency == "USD") return UAH / USDcurrency;
            else if (currency == "EUR") return UAH / EURcurrency;
            else if (currency == "UAH") return UAH;
        }
        else if (UAH == 0 && USD == 0)
        {
            if (currency == "USD") return (EUR / EURcurrency * USDcurrency);
            else if (currency == "UAH") return EUR * EURcurrency;
            else if (currency == "EUR") return EUR;
        }
        else if (UAH == 0 && EUR == 0)
        {
            if (currency == "EUR") return (USD / USDcurrency * EURcurrency);
            else if (currency == "UAH") return USD * EURcurrency;
            else if (currency == "USD") return USD;
        }
        return 0;
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        decimal enterValue()
        {
            decimal value;
            bool success = false;
            while (!success)
            {
                try
                {
                    Console.Write("Введiть сумму: ");
                    value = decimal.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введiть всюди тiльки числа!");
                    continue;
                }
                if (value > 0) return value;
                else Console.WriteLine("Числa повинно бути бiльше нуля");
            }
            return -1;
        }
        bool success = false;
        decimal EURcurrency = 0;
        decimal USDcurrency = 0;
        while (!success)
        {
            try
            {
                Console.Write("Введiть курс доллара: ");
                EURcurrency = decimal.Parse(Console.ReadLine());
                Console.Write("Введiть курс евро: ");
                USDcurrency = decimal.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Введiть тiльки числа!");
                continue;
            }
            if (EURcurrency > 0 && USDcurrency > 0) success = true;
            else Console.WriteLine("Числa повинно бути бiльше нуля");
        }
        while (true)
        {
            decimal showValue;
            decimal UAH = 0;
            decimal EUR = 0;
            decimal USD = 0;
            string cinCurrency = "";
            Converter conv = new Converter(EURcurrency,USDcurrency);

            Console.Write("Введiть валюту для конверта(UAH/USD/EUR): ");
            cinCurrency = Console.ReadLine();
            while (cinCurrency != "USD" && cinCurrency != "EUR" && cinCurrency != "UAH" && cinCurrency != "STOP")
            {
                Console.WriteLine("Помилка! Спробуйте ще раз!");
                cinCurrency = Console.ReadLine();
            }
            if (cinCurrency == "UAH") UAH = enterValue();
            else if (cinCurrency == "EUR") EUR = enterValue();
            else if (cinCurrency == "USD") USD = enterValue();
            else if (cinCurrency == "STOP") return;
            showValue = conv.Convert(UAH, USD, EUR); 
            Console.WriteLine("Це буде: " + showValue + "\n");
            UAH = 0;
            EUR = 0;
            USD = 0;

            Console.WriteLine("Якшо хочете зупинити програму напишiть (STOP)" + "\n");
        }
    }
}