using System;
using System.Collections.Generic;
using System.IO;

namespace Bowling
{
    public class FileProcess
    {
        public bool FileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("filename");
            }
            return File.Exists(fileName);
        }
        public int GetFirstRoll(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("filename");
            }
            File.OpenRead(fileName);
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader streamReader = new StreamReader(fileName);
                //Read the first line of text
                line = streamReader.ReadLine();
                return Convert.ToInt16(line);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return -2;
            }
        }
        public List<int> GetRolls(string fileName)
        {
            File.OpenRead(fileName);
            List<int> Rolls = new List<int>();
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader streamReader = new StreamReader(fileName);

                //Read the first line of text
                line = streamReader.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Rolls.Add(Convert.ToInt16(line));
                    //Console.WriteLine(line);
                    //Read the next line
                    line = streamReader.ReadLine();
                }

                //close the file
                streamReader.Close();
                return Rolls;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }
    }
}
