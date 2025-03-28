namespace CW_2_s28491;

public abstract class Kontener
{
    private static int _int = 1;
    public string NumerSeryjny { get; }
    public double MasaLadunku { get; set; }
    public double Wysokosc { get; }
    public double Glebokosc { get; }
    public double WagaWlasna { get; }
    public double MaksymalnaLadownosc { get; }

    protected Kontener(string typ, double wysokosc, double glebokosc, double wagaWlasna, double maksLadownosc)
    {
        NumerSeryjny = $"KON-{typ}-{_int++}";
        Wysokosc = wysokosc;
        Glebokosc = glebokosc;
        WagaWlasna = wagaWlasna;
        MaksymalnaLadownosc = maksLadownosc;
        MasaLadunku = 0;
    }

    public virtual void Zaladuj(double masa)
    {
        if (MasaLadunku + masa > MaksymalnaLadownosc)
            throw new OverfillException($"Kontener {NumerSeryjny} przekroczyl dopuszczalna ladownosc.");
        
        MasaLadunku += masa;
    }

    public virtual void Oproznij()
    {
        MasaLadunku = 0;
    }

    public override string ToString()
    {
        return $"[{NumerSeryjny}] Wys: {Wysokosc}cm, Gleb: {Glebokosc}cm, Masa ladunku: {MasaLadunku}kg";
    }
}