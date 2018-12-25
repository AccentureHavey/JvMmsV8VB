
Imports BLL
Imports Model
Imports WebMatrix.WebData

Public Class JvDatabaseSeed
    Public Shared Sub Seeds(context As JvDBContext)
        ''初始化数据库
        WebSecurity.CreateUserAndAccount("admin", "admin", New With {.RealName = "admin", .State = EnumTypes.AccountState.Normal})
        Roles.AddUsersToRole(New String() {"admin"}, "管理员")
    End Sub
End Class
