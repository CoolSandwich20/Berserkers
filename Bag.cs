namespace FirstLesson;

public struct Bag : IRandomProvider
{
    public uint Scalar { get; set; }
    public uint MaxNumber { get; set; }
    public int Modifier { get; set; }
    uint _minNumber;
    private List<int> _baggedList { get; set; } = new();

    public Bag(uint scalar, uint min, uint maxNumber, int modifier)
    {
        _minNumber = min;
        MaxNumber = maxNumber;
        Scalar = scalar;
        Modifier = modifier;
        FillTheBag();
    }

    void FillTheBag()
    {
        _baggedList = Enumerable.Range((int)_minNumber, (int)MaxNumber).ToList();
    }

    public int GetRandomNumber()
    {
        if (_baggedList.Count() == 0)
        {
            FillTheBag();
        }

        int tempRandom = Random.Shared.Next(0, _baggedList.Count());
        int result = _baggedList[tempRandom];
        _baggedList.RemoveAt(tempRandom);
        return result + Modifier;
    }

    public override string ToString()
    {
        string modifierSymb = "";
        if (Modifier >= 0) modifierSymb = "+";
        return $"Scalarus- {Scalar} Minimus - {_minNumber} Maximus- {MaxNumber} + Modifus {modifierSymb}{Modifier}";
    }
}