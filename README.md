# -Technical-test-TP-Dev-Back-V2


The following points are programming exercises, and these are intended to evaluate the handling of the C# language, by means of .Net Core, as well as its logic when facing some challenges.

1. A purchasing manager needs to buy a certain number of units of an item to replenish the warehouse. The main supplier has a list of containers, each with a number of units. The manager must purchase contiguous containers, starting with container 0 and continuing until at least the desired number has been purchased. If not enough units are available, they should be purchased from another supplier. If any surplus units are to be purchased, they should be resold. Determine the remaining number of units to buy or sell after purchasing from the main supplier.

Example :

n=5

itemCount = [10, 20, 30, 40, 15]

target = 80

The manager starts buying at index 0 and continues until all available units are purchased or until at least 80 units have been purchased. The manager buys containers with itemCounts = 10 + 20 + 30 + 40 + 100.

number sold is purchased - target = 100 - 80 = 20 units.

Complete the restock function in your editor:

public static int restock(List\&lt;Integer\&gt; itemCount, int target) {

// Write your code here

}

In this step the performance of the solution will be evaluated.

1. You need to know the average grades of a classroom, the number of students is &quot;n&quot;, the number of grades collected in the course is 3. Design a program that allows the teacher for each student to enter the 3 grades and show the average of the student and at the end the total average of the classroom.

Note: if you can save student information in a database, preferably SQL Server, it will be a plus

**To be delivered:**

- .Net codes
- Analysis of results
- Data Base Scripts

**What is evaluated:**

- Ability to analyze the problem
- Research capacity
- Recursivity
- .Net Core programming concepts (Best practices, unit testing)
- Data base concepts
- Application security.
