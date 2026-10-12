namespace PatternsLab.Problems.Prototype;

public class EnemyRegistry
{
    private Dictionary<string, Enemy> _prototypes = new Dictionary<string, Enemy>();

    public void Register(string key, Enemy prototype)
    {
        _prototypes[key] = prototype;
    }

    public Enemy CreateEnemy(string key)
    {
        if (_prototypes.TryGetValue(key, out Enemy prototype))
        {
            return prototype.Clone();
        }
        throw new ArgumentException($"No prototype found for key: {key}");
    }
}

