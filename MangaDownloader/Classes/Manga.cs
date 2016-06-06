using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangaDownloader.Classes
{
    public class Manga : HttpClient
    {
        private string _name;
        private Dictionary<string, string> _chapters;
        private int _from;
        private int _to;
        private int _count;
        private AutoResetEvent _complete;
        public event LogUpdateDelegate LogUpdate;
        public delegate void LogUpdateDelegate(string value);
        public event PercentUpdateDelegate PercentUpdate;
        public delegate void PercentUpdateDelegate(double value);

        public Manga(string url, int chapterFrom, int chapterTo)
        {
            _chapters = new Dictionary<string, string>();
            _from = chapterFrom;
            _to = chapterTo;
            _complete = new AutoResetEvent(false);

            string html = get(url);

            _name = Regex.Match(html, "class=\\\"aname\\\">([^\\<]+)\\<").Groups[1].Value;
            
            int firstIdx = html.IndexOf("Chapter Name");
            int secIdx = html.IndexOf("Network");
            
            html = html.Substring(firstIdx, secIdx - firstIdx);

            foreach (Match m in Regex.Matches(html, "a href=\\\"([^\\\"]+)\\\"\\>([^\\<]+)\\<\\/a\\>"))
            {
                int chapter = int.Parse(m.Groups[2].Value.Substring(_name.Length + 1));

                if ((_to == 0 && chapter >= _from) || (chapter >= _from && chapter <= _to))
                    _chapters.Add(m.Groups[2].Value, m.Groups[1].Value);
            }
        }

        public void download()
        {
            _count = _chapters.Count;
            _complete.Reset();

            foreach (string key in _chapters.Keys)
                ThreadPool.QueueUserWorkItem(downloadChapter, key);

            _complete.WaitOne();
        }

        private void downloadChapter(object stateInfo)
        {
            string html = string.Empty;
            string chapterName = stateInfo.ToString();
            string chapterUrl = string.Format("http://www.mangareader.net{0}", _chapters[chapterName]);
            string path = string.Format(@"{0}\{1}\{2}\", Application.StartupPath, _name, chapterName);

            createFolder(path);
            callLog(string.Format("Starting to download {0}.", chapterName));
            
            html = get(chapterUrl);
            
            int pages = int.Parse(Regex.Match(html, "select\\> of (\\d+)\\<").Groups[1].Value);
            string imageLink = Regex.Match(html, "src=\\\"([^\\\"]+)\\\" alt=").Groups[1].Value;

            callLog(string.Format("Downloading page 1 of {0}.", chapterName));
            downloadImage(string.Format("{0}Page 1{1}", path, Path.GetExtension(imageLink)), imageLink);

            for (int i = 2; i <= pages; i++)
            {
                html = get(string.Format("{0}/{1}", chapterUrl, i));

                imageLink = Regex.Match(html, "src=\\\"([^\\\"]+)\\\" alt=").Groups[1].Value;

                callLog(string.Format("Downloading page {0} of {1}.", i, chapterName));
                downloadImage(string.Format("{0}Page {1}{2}", path, i, Path.GetExtension(imageLink)), imageLink);
            }

            callLog(string.Format("Finished downloading {0}.", chapterName));

            if (Interlocked.Decrement(ref _count) == 0)
                _complete.Set();
        }

        private void downloadImage(string path, string imageLink)
        {
            getImage(imageLink).Save(path);
        }

        private void callLog(string value)
        {
            if (LogUpdate != null)
                LogUpdate(value);
        }

        private void createFolder(string path)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);

            Directory.CreateDirectory(path);
        }
    }
}
