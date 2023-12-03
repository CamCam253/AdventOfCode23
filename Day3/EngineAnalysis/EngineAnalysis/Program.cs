// See https://adventofcode.com/2023/day/3 for the assignment
string fileName = "..\\..\\..\\input.txt";
string[,] data = {};
int sum1;


using (StreamReader reader = new StreamReader(fileName))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        int row = 0;
        for (int col = 0; col < line.Length; col++)
        {
            string sub = line.Substring(col, 1).Trim();
            if (sub.Equals("."))
            {
                data[row, col] = " ";
            }
            else
            {
                 data[row, col] = sub;
            }
        }
        row++;
    }
}

for (int row = 0; row < data.GetLength(0); row++)
{
    for (int col = 0; col < data.GetLength(1); col++)
    {
        string temp = data[row, col];
        if (!temp.Equals(" "))
        {
            if (!Char.IsDigit(temp, 0))
            {
                GetNumbers();
            }
        }
    }
}

static int[] GetNumbers()
{
    return null;
}