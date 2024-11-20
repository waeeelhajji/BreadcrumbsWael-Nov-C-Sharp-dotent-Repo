interface IDecorate 
{
    //? Add a field (auto*implemented property)
    int numberOfItems {get;set;}
    List<string> AllItems{get;set;}

    //! Add Method
    void AddItem(string Item);
    void ShowItems();
}