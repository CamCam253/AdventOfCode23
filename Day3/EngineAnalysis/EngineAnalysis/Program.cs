// See https://adventofcode.com/2023/day/3 for the assignment
const string fileName = "..\\..\\..\\input.txt";
int sum1 = 0;


List<List<string>> data = new List<List<string>>();


using (StreamReader reader = new StreamReader(fileName))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        data.Add(new List<string>());
        for (int i = 0; i < line.Length; i++)
        {
            string sub = line.Substring(i, 1).Trim();
            if (sub.Equals("."))
            {
                data[data.Count-1].Add(" ");
            }
            else
            {
                data[data.Count-1].Add(sub);
            }
        }
    }
}

int rows = data.Count;
int cols = data[0].Count;

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        string temp = data[row][col];
        if (!temp.Equals(" "))
        {
            if (!Char.IsDigit(temp, 0))
            {
                List<int> numbers = GetNumbers(row, col, data);
                foreach (int number in numbers)
                {
                    sum1 += number;
                }
                Console.WriteLine("Row: " + row + " Column: " + col);
            }
        }
    }
}

Console.WriteLine(sum1);

static List<int> GetNumbers(int row, int column, List<List<string>> data)
{
    List<int> numbers = new List<int>();

    int topRow = row - 1;
    int bottomRow = row + 1;
    if (row == 0)
    {
        topRow = 0;
    }
    else if (row == data.Count - 1)
    {
        bottomRow = data.Count;
    }

    int rightMostCol = column + 1;
    int leftMostCol = column - 1;
    if (column == 0)
    {
        leftMostCol = 0;
    }
    else if (column == data[0].Count - 1) 
    {
        rightMostCol = data[0].Count;
    }

    for (int temprow = topRow; temprow < bottomRow; temprow++)
    {
        string number = "";
        for (int tempcol = leftMostCol; tempcol < rightMostCol; tempcol++)
        {
            if (Char.IsDigit(data[temprow][tempcol], 0))
            {
                if (tempcol == leftMostCol ) 
                {
                    bool borderFound = false;
                    int i = 1;
                    while (i >= 0)
                    {
                        if (tempcol - i == 0)
                        {
                            number += data[temprow][tempcol - i];
                            i--;
                            borderFound = true;
                        }
                        else if (Char.IsDigit(data[temprow][tempcol - i], 0) && !borderFound) { i++; }
                        else 
                        {
                            number += data[temprow][tempcol - i];
                            i--;
                        }
                    }
                }
                else if (tempcol == rightMostCol)
                {
                    int i = 0;
                    while (Char.IsDigit(data[temprow][tempcol + i], 0))
                    {
                        number += data[temprow][tempcol + i];
                        i++;
                        Console.WriteLine(number);
                    }
                }
                else
                {
                    number += data[temprow][tempcol];
                }
                
            }
            else if (number != "")
            {
                Console.WriteLine("Added: " + number);
                numbers.Add(Int32.Parse(number));
                number = "";
            }
        }
        if (number != "")
        {
            Console.WriteLine("Added: " + number);
            numbers.Add(Int32.Parse(number));
        }
        
    }
    return numbers;
}