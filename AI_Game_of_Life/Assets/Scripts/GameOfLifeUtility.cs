public static class GameOfLifeUtility
{
    public static bool DecideNextState(bool currentCellLivingState, int aliveNeighbourCount)
    {
        bool result = false;

        // DIY: CELL RULES
        if (currentCellLivingState == true && aliveNeighbourCount <= 1) //solitude
        {
            result = false;
        }
        else if (currentCellLivingState == true && aliveNeighbourCount >= 4) //overpopulation
        {
            result = false;
        }
        else if (currentCellLivingState == true && aliveNeighbourCount >= 2 && aliveNeighbourCount <= 3) //survives
        {
            result = true;
        }
        else if (currentCellLivingState == false && aliveNeighbourCount == 3)
        {
            result = true;
        }

        return result;
    }
}
