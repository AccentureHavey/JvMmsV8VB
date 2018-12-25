Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Threading
Imports Model
Imports WebMatrix.WebData

<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method, AllowMultiple:=False, Inherited:=True)>
Public NotInheritable Class InitializeSimpleMembershipAttribute
    Inherits ActionFilterAttribute

    Private Shared _initializer As SimpleMembershipInitializer
    Private Shared _initializerLock As New Object
    Private Shared _isInitialized As Boolean

    Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)
        ' Ensure ASP.NET Simple Membership is initialized only once per app start
        LazyInitializer.EnsureInitialized(_initializer, _isInitialized, _initializerLock)
    End Sub

    Private Class SimpleMembershipInitializer
        Public Sub New()
            Database.SetInitializer(Of JvDBContext)(Nothing)
            Dim init As Boolean = False
            Try
                Using context As New JvDBContext()
                    If Not context.Database.Exists() Then
                        ' Create the SimpleMembership database without Entity Framework migration schema
                        CType(context, IObjectContextAdapter).ObjectContext.CreateDatabase()
                        init = True
                    End If
                End Using
                WebSecurity.InitializeDatabaseConnection("JvMmsV8", "Us_Info", "UsId", "UsName", autoCreateTables:=True)
                If (init) Then
                    Using context = New JvDBContext
                        ''初始化数据库数据
                        JvDatabaseSeed.Seeds(context)
                    End Using
                End If
            Catch ex As Exception
                Throw New InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex)
            End Try
        End Sub
    End Class
End Class
