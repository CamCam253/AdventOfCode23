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
                int highestj = 1;
                if (i+5 > line.Length)
                {
                    highestj = line.Length - i;
                }
                else
                {
                    highestj = 5;
                }

                foreach (string writnum in writtenNumbers.Keys)
                {
                    bool found = false;
                    for (int j = 3; j <= highestj; j++)
                    {
                        //make sure there is not a digit in the other chars
                        temp = line.Substring(i, j);
                        if (temp.Any(char.IsDigit) && j==3)
                        {
                            found = true;
                            break;
                        }
                        else if (temp.Contains(writnum) && num1Found)
                        {
                            num2 = writtenNumbers[writnum];
                            found = true;
                            break;
                        }
                        else if (temp.Contains(writnum))
                        {
                            num1Found = true;
                            num1 = writtenNumbers[writnum];
                            num2 = writtenNumbers[writnum];
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        break;
                    }
                }
            }
        }
        string listed = num1.ToString() + num2.ToString();
        numbers.Add(int.Parse(listed));
    }
}

int sum = 0;
foreach (int num in numbers)
{
    Console.WriteLine(num);
    sum += num;
}
Console.WriteLine(sum);