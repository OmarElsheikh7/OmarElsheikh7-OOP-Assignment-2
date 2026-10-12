using System.Diagnostics;
using PatternsLab.Problems.Builder;
using PatternsLab.Problems.Prototype;
using PatternsLab.Problems.Singleton;

Console.WriteLine("=== SINGLETON: AFTER ===\n");
var db = new DatabaseService();
var ui = new UiService();
Console.WriteLine();

db.Config.Theme = "Dark";
Console.WriteLine("Admin changed theme to Dark.");

ui.Render();
Console.WriteLine($"\nSame config object? {ReferenceEquals(db.Config, ui.Config)}");
Console.WriteLine($"Times config was loaded from disk: {AppConfig.LoadCount}");


Console.WriteLine("\n=== PROTOTYPE: AFTER ===\n");
var registry = new EnemyRegistry();

Console.WriteLine("Setting up the Registry...");
registry.Register("BasicOrc", new Orc());
registry.Register("BasicElf", new Elf());

var sw = Stopwatch.StartNew();
var army = new List<Enemy>();

for (int i = 1; i <= 5; i++)
{
    var clone = registry.CreateEnemy("BasicOrc");
    clone.Name = $"Orc-{i}";
    army.Add(clone);
}
Console.WriteLine($"Created 5 orcs in {sw.ElapsedMilliseconds} ms (Bypassed the 500ms delay!)\n");

Enemy original = registry.CreateEnemy("BasicOrc");
original.Name = "Boss Orc";
Enemy copy = original.Clone();

Console.WriteLine($"Original model id: {original.ModelId}");
Console.WriteLine($"Copy model id:     {copy.ModelId} (Shares the heavy 3D model)");

copy.Weapon.Damage = 999;
Console.WriteLine($"\nWe changed the COPY's weapon damage to 999.");
Console.WriteLine($"Original's weapon damage is still: {original.Weapon.Damage} (Independent objects!)");

copy.Abilities.Add("Fire Breath");
Console.WriteLine($"Original abilities: {string.Join(", ", original.Abilities)} (Remains unchanged)");


Console.WriteLine("\n=== BUILDER: AFTER ===\n");

Console.WriteLine(RegistrationCallSites.CreateLiveStudent());
Console.WriteLine(RegistrationCallSites.CreateVideosOnly());