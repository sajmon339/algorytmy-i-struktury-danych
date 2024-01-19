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
}
