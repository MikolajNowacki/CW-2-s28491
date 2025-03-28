namespace CW_2_s28491;

public class KontenerGaz : Kontener, IHazardNotifier
{
    public double Cisnienie { get; }

    public KontenerGaz(double wysokosc, double glebokosc, double wagaWlasna, double maksLadownosc, double cisnienie)
        : base("G", wysokosc, glebokosc, wagaWlasna, maksLadownosc)
    {
        Cisnienie = cisnienie;
    }

    public override void Zaladuj(double masa)
    {
        if (masa > MaksymalnaLadownosc)
        {
            NotyfikacjaONiepbez(NumerSeryjny, "Zbyt duza masa ladunku dla kontenera na gaz");
            throw new OverfillException("Proba niebezpiecznej operacji - za duzo ladunku");
        }
        base.Zaladuj(masa);
    }

    public override void Oproznij()
    {
        MasaLadunku *= 0.05; // zostawiamy 5%
    }

    public void NotyfikacjaONiepbez(string numer, string tresc)
    {
        Console.WriteLine($"[ALERT - {numer}] {tresc}");
    }
}