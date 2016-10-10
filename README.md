# Assignment 3 - Inheritance, Abstract Classes, Interfaces, and Polymorphism
## Due: 10-18-2016

## Author
Jeffrey Martin


## Description

The Jawas on Tatooine have recently opened a droid factory and they want to hire you to write a program to hold a list of the available droids, and the price of each droid. The price is based on the type: (protocol, utility, janitor, or astromech), the material used and the options selected by the Jawa creating the list.

The program will keep a list of Droids that are created. This list can be either an array or in the form of one of the C# List classes. The array or list should be of a type that is high enough on the inheritance chain that all droids no matter what type they are can be stored in it. (Think Polymorphism)

A Jawa will be presented with a user interface to add a new Droid, or print the current Droid list. Adding a new Droid will require input from the Jawa to create the new droid. Once all of the needed information is added for the droid, the new droid will be added to the list.

If a Jawa decides to print the list of droids in inventory, the program should loop through all of the droids in the list and print out the information from ToString, and the TotalCost for each droid. This should be accomplished using Polymorphism to reduce the amount of code needed.

All of the prices for the various aspects of a droid are left up to you to determine. If I was doing it though, I would probably have a small set price for each of the following general options, and not get too specific to save time. ie:
1. A price for model(protocol, utility, etc.)
2. A few different materials (Something Made up), each with a differnet price
3. A price for each additional option (One of the various option bools listed below. One price for all will work)
4. A price per quantity option such as: numberOfLanguages, and numberOfShips

The program comes with an Interface IDroid that must be implemented by subclasses. It contains a public method called CalculateTotalCost, and a public Property called TotalCost. CalculateTotalCost returns a void, so it's job is to access the properties of the droid and literally calculate the total cost.
TotalCost is how you will get access to the total cost of the droid. This will be zero until CalculateTotalCost is called. Then it will have a value.
I didn't make CalculateTotalCost return the calculated value because I wanted you to have to implement both a method and a property in subclasses.

The program should have a base abstract class called Droid with the following variables, properties, constructors, methods, etc that implements the IDroid interface.

Droid:
* Variables: material (string), model (string), color (string), baseCost (decimal), totalCost (decimal)
* Constructors: 3 parameter constructor (string, string, string)
* Property: TotalCost to return the cost of the droid (Required by the interface)
* Methods:
	* ToString: return a formatted string containing the variables
	* CalculateBaseCost: Determines the baseCost based on material and type.
	* CalculateTotalCost: assigns baseCost to totalCost (Required by the interface)

There should be two derived classes from the abstract class Droid with appropriate variables, methods and properties.

Protocol:
* Variables: numberLanguages (int)
* Constant: costPerLanguage
* Constructors: 4 parameter constructor (string, string, string, int)
	* Uses the base class (Droid) constructor
* Methods:
	* ToString: return a formatted string containing the variables
	* CalculateTotalCost: Calculate the totalCost based on the number of languages and adds it to the base totalCost

Utility:
* Variables: toolbox (bool), computerConnection (bool), arm (bool)
* Constructors: 6 parameter constructor (string, string, string, bool, bool, bool)
	* Uses the base class (Droid) constructor
* Methods:
	* ToString: return a formatted string containing the variables
	* CalculateTotalCost: Calculates totalCost by calculating the cost of each selected option and add it to the base totalCost.

There should be two more derived classes from the class Utility with appropriate variables, methods and properties.

Janitor:
* Variables: trashCompactor (bool), vacuum (bool)
* Constructors: 8 parameter constructor (string, string, string, bool, bool, bool, bool, bool)
	* Uses the base class (Utility) constructor
* Methods:
	* ToString: return a formatted string containing the variables
	* CalculateTotalCost: Calculate totalCost by calculating the cost of each selected option and adds it to the base totalCost

Astromech:
* Variables: fireExtinquisher (bool), numberShips (int)
* Constant: costPerShip
* Constructors: 8 parameter constructor (string, string, string, bool, bool, bool, bool, int)
	* Uses the base class (Utility) constructor
* Methods:
	* ToString: return a formatted string containing the variables
	* CalculateTotalCost: Calculate totalCost by calculating the cost of each selected option and the cost based on the number of ships and adds both to the base CalculateTotalCost

You should put all of your UI into a UI class that will handle getting all of the necessary information from the Jawa, and display the feedback to the Jawa.

You should create a class for the collection of the Droids. It should have an add method that will do the work of determining which instance of a droid needs to be created and added to the array. The UI class will prompt for the needed information to add a droid, and then when it has all of the info, it will send it to the add method, which will then determine which type to add based on the 'model' that was entered. The add method might be a good place to do method overloading, though not required.

You should follow the concepts about inheritance talked about in class, and work hard at DRY (Don't Repeat Yourself) Principles.

Solution Must:
* Create abstract class Droid that implements IDroid
* Derive two classes (Protocol and Utility) from the class Droid
* Derive two classes (Janitorial and Astromech) from the class Utility
* Each derived class must either implement or override the ToString and CalculateTotalCost methods
* Create a UI class
* Create a DroidCollection class
* Use private, public and protected appropriately.
* Use abstract, virtual, and override appropriately.
* Have sufficient comments about what you are doing in the code.

### Notes

If you did not do well on Assignment 1, you may want to look at the Assignment 1 Key that I did for some help related to UI classes, Collection classes, arrays, and structure.

It may be beneficial for you to create extra methods within the droid sub classes. You are not limited to the ones mentioned. You may even find it useful to make some additional ones that are protected and virtual.

## Grading
| Feature                    | Points |
| -------------------------- | ------ |
| Droid Class                | 10     |
| Protocol / Utility         | 15     |
| Janitor / Astromech        | 15     |
| ToString / Total Cost      | 10     |
| UI Class                   | 10     |
| Droid Collection           | 10     |
| Add Droid / Print List     | 10     |
| Access Modifiers Correct   | 5      |
| Abstract / Virtual Correct | 5      |
| Documentation              | 5      |
| README                     | 5      |
| Total                      | 100    |

## Outside Resources Used
None -


## Known Problems, Issues, And/Or Errors in the Program
None