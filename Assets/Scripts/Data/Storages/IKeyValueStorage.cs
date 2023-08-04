namespace CalculatorApp.Data.Storage
{
    public interface IKeyValueStorage
    {
        void Set(string key, string value);
        string Get(string key, string defaultValue = "");
    }
}
