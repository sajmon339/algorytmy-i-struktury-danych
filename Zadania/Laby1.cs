using System;

public class LinearSearch
{
    private long[] array;
    public LinearSearch(long[] arr)
    {
        array = arr;
    }
    public void Reverse()
    {
        int left = 0;
        int right = array.Length - 1;

        while (left < right)
        {
            long temp = array[left];
            array[left] = array[right];
            array[right] = temp;

            left++;
            right--;
        }
    }
    public bool Find(long key)
    {
        foreach (long element in array)
        {
            if (element == key)
            {
                return true; // Znaleziono wartość key w tablicy
            }
        }
        return false; // Nie znaleziono wartości key w tablicy
    }
    public static void zadanie1()
    {
        /*algorytm wyszukiwania liniowego określonej wartości w tablicy*/
        long[] arr = { 10, 20, 30, 40, 50 };
        LinearSearch linearSearch = new LinearSearch(arr);

        long keyToFind = 30;
        if (linearSearch.Find(keyToFind))
        {
            Console.WriteLine($"Wartość {keyToFind} została znaleziona w tablicy.");
        }
        else
        {
            Console.WriteLine($"Wartość {keyToFind} nie została znaleziona w tablicy.");
        }

        keyToFind = 60;
        if (linearSearch.Find(keyToFind))
        {
            Console.WriteLine($"Wartość {keyToFind} została znaleziona w tablicy.");
        }
        else
        {
            Console.WriteLine($"Wartość {keyToFind} nie została znaleziona w tablicy.");
        }
    }
    public static void zadanie2()
    {
        /*algorytm wyszukiwania binarnego jako metodę:bool findbin (long key)*/
        long[] arr = { 5, 15, 25, 35, 45 };
        LinearSearch linearSearch = new LinearSearch(arr);

        long keyToFind = 25;
        if (linearSearch.Find(keyToFind))
        {
            Console.WriteLine($"Wartość {keyToFind} została znaleziona w tablicy.");
        }
        else
        {
            Console.WriteLine($"Wartość {keyToFind} nie została znaleziona w tablicy.");
        }

        keyToFind = 55;
        if (linearSearch.Find(keyToFind))
        {
            Console.WriteLine($"Wartość {keyToFind} została znaleziona w tablicy.");
        }
        else
        {
            Console.WriteLine($"Wartość {keyToFind} nie została znaleziona w tablicy.");
        }
    }
    public static void zadanie3()
    {
        
        /*Zaprojektuj i zaimplementuj algorytm, który odwróci tablicę jako metodę: void reverse ()*/
        long[] arr = { 10, 20, 30, 40, 50 };
        LinearSearch linearSearch = new LinearSearch(arr);

        Console.WriteLine("Tablica przed odwróceniem:");
        PrintArray(arr);
        linearSearch.Reverse();
        Console.WriteLine("Tablica po odwróceniu:");
        PrintArray(arr);
    }
    public static void PrintArray(long[] arr)
    {
        foreach (long element in arr)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
    public class ArrayProcessor
    {
        private long[] array;
              
        public ArrayProcessor(long[] array)
        {
            this.array = array;
        }

        // Metoda do znalezienia maksymalnego elementu w tablicy
        /*Zadanie 4 Zaimplementuj algorytm wyszukiwania elementu maksymalnego w tablicy jako metodę: long max();*/
        public long Max()
        {
            if (array == null || array.Length == 0)
            {
                throw new InvalidOperationException("Array is empty or null.");
            }

            long maxElement = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
        }
         /*Zadanie 5 Zaimplementuj algorytm wyszukiwania elementu minimalnego w tablicy jako metodę: long min();*/
        public long Min()
        {
            if (array == null || array.Length == 0)
            {
                throw new InvalidOperationException("Array is empty or null.");
            }

            long minElement = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minElement)
                {
                    minElement = array[i];
                }
            }

            return minElement;
        }        
        /*Zadanie 6 Zaprojektuj i zaimplementuj algorytm, który usuwa określoną wartość z tablicy jako metodę: void remove(long value);*/
        public void Remove(long value)
        {
            // Zliczamy ile razy wartość występuje
            int count = array.Count(x => x == value);

            // Jeśli wartość nie występuje, nie robimy nic
            if (count == 0)
            {
                return;
            }

            // Tworzymy nową tablicę bez tych elementów
            long[] newArray = new long[array.Length - count];
            int index = 0;
            foreach (var element in array)
            {
                if (element != value)
                {
                    newArray[index++] = element;
                }
            }

            // Zastępujemy starą tablicę nową
            array = newArray;
        }
         /*Zadanie  Zaprojektuj i zaimplementuj algorytm, który liczy średnią arytmetyczną elementów nieujemnych w tablicy jako metodę: long average();*/
        public long Average()
        {
            if (array == null || array.Length == 0)
            {
                throw new InvalidOperationException("Array is empty or null.");
            }

            long sum = 0;
            int count = 0;

            foreach (var element in array)
            {
                if (element >= 0)
                {
                    sum += element;
                    count++;
                }
            }

            if (count == 0)
            {
                throw new InvalidOperationException("No non-negative elements in the array.");
            }

            return sum / count; // Wynik jest typu long, więc następuje automatyczne zaokrąglenie
        }
        /*Zadanie 8 Zaprojektuj i zaimplementuj algorytm, który zlicza liczbę elementów parzystych w tablicy jako metodę: int even();*/
        public int Even()
        {
            if (array == null || array.Length == 0)
            {
                throw new InvalidOperationException("Array is empty or null.");
            }

            int count = 0;

            foreach (var element in array)
            {
                if (element % 2 == 0)
                {
                    count++;
                }
            }

            return count;
        }    
        /*Zadanie 9 Zaprojektuj i zaimplementuj algorytm, który zlicza liczbę elementów nieparzystychw tablicy jako metodę: int odd();*/
        public int Odd()
        {
            if (array == null || array.Length == 0)
            {
                throw new InvalidOperationException("Array is empty or null.");
            }

            int count = 0;

            foreach (var element in array)
            {
                if (element % 2 != 0)
                {
                    count++;
                }
            }

            return count;
        }        
        /*10. Zaprojektuj i zaimplementuj algorytm, który zlicza liczbę wystąpień elementu key w tablicy jako metodę: int numberInstances(long key);*/
        public int NumberInstances(long key)
        {
            if (array == null || array.Length == 0)
            {
                throw new InvalidOperationException("Array is empty or null.");
            }

            int count = 0;

            foreach (var element in array)
            {
                if (element == key)
                {
                    count++;
                }
            }

            return count;
        }    
    }
    /*Zadanie 11 Stwórz kolejkę wykorzystując tablicę jako strukturę danych. Zrealizuj operację oczytu pierwszej i ostatniej wartości. Zrealizuj funkcję pop pobierającą wartość zgodnie z LIFO oraz zgodnie z FIFO.*/
    public class ArrayQueue
    {
        private long[] tablica;
        private int rozmiar;
        private int poczatek;
        private int koniec;

        public ArrayQueue(int pojemnosc)
        {
            tablica = new long[pojemnosc];
            rozmiar = 0;
            poczatek = 0;
            koniec = -1;
        }

        public void Enqueue(long wartosc)
        {
            if (rozmiar >= tablica.Length)
            {
                throw new InvalidOperationException("Kolejka jest pełna.");
            }

            koniec = (koniec + 1) % tablica.Length;
            tablica[koniec] = wartosc;
            rozmiar++;
        }

        public long PeekFirst()
        {
            if (rozmiar == 0)
            {
                throw new InvalidOperationException("Kolejka jest pusta.");
            }

            return tablica[poczatek];
        }

        public long PeekLast()
        {
            if (rozmiar == 0)
            {
                throw new InvalidOperationException("Kolejka jest pusta.");
            }

            return tablica[koniec];
        }

        // Metoda FIFO
        public long DequeueFIFO()
        {
            if (rozmiar == 0)
            {
                throw new InvalidOperationException("Kolejka jest pusta.");
            }

            long wartosc = tablica[poczatek];
            poczatek = (poczatek + 1) % tablica.Length;
            rozmiar--;
            return wartosc;
        }

        // Metoda LIFO
        public long DequeueLIFO()
        {
            if (rozmiar == 0)
            {
                throw new InvalidOperationException("Kolejka jest pusta.");
            }

            long wartosc = tablica[koniec];
            koniec = (koniec - 1 + tablica.Length) % tablica.Length;
            rozmiar--;
            return wartosc;
        }
    }
    public class Stos
    {
        private int[] tablica;
        private int pojemnosc;
        private int indeks;

        public Stos(int pojemnosc)
        {
            this.pojemnosc = pojemnosc;
            tablica = new int[pojemnosc];
            indeks = -1;
        }

        public void Push(int wartosc)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Stos jest pełny.");
            }

            tablica[++indeks] = wartosc;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stos jest pusty.");
            }

            return tablica[indeks--];
        }

        public bool IsEmpty()
        {
            return indeks == -1;
        }

        public bool IsFull()
        {
            return indeks == pojemnosc - 1;
        }

        public int GetSize()
        {
            return indeks + 1;
        }

        public int Index()
        {
            return indeks;
        }
    }
    public class SingleNode
    {
        public int Data;
        public SingleNode Next;

        public SingleNode(int data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
    public class SingleLinkedList
    {
        private SingleNode head;

        public SingleLinkedList()
        {
            head = null;
        }

        // Add an element at the start of the list
        public void AddAtStart(int data)
        {
            SingleNode newNode = new SingleNode(data);
            newNode.Next = head;
            head = newNode;
        }

        // Remove the first element of the list
        public void RemoveFromStart()
        {
            if (head != null)
            {
                head = head.Next;
            }
        }

        // Traverse and print the list
        public void Traverse()
        {
            SingleNode current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
    public class DoubleNode
    {
        public int Data;
        public DoubleNode Next;
        public DoubleNode Previous;

        public DoubleNode(int data)
        {
            this.Data = data;
            this.Next = null;
            this.Previous = null;
        }
    }
    public class DoubleLinkedList
    {
        private DoubleNode head;
        private DoubleNode tail;

        public DoubleLinkedList()
        {
            head = null;
            tail = null;
        }

        // Add an element at the start of the list
        public void AddAtStart(int data)
        {
            DoubleNode newNode = new DoubleNode(data);
            newNode.Next = head;
            if (head != null) 
            {
                head.Previous = newNode;
            }
            head = newNode;

            if (tail == null)
            {
                tail = head;
            }
        }

        // Add an element at the end of the list
        public void AddAtEnd(int data)
        {
            if (head == null)
            {
                AddAtStart(data);
                return;
            }

            DoubleNode newNode = new DoubleNode(data);
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }

        // Remove the first element of the list
        public void RemoveFromStart()
        {
            if (head != null)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Previous = null;
                }
                else
                {
                    tail = null;
                }
            }
        }

        // Remove the last element of the list
        public void RemoveFromEnd()
        {
            if (tail != null)
            {
                tail = tail.Previous;
                if (tail != null)
                {
                    tail.Next = null;
                }
                else
                {
                    head = null;
                }
            }
        }

        // Traverse and print the list from the start
        public void TraverseForward()
        {
            DoubleNode current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        // Traverse and print the list from the end
        public void TraverseBackward()
        {
            DoubleNode current = tail;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Previous;
            }
        }
    }
}    