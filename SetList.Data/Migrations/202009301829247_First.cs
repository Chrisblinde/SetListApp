namespace SetList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Show");
            AlterColumn("dbo.Show", "ShowId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Show", "UserId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Show");
            AlterColumn("dbo.Show", "ShowId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Show", "ShowId");
        }
    }
}
