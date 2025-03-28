// See https://aka.ms/new-console-template for more information
namespace CW_2_s28491;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n~~~~Błędy:");
        
        // kontenery
        var plyn1 = new KontenerPlyn(200, 400, 1000, 5000, true);
        var plyn2 = new KontenerPlyn(200, 400, 1000, 5000, false);
        var gaz1 = new KontenerGaz(210, 410, 1200, 6000, 4.2);
        var chlod1 = new KontenerChlodniczy(220, 420, 1100, 3000, "Ice cream", -18);

        // zbyt niska temp
        try
        {
            var chlodError = new KontenerChlodniczy(220, 420, 1100, 3000, "Butter", 15);
        }
        catch (Exception ex)
        {
            Console.WriteLine("! za niska temperaturta: " + ex.Message);
        }

        // zbyt wysoka
        try
        {
            var chlodHighTemp = new KontenerChlodniczy(200, 400, 1000, 3000, "Chocolate", 25);
        }
        catch (Exception ex)
        {
            Console.WriteLine("! za wysoka temperatura: " + ex.Message);
        }

        // nieznany produkt
        try
        {
            var chlodniez = new KontenerChlodniczy(220, 420, 1100, 3000, "Tacos", 10);
        }
        catch (Exception ex)
        {
            Console.WriteLine("! nieznany produkt: " + ex.Message);
        }

        // przeładowanie kontenera z cieczą
        try
        {
            plyn1.Zaladuj(3000);
        }
        catch (OverfillException ex)
        {
            Console.WriteLine("! przeładowanie kontenera cieczą: " + ex.Message);
        }

        // poprawne kontenery
        plyn2.Zaladuj(4000);
        gaz1.Zaladuj(5800);
        chlod1.Zaladuj(2500);

        // kontenerowiec
        var statek = new Kontenerowiec("Kont11", 20, 10, 50);

        // ładowanie kontenerów
        statek.ZaladujKontener(plyn2);
        statek.ZaladujKontener(gaz1);
        statek.ZaladujKontener(chlod1);

        // info o kontenerowcu
        Console.WriteLine("\n~~~~Stan kontenerowca:");
        statek.WypiszInformacje();

        // rozładowanie kontenera gazowego
        statek.RozladujKontener(gaz1.NumerSeryjny);

        // kontener płynów na chłodniczy
        var nowyChlod = new KontenerChlodniczy(210, 400, 1000, 3000, "Cheese", 10);
        statek.ZamienKontener(plyn2.NumerSeryjny, nowyChlod);

        // Usuwanie gazowego
        statek.UsunKontener(gaz1.NumerSeryjny);

        // załadunek zbyt ciężkiego kontenera
        try
        {
            var ciezki = new KontenerPlyn(300, 500, 1000, 45000, false);
            ciezki.Zaladuj(44000);
            bool wynik = statek.ZaladujKontener(ciezki);
            if (!wynik) Console.WriteLine("! przekroczono dopuszczalną ładowność statku");
        }
        catch (OverfillException ex)
        {
            Console.WriteLine("! przekroczono limit wagi kontenera: " + ex.Message);
        }

        // przekroczenie limitu kontenerów
        var statekMini = new Kontenerowiec("Mini", 15, 1, 10);
        statekMini.ZaladujKontener(plyn2);
        bool ladunek = statekMini.ZaladujKontener(gaz1);
        if (!ladunek)
            Console.WriteLine("! przekroczono limit liczby kontenerów na statku");

        // przenoszenie kontenera między statkami
        var statekA = new Kontenerowiec("A", 25, 5, 40);
        var statekB = new Kontenerowiec("B", 25, 5, 40);
        statekA.ZaladujKontener(plyn2);
        if (statekA.UsunKontener(plyn2.NumerSeryjny))
        {
            statekB.ZaladujKontener(plyn2);
            Console.WriteLine("Przeniesiono kontener z A do B");
        }

        // końcowy stan statku
        Console.WriteLine("\n~~~~Stan końcowy:");
        statek.WypiszInformacje();
    }
}