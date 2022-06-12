using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace BecomeSifu.Logging
{
    public class LogIt
    {
        private static readonly string LogPath = string.Format(@$"c:\Program Files (x86)\BecomeSifu\log\{DateTime.Today:yyyyMMdd}BecomeSifu.txt");
        private static bool FromOverload;
        private static bool Written;
        
        public static void Write(string message)
        {
            bool cont = true;
            string newMessage;
            if (!FromOverload)
            {
                StackFrame stackFrame = new StackFrame(1);
                MethodBase method = stackFrame.GetMethod();
                string name = method.DeclaringType.Name + "." + method.Name;

                newMessage = $"{DateTime.Now:O} :: {name} -- {message}\n";
            }
            else
            {
                newMessage = message;
                FromOverload = false;
            }
            do
            {
                try
                {
                    File.AppendAllText(LogPath, newMessage);
                    cont = false;
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(LogPath));
                }

                catch (FileNotFoundException)
                {
                    File.Create(LogPath);
                }
                catch (IOException) when (cont)
                {
                    Thread.Sleep(2);
                }

                catch (Exception)
                {
                    throw;
                }
            } while (cont);

        }
        public static void Write()
        {
            StackFrame stackFrame = new StackFrame(1);
            MethodBase method = stackFrame.GetMethod();
            string name = method.DeclaringType.Name + "." + method.Name;
            FromOverload = true;
            Write($"{DateTime.Now:O} :: {name}\n");
        }
    }
}
