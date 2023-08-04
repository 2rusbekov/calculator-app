using CalculatorApp.Data.Storage;
using System;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;


namespace CalculatorApp.Data.Repositories
{
    public class MainScreenDataRepository : IMainScreenDataRepository
    {
        //TODO: Use DI
        private IKeyValueStorage storage;

        private const string InputStateKey = "main_screen.input_state";
        private const string HistoryKey = "main_screen.history";


        public MainScreenDataRepository(IKeyValueStorage storage)
        {
            this.storage = storage;
        }


        public void SaveInputState(InputStateData inputState)
        {
            storage.Set(InputStateKey, inputState.inputValue);
        }


        public InputStateData GetInputState()
        {
            return new InputStateData()
            {
                inputValue = storage.Get(InputStateKey)
            };
        }


        public void SaveHistoryEntry(HistoryData entry)
        {
            List<HistoryData> history = GetHistory() ?? new List<HistoryData>();
            history.Add(entry);
            string json = JsonConvert.SerializeObject(history);
            storage.Set(HistoryKey, json);
        }


        public List<HistoryData> GetHistory()
        {
            string json = storage.Get(HistoryKey);
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            try
            {
                return JsonConvert.DeserializeObject<List<HistoryData>>(json);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }
    }
}
