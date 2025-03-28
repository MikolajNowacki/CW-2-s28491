namespace CW_2_s28491;

public static class ProduktChlodniczy
{
    private static readonly Dictionary<string, double> _minimalneTemperatury = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public static bool CzyProduktZdefiniowany(string nazwa)
    {
        return _minimalneTemperatury.ContainsKey(nazwa);
    }

    public static double PobierzMinimalnaTemperature(string nazwa)
    {
        if (_minimalneTemperatury.TryGetValue(nazwa, out double temperatura))
        {
            return temperatura;
        }

        throw new ArgumentException($"Nieznany produkt: {nazwa}");
    }
}