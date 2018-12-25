Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Dep_info")>
Public Class Department
    <Key>
    Public Property DepartId() As Int32
    <Display(Name:="部门")>
    Public Property DepartName() As String

End Class