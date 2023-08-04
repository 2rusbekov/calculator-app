using System;


namespace CalculatorApp.Data
{
    [Serializable]
    public class InputStateData
    {
        public string inputValue;
    }

    
    [Serializable]
    public class HistoryData
    {
        public string request;
        public string answer;
    }
}
