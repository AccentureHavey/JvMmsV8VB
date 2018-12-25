Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class _20181225
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Us_Info", "State", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Us_Info", "State", Function(c) c.Int(nullable := False))
        End Sub
    End Class
End Namespace
