using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport.Utils;
using FastReport;
using System.Reflection;

namespace UserFunctions
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      RegisterOwnFunctions();
    }

    private void RegisterOwnFunctions()
    {
      RegisteredObjects.AddFunctionCategory("MyFuncs", "My Functions");
      
      // obtain MethodInfo for our functions
      Type myType = typeof(MyFunctions);
      MethodInfo myUpperCaseFunc = myType.GetMethod("MyUpperCase");
      MethodInfo myMaximumIntFunc = myType.GetMethod("MyMaximum", new Type[] { typeof(int), typeof(int) });
      MethodInfo myMaximumLongFunc = myType.GetMethod("MyMaximum", new Type[] { typeof(long), typeof(long) });
      
      // register simple function
      RegisteredObjects.AddFunction(myUpperCaseFunc, "MyFuncs");
      
      // register overridden functions
      RegisteredObjects.AddFunction(myMaximumIntFunc, "MyFuncs,MyMaximum");
      RegisteredObjects.AddFunction(myMaximumLongFunc, "MyFuncs,MyMaximum");
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Report report = new Report();
      report.Design();
      report.Dispose();
    }
  }

  public static class MyFunctions
  {
    /// <summary>
    /// Converts a specified string to uppercase.
    /// </summary>
    /// <param name="s">The string to convert.</param>
    /// <returns>A string in uppercase.</returns>
    public static string MyUpperCase(string s)
    {
      return s == null ? "" : s.ToUpper();
    }

    /// <summary>
    /// Returns the larger of two 32-bit signed integers. 
    /// </summary>
    /// <param name="val1">The first of two values to compare.</param>
    /// <param name="val2">The second of two values to compare.</param>
    /// <returns>Parameter val1 or val2, whichever is larger.</returns>
    public static int MyMaximum(int val1, int val2)
    {
      return Math.Max(val1, val2);
    }

    /// <summary>
    /// Returns the larger of two 64-bit signed integers. 
    /// </summary>
    /// <param name="val1">The first of two values to compare.</param>
    /// <param name="val2">The second of two values to compare.</param>
    /// <returns>Parameter val1 or val2, whichever is larger.</returns>
    public static long MyMaximum(long val1, long val2)
    {
      return Math.Max(val1, val2);
    }
  }
}