using MoreLinq;
using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AoC23
{
    internal class Program
    {
        record struct Point(int X, int Y);

        static void Main(string[] args)
        {
            string selection = string.Empty;
            while (selection.ToLower() != "e")
            {
                printMenu();

                switch (selection)
                {
                    case "1a":
                        day1a();
                        break;
                    case "1b":
                        day1b();
                        break;
                    case "2a":
                        day2a();
                        break;
                    case "2b":
                        day2b();
                        break;
                    case "3a":
                        day3a();
                        break;
                    case "3b":
                        day3b();
                        break;
                    case "4a":
                        day4a();
                        break;
                    case "4b":
                        day4b();
                        break;
                    case "5a":
                        day5a();
                        break;
                    case "5b":
                        day5b();
                        break;
                    case "6a":
                        day6a();
                        break;
                    case "6b":
                        day6b();
                        break;
                    case "7a":
                        day7a();
                        break;
                    case "7b":
                        day7b();
                        break;
                    case "8a":
                        day8a();
                        break;
                    case "8b":
                        day8b();
                        break;
                    case "9a":
                        day9a();
                        break;
                    case "9b":
                        day9b();
                        break;
                    case "10a":
                        day10a();
                        break;
                    case "10b":
                        day10b();
                        break;
                    case "11a":
                        day11a();
                        break;
                    case "11b":
                        day11b();
                        break;
                    case "12a":
                        day12a();
                        break;
                    case "12b":
                        day12b();
                        break;
                    case "13a":
                        day13a();
                        break;
                    case "13b":
                        day13b();
                        break;
                    case "14a":
                        day14a();
                        break;
                    case "14b":
                        day14b();
                        break;
                    case "15a":
                        day15a();
                        break;
                    case "15b":
                        day15b();
                        break;
                    case "16a":
                        day16a();
                        break;
                    case "16b":
                        day16b();
                        break;
                    case "17a":
                        day17a();
                        break;
                    case "17b":
                        day17b();
                        break;
                    case "18a":
                        day18a();
                        break;
                    case "18b":
                        day18b();
                        break;
                    case "19a":
                        day19a();
                        break;
                    case "19b":
                        day19b();
                        break;
                    case "20a":
                        day20a();
                        break;
                    case "20b":
                        day20b();
                        break;
                    case "21a":
                        day21a();
                        break;
                    case "21b":
                        day21b();
                        break;
                    case "22a":
                        day22a();
                        break;
                    case "22b":
                        day22b();
                        break;
                    case "23a":
                        day23a();
                        break;
                    case "23b":
                        day23b();
                        break;
                    case "24a":
                        day24a();
                        break;
                    case "24b":
                        day24b();
                        break;
                    case "25a":
                        day25a();
                        break;
                    case "25b":
                        day25b();
                        break;
                }
                Console.WriteLine("'e' to exit");
                selection = Console.ReadLine();
            }

            #region utility
            void printMenu()
            {
                Console.Clear();
                Console.WriteLine("Enter a day number and A or B");
            }

            void print(string message)
            {
                Console.WriteLine(message);
            }
            
            void printInt(int num)
            {
                Console.WriteLine(num);
            }

            void printDecimal(decimal num)
            {
                Console.WriteLine(num);
            }

            void printFloat(float num)
            {
                Console.WriteLine(num);
            }

            string getData(string day)
            {
                return File.ReadAllText("..\\..\\..\\data\\day" + day + ".txt");
            }

            List<string> dataToList(string data, string splitOn)
            {
                return data.Split(splitOn).ToList();
            }

            List<int> dataToIntList(string data, string splitOn)
            {
                return data.Split(splitOn).Select(int.Parse).ToList();
            }

            List<double> dataToDoubleList(string data, string splitOn)
            {
                return data.Split(splitOn).Select(double.Parse).ToList();
            }
            #endregion

            #region day 1
            void day1a() //54968
            {
                List<string> data = dataToList(getData("1"), Environment.NewLine);
                int total = 0;

                foreach (string row in data)
                {
                    Regex regex = new Regex(@"\d+");
                    string nums = "";

                    foreach (Match m in regex.Matches(row))
                        nums += m.Value;

                    int x = int.Parse(nums[0].ToString() + nums[nums.Length-1].ToString());
                    total += x;
                }
                printInt(total);
            }

            void day1b() //54094
            {
                List<string> data = dataToList(getData("1"), Environment.NewLine);
                int total = 0;

                foreach (string row in data)
                {
                    string newRow = row.Replace("twone", "21").Replace("oneight", "18").Replace("eightwo", "82");
                    newRow = newRow.Replace("one", "1").Replace("two", "2'").Replace("three", "3").Replace("four", "4").Replace("five", "5").Replace("six", "6").Replace("seven", "7").Replace("eight", "8").Replace("nine", "9");

                    Regex regex = new Regex(@"\d+");
                    string nums = "";

                    foreach (Match m in regex.Matches(newRow))
                        nums += m.Value;

                    int x = int.Parse(nums[0].ToString() + nums[nums.Length - 1].ToString());
                    total += x;
                }
                printInt(total);   
            }
            #endregion

            #region day 2
            void day2a() //2771
            {
                List<string> data = dataToList(getData("2"), Environment.NewLine);
                
                Regex regexB = new Regex(@"\d+ b");
                Regex regexR = new Regex(@"\d+ r");
                Regex regexG = new Regex(@"\d+ g");
                int sum = 0;
                
                foreach (string row in data)
                {
                    bool pass = true;
                    foreach(string r in row.Split(";"))
                    {
                        int red = 0, blue = 0, green = 0;

                        foreach (Match m in regexR.Matches(r))
                            red = int.Parse(m.Value.Replace(" r", ""));

                        pass = red <= 12;
                        if (pass)
                        {
                            foreach (Match m in regexB.Matches(r))
                                blue = int.Parse(m.Value.Replace(" b", ""));

                            pass = blue <= 14;
                            if (pass)
                            {
                                foreach (Match m in regexG.Matches(r))
                                    green = int.Parse(m.Value.Replace(" g", ""));

                                pass = green <= 13;
                            }
                        }

                        if (!pass)
                            break;
                    }

                    if (pass)
                     sum += data.IndexOf(row) + 1;                    
                }
                printInt(sum);
            }

            void day2b() //70924
            {
                List<string> data = dataToList(getData("2"), Environment.NewLine);

                Regex regexB = new Regex(@"\d+ b");
                Regex regexR = new Regex(@"\d+ r");
                Regex regexG = new Regex(@"\d+ g");
                int sum = 0;
                
                foreach (string row in data)
                {
                    List<int> red = new List<int>(), blue = new List<int>(), green = new List<int>();

                    foreach (Match m in regexR.Matches(row))
                        red.Add(int.Parse(m.Value.Replace(" r", "")));

                    foreach (Match m in regexB.Matches(row))
                        blue.Add(int.Parse(m.Value.Replace(" b", "")));

                    foreach (Match m in regexG.Matches(row))
                        green.Add(int.Parse(m.Value.Replace(" g", "")));

                    sum += red.Max() * blue.Max() * green.Max();
                }
                printInt(sum);
            }
            #endregion

            #region day 3
            void day3a() //
            {

            }

            void day3b() //
            {


            }
            #endregion

            #region day 4
            void day4a() //
            {

            }

            void day4b() //
            {

            }
            #endregion

            #region day 5
            void day5a() //
            {

            }

            void day5b() //
            {

            }
            #endregion

            #region day 6
            void day6a() //
            {

            }

            void day6b() //
            {

            }
            #endregion

            #region day 7
            void day7a() //
            {

            }

            void day7b() //
            {

            }
            #endregion

            #region day 8
            void day8a() //
            {

            }

            void day8b() //
            {

            }
            #endregion

            #region day[9]
            void day9a() //
            {

            }

            void day9b() //
            {

            }
            #endregion

            #region day 10
            void day10a() //
            {

            }

            void day10b() //
            {

            }
            #endregion

            #region day 11
            void day11a() //
            {

            }

            void day11b() //
            {

            }
            #endregion

            #region day 12
            void day12a() // 
            {

            }

            void day12b() // 
            {

            }
            #endregion

            #region day 13
            void day13a() //
            {

            }

            void day13b() //
            {

            }
            #endregion

            #region day 14
            void day14a() //
            {

            }

            void day14b() //
            {

            }
            #endregion

            #region day15
            void day15a() //
            {

            }

            void day15b() //
            {

            }
            #endregion

            #region day16
            void day16a() // 
            {

            }

            void day16b() // 
            {

            }
            #endregion

            #region day17
            void day17a() // 
            {

            }

            void day17b() // 
            {

            }
            #endregion

            #region day18
            void day18a() // 
            {

            }

            void day18b() // 
            {

            }
            #endregion

            #region day19
            void day19a() // 
            {

            }

            void day19b() // 
            {

            }
            #endregion

            #region day20
            void day20a() // 
            {

            }

            void day20b() // 
            {

            }
            #endregion

            #region day21
            void day21a() // 
            {

            }

            void day21b() // 
            {

            }
            #endregion

            #region day22
            void day22a() // 
            {

            }

            void day22b() // 
            {

            }
            #endregion

            #region day23
            void day23a() // 
            {

            }

            void day23b() // 
            {

            }
            #endregion

            #region day24
            void day24a() // 
            {

            }

            void day24b() // 
            {

            }
            #endregion

            #region day25
            void day25a() // 
            {

            }

            void day25b() // 
            {

            }
            #endregion
        }
    }
}
