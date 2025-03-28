namespace CW_2_s28491;

public class Kontenerowiec
{
    public string Nazwa { get; }
    public int MaksPredkosc { get; }
    public int MaksIloscKontenerow { get; }
    public double MaksLadownoscWTonach { get; }

    private List<Kontener> _kontenery = new List<Kontener>();

    public Kontenerowiec(string nazwa, int maksPredkosc, int maksIlosc, double maksLadownoscWTonach)
    {
        Nazwa = nazwa;
        MaksPredkosc = maksPredkosc;
        MaksIloscKontenerow = maksIlosc;
        MaksLadownoscWTonach = maksLadownoscWTonach;
    }

    public bool ZaladujKontener(Kontener kontener)
    {
        if (_kontenery.Count >= MaksIloscKontenerow) return false;

        double obecnaWaga = _kontenery.Sum(k => k.MasaLadunku + k.WagaWlasna) / 1000; // kg na tony
        double nowaWaga = obecnaWaga + (kontener.MasaLadunku + kontener.WagaWlasna) / 1000;
        if (nowaWaga > MaksLadownoscWTonach) return false;

        _kontenery.Add(kontener);
        return true;
    }

    public void ZaladujListeKontenerow(List<Kontener> kontenery)
    {
        foreach (var kontener in kontenery)
        {
            if (!ZaladujKontener(kontener))
            {
                Console.WriteLine($"Nie zaladowano kontenera {kontener.NumerSeryjny} - przekroczono limity.");
            }
        }
    }

    public bool UsunKontener(string numerSeryjny)
    {
        var kontener = _kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
        if (kontener != null)
        {
            _kontenery.Remove(kontener);
            return true;
        }
        return false;
    }

    public bool RozladujKontener(string numerSeryjny)
    {
        var kontener = _kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
        if (kontener != null)
        {
            kontener.Oproznij();
            return true;
        }
        return false;
    }

    public bool ZamienKontener(string numerSeryjny, Kontener nowy)
    {
        if (!UsunKontener(numerSeryjny)) return false;
        return ZaladujKontener(nowy);
    }

    public void WypiszInformacje()
    {
        Console.WriteLine($"Kontenerowiec: {Nazwa} (Max {MaksIloscKontenerow} kontenerów, {MaksLadownoscWTonach} ton)");
        Console.WriteLine($"Liczba kontenerów: {_kontenery.Count}");
        foreach (var kontener in _kontenery)
        {
            Console.WriteLine(kontener);
        }
    }

    public List<Kontener> PobierzKontenery()
    {
        return _kontenery;
    }
}