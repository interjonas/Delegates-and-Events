using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public delegate void stringDelegate();

class LR4
{
	public static event stringDelegate evenEvent;
	public static event stringDelegate oddEvent;
	public static event stringDelegate zeroEvent;

	static void Main(string[] args)
	{
		int[] array = new int[50];
		Random rnd = new Random();
		for(int i=0;i<array.Length;i++)
		{
			array[i]=rnd.Next(0,11);
		}
		Stats st = new Stats();
		evenEvent += new stringDelegate(st.incrementEven);
		oddEvent += new stringDelegate(st.incrementOdd);
		zeroEvent += new stringDelegate(st.incrementZero);

		for(int i=0; i<array.Length; i++)
		{
			int val = array[i];
			if(val==0)
			{
				zeroEvent();
			}
			else if(val%2 !=0)
			{
				oddEvent();
			}
			else if( (val%2==0) && (val!=0) )
			{
				evenEvent();
			}		
		}
		st.results();
	}
}
class Stats
{
	private int evenInt,oddInt,zeroInt;
	public Stats()
	{
		evenInt=0;
		oddInt=0;
		zeroInt=0;
	}
	public void incrementEven()
	{
		evenInt++;
	}
	public void incrementOdd()
	{
		oddInt++;
	}
	public void incrementZero()
	{
		zeroInt++;
	}
	public void results()
	{
		Console.WriteLine("# OF EVEN:\t" + evenInt);
		Console.WriteLine("# OF ODD:\t" + oddInt);
		Console.WriteLine("# OF ZEROS:\t" + zeroInt);
	}
}
