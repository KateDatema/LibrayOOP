﻿
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LibraryOOP
{

    class Book
    {
        
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

        public Book(string title, string author, string status, DateTime date)
        {
            Title = title;
            Author = author;
            Status = status;
            Date = date;
        }

        public void ReturnInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.WriteLine("Information on "+ Title);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("Title  \t\t\t\t Author \t\t\t\t Status");
            Console.WriteLine(Title + " \t\t" + Author + "\t\t\t" + Status);
            Console.WriteLine(" ");
        }

        public virtual string Checkout()
        {
            checkStatus();
            string checkingOut;
            if (Status == "OnShelf")
            {
                Date = DueDate();
                checkingOut = $"You have checked out {Title}, Please Return it by {Date}.";

            }
            else if (Status == "CheckedOut")
            {
                checkingOut=$"Sorry, this book is currently check out, it should be available after {Date}";

            }
            else
            {
                checkingOut = $"Sorry, this book is currently overdue! Please choose another one and check back later for this book";
            }
            return checkingOut;

        }

        public virtual DateTime DueDate()
        {
            DateTime dueDate = DateTime.Now.AddDays(14);
            Date = dueDate;
            return Date;
        }

        public virtual DateTime Return()
        {
            checkStatus();
            if (Status == "CheckedOut")
            {
                Console.WriteLine("Thank you for returning your book");
                DateTime returnDate = new DateTime(0001, 01, 01);
                Date = returnDate; 
            }
            else if (Status == "Overdue!")
            {
                DateTime current = DateTime.Now;
                String diff = (current - Date).TotalDays.ToString();
                double diffNum = Convert.ToInt64(Math.Round(Convert.ToDouble(diff)));
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"The book that you are returning is overdue by {diffNum} days!");
                double fines = diffNum * 5;
                DateTime returnDate = new DateTime(0001, 01, 01);
                Date = returnDate;

            }

            else
            {
                Console.WriteLine("This book is not currently Checked out!");
            }
          
            return Date;

        }

        public virtual string checkStatus()
        {
            DateTime current = DateTime.Now;
            DateTime returnDate = new DateTime(0001, 01, 01);
            if (Date > current)
            {
                Status = "CheckedOut";
            }
            else if (Date < current && Date != returnDate)
            {
                Status = "Overdue!";
            }
            else
            {
                Status = "OnShelf";
            }

            return Status;
        }

    }

}
