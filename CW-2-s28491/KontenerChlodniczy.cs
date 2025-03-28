namespace CW_2_s28491;

public class KontenerChlodniczy : Kontener
{
    public string RodzajProduktu { get; }
    public double Temperatura { get; }

    public KontenerChlodniczy(double wagaWlasna, double maksLadownosc, string produkt, double temperatura)
        : base("C", wagaWlasna, maksLadownosc)
    {
        RodzajProduktu = produkt;
        Temperatura = temperatura;
    }

    public override void Zaladuj(double masa)
    {
        if (masa > MaksymalnaLadownosc)
            throw new OverfillException("Zbyt duzo ladunku do kontenera chlodniczego");
        base.Zaladuj(masa);
    }
}