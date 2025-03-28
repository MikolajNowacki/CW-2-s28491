namespace CW_2_s28491;

public class KontenerPlyn : Kontener, IHazardNotifier
{
    public bool NiebezpiecznyLadunek { get; }

    public KontenerPlyn(double wysokosc, double glebokosc, double wagaWlasna, double maksLadownosc, bool niebezpieczny)
        : base("L", wysokosc, glebokosc, wagaWlasna, maksLadownosc)
    {
        NiebezpiecznyLadunek = niebezpieczny;
    }

    public override void Zaladuj(double masa)
    {
        double limit = NiebezpiecznyLadunek ? 0.5 : 0.9;
        if (masa > MaksymalnaLadownosc * limit)
        {
            NotyfikacjaONiepbez(NumerSeryjny, "Zbyt duza masa ladunku dla kontenera na plyny");
            throw new OverfillException("Proba niebezpiecznej operacji - za duzo ladunku");
        }
        base.Zaladuj(masa);
    }

    public void NotyfikacjaONiepbez(string numer, string tresc)
    {
        Console.WriteLine($"[ALERT - {numer}] {tresc}");
    }
}