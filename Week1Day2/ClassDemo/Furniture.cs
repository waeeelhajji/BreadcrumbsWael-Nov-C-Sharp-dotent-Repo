class Furniture 
{
    //~ Fields describe our object
    private string materials;
    public string _materials {get{ return materials;}}
    public double price;
    public string color;
    public bool outdoor;
    //~Constructor
    public Furniture(string m, string c, double p, bool o)
    {
        materials = m;
        price = p;
        color = c;
        outdoor = o;
    }
    Furniture(string m, string c, double p)
    {
        materials = m;
        price = p;
        color = c;
        outdoor = true;
    }

    
}