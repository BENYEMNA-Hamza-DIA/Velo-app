-- PROBELEME: CREATION DE LA DATABASE
-- ====================================

-- Création de la database

#show variables like 'sql_safe_updates' ;
#set sql_safe_updates = 0 ;

create database data_probleme;

#drop database if exists data_probleme;

use data_probleme;


-- Création des tables
#------------------------------------------------------------
# Table: Client_entreprise
#------------------------------------------------------------

CREATE TABLE Client_entreprise(
        nom_compagnie_entreprise      Varchar (100) NOT NULL ,
        rue_entreprise                Varchar (100) NOT NULL ,
        ville_entreprise              Varchar (100) NOT NULL ,
        code_postale_entreprise       Int (100) NOT NULL ,
        province_entreprise           Varchar (100) NOT NULL ,
        telephone_entreprise          Int (100) NOT NULL ,
        courriel_entreprise           Varchar (100) NOT NULL ,
        nom_contact_entreprise        Varchar (100) NOT NULL ,
        pourcentage_remise_entreprise Double (100,30)
	,CONSTRAINT Client_entreprise_PK PRIMARY KEY (nom_compagnie_entreprise)
)ENGINE=InnoDB;

#------------------------------------------------------------
# Table: Fournisseur
#------------------------------------------------------------

