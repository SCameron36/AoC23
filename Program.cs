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
        Regex regex = new Regex(@"\d+");
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
        }
        #region utility
        static void printMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter a day number and A or B");
        }

        static void print(string message)
        {
            Console.WriteLine(message);
        }

        static void printInt(int num)
        {
            Console.WriteLine(num);
        }

        static void printDecimal(decimal num)
        {
            Console.WriteLine(num);
        }

        static void printFloat(float num)
        {
            Console.WriteLine(num);
        }

        static string getData(string day)
        {
            return File.ReadAllText("..\\..\\..\\data\\day" + day + ".txt");
        }

        static List<string> dataToList(string data, string splitOn)
        {
            return data.Split(splitOn).ToList();
        }

        static List<int> dataToIntList(string data, string splitOn)
        {
            return data.Split(splitOn).Select(int.Parse).ToList();
        }

        static List<double> dataToDoubleList(string data, string splitOn)
        {
            return data.Split(splitOn).Select(double.Parse).ToList();
        }
        #endregion

        #region day 1
        static void day1a() //54968
        {
            List<string> data = dataToList(getData("1"), Environment.NewLine);
            int total = 0;

            foreach (string row in data)
            {
                Regex regex = new Regex(@"\d+");
                string nums = "";

                foreach (Match m in regex.Matches(row))
                    nums += m.Value;

                int x = int.Parse(nums[0].ToString() + nums[nums.Length - 1].ToString());
                total += x;
            }
            printInt(total);
        }

        static void day1b() //54094
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
        static void day2a() //2771
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

                if (red.Max() <= 12 && blue.Max() <= 14 && green.Max() <= 13)
                    sum += data.IndexOf(row) + 1;
            }
            printInt(sum);
        }

        static void day2b() //70924
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
        static void day3a() //512794
        {
            List<string> data = dataToList(getData("3"), Environment.NewLine);
            Regex regex = new Regex(@"\d+");

            int total = 0;

            for (int i = 0; i < data.Count; i++)
            {
                Dictionary<int, char>? curRow = getSymbols(data[i]);
                Dictionary<int, char>? prevRow = null, nextRow = null;

                MatchCollection matches = regex.Matches(data[i]);
                if (i > 0)
                    prevRow = getSymbols(data[i - 1]);

                if (i < data.Count - 1)
                    nextRow = getSymbols(data[i + 1]);

                foreach (Match m in matches)
                {
                    int indexS = m.Index; //match start index
                    int indexE = m.Index + m.Length - 1; //match end index

                    if ((prevRow != null && prevRow.Keys.Any(x => indexS - 1 <= x && indexE + 1 >= x))
                    || (curRow.Keys.Any(x => indexS - 1 <= x && indexE + 1 >= x))
                    || (nextRow != null && nextRow.Keys.Any(x => indexS - 1 <= x && indexE + 1 >= x)))
                        total += int.Parse(m.Value);
                }
            }
            printInt(total);
        }

        static Dictionary<int, char> getSymbols(string row, char? specific = null)
        {
            Dictionary<int, char> symbols = new Dictionary<int, char>();

            for (var i = 0; i < row.Length; i++)
                if (!char.IsNumber(row[i]) && !char.Equals(row[i], '.') && (specific == null || char.Equals(row[i], specific)))
                    symbols.Add(i, row[i]);

            return symbols;
        }

        static void day3b() //67779080
        {
            List<string> data = dataToList(getData("3"), Environment.NewLine);
            Regex regex = new Regex(@"\d+");

            int total = 0;

            for (int i = 0; i < data.Count; i++)
            {
                Dictionary<int, char> curRow = getSymbols(data[i], '*');
                string prevRow = null, nextRow = null;

                foreach (var s in curRow)
                {
                    if (i > 0)
                        prevRow = data[i - 1];

                    if (i < data.Count - 1)
                        nextRow = data[i + 1];

                    List<int> nums = adjNum(data[i], s.Key, prevRow, nextRow);

                    if (nums.Count == 2)
                        total += (nums[0] * nums[1]);
                }
            }
            printInt(total);
        }

        static List<int> adjNum(string row, int i, string? prevRow, string? nextRow)
        {
            List<int> adjNum = new List<int>();

            var matches = Regex.Matches(row, @"\d+").ToList();

            if (prevRow != null)
                matches.AddRange(Regex.Matches(prevRow, @"\d+"));

            if (nextRow != null)
                matches.AddRange(Regex.Matches(nextRow, @"\d+"));

            adjNum.AddRange(matches.Where(x => (i >= x.Index - 1 && i <= (x.Index + x.Length))).Select(x => int.Parse(x.Value)));

            return adjNum;
        }
        #endregion

        #region day 4
        static void day4a() //17782
        {
            List<string> data = dataToList(getData("4"), Environment.NewLine);
            Regex regex = new Regex(@"\d+");
            int total = 0;

            foreach (string row in data)
            {
                string winning = row.Split("|")[0];
                string yours = row.Split("|")[1];

                winning = winning.Remove(0, winning.IndexOf(":") + 1).Replace("  ", " 0");
                yours = yours.Replace("  ", " 0");

                MatchCollection winningNums = regex.Matches(winning);
                int rowTotal = 0;

                foreach (Match match in winningNums)
                    if (yours.Contains(match.Value))
                        rowTotal = rowTotal == 0 ? 1 : rowTotal * 2;

                total += rowTotal;
            }
            printInt(total);
        }

        static void day4b() //
        {
            List<string> data = dataToList(getData("4"), Environment.NewLine);
            Regex regex = new Regex(@"\d+");
            Dictionary<int, int> amounts = new Dictionary<int, int>();
            int total = 0;

            for (int i = 0; i < data.Count; i++)
                amounts.Add(i, 1);

            for (int i = 0; i < data.Count; i++)
            {
                string row = data[i];

                if (amounts.ContainsKey(i) && amounts[i] > 0)
                {
                    string winning = row.Split("|")[0];
                    string yours = row.Split("|")[1];

                    winning = winning.Remove(0, winning.IndexOf(":") + 1).Replace("  ", " 0");
                    yours = yours.Replace("  ", " 0");

                    MatchCollection winningNums = regex.Matches(winning);
                    int rowTotal = 0;

                    foreach (Match match in winningNums)
                        if (yours.Contains(match.Value))
                            rowTotal++;

                    for (int x = 1; x <= rowTotal; x++)
                        if (amounts.ContainsKey(i + x))
                            amounts[i + x] += amounts[i];

                    total += amounts[i];
                }
            }
            printInt(total);
        }
        #endregion

        #region day 5
        static void day5a() //
        {
            
        }

        static void day5b() //
        {

        }
        #endregion

        #region day 6
        static void day6a() //
        {

        }

        static void day6b() //
        {

        }
        #endregion

        #region day 7
        static void day7a() //
        {

        }

        static void day7b() //
        {

        }
        #endregion

        #region day 8
        static void day8a() //
        {

        }

        static void day8b() //
        {

        }
        #endregion

        #region day[9]
        static void day9a() //
        {

        }

        static void day9b() //
        {

        }
        #endregion

        #region day 10
        static void day10a() //
        {

        }

        static void day10b() //
        {

        }
        #endregion

        #region day 11
        static void day11a() //
        {

        }

        static void day11b() //
        {

        }
        #endregion

        #region day 12
        static void day12a() // 
        {

        }

        static void day12b() // 
        {

        }
        #endregion

        #region day 13
        static void day13a() //
        {

        }

        static void day13b() //
        {

        }
        #endregion

        #region day 14
        static void day14a() //
        {

        }

        static void day14b() //
        {

        }
        #endregion

        #region day15
        static void day15a() //
        {

        }

        static void day15b() //
        {

        }
        #endregion

        #region day16
        static void day16a() // 
        {

        }

        static void day16b() // 
        {

        }
        #endregion

        #region day17
        static void day17a() // 
        {

        }

        static void day17b() // 
        {

        }
        #endregion

        #region day18
        static void day18a() // 
        {

        }

        static void day18b() // 
        {

        }
        #endregion

        #region day19
        static void day19a() // 
        {

        }

        static void day19b() // 
        {

        }
        #endregion

        #region day20
        static void day20a() // 
        {

        }

        static void day20b() // 
        {

        }
        #endregion

        #region day21
        static void day21a() // 
        {

        }

        static void day21b() // 
        {

        }
        #endregion

        #region day22
        static void day22a() // 
        {

        }

        static void day22b() // 
        {

        }
        #endregion

        #region day23
        static void day23a() // 
        {

        }

        static void day23b() // 
        {

        }
        #endregion

        #region day24
        static void day24a() // 
        {

        }

        static void day24b() // 
        {

        }
        #endregion

        #region day25
        static void day25a() // 
        {

        }

        static void day25b() // 
        {

        }
        #endregion
    }
}
