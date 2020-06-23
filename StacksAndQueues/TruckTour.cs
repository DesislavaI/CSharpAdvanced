//Suppose there is a circle.There are N petrol pumps on that circle.Petrol pumps are numbered 0 to (N−1) (both inclusive). You have two pieces of information corresponding to each of the petrol pump: (1) the amount of petrol that particular petrol pump will give, and (2) the distance from that petrol pump to the next petrol pump.
//Initially, you have a tank of infinite capacity carrying no petrol.You can start the tour at any of the petrol pumps. Calculate the first point from where the truck will be able to complete the circle.Consider that the truck will stop at each of the petrol pumps. The truck will move one kilometer for each liter of the petrol.
//Input
//The first line will contain the value of N
//The next N lines will contain a pair of integers each, i.e.the amount of petrol that petrol pump will give and the distance between that petrol pump and the next petrol pump
//Output
//An integer which will be the smallest index of the petrol pump from which we can start the tour
//Constraints
//1 ≤ N ≤ 1000001
//1 ≤ Amount of petrol, Distance ≤ 1000000000


using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
	class Program
	{
		static void Main(string[] args)
		{
			Queue<int[]> petrolPumps = new Queue<int[]>();

			int count = int.Parse(Console.ReadLine());

			for (int i = 0; i < count; i++)
			{
				int[] petrolPump = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				petrolPumps.Enqueue(petrolPump);
			}

			int index = 0;

			while (true)
			{
				int totalFuel = 0;

				foreach (var petrolPump in petrolPumps)
				{

					int petrolAmpunt = petrolPump[0];
					int distance = petrolPump[1];

					totalFuel += petrolAmpunt - distance;

					if (totalFuel < 0)
					{
						petrolPumps.Enqueue(petrolPumps.Dequeue());
						index++;
						break;
					}
				}
				if (totalFuel >= 0)
				{
					break;
				}
			}
			Console.WriteLine(index);
		}
	}
}
