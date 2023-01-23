﻿using System.Diagnostics;

using static System.Console;

int a = 10; // 00001010
int b = 6; //  00000110

WriteLine($"a = {a}");
WriteLine($"b = {b}");
WriteLine($"a & b = {a & b}");  // 2-bit column only
WriteLine($"a | b = {a | b}");  // 8, 4 and 2-bit columns
WriteLine($"a ^ b = {a ^ b}");  // 8 and 4-bit columns

// 01010000 Left-shift a by three bit columns
WriteLine($"a << 3 = {a << 3}");

// Multiply a by 8
WriteLine($"a * 8 = {a * 8}");

// 0000011 Reft-shift b by one bit columns
WriteLine($"b >> 1 = {b >> 1}");

WriteLine();
WriteLine("Outputting integers as binary:");
WriteLine($"a = {ToBinaryString(a)}");
WriteLine($"b = {ToBinaryString(b)}");
WriteLine($"a & b = {ToBinaryString(a & b)}");
WriteLine($"a | b = {ToBinaryString(a | b)}");
WriteLine($"a ^ b = {ToBinaryString(a ^ b)}");

// Function to convert an integer value into a binary (Base2) string
static string ToBinaryString(int value)
{
    return Convert.ToString(value, toBase: 2).PadLeft(8, '0');
}