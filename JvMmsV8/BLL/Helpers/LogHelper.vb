Imports System.Runtime.InteropServices.WindowsRuntime
Imports Model

Public Class LogHelper
    Public Shared Function Log(db As JvDBContext, userName As String, logLevel As EnumTypes.LogLevelType, logEvent As EnumTypes.LogEvenType, message As String) As Boolean
        Try
            Dim u = db.Users.Single(Function(a) a.UsName = userName)
            Dim l = db.LogLevels.Find(CInt(Math.Truncate(logLevel)))
            Dim e = db.LogEvents.Find(CInt(Math.Truncate(logEvent)))
            db.Logs.Add(New SystemLog() With {.User = u, .Time = DateTime.Now, .Level = l, .Events = e, .Text = message})
            db.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
