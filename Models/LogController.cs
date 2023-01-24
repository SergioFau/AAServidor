using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;

namespace Classes;

public class LogController
{
    public static void WriteLog(string message)
    {
        StringBuilder sb = new StringBuilder();
        message = DateTime.Now.ToString() + "->" + message;
        sb.Append(message);
        try
        {           
        sb.Append("\n"); 
        //var reader = new StreamReader($@"{Path.GetFullPath(Directory.GetCurrentDirectory())}/Recursos/Coches.json");
        //File.AppendAllText("C:\\Users\\sergiofau\\Desktop\\CosasSergio\\ClaseServidor\\RutaLog\\NombreLog.txt", sb.ToString());
        File.AppendAllText($@"{Path.GetFullPath(Directory.GetCurrentDirectory())}/RutaLog/NombreLog.txt", sb.ToString());
        sb.Append("\n");
        sb.Clear();
        }
        catch (Exception ex)
        {
            throw ex;
        }       
    }
    public static void ReadLog()
    {
         String line;
            try
            {
                StreamReader sr = new StreamReader($@"{Path.GetFullPath(Directory.GetCurrentDirectory())}/RutaLog/NombreLog.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch(Exception e)
            {
            LogController.WriteLog("Ha habido un error: " + e.Message);
            }
    }
}    