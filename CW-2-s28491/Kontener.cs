namespace CW_2_s28491;

public abstract class Kontener
{
    private static int _int = 1;
    public string NumerSeryjny { get; }
    public double WagaWlasna { get; }
    public double MaksymalnaLadownosc { get; }
    public double MasaLadunku { get; protected set; }

    protected Kontener(string typ, double wagaWlasna, double maksLadownosc)
    {
        NumerSeryjny = $"KON-{typ}-{_int++}";
        WagaWlasna = wagaWlasna;
        MaksymalnaLadownosc = maksLadownosc;
        MasaLadunku = 0;
    }

    public virtual void Zaladuj(double masa)
    {
        if (MasaLadunku + masa > MaksymalnaLadownosc)
        {
            throw new OverfillException($"Przekroczono maksymalną ładowność kontenera {NumerSeryjny}");
        }
        MasaLadunku += masa;
    }

    public virtual void Oproznij()
    {
        MasaLadunku = 0;
    }

    public override string ToString()
    {
        return $"{NumerSeryjny} | Masa ładunku: {MasaLadunku}kg";
    }
}