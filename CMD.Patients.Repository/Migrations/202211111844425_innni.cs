namespace CMD.Patients.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class innni : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BloodGroup = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        EmailId = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 12),
                        Location = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SignInPatients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailId = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SignInPatients");
            DropTable("dbo.Patients");
        }
    }
}
