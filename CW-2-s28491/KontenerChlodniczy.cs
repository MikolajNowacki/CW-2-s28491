namespace CW_2_s28491;

public class KontenerChlodniczy : Kontener
{
    public string RodzajProduktu { get; }
    public double Temperatura { get; }

    public KontenerChlodniczy(double wysokosc, double glebokosc, double wagaWlasna, double maksLadownosc, string produkt, double temperatura)
        : base("C", wysokosc, glebokosc, wagaWlasna, maksLadownosc)
    {
        if (!ProduktChlodniczy.CzyProduktZdefiniowany(produkt))
            throw new Exception($"Produkt {produkt} nie jest wspierany.");

        var (minTemp, maxTemp) = ProduktChlodniczy.PobierzZakresTemperatury(produkt);

        if (temperatura < minTemp || temperatura > maxTemp)     // dodałem też sprawdzanie maksymalnej temperatury w kontenerowcu (nie ma tego w wymaganiach ale ma to dla mnie większy sens)
        {
            throw new Exception($"Temperatura {temperatura}°C jest poza dopuszczalnym zakresem dla produktu {produkt}. Dozwolony zakres: {minTemp}°C - {maxTemp}°C.");
        }

        RodzajProduktu = produkt;
        Temperatura = temperatura;
    }
}
