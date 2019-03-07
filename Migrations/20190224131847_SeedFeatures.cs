using Microsoft.EntityFrameworkCore.Migrations;

namespace mobilsentra.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO public.\"Features\" (\"Name\") VALUES ('Air Bags')");
            migrationBuilder.Sql("INSERT INTO public.\"Features\" (\"Name\") VALUES ('ABS Break')");
            migrationBuilder.Sql("INSERT INTO public.\"Features\" (\"Name\") VALUES ('Fog Lamp')");
            migrationBuilder.Sql("INSERT INTO public.\"Features\" (\"Name\") VALUES ('ECO')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE public.\"Features\"");
        }
    }
}
