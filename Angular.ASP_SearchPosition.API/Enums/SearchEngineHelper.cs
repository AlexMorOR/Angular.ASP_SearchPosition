namespace Angular.ASP_SearchPosition.Enums
{
    public enum SearchEngine
    {
        Google,
        Bing,
        Yahoo,
        UKYahoo,
    }

    public static class SearchEngineHelper
    {
        public static SearchEngine[] GetAllEngines()
        {
            return Enum.GetValues<SearchEngine>();
        }

        public static string GetEngineName(SearchEngine engine)
        {
            return engine switch
            {
                SearchEngine.UKYahoo => "Yahoo UK",
                _ => engine.ToString(),
            };
        }
    }
}
