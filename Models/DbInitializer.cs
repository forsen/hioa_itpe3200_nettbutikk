using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        private Random prodGen = new Random();
        private Random prodDate = new Random();
        private Random prodQuant = new Random();
        DateTime start = new DateTime(2012, 1, 1);
        int dateRange;
        protected override void Seed(DatabaseContext context)
        {
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Products', RESEED, 100001)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Orders', RESEED, 298423)");

            dateRange = (DateTime.Today - start).Days;

            var countries = new List<Countries>
            {
                new Countries {Name = "Afghanistan"},
                new Countries {Name = "Albania"},
                new Countries {Name = "Algerie"},
                new Countries {Name = "Andorra"},
                new Countries {Name = "Angola"},
                new Countries {Name = "Antigua og Barbuda"},
                new Countries {Name = "Argentina"},
                new Countries {Name = "Armenia"},
                new Countries {Name = "Aserbajdsjan"},
                new Countries {Name = "Australia"},
                new Countries {Name = "Bahamas"},
                new Countries {Name = "Bahrain"},
                new Countries {Name = "Bangladesh"},
                new Countries {Name = "Barbados"},
                new Countries {Name = "Belgia"},
                new Countries {Name = "Belize"},
                new Countries {Name = "Benin"},
                new Countries {Name = "Bhutan"},
                new Countries {Name = "Bolivia"},
                new Countries {Name = "Bosnia-Hercegovina"},
                new Countries {Name = "Botswana"},
                new Countries {Name = "Brasil"},
                new Countries {Name = "Brunei"},
                new Countries {Name = "Bulgaria"},
                new Countries {Name = "Burkina Faso"},
                new Countries {Name = "Burundi"},
                new Countries {Name = "Canada"},
                new Countries {Name = "Chile"},
                new Countries {Name = "Colombia"},
                new Countries {Name = "Cookøyene"},
                new Countries {Name = "Costa Rica"},
                new Countries {Name = "Cuba"},
                new Countries {Name = "Danmark"},
                new Countries {Name = "Den dominikanske republikk"},
                new Countries {Name = "Den sentralafrikanske republikk"},
                new Countries {Name = "Djibouti"},
                new Countries {Name = "Dominica"},
                new Countries {Name = "Ecuador"},
                new Countries {Name = "Egypt"},
                new Countries {Name = "Ekvatorial-Guinea"},
                new Countries {Name = "El Salvador"},
                new Countries {Name = "Elfenbenskysten"},
                new Countries {Name = "Eritrea"},
                new Countries {Name = "Estland"},
                new Countries {Name = "Etiopia"},
                new Countries {Name = "Fiji"},
                new Countries {Name = "Filippinene"},
                new Countries {Name = "Finland"},
                new Countries {Name = "Forente arabiske emirater"},
                new Countries {Name = "Frankrike"},
                new Countries {Name = "Gabon"},
                new Countries {Name = "Gambia"},
                new Countries {Name = "Georgia"},
                new Countries {Name = "Ghana"},
                new Countries {Name = "Grenada"},
                new Countries {Name = "Guatemala"},
                new Countries {Name = "Guinea"},
                new Countries {Name = "Guinea-Bissau"},
                new Countries {Name = "Guyana"},
                new Countries {Name = "Haiti"},
                new Countries {Name = "Hellas"},
                new Countries {Name = "Honduras"},
                new Countries {Name = "Hviterussland (Belarus)"},
                new Countries {Name = "India"},
                new Countries {Name = "Indonesia"},
                new Countries {Name = "Irak"},
                new Countries {Name = "Iran"},
                new Countries {Name = "Irland"},
                new Countries {Name = "Island"},
                new Countries {Name = "Israel"},
                new Countries {Name = "Italia"},
                new Countries {Name = "Jamaica"},
                new Countries {Name = "Japan"},
                new Countries {Name = "Jemen"},
                new Countries {Name = "Jordan"},
                new Countries {Name = "Kambodsja"},
                new Countries {Name = "Kamerun"},
                new Countries {Name = "Kapp Verde"},
                new Countries {Name = "Kasakhstan"},
                new Countries {Name = "Kenya"},
                new Countries {Name = "Kina"},
                new Countries {Name = "Kirgisistan"},
                new Countries {Name = "Kiribati"},
                new Countries {Name = "Komorene"},
                new Countries {Name = "Kongo"},
                new Countries {Name = "Kongo, Den demokratiske republikk"},
                new Countries {Name = "Kosovo"},
                new Countries {Name = "Kroatia"},
                new Countries {Name = "Kuwait"},
                new Countries {Name = "Kypros"},
                new Countries {Name = "Laos"},
                new Countries {Name = "Latvia"},
                new Countries {Name = "Lesotho"},
                new Countries {Name = "Libanon"},
                new Countries {Name = "Liberia"},
                new Countries {Name = "Libya"},
                new Countries {Name = "Liechtenstein"},
                new Countries {Name = "Litauen"},
                new Countries {Name = "Luxembourg"},
                new Countries {Name = "Madagaskar"},
                new Countries {Name = "Makedonia"},
                new Countries {Name = "Malawi"},
                new Countries {Name = "Malaysia"},
                new Countries {Name = "Maldivene"},
                new Countries {Name = "Mali"},
                new Countries {Name = "Malta"},
                new Countries {Name = "Marokko"},
                new Countries {Name = "Marshalløyene"},
                new Countries {Name = "Mauritania"},
                new Countries {Name = "Mauritius"},
                new Countries {Name = "Mexico"},
                new Countries {Name = "Mikronesia"},
                new Countries {Name = "Moldova"},
                new Countries {Name = "Monaco"},
                new Countries {Name = "Mongolia"},
                new Countries {Name = "Montenegro"},
                new Countries {Name = "Mosambik"},
                new Countries {Name = "Myanmar (Burma)"},
                new Countries {Name = "Namibia"},
                new Countries {Name = "Nauru"},
                new Countries {Name = "Nederland"},
                new Countries {Name = "Nepal"},
                new Countries {Name = "New Zealand"},
                new Countries {Name = "Nicaragua"},
                new Countries {Name = "Niger"},
                new Countries {Name = "Nigeria"},
                new Countries {Name = "Niue"},
                new Countries {Name = "Nord-Korea"},
                new Countries {Name = "Norge"},
                new Countries {Name = "Oman"},
                new Countries {Name = "Pakistan"},
                new Countries {Name = "Palau"},
                new Countries {Name = "Palestina"},
                new Countries {Name = "Panama"},
                new Countries {Name = "Papua Ny-Guinea"},
                new Countries {Name = "Paraguay"},
                new Countries {Name = "Peru"},
                new Countries {Name = "Polen"},
                new Countries {Name = "Portugal"},
                new Countries {Name = "Qatar"},
                new Countries {Name = "Romania"},
                new Countries {Name = "Russland"},
                new Countries {Name = "Rwanda"},
                new Countries {Name = "Saint Kitts og Nevis"},
                new Countries {Name = "Saint Lucia"},
                new Countries {Name = "Saint Vincent og Grenadinene"},
                new Countries {Name = "Salomonøyene"},
                new Countries {Name = "Samoa"},
                new Countries {Name = "San Marino"},
                new Countries {Name = "São Tomé og Príncipe"},
                new Countries {Name = "Saudi-Arabia"},
                new Countries {Name = "Senegal"},
                new Countries {Name = "Serbia"},
                new Countries {Name = "Seychellene"},
                new Countries {Name = "Sierra Leone"},
                new Countries {Name = "Singapore"},
                new Countries {Name = "Slovakia"},
                new Countries {Name = "Slovenia"},
                new Countries {Name = "Somalia"},
                new Countries {Name = "Spania"},
                new Countries {Name = "Sri Lanka"},
                new Countries {Name = "Storbritannia"},
                new Countries {Name = "Sudan"},
                new Countries {Name = "Surinam"},
                new Countries {Name = "Sveits"},
                new Countries {Name = "Sverige"},
                new Countries {Name = "Swaziland"},
                new Countries {Name = "Syria"},
                new Countries {Name = "Sør-Afrika"},
                new Countries {Name = "Sør-Korea"},
                new Countries {Name = "Sør-Sudan"},
                new Countries {Name = "Tadsjikistan"},
                new Countries {Name = "Taiwan"},
                new Countries {Name = "Tanzania"},
                new Countries {Name = "Thailand"},
                new Countries {Name = "Togo"},
                new Countries {Name = "Tonga"},
                new Countries {Name = "Trinidad og Tobago"},
                new Countries {Name = "Tsjad"},
                new Countries {Name = "Tsjekkia"},
                new Countries {Name = "Tunisia"},
                new Countries {Name = "Turkmenistan"},
                new Countries {Name = "Tuvalu"},
                new Countries {Name = "Tyrkia"},
                new Countries {Name = "Tyskland"},
                new Countries {Name = "Uganda"},
                new Countries {Name = "Ukraina"},
                new Countries {Name = "Ungarn"},
                new Countries {Name = "Uruguay"},
                new Countries {Name = "USA"},
                new Countries {Name = "Usbekistan"},
                new Countries {Name = "Vanuatu"},
                new Countries {Name = "Vatikanstaten"},
                new Countries {Name = "Venezuela"},
                new Countries {Name = "Vest-Sahara"},
                new Countries {Name = "Vietnam"},
                new Countries {Name = "Zambia"},
                new Countries {Name = "Zimbabwe"},
                new Countries {Name = "Øst-Timor"},
                new Countries {Name = "Østerrike"}
            };
            countries.ForEach(c => context.Countries.Add(c));

            var categories = new List<Categories>
            {
                new Categories {Name="Øl"},//1
                new Categories {Name="Rødvin"},//2
                new Categories {Name="Hvitvin"},//3
                new Categories {Name="Brennevin"},//4
                new Categories {Name="Musserende"}//5
            };

            // add data into context and save to db
            categories.ForEach(c => context.Categories.Add(c));
           
            var subcategories = new List<SubCategories>
            {
                new SubCategories {Name="Overgjæret", CategoriesId=1},//1
                new SubCategories {Name="Undergjæret", CategoriesId=1},//2
                new SubCategories {Name="Spotangjæret", CategoriesId=1},//3 
                new SubCategories {Name="Fyldig", CategoriesId=2},//4
                new SubCategories {Name="Mild", CategoriesId=2},//5
                new SubCategories {Name="Søt", CategoriesId=3},//6
                new SubCategories {Name="Tørr", CategoriesId=3},//7
                new SubCategories {Name="Vodka", CategoriesId=4},//8
                new SubCategories {Name="Rom", CategoriesId=4},//9
                new SubCategories {Name="Likør", CategoriesId=4},//10
                new SubCategories {Name="Cognac", CategoriesId=4},//11
                new SubCategories {Name="Wiskey", CategoriesId=4},//12
                new SubCategories {Name="Likør over 22%", CategoriesId=4},//13
                new SubCategories {Name="Akevitt", CategoriesId=4},//14
                new SubCategories {Name="Champagne", CategoriesId=5},//15
                new SubCategories {Name="Cava", CategoriesId=5},//16
                new SubCategories {Name="Prosecco", CategoriesId=5},//17


            };

            subcategories.ForEach(s => context.SubCategories.Add(s));

            var producers = new List<Producers>
            {
                new Producers {Name = "Ringnes"},//1
                new Producers {Name = "Carlsberg"},//2
                new Producers {Name = "Absolut Vodka"},//3
                new Producers {Name = "En vinprodusent"},//4
                new Producers {Name = "Nøgne Ø"},//5
                new Producers {Name = "Aas Bryggeri"},//6
                new Producers {Name = "Haandbryggeriet"},//7
                new Producers {Name = "Kinn brygghus"},//8
                new Producers {Name = "Brouwerij Verhaeghe"},//9
                new Producers {Name = "Palm Breweries NV"},//10
                new Producers {Name = "Orlando Wines"},//11
                new Producers {Name = "CVBC og CSPA"},//12
                new Producers {Name = "Agr Vallone"},//13
                new Producers {Name = "G.D. Vajra"},//14
                new Producers {Name = "Alain Hudelot-Noellat"},//15
                new Producers {Name = "Lucien le Moine"},//16
                new Producers {Name = "Hammeken Cellars"},//17
                new Producers {Name = "Erik Texier"},//18
                new Producers {Name = "Angove"},//19
                new Producers {Name = "Lammershoek"},//20
                new Producers {Name = "Weing Leitz"},//21
                new Producers {Name = "Agnes et Didier Dauvissat"},//22
                new Producers {Name = "Bod Villabuena"},//23
                new Producers {Name = "Bodegas Urbina"},//24
                new Producers {Name = "MGM Mondo del Vino"},//25
                new Producers {Name = "Az Agr Graci"},//26
                new Producers {Name = "Pewsey Vale Vineyard"},//27
                new Producers {Name = "Weing Allram"},//28
                new Producers {Name = "Weing Karl Fritsch"},//29
                new Producers {Name = "The Absolut Company"},//30
                new Producers {Name = "Irish Dist"},//31
                new Producers {Name = "Robert Prizelius AS"},//32
                new Producers {Name = "Bailey og Co"},//33
                new Producers {Name = "Captain Morgan Rum Dist"},//34
                new Producers {Name = "Bacardi"},//35
                new Producers {Name = "Arcus AS"},//36
                new Producers {Name = "Möet & Chandon"},//37
                new Producers {Name = "Mr.Prosecco Master ASA"},//38
                new Producers {Name = "Marques de monistrol"}//39
            };
            producers.ForEach(p => context.Producers.Add(p));
            context.SaveChanges();
            var products = new List<Products>
            {

                new Products {
                    Id = 100001,
                    Name="Julebukk", 
                    Description="En juleøl fra Ringnes. Vol: 8.0 % ",
                    LongDescription="En meget god Juleøl fra Ringnes som fungerer godt til Juleribbe og til Pinnekjøtt!", 
                    Price=200, Volum=33, ProducersId=1,SubCategoriesId=2, CountriesId=129
                },
                new Products {
                    Id = 100002,
                    Name="Carlsberg Pilsner", 
                    Description="En dansk øl. Vol: 4.7 %", 
                    LongDescription="En god dansk øl, som passer godt til god dansk pølse", 
                    Price=32,Volum=50, ProducersId=2,SubCategoriesId=2, CountriesId=33
                },
                new Products {
                    Id = 100003,
                    Name="Nøgne Ø TWO CAPTAINS", Description="Dobbel IPA. Vol: 6.8 %", 
                    LongDescription="Passer godt til fet mat. Fruktig øl med god bitterhet", 
                    Price=80, 
                    Volum=50,
                    ProducersId=5,
                    SubCategoriesId=1, 
                    CountriesId=129
                },
                new Products {
                    Id = 100004,
                    Name="Aass Bock",
                    Description="Undergjæret og mørk øl. Vol: 7.0 %", 
                    LongDescription="Kremet, mørk og litt sødmefull. Fint innslag av vørterkake og honning.", 
                    Price=39, 
                    Volum=33,
                    ProducersId=6,
                    SubCategoriesId=2,
                    CountriesId=129
                },
                new Products {
                    Id = 100005,
                    Name="Haandbryggeriet Rips", 
                    Description="Overgjæret rips øl. Vol: 5.5 %",
                    LongDescription="Syrlig øl laget på rips 7% alkohol", 
                    Price=71,
                    Volum=50,
                    ProducersId=7,
                    SubCategoriesId=1, 
                    CountriesId=129
                },
                new Products {
                    Id = 100006,
                    Name="Kinn Ivar Aasen-øl", 
                    Description="Norsk overgjæret øl. Vol: 11.0 %",
                    LongDescription="Kremet og halvtørr. Preg av ristet korn, hint av urter og honning, lang ettersmak.", 
                    Price=130, Volum=75, ProducersId=8,SubCategoriesId=1,CountriesId=129},
                new Products {
                    Id = 100007,
                    Name="Duchesse de Bourgogne", Description="Overgjæret belgisk øl. Vol: 6.2 %", 
                    LongDescription="Fruktig nese i retning kirsebær, humle og malt. Smak av syrlig frukt, kirsebær og bringebær, tydelig karamellmalt. 6,2% alkohol", 
                    Price=147,
                    Volum=50,
                    ProducersId=9,
                    SubCategoriesId=1, 
                    CountriesId=15
                },
                new Products {
                    Id = 100008,
                    Name="Oude Geuze Boon",
                    Description="Spontangjæret belgisk surøl. Vol: 6.2 %", 
                    LongDescription="Kompleks, frisk og saftig stil. Lang ettersmak.", 
                    Price=53,Volum=25, ProducersId=10,SubCategoriesId=3, CountriesId=15},
                new Products {
                    Id = 100009,
                    Name="Midtfyns Bryghus Chili Tripel", 
                    Description="Overgjæret dansk øl. Vol: 9.2 %", 
                    LongDescription="God fylde, mild humlesmak avrunder smaksbildet. Chili gir en varm følelse i avslutningen.",
                    Price=80, Volum=50,ProducersId=11,SubCategoriesId=1, CountriesId=33},
                new Products {
                    Id = 100010,
                    Name="Nøgne Ø Indian Pale Ale",
                    Description="Overgjæret norsk øl. Vol: 7.2 %", 
                    LongDescription="God og fyldig IPA med god rund bitterhet.", 
                    Price=74, Volum=50,ProducersId=5,SubCategoriesId=1, CountriesId=129},
                new Products {
                    Id = 100011,
                    Name="Ringnes pilsner",
                    Description="Undergjæret norsk øl. Vol: 4.7 %",
                    LongDescription="Frisk og god øl som passer fint sammen med fest og grilling i parken.", 
                    Price=28, Volum=33,ProducersId=1,SubCategoriesId=2, CountriesId=129},
                new Products {
                    Id = 100012,
                    Name="Jacob's Creek Shiraz 2011", 
                    Description="Rødvin fra Chile. Vol: 13 %",
                    LongDescription="En rød vin som er billig",
                    Price=80, Volum=75,ProducersId=11, SubCategoriesId=5, CountriesId=129},
                new Products {
                    Id = 100013,
                    Name="Doppio Passo",
                    Description="Rødvin fra Puglia, Italia. Vol: 12 %",
                    LongDescription="Krydret søtlig rødvin med mye fruktighet.",
                    Price=105, Volum=75,ProducersId=12,SubCategoriesId=5, CountriesId=71},
                new Products {
                    Id = 100014,
                    Name="Vallone Graticciaia 2008",
                    Description="Rødvin fra Puglia, Italia. Vol: 12 %", 
                    LongDescription="Myke tanniner, med balansert struktur.",
                    Price=500,Volum=75, ProducersId=13,SubCategoriesId=4, CountriesId=71},
                new Products {
                    Id = 100015,
                    Name="Vajra Langhe Rosso 2010/2011",
                    Description="Rødvin fra Piermonte, Italia. Vol: 14 %", 
                    LongDescription="Litt utviklet, preg av røde bær, litt tørket frukt og lakris, litt varm ettersmak.",
                    Price=135,Volum=75, ProducersId=14,SubCategoriesId=4, CountriesId=71},
                new Products {
                    Id = 100016,
                    Name="Hudelot-Noellat Clos de Vougeot Richebourg Grand Cru 2011. Vol: 13 %",
                    Description="Rødvin fra Burgund, Frankrike", LongDescription="Dyp med god frukt og konsentrasjon.", 
                    Price=2952, Volum=75,ProducersId=15,SubCategoriesId=4, CountriesId=50},
                new Products {
                    Id = 100017,
                    Name="Lucien Le Moine Bonnes Mares Grand Cru 2011. Vol: 13.5 %",
                    Description="Rødvin fra Burgund, Frankrike",
                    LongDescription="Balansert, mineralsk og lang.", 
                    Price=1800, Volum=75,ProducersId=16,SubCategoriesId=4, CountriesId=50},
                new Products {
                    Id = 100018,
                    Name="Avent Tempranillo 2012", 
                    Description="Rødvin fra Castilla y León, Spania. Vol: 12.5 %",
                    LongDescription="Frisk og fruktig, mørke skogsbær med myke tanniner.", 
                    Price=89, Volum=75,ProducersId=17,SubCategoriesId=5, CountriesId=160},
                new Products {
                    Id = 100019,
                    Name="Eric Texier Adéle Côtes du Rhône 2013",
                    Description="Frankrike, Rhône Sør, Côtes du Rhône. Vol: 13 %",
                    LongDescription="Frisk med god struktur.",
                    Price=180, Volum=75,ProducersId=18,SubCategoriesId=4,CountriesId=50},
                new Products {
                    Id = 100020,
                    Name="Eric Texier Brézème Roussanne 2012",
                    Description="Frankrike, Rhône Sør, Côtes du Rhône. Vol: 13 %",
                    LongDescription="", 
                    Price=71, Volum=75,ProducersId=18,SubCategoriesId=4,CountriesId=50},
                new Products {
                    Id = 100021,
                    Name="Angove Deep Creek Shiraz 2013", 
                    Description="Rødvin fra South Eastern Austra, Australia. Vol: 12 %",
                    LongDescription="Ung og saftig, preg av mørke bær, lakris og urter.", 
                    Price=280,Volum=75, ProducersId=19,SubCategoriesId=5,CountriesId=10},
                new Products {
                    Id = 100022,
                    Name="Lammershoek Lam Syrah 2013", 
                    Description="Rødvin fra Coastal Region, Swartland, Sør-Afrika. Vol: 14 %",
                    LongDescription="Tørr, fruktdrevet, frisk.",
                    Price=165, Volum=75,ProducersId=20,SubCategoriesId=4,CountriesId=169},
                new Products {
                    Id = 100023,
                    Name="Leitz Rüdesheimer Berg Roseneck Katerloch Riesling Trocken 2012", 
                    Description="Hvitvin fra Rheingau, Øvrige, Tyskland. Vol: 11 %", 
                    LongDescription="Tørr, mineral konsentrasjon.", 
                    Price=275,Volum=75, ProducersId=21,SubCategoriesId=7,CountriesId=185},
                new Products {
                    Id = 100024,
                    Name="AD Dauvissat Chablis 1er cru Beauroy 2012",
                    Description="Hitvin fra Burgund, Frankrike. Vol: 13 %",
                    LongDescription="Flott fylde, kompleks, stram og lang ettersmak.", 
                    Price=250,Volum=75, ProducersId=22,SubCategoriesId=7,CountriesId=50},
                new Products {
                    Id = 100025,
                    Name="Viña Izadi Blanco 2008", 
                    Description="Hvitvin fra Rioja, Spania. Vol: 14 %",
                    LongDescription="Strågul farge, frisk og fruktig med noe floral aroma samt noe toast- og nøttepreg. Rund og bløt med lang ettersmak.",
                    Price=99, Volum=75,ProducersId=23,SubCategoriesId=7,CountriesId=160},
                new Products {
                    Id = 100026,
                    Name="Urbina Viura 2011/2012",
                    Description="Hvitvin fra Rioja, Spania. Vol: 12.5 %", 
                    LongDescription="Saftig og moden frukt, preg av eple og sitrus.",
                    Price=165,Volum=75, ProducersId=24,SubCategoriesId=6,CountriesId=160},
                new Products {
                    Id = 100027,
                    Name="Amore Bianco 2012", 
                    Description="Hvitvin fra Sicilia, Italia. Vol: 13 %",
                    LongDescription="Frisk, med god fruktkonsentrasjon og lett bitterhet i avslutningen.",
                    Price=89,Volum=75, ProducersId=25,SubCategoriesId=7,CountriesId=71},
                new Products {
                    Id = 100028,
                    Name="Graci Etna Bianco 2013",
                    Description="Hvitvin fra Etna, Italia. Vol: 14.5 %",
                    LongDescription="Håndhøstet, gjæret med stedegengjær i sement og brukte fat, lagring på lees i 12 mnd.", 
                    Price=200,Volum=75, ProducersId=26,SubCategoriesId=7,CountriesId=71},
                new Products {
                    Id = 100029,
                    Name="Jacob's Creek Chardonnay 2012", 
                    Description="Hvitvin fra South Eastern Austra, Australia. Vol: 12 %",
                    LongDescription="Ren og fruktig, preget av sitrus og tropisk frukt, antydning til vanilje.", 
                    Price=108,Volum=75, ProducersId=11,SubCategoriesId=6,CountriesId=10},
                new Products {
                    Id = 100030,
                    Name="Pewsey Vale Riesling 2011",
                    Description="Hvitvin fra Eden Valley, Australia. Vol: 14 %",
                    LongDescription="Halmgul farge. Fruktaromaer av knust og lime. God lengde og dybde med sitron og lime.", 
                    Price=175,Volum=75, ProducersId=27,SubCategoriesId=6,CountriesId=10},
                new Products {
                    Id = 100031,
                    Name="Allram Grüner Veltliner Eiswein 2012",
                    Description="Hvitvin fra Niederösterreich, Østerike. Vol: 13 %", 
                    LongDescription="Gyllen farge. Aroma av hvit pepper, nektar, honning, moden sitrus og lime.",
                    Price=205,Volum=75, ProducersId=28,SubCategoriesId=7,CountriesId=200},
                new Products {
                    Id = 100032,
                    Name="Fritsch Windspiel Riesling 2010", 
                    Description="Hvitvin fra Niederösterreich, Østerike. Vol: 13.5 %",
                    LongDescription="Frisk, delikat og mineralsk med god konsentrasjon og fin lengde. Sitrus og eplepreget frukt. ", 
                    Price=145,Volum=75, ProducersId=29,SubCategoriesId=7,CountriesId=200},
                new Products {
                    Id = 100033,
                    Name="Lammershoek Roulette Blanc 2011", 
                    Description="Hvitvin fra Swartland, Sør-Afrika. Vol: 12 %", 
                    LongDescription="Tørr med krydret fruktighet, god konsentrasjon og mineralitet, krydret frukt i avslutning.",
                    Price=165, Volum=75,ProducersId=20,SubCategoriesId=7,CountriesId=169},
                new Products {
                    Id = 100034,
                    Name="Absolutt Vodka",
                    Description="Vodka fra Sverige. Vol: 40 %"
                    , LongDescription="Ren vodka.",
                    Price=300,Volum=100, ProducersId=30, SubCategoriesId=8,CountriesId=33},
                new Products {
                    Id = 100035,
                    Name="Jameson", 
                    Description="Wiskey fra Irland. Vol: 40 %", 
                    LongDescription="En ren wiskey med hint av korn.", 
                    Price=400,Volum=70,
                    ProducersId=31, SubCategoriesId=12,CountriesId=129},
                new Products {
                    Id = 100036,
                    Name="Thor Heyerdal X.O",
                    Description="Cognac fra Frankrike. Vol: 40 %", 
                    LongDescription="Bitter og fyldig cognac med tydelig preg av fat, 40% alkohol",
                    Price=450,Volum=100, ProducersId=32, SubCategoriesId=11,CountriesId=50},
                new Products {
                    Id = 100037,
                    Name="Baileys",
                    Description="Likør fra Irland. Vol: 19 %",
                    LongDescription="Tydelig sjokolade preg. Godt i kaffe. 17% alkohol", 
                    Price=200,Volum=50, ProducersId=33, SubCategoriesId=10,CountriesId=129},
                new Products {
                    Id = 100038,
                    Name="Absolut Citron",
                    Description="Vodka fra Sverige. Vol: 40 %",
                    LongDescription="Vodka med hint av Sitron. 40% alkohol",
                    Price=310,Volum=70, ProducersId=30, SubCategoriesId=8,CountriesId=33},
                new Products {
                    Id = 100039,
                    Name="Absolutt Mango",
                    Description="Vodka fra Sverige. Vol: 40 %", 
                    LongDescription="Vodka med hint av Mango. 40% alkohol", 
                    Price=310,Volum=70, ProducersId=30, SubCategoriesId=8,CountriesId=33},
                new Products {
                    Id = 100040,
                    Name="Captain Morgan",
                    Description="Rom fra Cuba. Vol: 40 %",
                    LongDescription="Søtelig rom som passer godt med cola og isbiter. 40% alkohol",
                    Price=320,Volum=70, ProducersId=34, SubCategoriesId=9,CountriesId=32},
                new Products {
                    Id = 100041,
                    Name="Bacardi Razz", 
                    Description="Søtt dritt fra Cuba Vol: 37.5 %",
                    LongDescription="Søt festdrikke for de som liker det. 37,5% alkohol",
                    Price=300,Volum=70, ProducersId=35, SubCategoriesId=9,CountriesId=11},
                new Products {
                    Id = 100042,
                    Name="Gammel dansk", 
                    Description="Bitter fra Danmark. Vol: 40 %",
                    LongDescription="En bitter drikke som fungerer bra som shot",
                    Price=410,Volum=100, ProducersId=36, SubCategoriesId=13,CountriesId=33},
                new Products {
                    Id = 100043,
                    Name="Løyten Linie Akevitt",
                    Description="Akevitt fra Norge. Vol: 40 %",
                    LongDescription="Fatpreget fyldig akevitt som passer godt til litt fet mat 40% alkohol",
                    Price=450,Volum=70, ProducersId=36, SubCategoriesId=14,CountriesId=129},
                new Products {
                    Id = 100044,
                    Name="Moët & Chandon Imperial Brut",
                    Description="Tørr, frisk champagne fra Frankrike. Vol 13%",
                    LongDescription="Frisk og tørr musserende vin som passer til reker",
                    Price=450, Volum=75,ProducersId=37, SubCategoriesId=15,CountriesId=50},
                new Products {
                    Id = 100045,
                    Name="Valdobbiane Prosecco",
                    Description="Tørr, frisk prosecco fra Italia. Vol 12,5 %",
                    LongDescription="Deilig prosecco med hint av pære i ettersmaken.",
                    Price=125,Volum=75, ProducersId=38, SubCategoriesId=17,CountriesId=71},
                new Products {
                    Id = 100046,
                    Name="Marques Monistrol Cava Brut",
                    Description="Tørr frisk Cava fra Spania. Vol 13 %",
                    LongDescription="Tørr of frisk cava fra spania. Passer godt som apertif og til fiskesuppe.",
                    Price=95,Volum=75, ProducersId=39, SubCategoriesId=16,CountriesId=160},
                
            };
            products.ForEach(c => context.Products.Add(c));
            context.SaveChanges();
            var postalareas = new List<Postalareas> 
            {
                new Postalareas{PostalareasId=0001, Postalarea="Oslo"},
                new Postalareas{PostalareasId=0123, Postalarea="Oslo"},
                new Postalareas{PostalareasId=0169, Postalarea="Oslo"},
                new Postalareas{PostalareasId=0170, Postalarea="Oslo"},
                new Postalareas{PostalareasId=0180, Postalarea="Oslo"},
                new Postalareas{PostalareasId=0184, Postalarea="Holmlia"},
                new Postalareas{PostalareasId=0482, Postalarea="Oslo"},
                new Postalareas{PostalareasId=1874, Postalarea="Lørenskog"},
                new Postalareas{PostalareasId=5060, Postalarea="Bergen"},
                new Postalareas{PostalareasId=9170, Postalarea="Barcelona"},
                new Postalareas{PostalareasId=9123, Postalarea="Stockholm"},
                new Postalareas{PostalareasId=9898, Postalarea="Sydpolen"},
                new Postalareas{PostalareasId=2322, Postalarea="Ridabu"},
                new Postalareas{PostalareasId=0566, Postalarea="Oslo"},
                new Postalareas{PostalareasId=8888, Postalarea="Det hvite hus"},
                new Postalareas{PostalareasId=3560, Postalarea="Hemsedal"},
                new Postalareas{PostalareasId=2256, Postalarea="Finnskog"}
                
            };
            postalareas.ForEach(c => context.Postalareas.Add(c));
            context.SaveChanges();
            var customers = new List<Customers>
            {
                new Customers {Firstname = "Per", Lastname="Hansen",Email="Per@Hansen.com",Phonenumber="91827364",Address="Pilestredet 35", PostalareasId=0170, Password= System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("mappeinnlevering1"))},
                new Customers {Firstname = "Admin", Lastname="Istrator",Email="admin@istrat.or",Phonenumber="13371337",Address="Systemveien 20",PostalareasId=0170, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("admin")),Admin=true},
                new Customers {Firstname = "Erlend", Lastname="Rognes",Email="erlend@rognes.no",Phonenumber="98878986",Address="Frydenlundgata 20",PostalareasId=0169, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("hemmelig"))},
                new Customers {Firstname = "Julie", Lastname="Roa",Email="horselady91@hotmail.com",Phonenumber="45859211",Address="Lørenvegen 20B",PostalareasId=1874, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("horseisbest"))},
                new Customers {Firstname = "Karl", Lastname="Hagen",Email="karlihagen@staten.no",Phonenumber="49879901",Address="Stortingsgata 120",PostalareasId=0170, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("politiker"))},
                new Customers {Firstname = "Franz", Lastname="Ferdinant",Email="musikk@yolo.com",Phonenumber="98765432",Address="Musikalsklia 10",PostalareasId=0180, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("musikk12345"))},
                new Customers {Firstname = "Lionel", Lastname="Messi",Email="barcelona@fotball.es",Phonenumber="20020050",Address="Camp Nou 1",PostalareasId=9170, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("fotball"))},
                new Customers {Firstname = "Erik", Lastname="Forsen", Email="erik@forsen.no",Phonenumber="47050032",Address="Nils Huus' gate 11", PostalareasId=0482, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("tullball"))},
                new Customers {Firstname = "Jarle", Lastname="Andøy", Email="jarle@berserk.no",Phonenumber="98238933",Address="Sydpolen 1", PostalareasId=9898, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("tullball"))},
                new Customers {Firstname = "Erna", Lastname="Solberg", Email="stats@minister.no",Phonenumber="45238932",Address="Løvebakken 5", PostalareasId=0001, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("høyre"))},
                new Customers {Firstname = "Herman", Lastname="Friele", Email="kaffe@bergen.no",Phonenumber="97232424",Address="Fløybanen 23", PostalareasId=5060, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("kaffe<3<3"))},
                new Customers {Firstname = "Egil", Lastname="Olsen", Email="drillo@norge.no",Phonenumber="98989898",Address="Ullevål stadion 1", PostalareasId=0123, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("landslag"))},
                new Customers {Firstname = "Roar", Lastname="Strand", Email="legende@rbk.no",Phonenumber="11333377",Address="Trondheim 1", PostalareasId=0123, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("legende"))},
                new Customers {Firstname = "Harald", Lastname="Rex", Email="konge@norge.no",Phonenumber="99999999",Address="Karl Johans gate 1", PostalareasId=0123, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("rulez"))},
                new Customers {Firstname = "Fredrik", Lastname="Skavland", Email="skavland@svensk.se",Phonenumber="20395738",Address="Partygata 15", PostalareasId=9123, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("talkshow"))},
                new Customers {Firstname = "Vegard", Lastname="Ylvisåker", Email="ylvis1@norge.no",Phonenumber="98888888",Address="Folketheateret 199", PostalareasId=0169, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("whatdoes"))},
                new Customers {Firstname = "Bård", Lastname="Ylvisåker", Email="ylvis2@norge.no",Phonenumber="89999999",Address="Folketheateret 200", PostalareasId=0169, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("thefoxsay"))},
                new Customers {Firstname = "Knudsen og", Lastname="Ludvigsen", Email="allsang@forbarn.no",Phonenumber="42546475",Address="Holmlia 67", PostalareasId=0184, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("allsang"))},
                new Customers {Firstname = "Barrack", Lastname="Obama", Email="mrpresident@whitehouse.gov",Phonenumber="11111111",Address="White House Oval Office", PostalareasId=8888, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("michellemytiger"))},
                new Customers {Firstname = "Ole", Lastname="Hansen Fransen", Email="ole@gmail.com",Phonenumber="40102803",Address="Skogstjerneveien 40", PostalareasId=2322, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("jarjarbinks"))},
                new Customers {Firstname = "DJ", Lastname="Dan", Email="almightydan@stavkroa.no",Phonenumber="40837382",Address="Staven Apartments", PostalareasId=3560, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("afterski"))},
                new Customers {Firstname = "Willhelm", Lastname="Tyskeberget", Email="willhelmtyskeb19@gmail.com",Phonenumber="91919191",Address="Myrhøl i Finnskog", PostalareasId=2256, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("ettanfrasverige"))},
                new Customers {Firstname = "Captain", Lastname="Morgan", Email="captain@morgan.com",Phonenumber="12345123",Address="The black pearl", PostalareasId=2322, Password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("rumandladies"))}
            };
            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();
            var orders = new List<Orders>
            {
                new Orders {OrderDate=RandomDay(), CustomersId=12},
                new Orders {OrderDate=RandomDay(), CustomersId=16},
                new Orders {OrderDate=RandomDay(), CustomersId=17},
                new Orders {OrderDate=RandomDay(), CustomersId=18},
                new Orders {OrderDate=RandomDay(), CustomersId=18},
                new Orders {OrderDate=RandomDay(), CustomersId=12},
                new Orders {OrderDate=RandomDay(), CustomersId=13},
                new Orders {OrderDate=RandomDay(), CustomersId=14},
                new Orders {OrderDate=RandomDay(), CustomersId=20},
                new Orders {OrderDate=RandomDay(), CustomersId=21},
                new Orders {OrderDate=RandomDay(), CustomersId=11},
                new Orders {OrderDate=RandomDay(), CustomersId=14},
                new Orders {OrderDate=RandomDay(), CustomersId=14},
                new Orders {OrderDate=RandomDay(), CustomersId=13},
                new Orders {OrderDate=RandomDay(), CustomersId=15},
                new Orders {OrderDate=RandomDay(), CustomersId=16},
                new Orders {OrderDate=RandomDay(), CustomersId=17},
                new Orders {OrderDate=RandomDay(), CustomersId=15},
                new Orders {OrderDate=RandomDay(), CustomersId=14},
                new Orders {OrderDate=RandomDay(), CustomersId=11},
                new Orders {OrderDate=RandomDay(), CustomersId=11},
                new Orders {OrderDate=RandomDay(), CustomersId=12},
                new Orders {OrderDate=RandomDay(), CustomersId=14},
                new Orders {OrderDate=RandomDay(), CustomersId=12},
                new Orders {OrderDate=RandomDay(), CustomersId=21},
                new Orders {OrderDate=RandomDay(), CustomersId=22},
                new Orders {OrderDate=RandomDay(), CustomersId=23},
                new Orders {OrderDate=RandomDay(), CustomersId=19},
                new Orders {OrderDate=RandomDay(), CustomersId=8},
                new Orders {OrderDate=RandomDay(), CustomersId=9},
                new Orders {OrderDate=RandomDay(), CustomersId=9},
                new Orders {OrderDate=RandomDay(), CustomersId=22},
                new Orders {OrderDate=RandomDay(), CustomersId=23},
                new Orders {OrderDate=RandomDay(), CustomersId=19},
                new Orders {OrderDate=RandomDay(), CustomersId=20},
                new Orders {OrderDate=RandomDay(), CustomersId=6},
                new Orders {OrderDate=RandomDay(), CustomersId=7},
                new Orders {OrderDate=RandomDay(), CustomersId=5},
                new Orders {OrderDate=RandomDay(), CustomersId=3},
                new Orders {OrderDate=RandomDay(), CustomersId=22},
                new Orders {OrderDate=RandomDay(), CustomersId=23},
                new Orders {OrderDate=RandomDay(), CustomersId=19},
                new Orders {OrderDate=RandomDay(), CustomersId=4},
                new Orders {OrderDate=RandomDay(), CustomersId=1},
                new Orders {OrderDate=RandomDay(), CustomersId=12},
                new Orders {OrderDate=RandomDay(), CustomersId=11},
                new Orders {OrderDate=RandomDay(), CustomersId=9},
                new Orders {OrderDate=RandomDay(), CustomersId=20},
                new Orders {OrderDate=RandomDay(), CustomersId=21},
                new Orders {OrderDate=RandomDay(), CustomersId=22},
                new Orders {OrderDate=RandomDay(), CustomersId=23},
                new Orders {OrderDate=RandomDay(), CustomersId=10},
                new Orders {OrderDate=RandomDay(), CustomersId=8},
                new Orders {OrderDate=RandomDay(), CustomersId=6},
                new Orders {OrderDate=RandomDay(), CustomersId=7},
                new Orders {OrderDate=RandomDay(), CustomersId=5},
                new Orders {OrderDate=RandomDay(), CustomersId=4},
                new Orders {OrderDate=RandomDay(), CustomersId=3},
                new Orders {OrderDate=RandomDay(), CustomersId=2},
                new Orders {OrderDate=RandomDay(), CustomersId=12},
                new Orders {OrderDate=RandomDay(), CustomersId=11},
                new Orders {OrderDate=RandomDay(), CustomersId=10},
                new Orders {OrderDate=RandomDay(), CustomersId=9},
                new Orders {OrderDate=RandomDay(), CustomersId=8},
                new Orders {OrderDate=RandomDay(), CustomersId=7},
                new Orders {OrderDate=RandomDay(), CustomersId=6},
                new Orders {OrderDate=RandomDay(), CustomersId=5},
                new Orders {OrderDate=RandomDay(), CustomersId=4},
                new Orders {OrderDate=RandomDay(), CustomersId=3},
                new Orders {OrderDate=RandomDay(), CustomersId=1},
                new Orders {OrderDate=RandomDay(), CustomersId=12},
                new Orders {OrderDate=RandomDay(), CustomersId=11},
                new Orders {OrderDate=RandomDay(), CustomersId=10},
                new Orders {OrderDate=RandomDay(), CustomersId=9},
                new Orders {OrderDate=RandomDay(), CustomersId=8},
                new Orders {OrderDate=RandomDay(), CustomersId=7},
                new Orders {OrderDate=RandomDay(), CustomersId=6},
                new Orders {OrderDate=RandomDay(), CustomersId=5},
                new Orders {OrderDate=RandomDay(), CustomersId=4},
                new Orders {OrderDate=RandomDay(), CustomersId=3},
                new Orders {OrderDate=RandomDay(), CustomersId=1},
                new Orders {OrderDate=RandomDay(), CustomersId=12},
                new Orders {OrderDate=RandomDay(), CustomersId=11},
                new Orders {OrderDate=RandomDay(), CustomersId=10},
                new Orders {OrderDate=RandomDay(), CustomersId=9},
                new Orders {OrderDate=RandomDay(), CustomersId=8},
                new Orders {OrderDate=RandomDay(), CustomersId=7},
                new Orders {OrderDate=RandomDay(), CustomersId=6},
                new Orders {OrderDate=RandomDay(), CustomersId=5},
                new Orders {OrderDate=RandomDay(), CustomersId=4},
                new Orders {OrderDate=RandomDay(), CustomersId=3},  
                new Orders {OrderDate=RandomDay(), CustomersId=1}
            };
            orders.ForEach(c => context.Orders.Add(c));
            context.SaveChanges();
            var orderlines = new List<OrderLines>
            {

                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298514},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298514},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298514},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298514},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298514},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298514},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298513},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298513},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298513},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298513},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298513},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298512},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298512},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298512},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298512},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298511},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298511},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298511},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298510},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298510},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298510},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298509},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298509},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298500},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298509},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298508},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298507},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298506},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298506},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298505},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298504},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298503},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298503},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298503},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298502},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298502},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298502},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298502},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298501},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298500},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298500},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298499},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298498},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298498},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298497},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298496},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298497},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298495},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298495},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298494},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298494},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298494},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298494},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298493},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298493},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298493},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298493},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298492},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298492},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298491},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298490},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298490},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298490},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298489},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298489},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298489},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298488},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298488},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298487},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298487},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298486},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298486},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298486},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298485},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298485},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298485},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298485},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298485},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298484},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298484},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298484},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298484},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298484},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298484},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298483},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298483},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298483},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298483},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298482},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298482},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298481},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298481},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298481},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298480},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298479},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298479},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298479},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298479},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298478},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298478},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298478},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298477},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298477},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298477},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298477},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298476},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298475},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298475},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298474},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298473},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298472},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298471},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298470},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298469},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298468},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298467},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298466},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298465},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298464},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298463},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298462},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298461},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298461},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298460},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298459},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298458},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298457},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298456},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298456},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298455},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298454},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298454},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298453},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298453},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298453},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298453},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298453},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298453},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298452},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298451},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298450},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298449},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298449},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298448},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298447},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 4, OrdersId=298447},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 4, OrdersId=298446},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 5, OrdersId=298445},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 1, OrdersId=298444},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298443},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298443},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298442},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298441},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298440},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 5, OrdersId=298439},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298439},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 5, OrdersId=298439},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 4, OrdersId=298439},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298439},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298438},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 5, OrdersId=298438},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 7, OrdersId=298438},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 1, OrdersId=298437},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 9, OrdersId=298437},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 5, OrdersId=298436},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 1, OrdersId=298436},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298435},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298435},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 6, OrdersId=298435},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298434},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298434},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 7, OrdersId=298434},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298433},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 1, OrdersId=298433},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 1, OrdersId=298432},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 6, OrdersId=298431},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298431},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298430},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298429},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 1, OrdersId=298428},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298427},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298427},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 1, OrdersId=298427},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298426},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 4, OrdersId=298426},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298426},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 4, OrdersId=298425},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 5, OrdersId=298425},
                new OrderLines {ProductsId=RandomProduct(), Quantity = RandomQuantity(), OrdersId=298425},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 8, OrdersId=298425},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298424},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 1, OrdersId=298424},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 1, OrdersId=298423},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 3, OrdersId=298423},
                new OrderLines {ProductsId=RandomProduct(), Quantity = 1, OrdersId=298423}
            }; 
            orderlines.ForEach(c => context.OrderLines.Add(c));
            context.SaveChanges();
        }
        DateTime RandomDay()
        {           
            return start.AddDays(prodDate.Next(dateRange));
        }
        int RandomProduct()
        {

            return prodGen.Next(100001, 100047);
        }
        int RandomQuantity() 
        {

            return prodQuant.Next(1, 5); 
        }
    }
}


/*
,
                
*/