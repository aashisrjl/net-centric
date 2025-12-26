//async programming 
// A programming model that allows a program to perform other 
// tasks while waiting for long-running operations to complete

 static async Task Main()
    {
        Console.WriteLine("Before calling asynchronous method");
        
        string result = await GetDataAsync();

        Console.WriteLine($"Result: {result}");
        Console.WriteLine("After calling asynchronous method");
    }

    static async Task<string> GetDataAsync()
    {
        Console.WriteLine("before async");
        await Task.Delay(2000); // Simulate async work (e.g., API call)
        return "Hello from async method!";
    }
    Main();


//delegates and events
// delegates are type-safe function pointers in C#


