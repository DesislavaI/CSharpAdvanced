//Write a program that keeps track of a songs queue. The first song that is put in the queue, should be the first that gets played. A song cannot be added if it is currently in the queue.
//You will be given a sequence of songs, separated by a comma and a single space. After that you will be given commands until there are no songs enqueued. When there are no more songs in the queue print "No more songs!" and stop the program.
//The possible commands are:
//"Play" - plays a song (removes it from the queue)
//"Add {song}" - adds the song to the queue if it isn’t contained already, otherwise print "{song} is already contained!"
//"Show" - prints all songs in the queue separated by a comma and a white space (start from the first song in the queue to the last)
//Input
//On the first line, you will be given a sequence of strings, separated by a comma and a white space
//On the next lines you will be given commands until there are no songs in the queue
//Output
//While receiving the commands, print the proper messages described above
//After the command "Show", print the songs from the first to the last
//Constraints
//The input will always be valid and in the formats described above
//There might be commands even after there are no songs in the queue (ignore them)
//There will never be duplicate songs in the initial queue




using System;
using System.Collections.Generic;

namespace SongsQueue
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] songsList = Console.ReadLine().Split(", ");

			Queue<string> songs = new Queue<string>(songsList);

			string command = "";

			while (songs.Count > 0)
			{
				command = Console.ReadLine();

				string[] details = command.Split();

				if (details[0] == "Play")
				{
					if (songs.Count > 0)
					{
						songs.Dequeue();
					}
					
					
				}
				else if (details[0] == "Add")
				{
					int count = details.Length;
					List<string> songName = new List<string>(details);
					songName.RemoveAt(0);
					string name = String.Join(' ', songName);
					

					if (!songs.Contains(name))
					{
						songs.Enqueue(name);
					}
					else
					{
						Console.WriteLine($"{name} is already contained!");
					}

					
				}
				else if (details[0] == "Show")
				{
					Console.WriteLine(String.Join(", ", songs));
				}
			}

			if(songs.Count == 0)
			{
				Console.WriteLine("No more songs!");
				
			}


		}
	}
}
