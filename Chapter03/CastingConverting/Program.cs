using static System.Console;

// ----------- Casting numbers implicitly and explicitly
int a = 10;
double b = a; // an int can be safely cas into a double
WriteLine(b);

double c = 9.8;
int d = (int)c;
WriteLine(d);

long e = 5_000_000_000;
int f = (int)e;
WriteLine($"e is {e:N0} and f is {f:N0}");

e = long.MaxValue;
f = (int)e;
WriteLine($"e is {e:N0} and f is {f:N0}");

// ------------ Converting with the System.Convert type