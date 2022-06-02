using System;

namespace Lab1_Task2
{
    public class Task2_Account
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("===== Test for Account Class ====");
            Console.WriteLine("");

            Account saving1 = new Account();
            Console.WriteLine("===== Account with zero balance (Step 4) ======");
            Console.WriteLine("Balance: " + saving1.getBalance());
            Console.WriteLine("");


            Account saving2 = new Account(1000);
            Console.WriteLine("===== Account with initial balance (Step 3) ======");
            Console.WriteLine("Balance: " + saving2.getBalance());
            Console.WriteLine("");

            Console.WriteLine("===== Deposit 500 to the zero balance account (Step 2) ======");
            saving1.addMoney(500);
            Console.WriteLine("Balance: " + saving1.getBalance());
            Console.WriteLine("");

            Console.WriteLine("===== Withdraw 200 from 500 balance account (Step 2) ======");
            saving1.withdrawMoney(200);
            Console.WriteLine("Balance: " + saving1.getBalance());
            Console.WriteLine("");

            Console.WriteLine("===== Withdraw 400 from 300 balance account (Step 2) ======");
            saving1.withdrawMoney(400);
            Console.WriteLine("Balance: " + saving1.getBalance());
            Console.WriteLine("");

            Console.WriteLine("===== Calculate interest (rate=10 & years=2) for 1K balance account (Step 5) ======");
            double int1 = Math.Round(saving2.getInterest(10, 2), 2);
            Console.WriteLine("Interest: " + int1);
            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("===== Test for Bank Class ====");
            Console.WriteLine("");
            Bank bank = new Bank();

            Console.WriteLine("====== Deposit 150 to savings and 240 to checking A/C ======");            
            bank.deposit(150, "savings");
            bank.deposit(240, "checking");
            bank.printBalances();
            Console.WriteLine("");

            Console.WriteLine("====== Withdraw 50 from savings and 40 from checking A/C ======");
            bank.withdraw(50, "savings");
            bank.withdraw(40, "checking");
            bank.printBalances();
            Console.WriteLine("");

            Console.WriteLine("====== Transfer 50 from savings to checking A/C ======");
            bank.transfer(50, "savings");
            bank.printBalances();
            Console.WriteLine("");

            Console.WriteLine("====== Transfer 100 from checking to savings A/C ======");
            bank.transfer(100, "checking");
            bank.printBalances();
        }

        public class Account
        {
            //Step 1 - Account class with balance field
            private double balance;

            //Step 2 - Method to deposit/add money
            public void addMoney(double amount)
            {
                if (amount > 0)
                    balance += amount;
                else
                    Console.WriteLine("Incorrect Amount");
            }

            //Step 2 - Method to withdraw money.
            //If else to check sufficient fund before withdrawal
            public void withdrawMoney(double amount)
            {
                if (balance > amount)
                    balance -= amount;
                else
                    Console.WriteLine("Insufficient Fund!");
            }

            //Step 2 - Method to do a balance inquiry
            //this keyword to pass the value outside the class
            public double getBalance()
            {
                return this.balance;
            }

            //Step 3 - pass a value into a constructor to set an initial balance
            //Constructor has the same name as class
            public Account(double Balance)
            {
                this.balance = Balance;
            }

            //Step 4 - Initial balance to zero
            // If no value is passed
            public Account()
            {
                balance = 0;
            }


            //Step 5 - compute interest on the current balance
            //Calculated as compunded interest [Balance*(1+rate/100)^NoOfYears]

            double interest = 0;
            public double getInterest(double rate, double years)
            {
                interest = this.balance * Math.Pow(1 + rate / 100, years);
                return this.interest;
            }
        }

        public class Bank
        {
            // Create 2 objects using reference class Account
            Account checking;
            Account savings;

            public Bank()
            {
                checking = new Account();
                savings = new Account();
            }

            //Step 1 - deposit Method
            public void deposit(double amount, string account)
            {
                if (account == "savings")
                    savings.addMoney(amount);
                else if (account == "checking")
                    checking.addMoney(amount);
            }

            //Step 2 - withdraw Method
            public void withdraw(double amount, string account)
            {
                if (account == "savings")
                    savings.withdrawMoney(amount);
                else if (account == "checking")
                    checking.withdrawMoney(amount);
            }

            //Step 3 - transfer Method
            //Transfer from user provided account to the other
            public void transfer(double amount, string account)
            {
                if (account == "savings")
                {
                    savings.withdrawMoney(amount);
                    checking.addMoney(amount);
                }
                else if (account == "checking")
                {
                    checking.withdrawMoney(amount);
                    savings.addMoney(amount);
                }

            }

            //Step 4 - Print Balance
            public void printBalances()
            {
                Console.WriteLine("Savings: " + savings.getBalance());
                Console.WriteLine("Checking: " + checking.getBalance());                
            }

        }
    }
}