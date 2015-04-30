namespace FWS.Dao.Migrations.Migrations_FWSVolcano
{
    using System.Data.Entity.Migrations;
    
    public partial class FWSVolcano : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LancamentoGrupo",
                c => new
                    {
                        lancamentoGrupoId = c.Short(nullable: false, identity: true),
                        descricao = c.String(nullable: false, maxLength: 100),
                        sigla = c.String(nullable: false, maxLength: 2),
                        tipo = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.lancamentoGrupoId);
            
            CreateTable(
                "dbo.LancamentoTipo",
                c => new
                    {
                        lancamentoTipoId = c.Int(nullable: false, identity: true),
                        descricao = c.String(nullable: false, maxLength: 100),
                        dataInicio = c.DateTime(nullable: false),
                        dataTermino = c.DateTime(),
                        status = c.String(nullable: false, maxLength: 1),
                        lancamentoGrupoId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.lancamentoTipoId)
                .ForeignKey("dbo.LancamentoGrupo", t => t.lancamentoGrupoId, cascadeDelete: true)
                .Index(t => t.lancamentoGrupoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LancamentoTipo", "lancamentoGrupoId", "dbo.LancamentoGrupo");
            DropIndex("dbo.LancamentoTipo", new[] { "lancamentoGrupoId" });
            DropTable("dbo.LancamentoTipo");
            DropTable("dbo.LancamentoGrupo");
        }
    }
}
