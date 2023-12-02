// See https://adventofcode.com/2023/day/2 for the assignment
string fileName = "..\\..\\..\\input.txt";
const int maxRedCubes = 12;
const int maxGreenCubes = 13;
const int maxBlueCubes = 14;

using (StreamReader reader = new StreamReader(fileName))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        //a game is believed to be true unless proven false
        bool possibleGame = true;
        string[] splitLine = line.Split(':');
        string[] cubeSets = splitLine[1].Split(";");
        int gameNum = int.Parse(splitLine[0].Split(" ")[1]);

        foreach (string cubeSet in cubeSets)
        {
            string[] cubes = cubeSet.Trim().Split(",");
            foreach (string cube in cubes)
            {
                string[] pair = cube.Split(" ");
                switch (pair[1])
                {
                    case "red":
                        break;
                    case "green":
                        break;
                    case "blue":
                        break;
                    default: 
                        break;
                }
            }
        }
    }
}