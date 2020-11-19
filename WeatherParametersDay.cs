using System;
using System.IO;

public class WeatherParametersDay
{
    private enum WeatherType: int
    {
        NotDefined = 0,
        Rain,
        Drizzle,
        Thunder,
        Snow,
        Fog,
        Cloudy,
        Sunny
    }


    private int dayNumber;
    private int weather;
    private double avDayTemp;
    private double avNightTemp;
    private double avAtmPressure;
    private double precipitationAm;

    public void SetParameters()
    {

        while (true) // перевірка введеного дня
        {
            try
            {
                Console.Write("\nInput number of a day: ");
                this.dayNumber = Int32.Parse(Console.ReadLine()); 
                if ((dayNumber <= 0) | (dayNumber > 31))
                {
                    Console.WriteLine("Error. Inputed date must be in range [1, 31].\n");
                    continue;
                }
                else { break; }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Wrong type. Please input type int. \n");
                continue;
            }
        }

        while (true) // перевірка введеного типу погоди
        {
            try
            {
                Console.WriteLine("Input number of type of weather: \nNot defined - 0\nRain - 1\nDrizzle - 2\nThunder - 3\nSnow - 4\nFog - 5\nCloudy - 6\nSunny - 7\nAnswer: ");
                weather = Int32.Parse(Console.ReadLine());
                if (weather == 0 | weather == 1 | weather == 2 | weather == 3 | weather == 4 | weather == 5 | weather == 6 | weather == 7)
                {
                    this.weather = weather;
                    break;
                }
                else
                {
                    Console.WriteLine("Error. Please input one of the numbers listed.\n");
                    continue;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Wrong type. Please input one of the numbers listed. \n");
                continue;
            }
        }

        while (true) // перевірка введеної середньої температури за день
        {
            try
            {
                Console.Write($"Input average day temperature for day {dayNumber}: ");
                this.avDayTemp = Double.Parse(Console.ReadLine());
                if ((avDayTemp < -20) | (avDayTemp > 60))
                {
                    Console.WriteLine("Error. Impossible inputed temperature. Must be in range [-20, 60].\n");
                    continue;
                }
                else { break; }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Wrong type. Please input type integer or double. Use coma ',' if needed. \n");
                continue;
            }
        }

        while (true) // перевірка введеної середньої температури за ніч
        {
            try
            {
                Console.Write($"Input average night temperature for day {dayNumber}: ");
                this.avNightTemp = Double.Parse(Console.ReadLine());
                if ((avNightTemp < -20) | (avNightTemp > 60))
                {
                    Console.WriteLine("Error. Impossible inputed temperature. Must be in range [-20, 60].\n");
                    continue;
                }
                else { break; }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Wrong type. Please input type integer or double. Use coma ',' if needed. \n");
                continue;
            }
        }

        while (true) // перевірка введеного середнього атмосферного тиску
        {
            try
            {
                Console.Write($"Input average atmospheric pressure for day {dayNumber} in mmHg: ");
                this.avAtmPressure = Double.Parse(Console.ReadLine());
                if ((avAtmPressure < 720) | (avAtmPressure > 820))
                {
                    Console.WriteLine("Error. Impossible inputed atmospheric pressure. Must be in range [720, 820] in mmHg.\n");
                    continue;
                }
                else { break; }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Wrong type. Please input type integer or double. Use coma ',' if needed. \n");
                continue;
            }
        }

        while (true) // перевірка введеної кількості опадів
        {
            try
            {
                Console.Write($"Input amount of precipitation for day {dayNumber} in mm: ");
                this.precipitationAm = Double.Parse(Console.ReadLine());
                if ((precipitationAm < 0) | (precipitationAm > 50))
                {
                    Console.WriteLine("Error. Impossible inputed amount of precipitation. Must be in range [0, 50] in mm.\n");
                    continue;
                }
                else { break; }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Wrong type. Please input type integer or double. Use coma ',' if needed. \n");
                continue;
            }
        }

    }

    public void SetParametersFromFile(StreamReader sr)
    {

        string line = sr.ReadLine();
        string[] parameters = line.Split(';');

        if (parameters.Length != 6)
        {
            Console.WriteLine("\nError. Not enough data in the file. Make changes and start the program again.\n");
        }
        else
        {

            try
            {
                this.dayNumber = Int32.Parse(parameters[0]);
                this.weather = Int32.Parse(parameters[1]);
                this.avDayTemp = Double.Parse(parameters[2]);
                this.avNightTemp = Double.Parse(parameters[3]);
                this.avAtmPressure = Double.Parse(parameters[4]);
                this.precipitationAm = Double.Parse(parameters[5]);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError. One of the parameters has wrong type. Please input type integer or double. Use coma ',' if needed.\n");
            }
        }

    }

    public int GetDayNumber() { return dayNumber; }
    public object GetWeather() { return (WeatherType)weather; }
    public int GetWeatherKey() { return weather; }
    public double GetAvDayTemp() { return avDayTemp; }
    public double GetAvNightTemp() { return avNightTemp; }
    public double GetAvAtmPressure() { return avAtmPressure; }
    public double GetPrecipitationAm() { return precipitationAm; }
    public string Display()
    {
        Console.WriteLine($"Day {dayNumber}: weather: {(WeatherType)weather}, average day temperature: {avDayTemp}\u00b0C , average night temperature: {avNightTemp}\u00b0C, average atmospheric pressure: {avAtmPressure} mmHg, amount of precipitation: {precipitationAm} mm");
        return $"Day {dayNumber}: weather: {(WeatherType)weather}, average day temperature: {avDayTemp}\u00b0C, average night temperature: {avNightTemp}\u00b0C, average atmospheric pressure: {avAtmPressure} mmHg, amount of precipitation: {precipitationAm} mm";
    }
}
