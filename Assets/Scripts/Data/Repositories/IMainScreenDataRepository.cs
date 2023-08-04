using System.Collections.Generic;


namespace CalculatorApp.Data.Repositories
{
    public interface IMainScreenDataRepository
    {
        void SaveInputState(InputStateData inputState);
        InputStateData GetInputState();
        void SaveHistoryEntry(HistoryData entry);
        List<HistoryData> GetHistory();
    }
}
