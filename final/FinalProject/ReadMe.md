# Personal Debt and Budget Manager

This is my final project for my C# Programming with Classes course. I wanted to build a tool that helps track personal finances but specifically focuses on paying off debts. 

## What it does
The program is a console app that lets you:
1. View a list of current debts (like credit cards or loans).
2. Make payments toward a specific debt. The program automatically subtracts that payment from the balance so you can see it go down.
3. Track income and general expenses.
4. View a full history of every transaction you have made.

## How to use it
When you start the program, it shows a main menu with 6 options. You just type the number for what you want to do.
* If you choose to pay a debt, the program asks for the ID number of the debt. I made it show the ID numbers next to the debts so you don't have to guess.
* All history is saved in a list while the program is running so you can check your work.

## Core Principles Used
I used all four principles from class:
* **Abstraction**: I made a base class for Transactions so I didn't have to rewrite code for dates and amounts every time.
* **Encapsulation**: I kept the debtor balances private so they can only be changed by the Pay method.
* **Inheritance**: My Income, Expense, and DebtPayment classes all inherit from the Transaction class.
* **Polymorphism**: I used a virtual Show method so the history list knows exactly how to print each different type of transaction.