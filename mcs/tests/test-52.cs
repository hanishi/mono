//
// Tests the foreach on strings, and tests the implicit use of foreach
// to pull the enumerator from the class and identify the pattern to be called
//
using System;
using System.Collections;

class Y {
	int count = 0;
	
	public bool MoveNext ()
	{
		count++;
		return count != 10;
	}
	
	public object Current {
		get {
			return count;
		}
	}
}

class X {

	static string [] a = {
		"one", "two", "three"
	};

	public Y GetEnumerator ()
	{
		return new Y ();
	}
	
	static int Main ()
	{
		//
		// String test
		//
		string total = "";
		
		foreach (string s in a){
			total = total + s;
		}
		if (total != "onetwothree")
			return 1;

		//
		// Pattern test
		//
		X x = new X ();

		int t = 0;
		foreach (object o in x){
			t += (int) o;
		}
		if (t != 45)
			return 2;

		//
		// Looking for GetEnumerator on interfaces test
		//
		Hashtable xx = new Hashtable ();
		xx.Add ("A", 10);
		xx.Add ("B", 20);

		IDictionary vars = xx;
		string total2 = "";
		foreach (string name in vars.Keys){
			total2 = total2 + name;
		}

		if (total2 != "AB")
			return 3;

		Console.WriteLine ("test passes");
		return 0;
	}
}
