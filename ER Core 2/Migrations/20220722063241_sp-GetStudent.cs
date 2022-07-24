using Microsoft.EntityFrameworkCore.Migrations;

namespace ER_Core_2.Migrations
{
    public partial class spGetStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         var sp = @"CREATE PROCEDURE [dbo].[GetStudent]
                    @FirstName varchar(50)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Student where FirstName like @FirstName +'%'
                END";

         migrationBuilder.Sql(sp);
      }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
