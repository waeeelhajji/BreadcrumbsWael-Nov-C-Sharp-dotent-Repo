
abstract class Furniture 
{
    //~ Fields describe our object
    private string materials;
    public string _materials {get{ return materials;}}
    public double price;
    protected string color;
    public string _color {get{ return color;}}
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
    //! Methods - what can our object do 
    //? Paint our furniture
    //~ Overriding Method
    public virtual void ChangeColor(string newColor)
    {
        Console.WriteLine($"Change our furniture from {color} to {newColor}");
        color = newColor;
    }

}