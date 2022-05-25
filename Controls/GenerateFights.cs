using BecomeSifu.FightObjects;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BecomeSifu.Controls
{
    public class GenerateFights
    {
       
        public GenerateFights()
        {
            List<Type> types = GetFightTypes();
            CreateFights(types);
        }

        private List<Type> GetFightTypes()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Name != "IFights" && t.Name != "AllFights" && t.Namespace == typeof(IFights).Namespace)
                .ToList();
        }

        private void CreateFights(List<Type> types)
        {
            foreach (Type type in types)
            {
                Dojos.AddFight((IFights)Activator.CreateInstance(type.Assembly.ToString(), type.FullName).Unwrap());
            }
        }
    }
}
