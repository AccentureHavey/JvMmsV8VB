Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("LogObjects")>
Public Class SystemLogObject
    <Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), ScaffoldColumn(False)>
    Public Property ObjectId() As Int32
    <Required>
    Public Property ObjectName() As String

End Class