using System;
using System.Diagnostics;
using System.Linq;

public class Laby2
{
    public static void zadanie1()
    {
        int[] tablica = RNG();
        Console.WriteLine("Nieposortowana tablica:");
        WyswietlTablice(tablica);

        Stopwatch stopwatch = new Stopwatch();

        // Pomiar czasu dla sortowania bąbelkowego
        stopwatch.Start();
        SortowanieBabelkowe(tablica);
        stopwatch.Stop();
        Console.WriteLine("\nPosortowana tablica (Bubble Sort):");
        WyswietlTablice(tablica);
        Console.WriteLine($"Czas wykonania sortowania bąbelkowego: {stopwatch.ElapsedMilliseconds} ms");

        tablica = RNG(); // Przywrócenie nieposortowanej tablicy

        // Pomiar czasu dla sortowania QuickSort
        stopwatch.Reset();
        stopwatch.Start();
        QuickSort(tablica, 0, tablica.Length - 1);
        stopwatch.Stop();
        Console.WriteLine("\nPosortowana tablica (QuickSort):");
        WyswietlTablice(tablica);
        Console.WriteLine($"Czas wykonania QuickSort: {stopwatch.ElapsedMilliseconds} ms");
    }

    public static void zadanie2()
    {
        int[] tablica = RNG();
        Console.WriteLine("Nieposortowana tablica:");
        WyswietlTablice(tablica);

        Stopwatch stopwatch = new Stopwatch();

        // Pomiar czasu dla sortowania bąbelkowego
        stopwatch.Start();
        SortowanieBabelkowe(tablica);
        stopwatch.Stop();
        Console.WriteLine("\nPosortowana tablica (Bubble Sort):");
        WyswietlTablice(tablica);
        Console.WriteLine($"Czas wykonania sortowania bąbelkowego: {stopwatch.ElapsedMilliseconds} ms");

        tablica = RNG(); // Przywrócenie nieposortowanej tablicy

        // Pomiar czasu dla sortowania QuickSort
        stopwatch.Reset();
        stopwatch.Start();
        QuickSort(tablica, 0, tablica.Length - 1);
        stopwatch.Stop();
        Console.WriteLine("\nPosortowana tablica (QuickSort):");
        WyswietlTablice(tablica);
        Console.WriteLine($"Czas wykonania QuickSort: {stopwatch.ElapsedMilliseconds} ms");
    }

    public static int[] RNG()
    {
        Random random = new Random();
        int[] tablica = new int[1000];
        for (int i = 0; i < tablica.Length; i++)
        {
            tablica[i] = random.Next(1, 1000); // Zakres od 1 do 999
        }
        return tablica;
    }

    public static void WyswietlTablice(int[] tablica)
    {
        foreach (var liczba in tablica)
        {
            Console.Write(liczba + " ");
        }
        Console.WriteLine();
    }

    public static void SortowanieBabelkowe(int[] tablica)
    {
        int n = tablica.Length;
        bool zamiana;
        do
        {
            zamiana = false;
            for (int i = 1; i < n; i++)
            {
                if (tablica[i - 1] > tablica[i])
                {
                    int temp = tablica[i - 1];
                    tablica[i - 1] = tablica[i];
                    tablica[i] = temp;
                    zamiana = true;
                }
            }
        } while (zamiana);
    }

