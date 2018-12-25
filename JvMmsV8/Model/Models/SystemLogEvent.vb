Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("LogEvents")>
Public Class SystemLogEvent
    <Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), ScaffoldColumn(False)>
    Public Property EvenId() As Int32
    <Required()>
    Public Property EvenName() As String
End Class