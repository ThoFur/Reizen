use master;

drop database if exists reizen;
create database reizen;
go
use reizen;

create table woonplaatsen (
	id int not null primary key identity,
	postcode int not null,
	naam varchar(50) not null
);

insert into woonplaatsen(postcode, naam) values
(8000, 'Brugge'),
(9300, 'Aalst'),
(2300, 'Turnhout'),
(3500, 'Hasselt'),
(2000, 'Antwerpen'),
(3800, 'Sint-Truiden'),
(8800, 'Roeselare'),
(9800, 'Deinze'),
(8810, 'Lichtervelde'),
(8500, 'Kortrijk'),
(3700, 'Tongeren'),
(9000, 'Gent'),
(3600, 'Genk'),
(8400, 'Oostende'),
(2200, 'Herentals');

create table klanten (
  id int not null primary key identity,
  familienaam varchar(50) not null,
  voornaam varchar(50) not null,
  adres varchar(50) not null,
  woonplaatsid int not null,
  constraint klanten_woonplaatsen foreign key(woonplaatsid) references woonplaatsen(id)
);

INSERT INTO klanten(familienaam, voornaam, adres, woonplaatsid) values
('Rovers', 'Veerle', 'Kerkstraat 26', 1),
('Vandenabeele', 'Marc', 'Markt 16', 2),
('Tijtgat', 'Ward', 'Noordstraat 23', 3),
('Dhollander', 'Dirk', 'Sepulkrijnenlaan 14', 4),
('Vanacker', 'Hanne', 'Langestraat 98', 3),
('Catteeuw', 'Eric', 'Provinciestraat 14', 5),
('Bonnet', 'Roger', 'St-Hubertuslaan 41', 6),
('Platteau', 'Magda', 'Vijfwegenstraat 164', 7),
('Van Elk', 'Peter', 'Molenstraat 56', 8),
('Van den Broecke', 'Lucie', 'Koning Albertlaan 23', 6),
('Lanssens', 'Piet', 'Hoogstraat 10', 7),
('Ramon', 'Johan', 'Beukenlaan 16', 9),
('De Clerk', 'Dorine', 'Lindenlaan 23', 6),
('Glorieux', 'Ann', 'Hoogstraat 2', 2),
('Janssens', 'Johan', 'Kortrijkse steenweg 56', 8),
('Kerkhove', 'Greet', 'Kattestraat 10', 15),
('Desmet', 'Jozef', 'Brugse steenweg 203', 7),
('Ruysschaert', 'Ann', 'Beheersstraat 12', 10),
('Van Den Broecke', 'Luc', 'Eikenberg 62', 11),
('Vandenbroucke', 'Jan', 'Stationsstraat 89', 4),
('Declerck', 'Mia', 'Rodestraat 12', 11),
('Deschuymere', 'Kathy', 'Jozef Plateaustraat 10', 13),
('Cloet', 'Hugo', 'Keizerlei 57', 5),
('Coopman', 'Peter', 'Eikenlaan 54', 8),
('Deschuymer', 'Elsie', 'St-Pietersnieuwstraat 2',  13),
('Lambrecht', 'Geert', 'Groenstraat 412', 15),
('Janssens', 'Dirk', 'Grote Markt 12', 10),
('Goethals', 'Patrick', 'Romeinse laan 16', 10),
('Meuleman', 'Luc', 'Italiëlei 203', 5),
('Staelens', 'Els', 'Scheldestraat 89', 5),
('Blomme', 'Alain', 'Klaverheide 10', 5),
('D''hollander', 'Luc', 'Zuidmolenstraat 12', 7),
('Vanackere', 'Charlotte', 'Zuidstraat 87', 2),
('Desmedt', 'Mia', 'Stationsstraat 16', 1),
('Grymonprez', 'Hans', 'Heidebloemlaan 16', 15),
('Cooman', 'Eric', 'Leopold 3-laan', 14),
('Mussche', 'Rose-Anne', 'Overleiestraat 10', 10),
('Bonte', 'Louise', 'Westlaan 16', 7),
('Vandenbroecke', 'Stefaan', 'Sikkelstraat 56', 11),
('Vanden Abeele', 'Roger', 'Tongerse steenweg 124', 4),
('Declercq', 'Maria', 'Demerstraat 45', 4),
('Kerckhof', 'Guido', 'Sterreweg 45', 15),
('Jansen', 'Wilfried', 'Blandijnberg 56', 12),
('De Smet', 'Dirk', 'Kouter 23', 12),
('Jansens', 'Simon', 'Schoolstraat 78', 3),
('Waterloos', 'Marie-Anne', 'Overpoortstraat 25', 12),
('Janssen', 'Veerle', 'Kortrijkse steenweg 10', 12),
('Stockmans', 'Mieke', 'Oude Vest 14', 2),
('Dereygere', 'Clement', 'Berkenlaan 8', 13),
('Jacobs', 'Dirk', 'Vindictievelaan 14', 14);