    public static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right);
            QuickSort(arr, left, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, right);
        }
    }

    private static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, right);
        return i + 1;
    }

    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    public static void zadanie3()
    {
        string[] imiona = { "Franciszka", "Barbara", "Cezary", "Dariusz", "Ewelina", "Adam","Stefan","Ziemowit" };
        int k = imiona.Length;
        int n = 3;
        int liczbaOsob = k;
        bool[] obecni = new bool[k];
        for (int i = 0; i < k; i++)
        {
            obecni[i] = true;
        }

        int index = 0;

        while (liczbaOsob > 1)
        {
            int licznik = 0;
            while (licznik < n)
            {
                if (obecni[index])
                {
                    licznik++;
                }

                if (licznik < n)
                {
                    index = (index + 1) % k;
                }
            }

            obecni[index] = false;
            liczbaOsob--;

            Console.Write("Osoby w kręgu: ");
            for (int i = 0; i < k; i++)
            {
                if (obecni[i])
                {
                    Console.Write($"{imiona[i]} ");
                }
            }
            Console.WriteLine();

            // Aktualizacja indeksu po sprawdzeniu obecności
            index = (index + 1) % k;
        }

        for (int i = 0; i < k; i++)
        {
            if (obecni[i])
            {
                Console.WriteLine($"Ostatnia osoba w kręgu: {imiona[i]}");
                break;
            }
        }
    }
    public static void zadanie4()
    {
        string[] imiona = { "Franciszka", "Barbara", "Cezary", "Dariusz", "Ewelina", "Adam","Stefan","Ziemowit" };
        int k = imiona.Length;
        int n = 3;
        Queue<string> kolejka = new Queue<string>(imiona);

        while (kolejka.Count > 1)
        {
            for (int i = 0; i < n - 1; i++)
            {
                string osoba = kolejka.Dequeue();
                kolejka.Enqueue(osoba);
            }

            string eliminowanaOsoba = kolejka.Dequeue();
            Console.WriteLine($"Eliminowana osoba: {eliminowanaOsoba}");
        }

        string ostatniaOsoba = kolejka.Dequeue();
        Console.WriteLine($"Ostatnia osoba w kręgu: {ostatniaOsoba}");
    }
    public class CarWashSimulation
    {
        private int numberOfWashStations;
        private int simulationDuration;
        private List<int> washDurations;

        public CarWashSimulation(int numberOfWashStations, int simulationDuration, List<int> washDurations)
        {
            this.numberOfWashStations = numberOfWashStations;
            this.simulationDuration = simulationDuration;
            this.washDurations = washDurations;
        }

        public void RunSimulation()
        {
            Random random = new Random();
            Queue<int> waitingCars = new Queue<int>();
            int totalWaitTime = 0;
            int currentTime = 0;

            while (currentTime < simulationDuration)
            {
                // Pojazd przyjeżdża z pewnym prawdopodobieństwem (np. co 1 minutę)
                if (random.NextDouble() < 0.1) // Przykładowa wartość prawdopodobieństwa
                {
                    int washDuration = washDurations[random.Next(washDurations.Count)];
                    if (numberOfWashStations > 0)
                    {
                        // Samochód jest natychmiast obsługiwany, jeśli jest dostępne stanowisko
                        numberOfWashStations--;
                        totalWaitTime += currentTime;
                    }
                    else
                    {
                        // Samochód jest dodawany do kolejki oczekujących
                        waitingCars.Enqueue(currentTime);
                    }
                    currentTime += washDuration;
                }
                else
                {
                    currentTime++;
                }

                // Zwolnienie stanowiska myjącego
                if (waitingCars.Any() && currentTime >= waitingCars.Peek() + washDurations.Min())
                {
                    waitingCars.Dequeue();
                    numberOfWashStations++;
                }
            }

            // Średni czas oczekiwania
            double averageWaitTime = (double)totalWaitTime / (double)simulationDuration;
            Console.WriteLine($"Średni czas oczekiwania: {averageWaitTime} minut");
        }
    }
    public class zadanie5
        {
            
                private static int numberOfWashStations=2;
                private static int simulationDuration=240;
                private static List<int> fixedWashDurations=new List<int> { 3 }; // Stały czas mycia - 3 minuty;
                private static List<int> randomWashDurations=new List<int> { 2, 3, 4, 5 }; // Losowe czasy mycia od 2 do 5 minut;

            public static void case1()
            {
                // Punkt 2: Symulacja z czasem mycia stałym (3 minuty) i samochody co 1 minutę
                CarWashSimulation fixedDurationSimulation = new CarWashSimulation(numberOfWashStations,simulationDuration,fixedWashDurations);
                Console.WriteLine("Punkt 2: Czas mycia stały, samochody co 1 minutę");
                fixedDurationSimulation.RunSimulation();
            }
            public static void case2()
            {
                // Punkt 3: Symulacja z losowym czasem mycia (2-5 minut) i różnymi prawdopodobieństwami
                List<double> probabilities = new List<double> { 0.1, 0.25, 0.5, 0.75 };
                Console.WriteLine("\nPunkt 3: Losowy czas mycia, różne prawdopodobieństwa pojawienia się pojazdu");
                foreach (double probability in probabilities)
                {
                    Console.WriteLine($"Prawdopodobieństwo: {probability}");
                    CarWashSimulation randomDurationSimulation = new CarWashSimulation(numberOfWashStations, simulationDuration, randomWashDurations);
                    randomDurationSimulation.RunSimulation();
                }
            }
            public static void case3()
            {
                // Punkt 4: Optymalizacja czasu mycia
                int optimalWashDuration = 3; // Optymalny czas mycia (może być dostosowany)
                Console.WriteLine("\nPunkt 4: Optymalizacja czasu mycia");
                Console.WriteLine($"Optymalny czas mycia: {optimalWashDuration} minut");
                List<int> optimizedWashDurations = randomWashDurations.Select(duration => Math.Max(duration, optimalWashDuration)).ToList();
                CarWashSimulation optimizedSimulation = new CarWashSimulation(numberOfWashStations, simulationDuration, optimizedWashDurations);
                optimizedSimulation.RunSimulation();
            }

        }
}
