namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Books", "Auther");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Auther", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Books", "Author");
        }
    }
}
