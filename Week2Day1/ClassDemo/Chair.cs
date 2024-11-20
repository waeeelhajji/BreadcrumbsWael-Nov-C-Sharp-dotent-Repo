class Chair : Furniture
{
    //~Methods
    int numLegs;
    bool hasArms;

    public Chair(string m, string c, double p, bool o) : base(m, c, p, o)
    {
    }

    //~Constructor
    public Chair(string m, string c , double p, bool o,int nl,bool ha): base(m,c,p,o)
    {
        numLegs = nl;
        hasArms = ha;

    }
    //~ Overriding Method
    public override void ChangeColor(string newColor)
    {
        Console.WriteLine($"Change our Chair from {color} to {newColor}");
        color = newColor;
    }
}