CREATE TABLE Fournisseur(
        num_siret_fournisseur    Int (100) NOT NULL ,
        nom_fournisseur          Varchar (100) NOT NULL ,
        contact_fournisseur      Varchar (100) NOT NULL ,
        rue_fournisseur          Varchar (100) NOT NULL ,
        ville_fournisseur        Varchar (100) NOT NULL ,
        code_postale_fournisseur Int (100) NOT NULL ,
        province_fournisseur     Varchar (100) NOT NULL ,
        label_fournisseur        Int (100) NOT NULL
	,CONSTRAINT Fournisseur_PK PRIMARY KEY (num_siret_fournisseur)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Client_particulier
#------------------------------------------------------------

CREATE TABLE Client_particulier(
        id_particulier           Int (100) NOT NULL ,
        nom_particulier          Varchar (100) NOT NULL ,
        prenom_particulier       Varchar (100) NOT NULL ,
        rue_particulier          Varchar (100) NOT NULL ,
        ville_particulier        Varchar (100) NOT NULL ,
        code_postale_particulier Int (100) NOT NULL ,
        province_particulier     Varchar (100) NOT NULL ,
        telephone_particulier    Int (100) NOT NULL ,
        courriel_particulier     Varchar (100) NOT NULL ,
        num_programme_fidelio    Int (100)
	,CONSTRAINT Client_particulier_PK PRIMARY KEY (id_particulier)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Commande
#------------------------------------------------------------

CREATE TABLE Commande(
        num_commande                  Int (100) NOT NULL ,
        date_commande                 Datetime NOT NULL ,
        rue_livraison_commande          Varchar (100) NOT NULL ,
        ville_livraison_commande        Varchar (100) NOT NULL ,
        code_postale_livraison_commande Int (100) NOT NULL ,
        province_livraison_commande     Varchar (100) NOT NULL ,
        quantite_bicyclettes_commande Int (100) NOT NULL ,
        quantite_pieces_commande      Int (100) NOT NULL ,
        date_livraison_commande       Datetime NOT NULL ,
        nom_compagnie_entreprise      Varchar (100),
        id_particulier                Int (100)
	,CONSTRAINT Commande_PK PRIMARY KEY (num_commande)

	,CONSTRAINT Commande_Client_entreprise_FK FOREIGN KEY (nom_compagnie_entreprise) REFERENCES Client_entreprise(nom_compagnie_entreprise)
	,CONSTRAINT Commande_Client_particulier0_FK FOREIGN KEY (id_particulier) REFERENCES Client_particulier(id_particulier)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Bicyclette
#------------------------------------------------------------

CREATE TABLE Bicyclette(
		id_bicyclette			Varchar(100) NOT NULL,
        num_modele_bicyclette    Int (100) NOT NULL ,
        nom_bicyclette           Varchar (100) NOT NULL ,
        grandeur_bicyclette      Varchar (100) NOT NULL ,
        prix_unitaire_bicyclette Int (100) NOT NULL ,
        ligne_produit_bicyclette Varchar (100) NOT NULL ,
        num_commande             Int (100)	
	,CONSTRAINT Bicyclette_PK PRIMARY KEY (id_bicyclette)

	,CONSTRAINT Bicyclette_Commande_FK FOREIGN KEY (num_commande) REFERENCES Commande(num_commande)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Piece
#------------------------------------------------------------

CREATE TABLE Piece (
		id_produit_piece				Varchar(100) NOT NULL,
        num_produit_piece              varchar (100) NOT NULL ,
        description_piece              Varchar (100) NOT NULL ,
        prix_unitaire_piece            Int (100) NOT NULL ,
        date_introduction_marche_piece Datetime NOT NULL ,
        date_discontinuation_piece     Datetime NOT NULL ,
        nom_fournisseur                Varchar (100) NOT NULL ,
        id_bicyclette         Varchar (100) ,
        num_commande                   Int (100)	
	,CONSTRAINT Piece_PK PRIMARY KEY (id_produit_piece)

	,CONSTRAINT Piece_Bicyclette_FK FOREIGN KEY (id_bicyclette) REFERENCES Bicyclette(id_bicyclette)
	,CONSTRAINT Piece_Commande0_FK FOREIGN KEY (num_commande) REFERENCES Commande(num_commande)
)ENGINE=InnoDB;

#------------------------------------------------------------
# Table: Fournir
#------------------------------------------------------------

CREATE TABLE Fournir(
        id_produit_piece             Varchar (100) NOT NULL ,
        num_siret_fournisseur         Int (100) NOT NULL ,
        num_produit_fournisseur       Int (100) NOT NULL ,
        delai_approvisionnement_piece Time NOT NULL
	,CONSTRAINT Fournir_PK PRIMARY KEY (id_produit_piece,num_siret_fournisseur)

	,CONSTRAINT Fournir_Piece_FK FOREIGN KEY (id_produit_piece) REFERENCES Piece(id_produit_piece )
	,CONSTRAINT Fournir_Fournisseur0_FK FOREIGN KEY (num_siret_fournisseur) REFERENCES Fournisseur(num_siret_fournisseur)
)ENGINE=InnoDB;


-- Création des utilisateaurs avec connexion root et bozo en lecture seule

--
#create user 'user-reader'@'localhost' identified by 'mdp-reader' ;

#create user 'user-writer'@'localhost' identified by 'mdp-writer';

-- Occtroiement des droits aux utilisateurs

#grant select on data_probleme.* to 'user-reader'@'localhost' ;

#grant all on data_probleme.* to 'user-writer'@'localhost';
--
#select * from mysql.user;

#drop user 'user-writer'@'localhost';


#---------------------------------------------------------------------------------------------------------------


-- Remplissage des tables 

-- Fournisseur

insert into Fournisseur values (123,'THOMPSON & THOMPSON','0458795458','24 Quai de Rive Neuve','Marseille',13007,'Provence-Alpes-Côte d’Azur',1);
insert into Fournisseur values (145,'COBANYAL BIKES','0475984285','3 Rue Frédéric Mistral','Aix-en-Provence',13100,'Provence-Alpes-Côte d’Azur',2);
insert into Fournisseur values (751,'MIRANDA & IRMA, DLA','0471974521','16 Rue Frédéric Mistral', 'Gignac-la-Nerthe', 13180,'Provence-Alpes-Côte d’Azur',1);
insert into Fournisseur values (452,'SERENISSIMO COMMERCIALE SRL','0445218679','7 av. du Lac' , 'Embrun', 05200,'Provence-Alpes-Côte d’Azur',2);
insert into Fournisseur values (512,'SUPERBIKE','0489654123','523 Rue Sainte-Geneviève' , 'Avignon', 84000 ,'Provence-Alpes-Côte d’Azur',4);
insert into Fournisseur values (378,'VELOMANIA','0487451267','26 Avenue Clément Ader' , 'Istres', 13800  ,'Provence-Alpes-Côte d’Azur',3);

-- Clients entreprise

insert into Client_entreprise values ('Easy Rider','Avenue Denis Padovani', 'Vitrolles',13127,'Provence-Alpes-Côte d’Azur','0442151050','EasyRider@gmail.com','Strebi',2.5);
insert into Client_entreprise values ('Tinabico','Route Nationale 113', 'Vitrolles',13127,'Provence-Alpes-Côte d’Azur','0442845687','Tinabico_Bike@gmail.com','Amery',4);
insert into Client_entreprise values ('Bike Marseille Vélodrome','3 Boulevard Michelet','Marseille', 13008 ,'Provence-Alpes-Côte d’Azur','0447841687','BikeVelodrome@gmail.com','Olive',4);

-- Clients particulier

insert into Client_particulier values (754,'Detair', 'Billy','53 La Canebière','Marseille',13001 ,'Provence-Alpes-Côte d’Azur',0706060,'Rdetair@gmail.com',null);
insert into Client_particulier values (792,'Zousa', 'Kotei','7 Place du Mérou','Marseille',13016 ,'Provence-Alpes-Côte d’Azur',0778452695,'KoteiZousaa@gmail.com',null);
insert into Client_particulier values (086,'Mirio', 'Driss','14 Résidence Campagne Lévêque', 'Marseille',13015,'Provence-Alpes-Côte d’Azur',0678450495,'DrissMirioo@gmail.com',null);
insert into Client_particulier values (068,'Berlouni', 'Boulbaba','1 Cours Julien', 'Marseille',13001,'Provence-Alpes-Côte d’Azur',0654875219,'BoublBaBerlou@gmail.com',null);
insert into Client_particulier values (992,'Raconte', 'Miguel','Rue Fort du Sanctuaire','Marseille', 13281,'Provence-Alpes-Côte d’Azur',0785342655,'MiguelTom@gmail.com',null);
insert into Client_particulier values (667,'Kebir', 'Kamel','162 Boulevard Mireille Lauze', 'Marseille',13010,'Provence-Alpes-Côte d’Azur',0678450485,'KametoK@gmail.com',null);

-- Commande

insert into Commande values (2,'2021-05-20', '96 Rue de 8 mai 1945','Cavaillon',84300,'Provence-Alpes-Côte d’Azur',2,0,'2021-05-25','Easy Rider',null);
insert into Commande values (3,'2021-05-27', '96 Rue de 8 mai 1945','Cavaillon',84300,'Provence-Alpes-Côte d’Azur',1,0,'2021-06-1','Easy Rider',null);
insert into Commande values (4,'2021-05-25', '96 Rue de 8 mai 1945','Cavaillon',84300,'Provence-Alpes-Côte d’Azur',1,0,'2021-05-27','Easy Rider',null);
insert into Commande values (5,'2021-05-24', '96 Rue de 8 mai 1945','Cavaillon',84300,'Provence-Alpes-Côte d’Azur',1,1,'2021-05-28','Easy Rider',null);
insert into Commande values (10,'2021-05-20', 'Route Nationale 113', 'Vitrolles',13127,'Provence-Alpes-Côte d’Azur',0,5,'2021-05-25','Tinabico',null);
insert into Commande values (11,'2021-05-27', 'Route Nationale 113', 'Vitrolles',13127,'Provence-Alpes-Côte d’Azur',1,0,'2021-06-1','Tinabico',null);
insert into Commande values (12,'2021-05-25', 'Route Nationale 113', 'Vitrolles',13127,'Provence-Alpes-Côte d’Azur',0,1,'2021-05-27','Tinabico',null);
insert into Commande values (15,'2021-05-20', '53 La Canebière','Marseille',13001 ,'Provence-Alpes-Côte d’Azur',0,5,'2021-05-25',null,754);
insert into Commande values (16,'2021-05-27', '53 La Canebière','Marseille',13001 ,'Provence-Alpes-Côte d’Azur',1,0,'2021-06-1',null,754);
insert into Commande values (17,'2021-05-25', '53 La Canebière','Marseille',13001 ,'Provence-Alpes-Côte d’Azur',0,1,'2021-05-27',null,754);
insert into Commande values (18,'2021-05-20', '7 Place du Mérou','Marseille',13016 ,'Provence-Alpes-Côte d’Azur',0,5,'2021-05-25',null,792);
insert into Commande values (19,'2021-05-27', '7 Place du Mérou','Marseille',13016 ,'Provence-Alpes-Côte d’Azur',2,0,'2021-06-1',null,792);
insert into Commande values (20,'2021-05-25', '7 Place du Mérou','Marseille',13016,'Provence-Alpes-Côte d’Azur',0,2,'2021-05-27',null,792);
insert into Commande values (21,'2021-05-27', '3 Boulevard Michelet','Marseille', 13008, 'Provence-Alpes-Côte d’Azur',1,1,'2021-06-1',null,086);
insert into Commande values (22,'2021-05-25', '3 Boulevard Michelet','Marseille', 13008, 'Provence-Alpes-Côte d’Azur',0,1,'2021-05-27',null,086);
insert into Commande values (23,'2021-05-24', '3 Boulevard Michelet','Marseille', 13008,'Provence-Alpes-Côte d’Azur',1,0,'2021-05-28','Bike Marseille Vélodrome',null);
insert into Commande values (24,'2021-05-24', 'Rue Fort du Sanctuaire','Marseille', 13281,'Provence-Alpes-Côte d’Azur',1,0,'2021-05-28',null,992);
insert into Commande values (25,'2021-05-18', '162 Boulevard Mireille Lauze', 'Marseille',13010,'Provence-Alpes-Côte d’Azur',1,0,'2021-05-18',null,667);

-- Piece

insert into Piece values ('C320001','C32','Cadre',280,'2014-04-05', '2021-04-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('G700001','G7','Guidon',30,'2019-08-12', '2029-08-13', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('F300001','F3','Freins',30,'2018-02-28', '2028-03-01', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('S880001','S88','Selle',50,'2015-06-10', '2025-04-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('DV10001','DV133','Derailleur Avant',20,'2020-08-25', '2030-08-26', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('DR50001','DR56','Derailleur Arriere',20,'2018-04-05', '2028-04-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('R450001','R45','Roue Avant',70,'2016-08-18', '2026-08-18', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('R460002','R46','Roue Arriere',80,'2016-02-12', '2026-02-12', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('P120001','P12','Pedalier',60,'2020-06-10', '2030-04-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('O200001','O2','Ordinateur',200,'2015-08-25', '2025-08-26', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('C340001','C34','Cadre',300,'2019-04-05', '2029-04-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('G700002','G7','Guidon',30,'2019-08-12', '2029-08-13', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('F300002','F3','Freins',30,'2018-02-28', '2028-03-01', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('S880002','S88','Selle',50,'2015-06-10', '2025-04-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('DV10002','DV17','Derailleur Avant',25,'2021-01-25', '2031-01-26', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('DR80001','DR87','Derailleur Arriere',22,'2019-02-05', '2028-02-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('R480001','R48','Roue Avant',80,'2018-08-18', '2028-08-18', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('R470001','R47','Roue Arriere',90,'2018-02-12', '2028-02-12', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('P120002','P12','Pedalier',60,'2020-06-10', '2030-04-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('C340002','C76','Cadre',250,'2019-08-05', '2029-08-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('G700003','G7','Guidon',30,'2019-08-12', '2029-08-13', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('F300003','F3','Freins',30,'2018-02-28', '2028-03-01', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('S880003','S88','Selle',50,'2015-06-10', '2025-04-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('DV10003','DV17','Derailleur Avant',25,'2021-01-25', '2031-01-26', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('DR80002','DR87','Derailleur Arriere',22,'2019-02-05', '2029-02-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('R480002','R48','Roue Avant',80,'2018-08-18', '2028-08-18', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('R470002','R47','Roue Arriere',90,'2018-02-12', '2028-02-12', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('P120003','P12','Pedalier',60,'2020-06-10', '2030-04-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('O200002','O2','Ordinateur',200,'2015-08-25', '2025-08-26', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('C340003','C76','Cadre',250,'2019-08-05', '2029-08-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('G700004','G7','Guidon',30,'2019-08-12', '2029-08-13', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('F300004','F3','Freins',30,'2018-02-28', '2028-03-01', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('S880004','S88','Selle',50,'2015-06-10', '2025-04-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('DV80001','DR87','Derailleur Avant',22,'2019-02-05', '2029-02-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('DR80004','DR86','Derailleur Arriere',22,'2018-02-05', '2028-02-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('R120001','R12','Roue Avant',50,'2018-08-18', '2028-08-18', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('R320001','R32','Roue Arriere',60,'2018-02-12', '2028-02-12', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('P120004','P12','Pedalier',60,'2020-06-10', '2030-04-06', 'THOMPSON & THOMPSON' ,null,null);
insert into Piece values ('C430001','C43','Cadre',1050,'2019-08-05', '2029-08-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('G900001','G9','Guidon',180,'2019-08-12', '2029-08-13', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('F900001','F9','Freins',40,'2019-02-28', '2029-03-01', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('S370001','S37','Selle',115,'2019-06-10', '2029-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('DV50001','DV57','Derailleur Avant',50,'2019-02-05', '2029-02-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('DR80008','DR86','Derailleur Arriere',65,'2018-02-05', '2028-02-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R190001','R19','Roue Avant',180,'2019-08-18', '2029-08-18', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R180001','R18','Roue Arriere',190,'2019-02-12', '2029-02-12', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R020001','R02','Reflecteur',10,'2014-06-10', '2024-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('P340001','P34','Pedalier',115,'2020-06-10', '2030-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('C440001','C44f','Cadre',1050,'2019-08-05', '2029-08-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('G900002','G9','Guidon',180,'2019-08-12', '2029-08-13', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('F900002','F9','Freins',40,'2019-02-28', '2029-03-01', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('S350001','S35','Selle',115,'2019-06-10', '2029-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('DV50002','DV57','Derailleur Avant',50,'2019-02-05', '2029-02-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('DR80003','DR86','Derailleur Arriere',65,'2018-02-05', '2028-02-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R190002','R19','Roue Avant',180,'2019-08-18', '2029-08-18', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R180002','R18','Roue Arriere',190,'2019-02-12', '2029-02-12', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R020002','R02','Reflecteur',10,'2014-06-10', '2024-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('P340002','P34','Pedalier',115,'2020-06-10', '2030-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('C430002','C43','Cadre',1050,'2019-08-05', '2029-08-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('G900003','G9','Guidon',180,'2019-08-12', '2029-08-13', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('F900003','F9','Freins',40,'2019-02-28', '2029-03-01', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('S370002','S37','Selle',115,'2019-06-10', '2029-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('DV50003','DV57','Derailleur Avant',50,'2019-02-05', '2029-02-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('DR80009','DR86','Derailleur Arriere',65,'2018-02-05', '2028-02-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R190003','R19','Roue Avant',180,'2019-08-18', '2029-08-18', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R180003','R18','Roue Arriere',190,'2019-02-12', '2029-02-12', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R020003','R02','Reflecteur',10,'2014-06-10', '2024-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('P340003','P34','Pedalier',115,'2020-06-10', '2030-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('O400001','O4','Ordinateur',350,'2019-08-25', '2029-08-26', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('C430003','C43f','Cadre',1030,'2019-08-05', '2029-08-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('G900004','G9','Guidon',180,'2019-08-12', '2029-08-13', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('F900004','F9','Freins',40,'2019-02-28', '2029-03-01', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('S350002','S35','Selle',115,'2019-06-10', '2029-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('DV50086','DV57','Derailleur Avant',50,'2019-02-05', '2029-02-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('DR80010','DR86','Derailleur Arriere',65,'2018-02-05', '2028-02-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R190004','R19','Roue Avant',180,'2019-08-18', '2029-08-18', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R180004','R18','Roue Arriere',190,'2019-02-12', '2029-02-12', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('R020004','R02','Reflecteur',10,'2014-06-10', '2024-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('P340004','P34','Pedalier',115,'2020-06-10', '2030-04-06', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('O400002','O4','Ordinateur',350,'2019-08-25', '2029-08-26', 'COBANYAL BIKES' ,null,null);
insert into Piece values ('C430009','C43','Cadre',1050,'2019-08-05', '2029-08-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('G900005','G9','Guidon',180,'2019-08-12', '2029-08-13', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('F900783','F9','Freins',40,'2019-02-28', '2029-03-01', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('S370802','S37','Selle',115,'2019-06-10', '2029-04-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('DV50009','DV57','Derailleur Avant',50,'2019-02-05', '2029-02-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('DR80025','DR86','Derailleur Arriere',65,'2018-02-05', '2028-02-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R190903','R19','Roue Avant',180,'2019-08-18', '2029-08-18', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R180903','R18','Roue Arriere',190,'2019-02-12', '2029-02-12', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R020903','R02','Reflecteur',10,'2014-06-10', '2024-04-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('P340903','P34','Pedalier',115,'2020-06-10', '2030-04-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('O409001','O4','Ordinateur',350,'2019-08-25', '2029-08-26', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('C430010','C43f','Cadre',1030,'2019-08-05', '2029-08-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('G900006','G9','Guidon',180,'2019-08-12', '2029-08-13', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('F900054','F9','Freins',40,'2019-02-28', '2029-03-01', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('S350062','S35','Selle',115,'2019-06-10', '2029-04-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('DV50014','DV57','Derailleur Avant',50,'2019-02-05', '2029-02-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('DR80035','DR86','Derailleur Arriere',65,'2018-02-05', '2028-02-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R190074','R19','Roue Avant',180,'2019-08-18', '2029-08-18', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R180084','R18','Roue Arriere',190,'2019-02-12', '2029-02-12', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R020094','R02','Reflecteur',10,'2014-06-10', '2024-04-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('P340784','P34','Pedalier',115,'2020-06-10', '2030-04-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('O400742','O4','Ordinateur',350,'2019-08-25', '2029-08-26', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('C010001','C01','Cadre',90,'2018-08-05', '2028-08-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('G120001','G12','Guidon',40,'2015-08-12', '2025-08-13', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('S020001','S02','Selle',15,'2014-06-10', '2024-04-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R100001','R1','Roue Avant',30,'2017-08-18', '2027-08-18', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R200001','R2','Roue Arriere',35,'2017-02-12', '2027-02-12', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R090001','R09','Reflecteur',5,'2014-06-10', '2024-04-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('P100001','P1','Pedalier',60,'2020-11-10', '2030-11-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('S010001','S01','Panier',15,'2015-08-25', '2025-08-26', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('C020001','C02','Cadre',90,'2018-08-05', '2028-08-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('G120002','G12','Guidon',40,'2015-08-12', '2025-08-13', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('S030001','S03','Selle',15,'2014-06-10', '2024-04-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R100002','R1','Roue Avant',30,'2017-08-18', '2027-08-18', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R200002','R2','Roue Arriere',35,'2017-02-12', '2027-02-12', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('R090002','R09','Reflecteur',10,'2014-06-10', '2024-04-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('P100002','P1','Pedalier',115,'2020-11-10', '2030-11-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('S050001','S05','Panier',16,'2015-08-25', '2025-08-26', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('C320011','C32','Cadre',280,'2014-04-05', '2021-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('G700011','G7','Guidon',30,'2019-08-12', '2029-08-13', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('F300011','F3','Freins',30,'2018-02-28', '2028-03-01', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('S880011','S88','Selle',50,'2015-06-10', '2025-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('DV10011','DV133','Derailleur Avant',20,'2020-08-25', '2030-08-26', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('DR50011','DR56','Derailleur Arriere',20,'2018-04-05', '2028-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('R450011','R45','Roue Avant',70,'2016-08-18', '2026-08-18', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('R460012','R46','Roue Arriere',80,'2016-02-12', '2026-02-12', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('P120011','P12','Pedalier',60,'2020-06-10', '2030-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('O200011','O2','Ordinateur',200,'2015-08-25', '2025-08-26', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('C340012','C76','Cadre',250,'2019-08-05', '2029-08-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('G700013','G7','Guidon',30,'2019-08-12', '2029-08-13', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('F300013','F3','Freins',30,'2018-02-28', '2028-03-01', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('S880013','S88','Selle',50,'2015-06-10', '2025-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('DV10013','DV17','Derailleur Avant',25,'2021-01-25', '2031-01-26', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('DR80012','DR87','Derailleur Arriere',22,'2019-02-05', '2029-02-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('R480012','R48','Roue Avant',80,'2018-08-18', '2028-08-18', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('R470012','R47','Roue Arriere',90,'2018-02-12', '2028-02-12', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('P120013','P12','Pedalier',60,'2020-06-10', '2030-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('O200012','O2','Ordinateur',200,'2015-08-25', '2025-08-26', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('C340013','C76','Cadre',250,'2019-08-05', '2029-08-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('G700014','G7','Guidon',30,'2019-08-12', '2029-08-13', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('F300014','F3','Freins',30,'2018-02-28', '2028-03-01', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('S880014','S88','Selle',50,'2015-06-10', '2025-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('DV80011','DR87','Derailleur Avant',22,'2019-02-05', '2029-02-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('DR80011','DR86','Derailleur Arriere',22,'2018-02-05', '2028-02-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('R120011','R12','Roue Avant',50,'2018-08-18', '2028-08-18', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('R320011','R32','Roue Arriere',60,'2018-02-12', '2028-02-12', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('R1000021','R10','Reflecteur',12,'2016-06-10', '2026-04-06', 'MIRANDA & IRMA' ,null,null);
insert into Piece values ('P127594','P12','Pedalier',60,'2021-06-10', '2031-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('C150001','C15','Cadre',200,'2015-04-05', '2025-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('G120012','G12','Guidon',40,'2015-08-12', '2025-08-13', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('F900013','F9','Freins',40,'2019-02-28', '2029-03-01', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('S360001','S36','Selle',50,'2017-06-10', '2027-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('DV10015','DV15','Derailleur Avant',15,'2020-08-25', '2030-08-26', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('DR20001','DR23','Derailleur Arriere',18,'2018-04-05', '2028-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('R110001','R11','Roue Avant',50,'2015-08-18', '2025-08-19', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('R120061','R12','Roue Arriere',60,'2015-02-12', '2025-02-13', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('P150071','P15','Pedalier',60,'2020-06-10', '2030-04-06', 'SERENISSIMO COMMERCIALE SRL' ,null,null);
insert into Piece values ('S740081','S74','Panier',18,'2018-08-25', '2028-08-26', 'SERENISSIMO COMMERCIALE SRL' ,null,17);
insert into Piece values ('C877801','C87','Cadre',240,'2018-04-05', '2028-04-06', 'SUPERBIKE' ,null,null);
insert into Piece values ('G129712','G12','Guidon',40,'2015-08-12', '2025-08-13', 'SUPERBIKE' ,null,null);
insert into Piece values ('F909813','F9','Freins',40,'2019-02-28', '2029-03-01', 'SUPERBIKE' ,null,null);
insert into Piece values ('S369501','S36','Selle',50,'2017-06-10', '2027-04-06', 'SUPERBIKE' ,null,null);
insert into Piece values ('DV49215','DV41','Derailleur Avant',18,'2020-08-25', '2030-08-26', 'SUPERBIKE' ,null,null);
insert into Piece values ('DR29101','DR23','Derailleur Arriere',17,'2019-04-05', '2029-04-06', 'SUPERBIKE' ,null,null);
insert into Piece values ('R119101','R11','Roue Avant',50,'2015-08-18', '2025-08-19', 'SUPERBIKE' ,null,null);
insert into Piece values ('R129161','R12','Roue Arriere',60,'2015-02-12', '2025-02-13', 'SUPERBIKE' ,null,null);
insert into Piece values ('P129171','P12','Pedalier',60,'2020-06-10', '2030-04-06', 'SUPERBIKE' ,null,20);
insert into Piece values ('S749181','S74','Panier',13,'2018-08-25', '2028-08-26', 'SUPERBIKE' ,null,20);
insert into Piece values ('C877890','C87f','Cadre',245,'2018-04-05', '2028-04-06', 'VELOMANIA' ,null,21);
insert into Piece values ('G129912','G12','Guidon',40,'2015-08-12', '2025-08-13', 'VELOMANIA' ,null,null);
insert into Piece values ('F909913','F9','Freins',40,'2019-02-28', '2029-03-01', 'VELOMANIA' ,null,null);
insert into Piece values ('S369901','S34','Selle',30,'2014-06-10', '2024-04-06', 'VELOMANIA' ,null,null);
insert into Piece values ('DV49915','DV41','Derailleur Avant',18,'2020-08-25', '2030-08-26', 'VELOMANIA' ,null,null);
insert into Piece values ('DR29901','DR23','Derailleur Arriere',17,'2019-04-05', '2029-04-06', 'VELOMANIA' ,null,null);
insert into Piece values ('R119901','R11','Roue Avant',50,'2015-08-18', '2025-08-19', 'VELOMANIA' ,null,null);
insert into Piece values ('R129961','R12','Roue Arriere',60,'2015-02-12', '2025-02-13', 'VELOMANIA' ,null,null);
insert into Piece values ('P129971','P12','Pedalier',60,'2020-06-10', '2030-04-06', 'VELOMANIA' ,null,null);
insert into Piece values ('S739981','S73','Panier',11,'2018-02-25', '2028-02-26', 'VELOMANIA' ,null,5);
insert into Piece values ('C250001','C25','Cadre',225,'2017-04-05', '2027-04-06', 'VELOMANIA' ,null,null);

-- Bicyclette

insert into Bicyclette values ('KTA1254',101,'Kilimandjaro','Adultes',929,'VTT',2);
insert into Bicyclette values ('NTA5458',102,'NorthPole','Adultes',749,'VTT',3);
insert into Bicyclette values ('MTJ4597',103,'MontBlanc','Jeunes',879,'VTT',null);
insert into Bicyclette values ('HTA2546',104,'Hooligan','Jeunes',699,'VTT',5);
insert into Bicyclette values ('ORH4565',105,'Orléans','Hommes',2149,'Vélo de course',null);
insert into Bicyclette values ('ORD4527',106,'Orléans','Dames',2149,'Vélo de course',null);
insert into Bicyclette values ('BRH4857',107,'BlueJay','Hommes',2459,'Vélo de course',null);
insert into Bicyclette values ('BRD3459',108,'BlueJay','Dames',2459,'Vélo de course',null);
insert into Bicyclette values ('TCF2647',109,'Trail Explorer','Filles',319,'Classique',null);
insert into Bicyclette values ('TCG4597',110,'Trail Explorer','Garçons',319,'Classique',null);
insert into Bicyclette values ('NCJ4587',111,'Night Hawk','Jeunes',489,'Classique',null);
insert into Bicyclette values ('TCH6548',112,'Tierra Verde','Hommes',399,'Classique',null);
insert into Bicyclette values ('CD2594',113,'Tierra Verde','Dames',399,'Classique',null);
insert into Bicyclette values ('MBJ4569',114,'Mud Zinger I ','Jeunes',279,'BMX',null);
insert into Bicyclette values ('MBA4256',115,'Mud Zinger II','Adultes',359,'BMX',null);
insert into Bicyclette values ('KTA5784',101,'Kilimandjaro','Adultes',929,'VTT',16);
insert into Bicyclette values ('NTA6458',102,'NorthPole','Adultes',749,'VTT',19);
insert into Bicyclette values ('MTJ4847',103,'MontBlanc','Jeunes',879,'VTT',19);
insert into Bicyclette values ('HTA2456',104,'Hooligan','Jeunes',699,'VTT',null);
insert into Bicyclette values ('ORH4995',105,'Orléans','Hommes',2149,'Vélo de course',21);
insert into Bicyclette values ('ORD4117',106,'Orléans','Dames',2149,'Vélo de course',null);
insert into Bicyclette values ('BRH4347',107,'BlueJay','Hommes',2449,'Vélo de course',2);
insert into Bicyclette values ('BRD3999',108,'BlueJay','Dames',2449,'Vélo de course',null);
insert into Bicyclette values ('TCF2747',109,'Trail Explorer','Filles',319,'Classique',null);
insert into Bicyclette values ('TCG4557',110,'Trail Explorer','Garçons',319,'Classique',null);
insert into Bicyclette values ('NCJ7587',111,'Night Hawk','Jeunes',489,'Classique',null);
insert into Bicyclette values ('TCH8548',112,'Tierra Verde','Hommes',499,'Classique',null);
insert into Bicyclette values ('TCD8411',113,'Tierra Verde','Dames',499,'Classique',null);
insert into Bicyclette values ('MBJ9999',114,'Mud Zinger I ','Jeunes',479,'BMX',null);
insert into Bicyclette values ('MBA8245',115,'Mud Zinger II','Adultes',559,'BMX',null);
insert into Bicyclette values ('KTA8480',101,'Kilimandjaro','Adultes',929,'VTT',null);
insert into Bicyclette values ('NTA7845',102,'NorthPole','Adultes',749,'VTT',null);
insert into Bicyclette values ('ORD0117',106,'Orléans','Dames',2149,'Vélo de course',null);
insert into Bicyclette values ('BRH3652',107,'BlueJay','Hommes',2149,'Vélo de course',null);
insert into Bicyclette values ('TCH1254',112,'Tierra Verde','Hommes',499,'Classique',null);
insert into Bicyclette values ('TCD7840',113,'Tierra Verde','Dames',499,'Classique',null);
insert into Bicyclette values ('MBJ0012',114,'Mud Zinger I ','Jeunes',579,'BMX',11);
insert into Bicyclette values ('MBA8054',115,'Mud Zinger II','Adultes',659,'BMX',null);
insert into Bicyclette values ('TCD0485',113,'Tierra Verde','Dames',499,'Classique',null);
insert into Bicyclette values ('MBJ0912',114,'Mud Zinger I ','Jeunes',579,'BMX',null);
insert into Bicyclette values ('MBA8504',115,'Mud Zinger II','Adultes',659,'BMX',4);


