/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 1");

        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);
        Console.WriteLine("=================");

        // Test 2
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 2");

        var cs2=new CustomerService(2);
        cs2.AddNewCustomer("Ana","101","Problem de login");
        Console.WriteLine(cs2);
        Console.WriteLine("=================");

        Console.WriteLine("Test 3");
        var cs3= new CustomerService(1);
        cs3.AddNewCustomer("Luis","102","Error de pago");
        cs3.AddNewCustomer("Maria","103","Problem of accesso");
        Console.WriteLine(cs3);
        Console.WriteLine("=================");

        Console.WriteLine("Test 4");
        var cs4= new CustomerService(2);
        cs4.ServeCustomer();
        Console.WriteLine("=================");

        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(2);
        cs5.AddNewCustomer("Pedro","104","Problem of passwords");
        cs5.ServeCustomer();
        Console.WriteLine(cs5);
        Console.WriteLine("=================");


    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer(string name, string accountId, string problem) {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

       

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    public void ServeCustomer() {
       if (_queue.Count ==0){
        Console.WriteLine("No sutomers in queue.");
        return;
       }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine("serving" + customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}