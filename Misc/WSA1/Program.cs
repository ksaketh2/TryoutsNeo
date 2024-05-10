// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<List<int>> d2 = new List<List<int>> { new List<int> { 1,2,3 }, new List<int> { 4,5,6 } };
List<int> d1 = new List<int>();

int i = 0;
int totalItems = d2.SelectMany(x => x).Count();
while (totalItems > 0)
{
    foreach (List<int> list in d2)
    {
        d1.Add(list[i]);
        totalItems--;
    }

    i++;
}

Console.WriteLine(string.Join(",", d1));
Console.ReadKey();