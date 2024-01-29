namespace FirstLesson
{
    public interface IRandomProvider
    {
        uint Scalar { get; set; }
        uint MaxNumber { get; set; }
        int Modifier { get; set; }
        int GetRandomNumber();

        void ChangeModifier(int change)
        {
            Modifier = change;
        }
    }
}