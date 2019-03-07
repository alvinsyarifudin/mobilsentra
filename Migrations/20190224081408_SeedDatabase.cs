using Microsoft.EntityFrameworkCore.Migrations;

namespace mobilsentra.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO public.\"Makes\" (\"Name\") VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO public.\"Makes\" (\"Name\") VALUES ('Make2')");
            migrationBuilder.Sql("INSERT INTO public.\"Makes\" (\"Name\") VALUES ('Make3')");

            migrationBuilder.Sql("INSERT INTO public.\"Models\" (\"Name\",\"MakeId\") VALUES ('Make1-ModelA',(SELECT \"id\" FROM public.\"Makes\" WHERE \"Name\"='Make1'))");
            migrationBuilder.Sql("INSERT INTO public.\"Models\" (\"Name\",\"MakeId\") VALUES ('Make1-ModelB',(SELECT \"id\" FROM public.\"Makes\" WHERE \"Name\"='Make1'))");
            migrationBuilder.Sql("INSERT INTO public.\"Models\" (\"Name\",\"MakeId\") VALUES ('Make1-ModelC',(SELECT \"id\" FROM public.\"Makes\" WHERE \"Name\"='Make1'))");

            migrationBuilder.Sql("INSERT INTO public.\"Models\" (\"Name\",\"MakeId\") VALUES ('Make1-ModelA',(SELECT \"id\" FROM public.\"Makes\" WHERE \"Name\"='Make2'))");
            migrationBuilder.Sql("INSERT INTO public.\"Models\" (\"Name\",\"MakeId\") VALUES ('Make1-ModelB',(SELECT \"id\" FROM public.\"Makes\" WHERE \"Name\"='Make2'))");
            migrationBuilder.Sql("INSERT INTO public.\"Models\" (\"Name\",\"MakeId\") VALUES ('Make1-ModelC',(SELECT \"id\" FROM public.\"Makes\" WHERE \"Name\"='Make2'))");

            migrationBuilder.Sql("INSERT INTO public.\"Models\" (\"Name\",\"MakeId\") VALUES ('Make1-ModelA',(SELECT \"id\" FROM public.\"Makes\" WHERE \"Name\"='Make3'))");
            migrationBuilder.Sql("INSERT INTO public.\"Models\" (\"Name\",\"MakeId\") VALUES ('Make1-ModelB',(SELECT \"id\" FROM public.\"Makes\" WHERE \"Name\"='Make3'))");
            migrationBuilder.Sql("INSERT INTO public.\"Models\" (\"Name\",\"MakeId\") VALUES ('Make1-ModelC',(SELECT \"id\" FROM public.\"Makes\" WHERE \"Name\"='Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes");
        }
    }
}
