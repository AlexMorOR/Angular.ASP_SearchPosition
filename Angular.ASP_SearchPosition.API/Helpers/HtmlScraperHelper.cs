namespace Angular.ASP_SearchPosition.Helpers
{
    public static class HtmlScraperHelper
    {
        public static int[] FindUrlPositionsByTags(string openTag, string closeTag, string url, string html)
        {
            int currPos = 0;
            // first cite tag
            int indexOfOpenTag = html.IndexOf(openTag);
            if(indexOfOpenTag == -1)
                return new int[0];

            int indexOfCloseTag = html.IndexOf(closeTag, indexOfOpenTag);

            List<int> positions = new List<int>(5);

            while (indexOfOpenTag != -1)
            {
                if (html.Substring(indexOfOpenTag, indexOfCloseTag - indexOfOpenTag).Contains(url))
                {
                    positions.Add(currPos);
                }

                // get new cite tag
                indexOfOpenTag = html.IndexOf(openTag, indexOfCloseTag);
                if (indexOfOpenTag == -1)
                    break;

                indexOfCloseTag = html.IndexOf(closeTag, indexOfOpenTag);
                // check next site
                currPos++;
            }

            return positions.ToArray();
        }
    }
}
