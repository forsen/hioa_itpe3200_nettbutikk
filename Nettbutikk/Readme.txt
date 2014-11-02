



Begrunnelse av valg vi har gjort
================================

	Oppstart av l�sningen
	------------------------------
	Vi har valgt � opprette admin som et eget prosjekt i samme l�sning. Vi benytter samme database som 
	nettbutikken gj�r. Denne databasen opprettes av nettbutikken, da vi ikke har f�tt laget referanser fra
	admin til nettbutikk pga namespace utfordringer. Det er derfor viktig � f�lge disse stegene for � starte 
	prosjektet:
		
		1: Build Solution
		2: S�rg for at "store" er oppstartsprosjekt (h�yreklikk p� Store og velg "Set as StartUp Project")
		3: Du vil n� f� opp en side p� http://localhost:1209/ som er nettbutikken
		4: �pne en ny tab med http://localhost:1054/ som da vil v�re adminsiden.
		5: Innlogging for adminsiden: login: admin@istrat.or passord: admin


	Admin kan ikke opprette bruker
	------------------------------
	Admin skal naturligvis ikke ha tilgang til brukeres passord. Vi har ingen
	epost-tjener som kan sende ut bekreftelsesmelding til brukeren, derfor er brukere
	p� dette tidspunktet n�dt til � opprette bruker selv. 


	Opprettelse av underkategorier
	------------------------------
	Det er mulig � opprette underkategorier, men de vil ikke vises i nettbutikken. 
	Dette er fordi underkategoriene p� dette tidspunktet er hardkodet inn i drop-downlistene
	i nettbutikken.


	Sletting fra databasen
	------------------------------
	S�nn det er n�, s� kan man ikke slette en kategori f�r den er tom, samme gjelder
	subkategori og produsent. Dersom det skulle v�rt gjeldende praksis for hele
	prosjektet, hadde vi aldri f�tt slettet noe pga. produkter ligger i ordrelinjer 
	osv. N� g�r det an � slette produkter og brukere, det resulterer i at dersom man
	sletter et produkt, s� vil alle ordrelinjer som inneholder det produktet ogs� bli
	slettet. Det samme samme gjelder for brukere - dersom man sletter en bruker vil
    alle ordre tilh�rende den brukeren forsvinne.


	Bilder av nye produkter
	-----------------------------
	Det g�r ikke an � gi nye produkter bilde fra administratorvertk�yet p� dette 
	tidspunktet. Dette fordi bildene m� ha riktige proposjoner for � se bra ut i
	nettbutikken. Bildene vil imidlertid f� et "defaultbilde". Hvis man vil kan 
	man p� dette tidspunktet  legge inn et bilde manuelt i /img/products/ og kalle
	bildet "[varenummer].png" - og det vil synes i nettbutikken. 


