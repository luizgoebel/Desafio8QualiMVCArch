using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class seedTables : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Usuarios(Nome, Empresa, Email, TelefonePessoal, TelefoneComercial) VALUES ('Luiz', 'Benner', 'goebel.adm@gmail.com', '47991832512', '4733305172')");
            mb.Sql("INSERT INTO Usuarios(Nome, Empresa, Email, TelefonePessoal, TelefoneComercial) VALUES ('Joao', 'Senior', 'tec.seniorm@senior.com', '47991439512', '4733307432')");

            mb.Sql("INSERT INTO Emails(Endereco, UsuarioId) VALUES ('teste@teste.com.br', 1)");
            mb.Sql("INSERT INTO Emails(Endereco, UsuarioId) VALUES ('testando@tesando.com.br', 1)");
            mb.Sql("INSERT INTO Emails(Endereco, UsuarioId) VALUES ('okok@okok.com.br', 1)");
            mb.Sql("INSERT INTO Emails(Endereco, UsuarioId) VALUES ('qweqwe.w@asd.com', 2)");
            mb.Sql("INSERT INTO Emails(Endereco, UsuarioId) VALUES ('vcvcvcvw@acvcvcv.com', 2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Usuarios");
            mb.Sql("DELETE FROM Emails");
        }
    }
}
