Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("LogLevels")>
Public Class SystemLogLevel
    <Key>
    Public Property LevelId() As Int32
    <Required()>
    Public Property LevelName() As String
End Class