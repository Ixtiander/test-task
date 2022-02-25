using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApplication.DAL.Migrations
{
    public partial class InsertTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql(@"INSERT INTO public.country(name)
                SELECT name FROM
                (
                    SELECT generate_series(1,250) AS id, md5(random()::text) as name
                ) as innertable;");
            
            migrationBuilder.Sql(@"INSERT INTO public.city(name, country_id)
                SELECT innertable.name, country.id FROM
                (
	                SELECT generate_series(1,100000) AS id, md5(random()::text) as name
                ) as innertable
                , public.country as country;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
