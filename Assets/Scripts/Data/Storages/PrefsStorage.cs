using UnityEngine;


namespace CalculatorApp.Data.Storage
{
    public class PrefsStorage : IKeyValueStorage
    {
        public void Set(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        }


        public string Get(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }
    }
}
