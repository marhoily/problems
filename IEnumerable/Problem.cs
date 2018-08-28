var list = new List<int> { 1, 2, 3 };

foreach (var item in list)
{
	Console.WriteLine(item);
}

var en = list.GetEnumerator();
while (en.MoveNext())
{
	var item = en.Current;
    Console.WriteLine(item);
}

