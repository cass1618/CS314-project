using System.Globalization;

namespace CS314Project;

    class Record
    {
        public DateTime RecordCreated;
        public DateOnly ServiceDate;
        public int ProviderNumber;
        public int MemberNumber;
        public int ServiceCode;

        //prompts and validates user input, returns record
        public Record()
        {
            RecordCreated = DateTime.Now;
            while(ServiceDate == DateOnly.MinValue)
            {
                Console.Write("Enter Date of Service (MM-DD-YYYY): ");
                string? input = Console.ReadLine();
                Console.WriteLine(input);
                if(DateOnly.TryParseExact(
                    input,
                    "MM-dd-yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateOnly date
                ))
                {
                    ServiceDate = date;
                }
                else Console.WriteLine("Please enter a valid date.");
            }
            //prompt user until a valid integer is entered
            while(ProviderNumber == 0)
            {
                Console.Write("Enter Provider Number: ");
                string? input = Console.ReadLine();
                if(int.TryParse(input, out int number)) ProviderNumber = number;
                else Console.WriteLine("Invalid input. Please enter a valid Provider Number.");
            }
            while(MemberNumber == 0)
            {
                Console.Write("Enter Member Number: ");
                string? input = Console.ReadLine();
                if(int.TryParse(input, out int number)) MemberNumber = number;
                else Console.WriteLine("Invalid input. Please enter a valid Member Number.");
            }
            while(ServiceCode == 0)
            {
                Console.Write("Enter Service Code: ");
                string? input = Console.ReadLine();
                if(int.TryParse(input, out int number)) ServiceCode = number;
                else Console.WriteLine("Invalid input. Please enter a valid Service Code.");
            }
        }

        //displays all data of a record object
        public void DisplayRecord()
        {
            Console.WriteLine($"\nRecord created: {RecordCreated}");
            Console.WriteLine($"Date of Service: {ServiceDate}");
            Console.WriteLine($"Provider Number: {ProviderNumber}");
            Console.WriteLine($"Member Number: {MemberNumber}");
            Console.WriteLine($"Service Code: {ServiceCode}");
        }
    }
