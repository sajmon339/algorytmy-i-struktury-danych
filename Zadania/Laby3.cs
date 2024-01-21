public class Laby3
{

    public static void zadanie1()
    {
        Console.WriteLine("Enter directory path: ");
        var path=Console.ReadLine();
        
        if(Directory.Exists(path))
        {
            Console.WriteLine("Directory Tree for " + path + ":");
            ListDirectories(path, "");
        
        }
    }
    static void ListDirectories(string directoryPath, string prefix)
    {
        try
        {
            string[] directories = Directory.GetDirectories(directoryPath);

            for (int i = 0; i < directories.Length; i++)
            {
                string directory = directories[i];
                bool isLast = i == directories.Length - 1;

                Console.WriteLine(prefix + (isLast ? "└── " : "├── ") + Path.GetFileName(directory));
                ListDirectories(directory, prefix + (isLast ? "    " : "│   "));
            }

            string[] files = Directory.GetFiles(directoryPath);
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                bool isLast = i == files.Length - 1;

                Console.WriteLine(prefix + (isLast ? "└── " : "├── ") + Path.GetFileName(file));
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine(prefix + "├── Access Denied");
        }
        catch (Exception ex)
        {
            Console.WriteLine(prefix + "├── Error: " + ex.Message);
        }
    }
 
}




    