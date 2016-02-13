using System;
using System.Numerics;
using System.IO;

class Central{
	static BigInteger MFac(uint rage, uint depth){
		BigInteger ixy = 1;
		for (uint w = 1; w <= rage; w++){
			if (depth > 1){
				ixy *= MFac(w, depth - 1);
			}
			else{
				ixy *= (BigInteger)(w);
			}
		}
		return ixy;
	}
	
	static void Main(string[] args){
		Console.WriteLine("M: Multiple-level factorial\nF: Factorial (1-level factorial)\n" +
						  "S: Superfactorial (2-level factorial)\nH: Superduperfactorial (3-level factorial)");
		BigInteger res;
		string victim;
		uint mlevel;
		switch (Console.ReadKey(true).Key){
			case ConsoleKey.M:
				Console.Write("Type M value:");
				mlevel = uint.Parse(Console.ReadLine());
				Console.Write("Type factorial value:");
				victim = Console.ReadLine();
				res = MFac(uint.Parse(victim), mlevel);
				Console.WriteLine(mlevel.ToString() + "-level Factorial of " + victim + " equals to " + res);
				Console.WriteLine("Length: " + res.ToString().Length + " digits");
				break;
			case ConsoleKey.F:
				mlevel = 1;
				Console.Write("Factorial of ");
				victim = Console.ReadLine();
				res = MFac(uint.Parse(victim), mlevel);
				Console.WriteLine("Factorial of " + victim + " equals to " + res);
				Console.WriteLine("Length: " + res.ToString().Length + " digits");
				break;
			case ConsoleKey.S:
				mlevel = 2;
				Console.Write("Superfactorial of ");
				victim = Console.ReadLine();
				res = MFac(uint.Parse(victim), mlevel);
				Console.WriteLine("Superfactorial of " + victim + " equals to " + res);
				Console.WriteLine("Length: " + res.ToString().Length + " digits");
				break;
			case ConsoleKey.H:
				mlevel = 3;
				Console.Write("Superduperfactorial of ");
				victim = Console.ReadLine();
				res = MFac(uint.Parse(victim), mlevel);
				Console.WriteLine("Superduperfactorial of " + victim + " equals to " + res);
				Console.WriteLine("Length: " + res.ToString().Length + " digits");
				break;
			default: 
				Console.WriteLine("Wrong mode");
				Console.ReadLine();
				return;
		}
		
		if (res == null)
			goto DENGO;//Velociraptor attacked me when I wrote this line. WHAT THE HAY IS GOING ON?!
		do {
			Console.WriteLine();
			Console.Write("Save result to file? Y/N");
			ConsoleKey _key = Console.ReadKey(true).Key;
			if (_key == ConsoleKey.Y){
				Console.WriteLine();
				Console.Write("Type output filename: ");
				string _fn = Console.ReadLine();
				File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + _fn + ".out",
								  mlevel.ToString() + "-level Factorial of " + victim + " equals to " + res + "\n" +
								  "Length: " + res.ToString().Length + " digits");
				Console.Write("Saved to " + Directory.GetCurrentDirectory() + "\\" + _fn + ".out");
				break;
			} else if (_key == ConsoleKey.N)
				break;
		}while(true);
		Console.WriteLine();
		DENGO:
		Console.WriteLine("Daww. I did it, M-master. You're happy, aren't you? ^^");
		Console.ReadLine();
	}
}