create table werelddelen (
	id int not null primary key identity,
    naam varchar(50) not null unique);
    
insert into werelddelen(naam) values
('West Europa'),
('Afrika'),
('Azië'),
('Zuid-Amerika'),
('Noord-Amerika'),
('Centraal-Amerika');

create table landen (
	id int not null primary key identity,
    naam varchar(50) not null unique,
    werelddeelid int not null,
    constraint landen_werelddelen foreign key(werelddeelid) references werelddelen(id)
);
    
insert into landen(naam, werelddeelid) values 
('Turkije',1),
('Egypte',2),
('Irak',3),
('Indonesië',3),
('Thailand',3),
('Spanje',1),
('Colombia',4),
('Argentinië',4),
('Canada',5),
('Venezuela',4),
('Marokko',2),
('Frankrijk',1),
('Verenigde Staten',5),
('Duitsland',1),
('Cuba',6),
('Finland',1),
('Peru',4),
('Filipijnen',3),
('Mexico',4),
('Uruguay',4),
('China',3),
('Brazilië',4);    

create table bestemmingen (
  code char(5) not null primary key,
  landid int not null,
  plaats varchar(20) not null,
  constraint bestemmingen_landen foreign key (landid) references landen(id)
);

insert into bestemmingen(code,plaats,landid) values
('VERAC', 'Veracruz', 19),
('ALANY','Alanya',1),
('ALEXA', 'Alexandrie', 2),
('ANTAL','Antalya',1),
('BAGHD', 'Baghdad', 3),
('BALI', 'Bali (Kuta)', 4),
('BANGK', 'Bangkok', 5),
('BARCE',  'Barcelona', 6),
('BASRA',  'Basra', 3),
('BENID',  'Benidorm', 6),
('BOGOT', 'Bogota', 7),
('BUENO',  'Buenos Aires', 8),
('CAIRO', 'Caïro', 2),
('CALGA',  'Calgary', 9),
('CARAC',  'Caracas', 10),
('CARTA',  'Cartagena', 7),
('CASSA', 'Cassablanca', 11),
('CHIAN', 'Chiangmai', 5),
('CORDO', 'Cordoba', 8),
('CORSI',  'Corsica', 12),
('HAVA',  'Havana', 15),
('DALLA',  'Dallas', 13),
('DROME',  'Drome', 12),
('DUSSD',  'Dusseldorf', 14),
('ELALA', 'El''Alamein', 2),
('GERON',  'Gerona', 6),
('GITES', 'Gites', 12),
('GRANC',  'Gran Canaria', 6),
('HELSI','Helsinki', 16),
('ISTAN', 'Istanbul', 1),
('JAKAR', 'Jakarta', 4),
('KIRKU', 'Kirkuk', 3),
('LIMA', 'Lima', 17),
('MADRI',  'Madrid', 6),
('MANIL', 'Manila', 18),
('MARDE',  'Mar del Plata', 8),
('MEDAN',  'Medan', 4),
('MEXIC',  'Mexico', 19),
('MIAMI',  'Miami', 13),
('MOIRA', 'Moirara', 6),
('MONTE',  'Montevideo', 20),
('MONTR',  'Montreal', 9),
('MOSUL', 'Mosul', 3),
('NEWOR',  'New Orleans', 13),
('OTTAW',  'Ottawa', 9),
('PARIJ',  'Parijs', 12),
('PATTA',  'Pattaya', 5),
('PEKIN',  'Peking', 21),
('RABAT', 'Rabat', 11),
('RECIF',  'Recife', 22),
('RIO', 'Rio de Janeiro', 22),
('SALOU', 'Salou', 6),
('SANFR',  'San Francisco', 13),
('SANPA','San Pablo',18),
('SAOPA',  'Sao Paulo', 22),
('SURUB', 'Surubaya', 4),
('TANGE',  'Tanger', 11),
('THEBE', 'Thebes', 2);

