using System;
using System.IO;

public class WeatherDays
{
    private WeatherParametersDay[] monthData = new WeatherParametersDay[30];

    public void AddMonthDataFile()  // зчитування з файлу даних до кожного дня місяця 
    { 
        string pathWeather = @"E:\university\ооп\task7_enum\bin\Debug\netcoreapp3.1\WeatherData.txt";
        try
        {
            StreamReader readData = new StreamReader(pathWeather);
            int fileLength = CountLength(pathWeather);
            if (fileLength != 30)
            {
                Console.WriteLine("\nError. File must contain data for exactly 30 days. Make changes and start the program again.");
            }
            else
            {
                for (int i = 0; i < fileLength; i++)
                {
                    WeatherParametersDay day = new WeatherParametersDay();
                    monthData[i] = day;
                    day.SetParametersFromFile(readData);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nFile not found. Make changes and start the program again.");
        }
    }

    public void AddMonthData()  // ввід даних вручну за кожен день місяця
    {
        for (int i = 0; i < 30; i++)
        {
            WeatherParametersDay day = new WeatherParametersDay();
            monthData[i] = day;
            day.SetParameters();
        }

    }

    public void CloudyDays()  // метод виводить кількість пасмурних днів
    {
        int numberOfCloudyDays = 0;
        for (int i = 0; i < 30; i++)
        {
            if (monthData[i].GetWeatherKey() == 6)
            {
                numberOfCloudyDays++;
            }
        }
        Console.WriteLine("\nNumber of cloudy days in june: " + numberOfCloudyDays);
    }

    public void PrecipitationDays()  // метод виводить кількість днів, коли були опади
    {
        int numberOfPrecipitationDays = 0;
        for (int i = 0; i < 30; i++)
        {
            if (monthData[i].GetPrecipitationAm() != 0)
            {
                numberOfPrecipitationDays++;
            }
        }
        Console.WriteLine("Number of days with precipitation in june: " + numberOfPrecipitationDays);
    }
    public void MinMaxNightTemp()  // метод виводить мінімальну та максимальну температуру вночі 
    {
        double min = 60;
        double max = -20;

        for (int i = 0; i < 30; i++)
        {
            if (monthData[i].GetAvNightTemp() <= min)
            {
                min = monthData[i].GetAvNightTemp();
            }
            if (monthData[i].GetAvNightTemp() >= max)
            {
                max = monthData[i].GetAvNightTemp();
            }
        }
        Console.WriteLine("Maximum night temperature in june: " + max + "\u00b0C");
        Console.WriteLine("Minimum night temperature in june: " + min + "\u00b0C");
    }

    public void DisplayTable()  // метод виводить у консоль таблицю з даними за цілий місяць
    {
        Console.WriteLine("\nDay \tWeather Day temp (\u00b0C) Night temp (\u00b0C) Av atmosph pressure (in in mmHg) Amount of precipitation (in mm)");
        for (int i = 0; i < monthData.Length; i++)
        {
            Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t\t\t\t{5}", monthData[i].GetDayNumber(), monthData[i].GetWeather(), monthData[i].GetAvDayTemp(), monthData[i].GetAvNightTemp(), monthData[i].GetAvAtmPressure(), monthData[i].GetPrecipitationAm());
        }
    }

    public void UserChoice()
    {
        string answer;
        while (true) // перевірка введених даних
        {
            try
            {
                Console.Write("Input '1' if you want to input weather data or input '2' if you want to read data from file: ");
                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        AddMonthData();
                        DisplayTable();
                        CloudyDays();
                        PrecipitationDays();
                        MinMaxNightTemp();
                        break;
                    case "2":
                        AddMonthDataFile();
                        DisplayTable();
                        CloudyDays();
                        PrecipitationDays();
                        MinMaxNightTemp();
                        break;
                    default:
                        Console.WriteLine("\nError. Please input '1' or '2'. \n");
                        continue;
                }
                break;

            }
            catch (FormatException)
            {
                Console.WriteLine("\nError. Please input '1' or '2'. \n");
                continue;
            }
        }
    }

    public int CountLength(string path)  // метод повертає кількість рядків у файлі
    {
        int count = 0;
        foreach (string i in File.ReadAllLines(path))
        { count++; }
        return count;
    }


}
