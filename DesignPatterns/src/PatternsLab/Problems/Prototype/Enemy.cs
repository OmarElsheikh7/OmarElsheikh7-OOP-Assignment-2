namespace PatternsLab.Problems.Prototype;

public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Weapon Clone()
    {
        Weapon clone = (Weapon)this.MemberwiseClone();

        clone.Damage = this.Damage;
        clone.Name = this.Name;

        return clone;
    }
}

public abstract class Enemy
{
    private string _modelData;

    public string Name { get; set; }
    public int Health { get; set; }
    public Weapon Weapon { get; set; }
    public List<string> Abilities { get; set; } = new();
    public string ModelId => _modelData;

    protected Enemy()
    {
        Console.WriteLine("   ...loading 3D model (slow)...");
        Thread.Sleep(500);
        _modelData = "MODEL_" + Guid.NewGuid().ToString("N")[..6];
    }

    public abstract Enemy Clone();
}

public class Orc : Enemy
{
    public Orc()
    {
        Name = "Orc";
        Health = 100;
        Weapon = new Weapon { Name = "Axe", Damage = 25 };
        Abilities.Add("Rage");
    }

    public override Enemy Clone()
    {
        
        Orc clone = (Orc)this.MemberwiseClone();
        clone.Weapon = this.Weapon.Clone();
        clone.Abilities = new List<string>(this.Abilities);

        return clone;
    }
}

public class Elf : Enemy
{
    public Elf()
    {
        Name = "Elf";
        Health = 70;
        Weapon = new Weapon { Name = "Bow", Damage = 18 };
        Abilities.Add("Stealth");
    }

    public override Enemy Clone()
    {

        Elf clone = (Elf)this.MemberwiseClone();
        clone.Weapon = this.Weapon.Clone();
        clone.Abilities = new List<string>(this.Abilities);

        return clone;
    }
}

