using System;
using System.IO;
using System.Text;

namespace Programming005.Library.DesktopUI.Utils
{
    public static class CsvExporter
    {
        private const string _filePath = "D:\\";

        public static string Export(object[] objects, string filename)
        {
            string fullPath = _filePath + filename;

            Type type = objects[0].GetType();

            foreach (var item in objects)
            {
                if(item.GetType().FullName != type.FullName)
                {
                    throw new InvalidOperationException("Unable to export due to multiple type objects");
                }
            }

            StringBuilder builder = new StringBuilder();

            var properties = type.GetProperties();

            bool isFirst = true;
            foreach (var prop in properties)
            {
                if (!isFirst)
                    builder.Append(",");

                builder.Append(prop.Name);

                isFirst = false;
            }

            builder.AppendLine();

            foreach (var obj in objects)
            {
                bool isFirst2 = true; 
                foreach (var prop in properties)
                {
                    if (!isFirst2)
                        builder.Append(",");

                    builder.Append(prop.GetValue(obj));

                    isFirst2 = false;
                }

                builder.AppendLine();
            }

            File.WriteAllText($"{fullPath}.csv", builder.ToString());

            return $"{fullPath}.csv";
        }
    }
}
