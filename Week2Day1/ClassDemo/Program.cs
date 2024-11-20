
Chair Chair = new Chair("Wood","Brown",5.00,false);
Chair TA = new Chair("Cupper","Iron",8.45,true);

Console.WriteLine(Chair._materials);
// Chair.materials = "Metal";
Console.WriteLine(Chair._materials);
// Console.WriteLine(TA.materials);

Chair.ChangeColor("Pink");

Furniture Stool = new Chair("Metal","gray",70.45,false,4,false);

Console.WriteLine(Stool._materials);
Stool.ChangeColor("Black");

//? Polymorphism
List<Furniture> AllFurniture = new List<Furniture>();
AllFurniture.Add(Chair);
AllFurniture.Add(TA);
AllFurniture.Add(Stool);

Table Table = new Table("Wood","Brown",5.00,false);
Table.AddItem("H");
Table.AddItem("Ha");
Table.AddItem("Haj");
Table.AddItem("Hajj");
Table.AddItem("Hajji");
Table.ShowItems();