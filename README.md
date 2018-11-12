Ovaj projekt je rađen u svrhu samostalnog ucenja kako programirati windows aplikacije u visual studiu uz upotrebu MySQL baze podataka, kasnije još i dodana mogućnost izrade izvještaja.
Ukoliko se želi testirati potrebno je učiniti sljedeće:<br>
-skinuti .msi datoteku<br>
-skinuti MySQL ukoliko ga vec nemate, preporuka je skinuti MySQL comunity installer i tamo instalirati workbench, bazu i odbc konektore, 32-bit<br>
-skinuti dva .sql fajla u prilogu<br>
-skinuti CRRuntime 13.0.23 verziju ( ako želite funkcionalnost ispisa izvještaja ,naci na google-u)
-pokrenuti MySQL workbench, napraviti bazu "database" sa username root i password pass123 i loadati baza-struktura.sql, izvršiti, loadati baza-some-needed-data.sql, izvršiti.
<br>-u windowsu napraviti ODBC konekciju naziva MySQL, localhost, user: root, password: pass123<br>
Ovdije bi sad vec trebalo sve raditi, jos treba instalirati spomenuti crruntime za mogućnost ispisa obrazaca.
