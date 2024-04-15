namespace ConsoleApp2
{
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(" Welcome to the Basic Banking Application ");
                Console.WriteLine("------------------");
                Console.Write("Please enter your name: ");
                string name = Console.ReadLine();
                Console.Write("Enter your account number: ");
                int accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your initial deposit: ");
                double initialDeposit = Convert.ToDouble(Console.ReadLine());


                BankAccount account = new BankAccount(name, accountNumber, initialDeposit);
                Console.WriteLine("Account setup successful!\n");

                while (true)
                {
                    account.DisplayMenu();
                    account.RecordTransaction();
                }
            }
        }
        class BankAccount
        {
            private string name;
            private int accountNumber;
            private double balance;
            private double[] transactions = new double[100];
            private int transactionCount = 0;

            public BankAccount(string name, int accountNumber, double initialBalance)
            {
                this.name = name;
                this.accountNumber = accountNumber;
                balance = initialBalance;
            }

            public void Deposit(double amount)
            {
                balance += amount;
                transactions[transactionCount++] = amount;
                Console.WriteLine($"Deposit of {amount:C} successful.");
            }

            public void Withdraw(double amount)
            {
                if (amount > balance)
                {
                    Console.WriteLine("Insufficient funds.");
                }
                else
                {
                    balance -= amount;
                    transactions[transactionCount++] = -amount;
                    Console.WriteLine($"Withdrawal of {amount:C} successful.");
                }
            }

            public void ViewBalance()
            {
                Console.WriteLine($"Current balance: {balance:C}");
            }

            public void ViewTransactionHistory()
            {
                Console.WriteLine("Transaction History:");
                for (int i = 0; i < transactionCount; i++)
                {
                    if (transactions[i] > 0)
                    {
                        Console.WriteLine($"Deposit: {transactions[i]:C}");
                    }
                    else
                    {
                        Console.WriteLine($"Withdrawal: {-transactions[i]:C}");
                    }
                }
            }

            public void DisplayMenu()
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. View Balance");
                Console.WriteLine("4. View Transaction History");
                Console.WriteLine("5. Exit");
            }

            public void RecordTransaction()
            {
                Console.WriteLine("Please select an option:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter deposit amount: ");
                        double depositAmount = Convert.ToDouble(Console.ReadLine());
                        Deposit(depositAmount);
                        break;
                    case "2":
                        Console.Write("Enter withdrawal amount: ");
                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                        Withdraw(withdrawAmount);
                        break;
                    case "3":
                        ViewBalance();
                        break;
                    case "4":
                        ViewTransactionHistory();
                        break;
                    case "5":
                        Console.WriteLine("Thank you for using the Basic Banking Application. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }



    }