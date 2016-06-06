﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MangaDownloader.Classes
{
    public abstract class HttpClient
    {
        protected CookieContainer _cookies;

        public HttpClient()
        {
            _cookies = new CookieContainer();
            
            AllowAutoRedirect = true;
            AutomaticDecompression = DecompressionMethods.None;
            ContentType = "application/x-www-form-urlencoded";
            UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.112 Safari/537.36";
            Proxy = null;
        }

        protected string get(string link, string referer = null, params KeyValuePair<string, string>[] headers)
        {
            bool success = false;

            while (!success)
            {
                try
                {
                    lock (_cookies)
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
                        request.KeepAlive = true;
                        request.AllowAutoRedirect = AllowAutoRedirect;
                        request.AutomaticDecompression = AutomaticDecompression;
                        request.CookieContainer = _cookies;
                        request.ContentType = ContentType;
                        request.UserAgent = UserAgent;
                        request.Proxy = Proxy;

                        if (!string.IsNullOrEmpty(referer))
                            request.Referer = referer;

                        if (headers != null)
                        {
                            foreach (KeyValuePair<string, string> item in headers)
                            {
                                if (item.Key.ToLower() == "host")
                                    request.Host = item.Value;
                                else if (item.Key.ToLower() == "accept")
                                    request.Accept = item.Value;
                                else
                                    request.Headers[item.Key] = item.Value;
                            }
                        }

                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        {
                            _cookies.Add(response.Cookies);
                            success = true;
                            return new StreamReader(response.GetResponseStream()).ReadToEnd();
                        }
                    }
                }
                catch { }
            }

            return null;
        }

        protected string post(string link, string postData, string referer = null, params KeyValuePair<string, string>[] headers)
        {
            bool success = false;

            while (!success)
            {
                try
                {
                    lock (_cookies)
                    {
                        Byte[] buffer = Encoding.Default.GetBytes(postData);

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
                        request.Method = "POST";
                        request.KeepAlive = true;
                        request.AllowAutoRedirect = AllowAutoRedirect;
                        request.AutomaticDecompression = AutomaticDecompression;
                        request.CookieContainer = _cookies;
                        request.ContentType = ContentType;
                        request.UserAgent = UserAgent;
                        request.ContentLength = buffer.Length;
                        request.Proxy = Proxy;

                        if (!string.IsNullOrEmpty(referer))
                            request.Referer = referer;

                        if (headers != null)
                        {
                            foreach (KeyValuePair<string, string> item in headers)
                            {
                                if (item.Key.ToLower() == "host")
                                    request.Host = item.Value;
                                else if (item.Key.ToLower() == "accept")
                                    request.Accept = item.Value;
                                else
                                    request.Headers[item.Key] = item.Value;
                            }
                        }

                        using (Stream s = request.GetRequestStream())
                        {
                            s.Write(buffer, 0, buffer.Length);
                            s.Close();
                        }

                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        {
                            _cookies.Add(response.Cookies);
                            success = true;
                            return new StreamReader(response.GetResponseStream()).ReadToEnd();
                        }
                    }
                }
                catch { }
            }

            return null;
        }

        protected Image getImage(string link, string referer = null, params KeyValuePair<string, string>[] headers)
        {
            bool success = false;

            while (!success)
            {
                try
                {
                    lock (_cookies)
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
                        request.KeepAlive = true;
                        request.AllowAutoRedirect = AllowAutoRedirect;
                        request.AutomaticDecompression = AutomaticDecompression;
                        request.CookieContainer = _cookies;
                        request.ContentType = ContentType;
                        request.UserAgent = UserAgent;
                        request.Proxy = Proxy;

                        if (!string.IsNullOrEmpty(referer))
                            request.Referer = referer;

                        if (headers != null)
                        {
                            foreach (KeyValuePair<string, string> item in headers)
                            {
                                if (item.Key.ToLower() == "host")
                                    request.Host = item.Value;
                                else if (item.Key.ToLower() == "accept")
                                    request.Accept = item.Value;
                                else
                                    request.Headers[item.Key] = item.Value;
                            }
                        }

                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        {
                            _cookies.Add(response.Cookies);

                            BinaryReader br = new BinaryReader(response.GetResponseStream());
                            MemoryStream m = new MemoryStream();

                            byte[] imageBuffer = br.ReadBytes(1024);

                            while (imageBuffer.Length > 0)
                            {
                                m.Write(imageBuffer, 0, imageBuffer.Length);
                                imageBuffer = br.ReadBytes(1024);
                            }

                            success = true;
                            return Image.FromStream(m);
                        }
                    }
                }
                catch { }
            }

            return null;
        }

        public bool AllowAutoRedirect { get; set; }

        public DecompressionMethods AutomaticDecompression { get; set; }

        public string ContentType { get; set; }

        public string UserAgent { get; set; }

        public IWebProxy Proxy { get; set; }
    }
}
