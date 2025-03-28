namespace CW_2_s28491;

public static class ProduktChlodniczy
{
    private static readonly Dictionary<string, (double min, double max)> _zakresy = new(StringComparer.OrdinalIgnoreCase) // dodałem maksymalną temperature dla produktu (nie ma tego w wymaganiach ale ma dla mnie większy sens)
    {
        { "Bananas", (13.3, 14) },
        { "Chocolate", (18, 21) },
        { "Fish", (2, 4) },
        { "Meat", (-15, -10) },
        { "Ice cream", (-18, -16) },
        { "Frozen pizza", (-30, -28) },
        { "Cheese", (7.2, 10) },
        { "Sausages", (5, 7) },
        { "Butter", (20.5, 22) },
        { "Eggs", (19, 22) }
    };

    public static bool CzyProduktZdefiniowany(string nazwa)
    {
        return _zakresy.ContainsKey(nazwa);
    }

    public static (double min, double max) PobierzZakresTemperatury(string nazwa)
    {
        if (_zakresy.TryGetValue(nazwa, out var zakres))
        {
            return zakres;
        }

        throw new ArgumentException($"Nieznany produkt: {nazwa}");
    }
}
