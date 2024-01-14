# LongSchlong

LongSchlong is a custom datatype that can calculate with any length of numbers.

## Example
```cs
// Create LongSchlong instances
LongSchlong num1 = new LongSchlong("123456789012345678901234567890");
LongSchlong num2 = new LongSchlong("987654321098765432109876543210");

// Add the numbers
LongSchlong result = num1 + num2;

// Print the result
Console.WriteLine($"Result: {result}");
```

## How it works:
When a string with numbers gets passed to the constructor it gets converted to a byte array.
When the add operator gets called you get two LongSchlongs. The first and the one that gets added to the first.
Then it backward iterates through the larger byte array and calculates the last number with the second last number of the array. 
When the numbers have different lengths it gets the last item from the array which represents the first number so it shifts the array.
Then it adds the last number from the first array with the last number from the second array. If the number is larger than 10 it stores the carry and adds it to the next calculation.
It works like simple math in the following.

```
  123123213132123
+ 521312312312312
-----------------
               35
```
