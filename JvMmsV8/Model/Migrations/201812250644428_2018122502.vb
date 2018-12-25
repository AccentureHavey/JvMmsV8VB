Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class _2018122502
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropTable("dbo.MyEntities")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.MyEntities",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
    End Class
End Namespace
