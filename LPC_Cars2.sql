create database LPC_CARS2;
use LPC_CARS2;
drop database LPC_CARS
create table Administrateur(
Cin varchar(12) primary key,
Logine varchar(10),
passwords varchar(8),
);
select * from Conducteur;
ALTER TABLE Locataire ADD Tel int;
create table Locataire(
CIN varchar(12) primary key,
Prenom varchar(12),
Nom varchar(12),
Nat varchar(12),
Adr varchar(40),
Passp int null,
Permis int,
Tel int,
Date_permis datetime,
date_inscription dateTime,
);
create table Conducteur(
CIN_conducteur varchar(12) primary key,
Prenom2 varchar(12),
Nom2 varchar(12),
Nat2 varchar(12),
Adr2 varchar(40),
Passp2 int null,
Permis2 int,
Tel2 int,
Date_permis2 datetime,
date_inscription2 dateTime,
);
ALTER TABLE Locataire Add constraint date_insc default getdate() for date_inscription;
ALTER TABLE Conducteur Add constraint date_insc2 default getdate() for date_inscription2;

create table Marque(
N_M int primary key identity,
Nom_M varchar(20) unique,
);
create table Modele(
N_Mod int primary key identity,
Nom_Mod varchar(20) unique,
N_M int references Marque(N_M) on delete cascade on update cascade, 
);
ALTER TABLE Modele Alter column Nom_Mod varchar(20);
create table Voiture(
Matricule varchar(12) primary key,
Annee varchar(12),
Num_M int references Marque(N_M) on delete cascade on update cascade,
N_M int references Modele(N_Mod),
);
create table Contrat(
N_Serie int primary key identity,
Date_Contrat date,
CIN varchar(12) references Locataire(CIN) on delete cascade on update cascade,
Matricule varchar(12) references Voiture(Matricule)on delete cascade on update cascade ,
Date_Depart DateTIME,
Date_retour Datetime,
Heur_Depart Time,
Heur_retour Time,
Prix float,
Duree int,
A_S float,
F_Assurance varchar(12),
Avances float,
CIN_Conducteur varchar(12) references Conducteur(CIN_conducteur) on delete cascade on update cascade ,
Net_location float,
 Entree int,
 Depart int,
 prix_rest float,
 Prix_total float,
F bit,F2 bit,F3 bit,E bit,
 Roue_secour bit,chric bit,Equip_securiter bit,Eclairage bit,Carts_gris bit,Assurance bit,Aurisation bit,Vignette bit,Visite_technique bit
);

select * from Contrat;
/* Insertion */
insert into Administrateur values('HH251022','zakaria','1234');
insert into Administrateur values('HH251900','Ahmed','1234');
Insert into Marque values('DACIA'),('Renault'),('HYUNDAI'),('NISSAN'),('Volswagen'),('Citreon'),('TOYOTA'),('FIAT');
INSERT INTO Modele values('duster',1),('sandero ess',1),('sandero diez',1),('Koongo noir',2),('Koongo maron',2),('punto class',8),('pick up',7),('diez',1),('clio4',2),('accent',3),('quashquai',4),('H1',3),('duster noir',1),('duster gris',1),('clio4 trust',2),('tiguan',5),('diez sea logn',1),('c-elysee',6);
/*Affichage*/
SELECT * from Administrateur;
SELECT * from Locataire;
select * from Marque;
select * from Modele;
Delete from  Modele  where N_Mod = 1
select * from Voiture;
select count(Matricule) from Voiture where Matricule not in (select Matricule from Contrat)
select count(Matricule) from Voiture where Etat = 'nom luoer'
select count(Prix) from Contrat where DAY(Date_Contrat) = 12;
Select  COUNT(N_Serie) from Contrat
Select * from Locataire;
Select  Max(N_Serie) from Contrat
select * from Contrat
select * from Locataire
SELECT * from Contrat;
select * from Voiture;
Select Max(N_Serie) from Contrat
Select Contrat.CIN,Locataire.Prenom,Locataire.Nom,Locataire.Tel,Matricule from   Locataire,Contrat  where Locataire.CIN = Contrat.CIN AND DATEDIFF(Year,getdate(),Date_retour) = 0 AND DATEDIFF(MONTH,getdate(),Date_retour) = 0 AND DATEDIFF(Day,getdate(),Date_retour) = 0   ;
/*Modification*/
ALTER TABLE Contrat add constraint ck1 default getdate() for Date_Contrat;
ALTER TABLE Voiture ADD  Etats varchar(12);
ALTER TABLE Voiture ADD CONSTRAINT CK5 default 'nom Louer' for Etats
alter table Voiture add constraint ck3 check(Etats = 'Luoer' or Etats = 'nom Luoer');
/*trigger*/
Alter trigger Ajoute_conducteur
ON Locataire
for Insert
AS begin
declare @CIN_conducteur varchar(12), @Prenom2 varchar(12), @Nom2 varchar(12), @Nat2 varchar(12),@Adr2 varchar(40),@Passp2 int,@Permis2 int,@Tel2 int,@Date_permis2 datetime;
set @CIN_conducteur = (select CIN from inserted);
set @Prenom2 = (select Prenom from inserted);
set @Nom2 = (select Nom from inserted);
set @Nat2 = (select Nat from inserted);
set @Adr2 = (select Adr from inserted);
set @Passp2 = (select Passp from inserted);
set @Permis2 = (select Permis from inserted);
set @Tel2 = (select Tel from inserted);
set @Date_permis2 = (select Date_permis from inserted);
INsert into Conducteur(CIN_conducteur,Prenom2,Nom2,Nat2,Adr2,Passp2,Permis2,Date_permis2,Tel2) values(@CIN_conducteur,@Prenom2,@Nom2,@Nat2,@Adr2,@Passp2,@Permis2,@Date_permis2,@Tel2);
END
Alter trigger Supprimer_conducteur
ON Locataire
FOR delete
AS BEGIN
declare @CIN_conducteur varchar(12);
set @CIN_conducteur = (select CIN from deleted);
delete from Conducteur where CIN_conducteur = @CIN_conducteur;
End
/*update*/
alter trigger Modification
on Locataire
for update
as begin
declare @CIN_conducteur varchar(12), @Prenom2 varchar(12), @Nom2 varchar(12), @Nat2 varchar(12),@Adr2 varchar(40),@Passp2 int,@Permis2 int,@Tel2 int,@Date_permis2 datetime;
set @CIN_conducteur = (select CIN from inserted);
set @Prenom2 = (select Prenom from inserted);
set @Nom2 = (select Nom from inserted);
set @Nat2 = (select Nat from inserted);
set @Adr2 = (select Adr from inserted);
set @Passp2 = (select Passp from inserted);
set @Permis2 = (select Permis from inserted);
set @Tel2 = (select Tel from inserted);
set @Date_permis2 = (select Date_permis from inserted);
update Conducteur set Prenom2 = @Prenom2,Nom2 = @Nom2,Nat2 = @Nat2,Adr2 = @Adr2,Passp2 = @Passp2,Tel2 = @Tel2,Permis2 = @Permis2,Date_permis2 = @Date_permis2 where CIN_conducteur = @CIN_conducteur;

END
INsert into Locataire(CIN,Prenom,Nom,Nat,Adr,Passp,Permis,Date_permis,Tel) values('HH2390','Ahmed','nore','Marocaine','kores',2390,1245,'4/8/2019',657468897);
select * from Conducteur;
select * from Contrat;
select * from Voiture;