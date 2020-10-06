Public Class Form1
    Private Sub RegisterOwnFunctions()
        RegisteredObjects.AddFunctionCategory("MyFuncs", "My Functions")

        ' obtain MethodInfo for our functions
        Dim myType As Type = GetType(MyFunctions)
        Dim myUpperCaseFunc As MethodInfo = myType.GetMethod("MyUpperCase")
        Dim myMaximumIntFunc As MethodInfo = myType.GetMethod("MyMaximum", New Type() {GetType(Integer), GetType(Integer)})
        Dim myMaximumLongFunc As MethodInfo = myType.GetMethod("MyMaximum", New Type() {GetType(Long), GetType(Long)})

        ' register simple function
        RegisteredObjects.AddFunction(myUpperCaseFunc, "MyFuncs")

        ' register overridden functions
        RegisteredObjects.AddFunction(myMaximumIntFunc, "MyFuncs,MyMaximum")
        RegisteredObjects.AddFunction(myMaximumLongFunc, "MyFuncs,MyMaximum")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RegisterOwnFunctions()
    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        Dim report As New Report
        report.Design()
        report.Dispose()
    End Sub
End Class

Public Class MyFunctions
    ''' <summary>
    ''' Converts a specified string to uppercase.
    ''' </summary>
    ''' <param name="s">The string to convert.</param>
    ''' <returns>A string in uppercase.</returns>
    Public Shared Function MyUpperCase(ByVal s As String) As String
        Return IIf((s Is Nothing), "", s.ToUpper)
    End Function

    ''' <summary>
    ''' Returns the larger of two 32-bit signed integers. 
    ''' </summary>
    ''' <param name="val1">The first of two values to compare.</param>
    ''' <param name="val2">The second of two values to compare.</param>
    ''' <returns>Parameter val1 or val2, whichever is larger.</returns>
    Public Shared Function MyMaximum(ByVal val1 As Integer, ByVal val2 As Integer) As Integer
        Return Math.Max(val1, val2)
    End Function

    ''' <summary>
    ''' Returns the larger of two 64-bit signed integers. 
    ''' </summary>
    ''' <param name="val1">The first of two values to compare.</param>
    ''' <param name="val2">The second of two values to compare.</param>
    ''' <returns>Parameter val1 or val2, whichever is larger.</returns>
    Public Shared Function MyMaximum(ByVal val1 As Long, ByVal val2 As Long) As Long
        Return Math.Max(val1, val2)
    End Function
End Class

