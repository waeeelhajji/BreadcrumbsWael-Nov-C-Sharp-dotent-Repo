class Table : Furniture,IDecorate
{
    public int numberOfItems{get;set;}
    public List<String> AllItems {get;set;}
    public Table(string m, string c , double p, bool o):base(m,c,p,o)
    {
        numberOfItems = 0;
        AllItems = new List<string>();

    }

    public void AddItem(string Item)
    {
        AllItems.Add(Item);
        numberOfItems++;
        Console.Write($"Placed a {Item} on the Table");
        Console.Write($"Numbers Of {numberOfItems} on the Table");


    }
    public void ShowItems()
    {
        foreach(string item in AllItems)
        {
            Console.WriteLine(item);
        }
    }
}