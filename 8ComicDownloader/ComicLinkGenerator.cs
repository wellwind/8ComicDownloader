using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace _8ComicDownloader
{
    /// <summary>
    /// reference: http://blog.wetprogrammer.net/?p=152
    /// </summary>
    public class ComicLinkGenerator
    {
        private const int f = 50;

        public string ItemId { get; set; }
        public string Code { get; set; }

        public Dictionary<string, Comic> DoParse()
        {
            Dictionary<string, Comic> result = new Dictionary<string, Comic>();
            var subKeys = Code.SplitInParts(f);
            foreach (string key in subKeys)
            {
                Debug.WriteLine(key);

                string vol = getOnlyDigit(key.Substring(0, 4));
                string pages = getOnlyDigit(key.Substring(7, 3));

                Comic c = new Comic();
                for (int i = 1; i <= Convert.ToInt32(pages); ++i)
                {
                    string url = urlCreator(key, i);
                    // Debug.WriteLine(url);
                    c.Urls.Add(url);
                }

                result.Add(Convert.ToInt32(vol).ToString("0000"), c);
            }

            return result;
        }

        private string getOnlyDigit(string key)
        {
            Regex regexObj = new Regex(@"[^\d]");
            string vol = regexObj.Replace(key, "");
            return vol;
        }

        private string urlCreator(string subKey, int page)
        {
            string vol = getOnlyDigit(subKey.Substring(0, 4));
            string sid = getOnlyDigit(subKey.Substring(4, 2));
            string did = getOnlyDigit(subKey.Substring(6, 1));
            string code = subKey.Substring(10);
            string hash = subKey.Substring(getHash(page) + 10, 3);

            return "http://img" + sid + ".8comic.com/" + did + "/" + this.ItemId+ "/" + vol + "/" + page.ToString("000") + "_" + hash + ".jpg";
        }

        private int getHash(int n)
        {
            return (((n - 1) / 10) % 10) + (((n - 1) % 10) * 3);
        }
    }

    public class Comic
    {
        public List<string> Urls { get; set; }

        public Comic()
        {
            Urls = new List<string>();
        }
    }

    static class StringExtensions
    {

        public static IEnumerable<string> SplitInParts(this string s, int partLength)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

    }
}
