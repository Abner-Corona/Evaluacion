using System.Runtime.Intrinsics.X86;

static string[] UniqueNames(string[] names1, string[] names2) => names1.Union(names2).ToArray();

string[] names1 = new string[] { "Ava", "Emma", "Olivia"};
string[] names2 = new string[] { "Olivia", "Sophia", "Emma"};
Console.WriteLine(string.Join(", ", UniqueNames(names1, names2)));  //should print Ava, Emma, Olivia, Sophia
