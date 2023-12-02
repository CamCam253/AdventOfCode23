// See https://adventofcode.com/2023/day/1 for the assingment
string filename = @"..\\..\\..\\input.txt";
List<int> numbers = new List<int>();
Dictionary<string, string> writtenNumbers = new Dictionary<string, string> { {"one","1"},{"two","2"},{"three","3"},{"four","4"},{"five","5"},{"six","6"},{"seven","7"},{"eight","8"},{"nine","9"}};

using (StreamReader reader = new StreamReader(filename))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        string num1 = "0";
        bool num1Found = false;
        string num2 = "0";
        for (int i = 0; i < line.Length; i++)
        {
            //first check if current char is a number
            if (Char.IsDigit(line[i]) && num1Found)
            {
                num2 = "" + line[i];
            }
            else if (Char.IsDigit(line[i]))
            {
                num1Found = true;
                num1 = "" + line[i];
                num2 = "" + line[i];
            }
            else
            {
                //Then check if the number is written
                string temp;
                if (i+5 > line.Length)
                {
                    temp = line.Substring(i);
                }
                else
                {
                    temp = line.Substring(i, 5);
                }

                foreach (string writnum in writtenNumbers.Keys)
                {
                    if (temp.Contains(writnum) && num1Found)
                    {
                        num2 = writtenNumbers[writnum];
                    }
                    else if (temp.Contains(writnum))
                    {
                        num1Found = true;
                        num1 = writtenNumbers[writnum];
                        num2 = writtenNumbers[writnum];
                    }
                }
            }
        }
        numbers.Add(int.Parse(num1 + num2));
    }
}

int sum = 0;
foreach (int num in numbers)
{
    Console.WriteLine(num);
    sum += num;
}
Console.WriteLine(sum);