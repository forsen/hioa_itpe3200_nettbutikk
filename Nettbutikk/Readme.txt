



Begrunnelse av valg vi har gjort
================================


	Admin kan ikke opprette bruker
	------------------------------
	Admin skal naturligvis ikke ha tilgang til brukeres passord. Vi har ingen
	epost-tjener som kan sende ut bekreftelsesmelding til brukeren, derfor er brukere
	p� dette tidspunktet n�dt til � opprette bruker selv. 


	Opprettelse av underkategorier
	------------------------------
	Det er mulig � opprette underkategorier, men de vil ikke vises i nettbutikken. 
	Dette er fordi underkategoriene p� dette tidspunktet er hardkodet inn i drop-downlistene
	p� adminsiden.


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
