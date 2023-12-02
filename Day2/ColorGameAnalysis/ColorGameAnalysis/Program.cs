// See https://adventofcode.com/2023/day/2 for the assignment
string fileName = "..\\..\\..\\input.txt";
const int maxRedCubes = 12;
const int maxGreenCubes = 13;
const int maxBlueCubes = 14;
int sum = 0;

using (StreamReader reader = new StreamReader(fileName))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        //a game is believed to be true unless proven false
        bool possibleGame = true;
        string[] splitLine = line.Split(':');
        string[] gameSets = splitLine[1].Split(";");
        int gameNum = int.Parse(splitLine[0].Split(" ")[1]);

        foreach (string cubeSet in gameSets)
        {
            string[] cubes = cubeSet.Trim().Split(",");
            foreach (string cube in cubes)
            {
                string[] pair = cube.Trim().Split(" ");
                int cubeNum = int.Parse(pair[0]);
                switch (pair[1])
                {
                    case "red":
                        if (cubeNum > maxRedCubes)
                        {
                            possibleGame = false;
                        }
                        break;
                    case "green":
                        if (cubeNum > maxGreenCubes)
                        {
                            possibleGame = false;
                        }
                        break;
                    case "blue":
                        if (cubeNum > maxBlueCubes)
                        { 
                            possibleGame = false; 
                        }
                        break;
                    default: 
                        break;
                }
                if (!possibleGame)
                {
                    break;
                }
            }
            if (!possibleGame)
            {
                break;
            }
        }
        if (possibleGame)
        {
            sum += gameNum;
        }
    }
}

Console.WriteLine(sum);