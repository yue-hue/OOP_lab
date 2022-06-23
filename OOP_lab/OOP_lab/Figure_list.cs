using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Fgr;

namespace OOP_lab
{
    internal class Figure_list
    {
        private Dictionary<string, Type> figure_list = new Dictionary<string, Type>();

        public void add_figure(string name, Type type)
        {
            figure_list.Add(name, type);
        }

        public Figure create_figure(string name)
        {
            Type type;
            if (this.figure_list.TryGetValue(name, out type))
            {
                ConstructorInfo info = type.GetConstructor(Type.EmptyTypes);
                return info.Invoke(new object[] { }) as Figure;
            }
            else
            {
                throw new KeyNotFoundException($"{ name } is not a figure type");
            }
        }

        public List<string> figures
        {
            get
            {
                return figure_list.Keys.ToList();
            }
        }

        public void refresh_plugins()
        {
            string pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugin");

            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
            if (!pluginDirectory.Exists)
            {
                pluginDirectory.Create();
            }

            string[] pluginFiles = Directory.GetFiles(pluginPath, "*.dll");

            foreach (string file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);
                var types = asm.GetTypes().Where(i => i.BaseType.FullName == typeof(Figure).FullName);

                foreach (Type type in types)
                {
                    add_figure((type.GetConstructor(Type.EmptyTypes).Invoke(new object[] { }) as Figure).figure_name, type);
                }
            }
        }
    }
}
