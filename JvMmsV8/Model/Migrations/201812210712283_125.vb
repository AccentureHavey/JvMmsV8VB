Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class _125
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Logs",
                Function(c) New With
                    {
                        .LogId = c.Int(nullable := False, identity := True),
                        .Time = c.DateTime(nullable := False),
                        .Text = c.String(),
                        .Events_EvenId = c.Int(),
                        .Level_LevelId = c.Int(),
                        .Objects_ObjectId = c.Int(),
                        .User_UsId = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.LogId) _
                .ForeignKey("dbo.LogEvents", Function(t) t.Events_EvenId) _
                .ForeignKey("dbo.LogLevels", Function(t) t.Level_LevelId) _
                .ForeignKey("dbo.LogObjects", Function(t) t.Objects_ObjectId) _
                .ForeignKey("dbo.Us_Info", Function(t) t.User_UsId) _
                .Index(Function(t) t.Events_EvenId) _
                .Index(Function(t) t.Level_LevelId) _
                .Index(Function(t) t.Objects_ObjectId) _
                .Index(Function(t) t.User_UsId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Logs", "User_UsId", "dbo.Us_Info")
            DropForeignKey("dbo.Logs", "Objects_ObjectId", "dbo.LogObjects")
            DropForeignKey("dbo.Logs", "Level_LevelId", "dbo.LogLevels")
            DropForeignKey("dbo.Logs", "Events_EvenId", "dbo.LogEvents")
            DropIndex("dbo.Logs", New String() { "User_UsId" })
            DropIndex("dbo.Logs", New String() { "Objects_ObjectId" })
            DropIndex("dbo.Logs", New String() { "Level_LevelId" })
            DropIndex("dbo.Logs", New String() { "Events_EvenId" })
            DropTable("dbo.Logs")
        End Sub
    End Class
End Namespace
