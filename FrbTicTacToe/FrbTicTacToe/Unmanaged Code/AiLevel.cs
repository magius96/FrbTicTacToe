namespace FrbTicTacToe
{
    public enum AiLevel
    {
        Easy, // Random placements
        NormalOffensive, // Random with priority towards completion
        NormalDefensive, // Rnadom with priority towards blocking
        Hard // Calculated placements
    }
}