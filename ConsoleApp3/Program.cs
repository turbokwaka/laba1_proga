using System.Runtime.Intrinsics.X86;
using System.Text.Json;

namespace ConsoleApp3;
class Program
{
    static void Main(string[] args)
    {
        // Task 1
        String Poem = "В КПІ декан Корнага владарює, " +
                      "Науки храм, де він правління несе. " +
                      "Знань страж, у кожному слові – мудрість, " +
                      "Серце його – терпіння та справедливість. " +
                      "На факультеті, де ростуть розуми, " +
                      "Декан Корнага, як провідник світлий. " +
                      "З зорею ранку він вже на порозі, " +
                      "Всіх викликів зустрічає у серці. " +
                      "Він, наче код, розгадує завдання, " +
                      "Сприяє розвитку в інформаційній станції. " +
                      "Великий КПІ – тут вченості пагода, " +
                      "А декан Корнага, як провідний свічник вода.";
        
        var task1 = new Task1(Poem);
        //task1.Implementation();
        
        // Task 2
        var task2 = new Task2();
        // task2.Implementation();
        
        // Task 3
        var NumList = new List<int> { 140, -20, 52, 100 };
        var task3 = new Task3(NumList);
        
        task3.Implementation();

        Console.ReadKey();
    }
    
    public class Task1
    {
        public string Poem;
        private List<string> _wordsList;
        private string _longestWord;
        
        public Task1(string poem)
        {
            Poem = poem;
            _wordsList = _sortList();
            _longestWord = _findLongestWord();
        }

        // interface?? хз ще недовчив цю тему
        public void Implementation()
        {
            // displaying sorted list
            Console.WriteLine("Sorted list: ");
            foreach (var VARIABLE in _wordsList)
            {
                Console.WriteLine(VARIABLE);
            }
            
            // displaying longest word
            Console.WriteLine("Longest word: " + _longestWord);
        }
        
        // implementation details
        private List<string> _sortList()
        {
            var list = _listBuilder(Poem)
                .OrderBy(word => word.Length)
                .ToList(); // sorting
            
            return list;
        }

        private string _findLongestWord()
        {
            return _wordsList.LastOrDefault();
        }

        private List<string> _listBuilder(string text)
        {
            return text.Split(' ').ToList(); // splitting by space => List<string>
        }
    }
    
    public class Task2
    {
        private Dictionary<int, string> _dict = new Dictionary<int, string>
        {
            { 0, "zero" },
            { 1, "two" },
            { 5, "five" },
            { 11, "eleven"}
        };
        

        public void Implementation()
        {
            _displayDictionary();
            _serialize();
            _deserialize();
        }

        private void _displayDictionary()
        {
            foreach (var VARIABLE in _dict)
            {
                Console.Write(VARIABLE.Value + " ");
            }
        }

        private void _serialize()
        {
            string jsonText = JsonSerializer.Serialize(_dict);
            Console.WriteLine(jsonText);
            File.WriteAllText("/home/artem/RiderProjects/ConsoleApp2/testDict.json", jsonText);
        }

        private void _deserialize()
        {
            string jsonText = File.ReadAllText("/home/artem/RiderProjects/ConsoleApp2/testDict.json");

            var deserialized = JsonSerializer.Deserialize<Dictionary<int, String>>(jsonText);
            Console.WriteLine(deserialized[5]);
        }
    }

    public class Task3
    {
        public List<int> NumList;
        public List<int> PositiveTwoDigits;
        public Task3(List<int> numList)
        {
            NumList = new List<int>(numList);
            PositiveTwoDigits = _findPositiveTwoDigits();
        }
        
        public void Implementation()
        {
            // displaying list of only positive two-digits
            Console.Write("List: ");
            foreach (var VARIABLE in PositiveTwoDigits)
            {
                Console.Write(VARIABLE + " ");
            }
            
            // count and display list
            Console.WriteLine();
            Console.WriteLine("Count: " + PositiveTwoDigits.Count);
            
            // displaying average of them
            _findAverage();
        }

        private List<int> _findPositiveTwoDigits()
        {
            return NumList.Where(x => x >= 10 && x <= 99).ToList();
        }

        // private int _findAverage()
        // {
        //     return PositiveTwoDigits.Any() ? (int)PositiveTwoDigits.Average() : 0;
        // }
        private void _findAverage()
        {
            if (PositiveTwoDigits.Any())
            {
                Console.WriteLine("Average: " + (int)PositiveTwoDigits.Average());
            }
            else
            {
                Console.WriteLine("0 0.0");
            }
        }
    }
}