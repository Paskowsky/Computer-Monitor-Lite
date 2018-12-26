using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace MonitorLiteCommon
{
    public class Report
    {
        public const byte REPORT_TEXT = 0;
        public const byte REPORT_IMAGE = 1;

        public string Title { get; private set; }
        public DateTime Date { get; private set; }
        public byte ContentType { get; private set; }
        public byte[] Content { get; private set; }
        
        public string ToText()
        {
            if (ContentType != REPORT_TEXT)
                throw new Exception();

            return Encoding.UTF8.GetString(Content);
        }

        public Image ToImage()
        {
            if (ContentType != REPORT_IMAGE)
                throw new Exception();

            using(MemoryStream ms = new MemoryStream(Content))
            {
                return Image.FromStream(ms, false, true);
            }
        }
                
        private Report(byte contentType)
        {
            ContentType = contentType;
            Title = "";
            Date = DateTime.Now;

        }

        public static Report CreateTextReport(string title,string text)
        {
            Report r = new Report(0);
            r.Title = title;
            r.Content = Encoding.UTF8.GetBytes(text);
            return r;
        }

        public static Report CreateImageReport(string title,Image image)
        {
            Report r = new Report(1);
            r.Title = title;
            using(MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                r.Content = ms.ToArray();
            }
            return r;
        }

        public static byte[] SerializeReport(Report r)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                using(BinaryWriter bw = new BinaryWriter(ms,Encoding.UTF8))
                {
                    bw.Write(r.ContentType);
                    bw.Write(r.Date.ToBinary());
                    bw.Write(r.Title);
                   
                    bw.Write(r.Content.Length);
                    bw.Write(r.Content);
                }
                return ms.ToArray();
            }
        }

        public static Report DeserializeReport(byte[] data)
        {
            using(MemoryStream ms = new MemoryStream(data))
            {
                using(BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
                {
                    Report r = new Report(br.ReadByte());
                    r.Date = DateTime.FromBinary(br.ReadInt64());
                    r.Title = br.ReadString();
                    r.Content = br.ReadBytes(br.ReadInt32());
                    return r;
                }
            }
        }

    }
}
