using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    internal class Stream {
        // Filenames
        internal static readonly string statusFile = "status.txt"; // to remember status of pets and balls
        internal static readonly string logFile = "log.txt"; // a log of what happens in the program
        // References
        internal Petowner petowner = new Petowner();

        internal static void WriteToFile(string fileName, string text) {
            try {
                using(var streamWriter = new StreamWriter(fileName, true)) {
                    streamWriter.WriteLine($"[{DateTime.Now}]: {text}");
                    streamWriter.Close();
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        internal static List<string> ReadFromFile(string _fileName) {
            List<string> linesFromFile = new List<string>();
            try {
                using(StreamReader streamReader = new StreamReader(_fileName)) {
                    while(true) {
                        string singleLine = streamReader.ReadLine();
                        if(singleLine != null) {
                            if(_fileName == statusFile) {
                                UpdateStatus(singleLine);
                            }
                            else {
                                linesFromFile.Add(singleLine);
                                singleLine = streamReader.ReadLine();
                                /* * * * * * * * * * * * * * * * * * * * *\
                                 *  only reads in the file in case it's  *
                                 *  going to be used for something else  *
                                 *  the lines are saved in linesFromFile *
                                \* * * * * * * * * * * * * * * * * * * * */
                            }
                        }
                        else {
                            break;
                        }
                    }
                    streamReader.Close();
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            return linesFromFile;
        }

        private static void UpdateStatus(string line) {
            Stream nonStatic = new Stream();
            if(line.Contains("[Pet]")) {
                int index = 0;
                for(int i = 5; i < 9; i++) { // Can find up to 3 digit integers
                    if(char.IsDigit(line[i])) { // Finds the index of a pet.
                        index += i;
                    }
                }
                List<string> petData = line.Split(',').ToList();
                petData.RemoveAt(0);
                nonStatic.GetPet(index, petData);
                foreach(string foo in petData) {
                }
            }

        }

        private void GetPet(int index, List<string> petData) {
            List<Animal> pets = petowner.GetPets;
            pets[index].Name = Convert.ToString(petData[0]);
            pets[index].Age = Convert.ToInt32(petData[1]);
            pets[index].Breed = Convert.ToString(petData[2]);
            pets[index].Hungry = Convert.ToBoolean(petData[3]);
            pets[index].FavFood = Convert.ToString(petData[4]);
        }

    }
}
