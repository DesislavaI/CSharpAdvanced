//Our favorite super-spy action hero Sam is back from his mission in the previous exam, and he has finally found some time to go on a holiday.He is taking his wife somewhere nice and they’re going to have a really good time, but first, they have to get there.Even on his holiday trip, Sam is still going to run into some problems and the first one is, of course, getting to the airport. Right now, he is stuck in a traffic jam at a very active crossroads where a lot of accidents happen.
//Your job is to keep track of traffic at the crossroads and report whether a crash happened or everyone passed the crossroads safely and our hero is one step closer to a much desired vacation.
//The road Sam is on has a single lane where cars queue up until the light goes green. When it does, they start passing one by one during the green light and the free window before the intersecting road’s light goes green. During one second only one part of a car (a single character) passes the crossroads.If a car is still in the crossroads when the free window ends, it will get hit at the first character that is still in the crossroads.
//Input
//On the first line, you will receive the duration of the green light in seconds – an integer in the range [1-100]
//On the second line, you will receive the duration of the free window in seconds – an integer in the range [0-100]
//On the following lines, until you receive the "END" command, you will receive one of two things:
//A car – a string containing any ASCII character, or
//The command "green" which indicates the start of a green light cycle
//A green light cycle goes as follows:
//During the green light cars will enter and exit the crossroads one by one
//During the free window cars will only exit the crossroads
//Output
//If a crash happens, end the program and print:
//"A crash happened!"
//"{car} was hit at {characterHit}."
//If everything goes smoothly and you receive an "END" command, print:
//"Everyone is safe."
//"{totalCarsPassed} total cars passed the crossroads."
//Constraints
//The input will be within the constaints specified above and will always be valid.There is no need to check it explicitly.

using System;
using System.Collections.Generic;

namespace Crossroads
{
	class Program
	{
		static void Main(string[] args)
		{
			int greenLight = int.Parse(Console.ReadLine());
			int freeWindow = int.Parse(Console.ReadLine());

			string command = Console.ReadLine(); ;

			int count = 0;

			bool isHitted = false;
			string hittedCarName = "";
			char hittedSymbol = '\0';

			Queue<string> cars = new Queue<string>();

			while (command != "END")
			{
				if (command != "green")
				{
					cars.Enqueue(command);
					command = Console.ReadLine();
					continue;
				}

				int currentGreenLightDuration = greenLight;

				while (currentGreenLightDuration > 0 && cars.Count > 0)
				{
					string carName = cars.Dequeue();
					int carLength = carName.Length;

					if (currentGreenLightDuration - carLength >= 0)
					{
						currentGreenLightDuration -= carLength;
						count++;
					}
					else
					{
						currentGreenLightDuration += freeWindow;

						if (currentGreenLightDuration - carLength >= 0)
						{
							count++;
							break;
						}
						else
						{
							isHitted = true;
							hittedCarName = carName;
							hittedSymbol = carName[currentGreenLightDuration];
							break;
						}
					}
				}
				if (isHitted)
				{
					break;
				}
				command = Console.ReadLine();
			}
			if (isHitted)
			{
				Console.WriteLine("A crash happened!");
				Console.WriteLine($"{hittedCarName} was hit at {hittedSymbol}.");
			}
			else
			{
				Console.WriteLine("Everyone is safe.");
				Console.WriteLine($"{count} total cars passed the crossroads.");
			}
		}
	}
}
