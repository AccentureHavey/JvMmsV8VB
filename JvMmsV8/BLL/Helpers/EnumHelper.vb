Imports System.Reflection

Public Class EnumHelper
    Public Function GetFields(type As Type) As List(Of IEnumerable(Of FieldInfo))
        Dim a = type.GetFields()
        Dim list As New List(Of IEnumerable(Of FieldInfo))
        For Each b In a
            If b.FieldType Is type Then
                list.Add(b)
            End If
        Next
        Return list
    End Function

End Class
