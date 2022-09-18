using System;
using System.IO;
using System.Text;

namespace Soccer365
{
    internal class Setting
    {
        static volatile Setting Class;
        static object SyncObject = new object();
        public static Setting GetInstance
        {
            get
            {
                if (Class == null)
                    lock (SyncObject)
                    {
                        if (Class == null)
                            Class = new Setting();
                    }
                return Class;
            }
        }
        internal void CheckingFileAvailability(string cmB_years_game)
        {
            if (!Directory.Exists($"C:\\Soccer\\"))
            {
                Directory.CreateDirectory($"C:\\Soccer\\");
            }
        }

        internal string WordsDistinct(string src)
        {
            var split = src.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();
            var buffer = new int[split.Length];
            var index = 0;

            foreach (var item in split)
            {
                var word = "";
                var puctuationIndex = FirstIndexOfPunctuation(item);
                if (puctuationIndex != -1)
                {
                    word = item.Substring(0, puctuationIndex);
                }
                else
                {
                    word = item;
                }

                var hash = word.ToLower().GetHashCode();
                if (Array.IndexOf(buffer, hash) == -1)
                {
                    buffer[index++] = hash;
                    sb.Append(item);
                    sb.Append(" ");
                }

            }

            return sb.ToString().TrimEnd();
        }

        int FirstIndexOfPunctuation(string src)
        {
            for (int i = 0; i < src.Length; i++)
            {
                if (char.IsPunctuation(src[i]))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
