using Microsoft.EntityFrameworkCore.Migrations;

namespace Labmark.Migrations
{
    public partial class AddEnsaios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(1,01, 'M01 Contagem de Bacillus cereus','','IN n°30 de 26/06/2018 MAPA/SDA')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(2, 02, 'M02 Contagem total de Bolores e Leveduras','','IN n°30 de 26/06/2018 MAPA/SDA')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(3, 05, 'M05 Contagem de Clostridium sulfito redutor','','IN n°30 de 26/06/2018 MAPA/SDA')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(4, 06, 'M06 Contagem total de Coliformes Termotolerantes','','IN n°30 de 26/06/2018 MAPA/SDA')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(5, 07, 'M07 Contagem de Coliformes Totais','','IN n°30 de 26/06/2018 MAPA/SDA')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(6, 12, 'M12 Contagem de Staphylococcus aureus','','2003.11 3MTM Staph Express Count Plate Method')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(7, 120, 'M12A Contagem de Staphylococcus Coagulase Positiva','','ISO 6888.1   1999')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(8, 13, 'M13 Contagem de Mesófilos Aeróbios estritos e Facultativos Viáveis','','IN n°30 de 26/06/2018 MAPA/SDA')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(9, 14, 'M14 Contagem Total de Enterobactérias','','IN n°30 de 26/06/2018 MAPA/SDA')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(10, 15, 'M15 NMP de Coliformes Termotolerantes','','Standard Methods For the Examination of Water and Wastewater 21ed. 2001, APHA')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(11,150, 'M15L NMP de Coliformes  Termotolerantes','','IN n°30 de 26/06/2018 MAPA/SDA')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(12, 16, 'M16 NMP de Coliformes Totais','','Standard Methods For the Examination of Water and Wastewater 21ed. 2001, APHA')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(13,160, 'M16L NMP de Coliformes  Totais','','IN n°30 de 26/06/2018 MAPA/SDA')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(14, 20, 'M20 Pesquisa de Listeria monocytogenes','','Molecular Detection System - MDS 3MTM')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(15, 26, 'M26 Pesquisa de Salmonella sp','','ISO 6579. Horizontal Method for the Detection of Salmonella sp.')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(16, 32, 'M32 Contagem Total de Escherichia coli','','AOAC 991.14')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(17, 101, 'AC Acidez','','Titulação de °D')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(18, 102, 'BL Contagem de Bactérias Láticas','','OXOID')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(19, 103, 'CR Crioscopia','','Criocópio Eletronico ITR MC5400')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(20, 104, 'QuantIficação de Cloro','','Iodometria')
                                    insert into lab.ensaio(ID,CODIGO, DESCRICAO,REFERENCIA, METODOLOGIA) values(21, 105, 'FOS Fosfatase','','-')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DELETE LAB.ENSAIO WHERE ID IN () 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21");
        }
    }
}
