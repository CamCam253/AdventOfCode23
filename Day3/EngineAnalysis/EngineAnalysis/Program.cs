// See https://adventofcode.com/2023/day/3 for the assignment
string fileName = "..\\..\\..\\input.txt";
string[,] data = {};

using (StreamReader reader = new StreamReader(fileName))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        int row = 0;
        for (int col = 0; col < line.Length; col++)
        {
            data[row, col] = line.Substring(col, 1).Trim();
        }
    }
}