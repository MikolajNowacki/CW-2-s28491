// See https://aka.ms/new-console-template for more information
namespace CW_2_s28491;

class Program
{
    static void Main()
    {
        // Tworzymy kontenery
        var kontenerPlyn = new KontenerPlyn(
            wysokosc: 200,
            glebokosc: 400,
            wagaWlasna: 1000,
            maksLadownosc: 5000,
            niebezpieczny: true
        );

        var kontenerGaz = new KontenerGaz(
            wysokosc: 220,
            glebokosc: 450,
            wagaWlasna: 1200,
            maksLadownosc: 6000,
            cisnienie: 5.5
        );

        var kontenerChlodniczy = new KontenerChlodniczy(
            wysokosc: 210,
            glebokosc: 420,
            wagaWlasna: 1100,
            maksLadownosc: 4000,
            produkt: "banany",
            temperatura: 5
        );

        // Ładujemy kontenery
        try
        {
            kontenerPlyn.Zaladuj(2500); // 50% max bo niebezpieczny
            kontenerGaz.Zaladuj(5500);  // pełna ładowność
            kontenerChlodniczy.Zaladuj(3500); // pełna ładowność
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Błąd załadunku: {ex.Message}");
        }

        // Tworzymy kontenerowiec
        var statek = new Kontenerowiec(
            nazwa: "Baltic Carrier",
            maksPredkosc: 25,
            maksIlosc: 100,
            maksLadownoscWTonach: 100
        );

        // Ładujemy kontenery na statek
        statek.ZaladujKontener(kontenerPlyn);
        statek.ZaladujKontener(kontenerGaz);
        statek.ZaladujKontener(kontenerChlodniczy);

        // Wypisujemy informacje o statku i kontenerach
        Console.WriteLine("\n=== STAN KONTENEROWCA ===");
        statek.WypiszInformacje();

        // Rozładunek jednego kontenera
        Console.WriteLine("\n--- Rozładunek kontenera gazowego ---");
        statek.RozladujKontener(kontenerGaz.NumerSeryjny);

        // Ponowny stan
        Console.WriteLine("\n=== STAN PO ROZLADUNKU ===");
        statek.WypiszInformacje();
    }
}