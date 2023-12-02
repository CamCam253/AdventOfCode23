// See https://adventofcode.com/2023/day/1 for the assingment
string filename = @"..\\..\\..\\input.txt";
List<int> numbers = new List<int>();

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