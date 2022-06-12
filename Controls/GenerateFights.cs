using BecomeSifu.FightObjects;
using BecomeSifu.Logging;
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
            try
            {
                List<Type> types = GetFightTypes();
                CreateFights(types);
                LogIt.Write($"Populated Fights Observable list");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private List<Type> GetFightTypes()
        {
            try
            {
                return Assembly.GetExecutingAssembly().GetTypes()
                        .Where(t => t.Name != "IFights" && t.Name != "AllFights" && t.Namespace == typeof(IFights).Namespace && t.BaseType.Name == "AllFights")
                        .ToList();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private void CreateFights(List<Type> types)
        {
            try
            {
                foreach (Type type in types)
                {
                    Dojos.AddFight((IFights)Activator.CreateInstance(type.Assembly.ToString(), type.FullName).Unwrap());
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