create table  reizen (
  id int not null primary key identity,
  bestemmingscode char(5) not null,
  vertrek date not null,
  aantalDagen int not null,
  prijsPerPersoon decimal(10,2) not null,
  aantalVolwassenen int not null default 0,
  aantalKinderen int not null default 0,
  constraint reizen_bestemmingen foreign key(bestemmingscode) references bestemmingen(code)
);

insert into reizen (bestemmingscode, vertrek, aantalDagen, prijsPerPersoon) values
('SANPA', dateadd(day, -10, getdate()), 14, 2300),
('SANFR', dateadd(day, -20, getdate()), 14, 3200),
('BALI', dateadd(day, -30, getdate()), 21, 4300),
('CORSI', dateadd(day, 40, getdate()), 23, 1600),
('CORDO', dateadd(day, 50, getdate()), 21, 5300),
('MADRI', dateadd(day, 60, getdate()), 10, 1400),
('SANPA', dateadd(day, 70, getdate()), 23, 4900),
('RABAT', dateadd(day, 80, getdate()), 12, 2770),
('TANGE', dateadd(day, 90, getdate()), 23, 3650),
('VERAC', dateadd(day, 100, getdate()), 14, 4900),
('MEDAN', dateadd(day, 10, getdate()), 19, 5320),
('TANGE', dateadd(day, 20, getdate()), 14, 2795),
('GRANC', dateadd(day, 30, getdate()), 10, 1300),
('ISTAN', dateadd(day, 40, getdate()), 14, 2773),
('HELSI', dateadd(day, 50, getdate()), 12, 2399),
('MIAMI', dateadd(day, 60, getdate()), 23, 5890),
('RABAT', dateadd(day, 70, getdate()), 14, 2950),
('RABAT', dateadd(day, 80, getdate()), 21, 3590),
('GITES', dateadd(day, 90, getdate()), 14, 3200),
('LIMA', dateadd(day, 100, getdate()), 28, 6790),
('BANGK', dateadd(day, 10, getdate()), 22, 5395),
('SURUB', dateadd(day, 20, getdate()), 28, 6666),
('CAIRO', dateadd(day, 30, getdate()), 8, 1468),
('BARCE', dateadd(day, 40, getdate()), 9, 1240),
('DUSSD', dateadd(day, 50, getdate()), 4, 840),
('MOIRA', dateadd(day, 60, getdate()), 20, 1630),
('MIAMI', dateadd(day, 70, getdate()), 21, 5300),
('CORSI', dateadd(day, 80, getdate()), 10, 2400),
('HAVA', dateadd(day, 90, getdate()), 14, 1800);

create table boekingen (
  id int not null primary key identity,
  klantid int not null,
  reisid int not null,
  geboektOp date not null,
  aantalVolwassenen int,
  aantalKinderen int ,
  annulatieVerzekering bit not null,
  constraint boekingen_klanten foreign key(klantid) references klanten(id),
  constraint boekingen_reizen foreign key(reisid) references reizen(id)
);