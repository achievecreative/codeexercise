using System;

int n = 7;

int k = 30;

var array = new int[n];

for (var i = 0; i < n; i++)
{
    array[i] = i + 1;
}

var steps = k % n;

var tempArray = new int[n];

for (var i = 0; i < array.Length; i++)
{
    var newIndex = (i + steps) % n;

    tempArray[newIndex] = array[i];
}

Console.WriteLine(string.Join(", ", tempArray));