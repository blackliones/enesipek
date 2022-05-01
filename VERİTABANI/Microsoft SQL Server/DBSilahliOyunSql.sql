      --CREATE COMMANDS

--Silahlar

CREATE TABLE Weapons (
	ID int IDENTITY (1,1) PRIMARY KEY,
	Name varchar(30),
	WeaponType varchar(30),
	PurchasingStatus smallint NOT NULL,
	Ammo int,
	Magazine int,
	Damage int,
	AccessibleLevel int,
	Price bigint
);
--Karakterler

CREATE TABLE Characters(
	ID int IDENTITY (1,1) PRIMARY KEY,
	Name varchar(30),
	Health int,
	Armor int,
	Rank varchar(50),
	UsingStatus smallint NOT NULL
);
--GenelVeriler
CREATE TABLE GeneralData(
	Money bigint,
	UnlockedLevel int,
	MaxLevel int
);
--Seviyeler
CREATE TABLE Level(
	LevelID int IDENTITY(1,1) PRIMARY KEY,
	EnemyID int,
	Reward int
);
--MevcutAnlýkVeriler
CREATE TABLE CurrentInstantData(
	Health int,
	Armor int,
	WeaponID int,
	CharacterID int,
	Rank varchar(50),
	Difficulty varchar(20),
	Level int
);
--Düþmanlar
CREATE TABLE Enemy(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Health int,
	Armor int,
	DifficultyLevel smallint
);
--Zorluk Seviyesi
CREATE TABLE Difficulty(
	DifficultyLevel int IDENTITY(1,1) PRIMARY KEY,
	Difficulty varchar(20)
);
--Rütbe
CREATE TABLE Rank(
	ID int IDENTITY(1,1) PRIMARY KEY,
	AccessibleLevel int,
	Name varchar(50)
);
--CREATING STORED PROCEDURES
								  --[GENERAL]
GO
CREATE PROC sp_getAccessData
@accessiblelevel int
AS
SELECT 
c.Name as 'Character Name',
r.AccessibleLevel as 'Character AccessibleLevel',
w.Name as 'Weapon Name',
w.AccessibleLevel as 'Weapon AccessibleLevel'
FROM 
Characters c
LEFT JOIN 
Rank r
ON 
c.Rank = r.Name
INNER JOIN 
Weapons w
ON
r.AccessibleLevel>=w.AccessibleLevel
WHERE r.AccessibleLevel=@accessiblelevel
ORDER BY c.Name ASC
GO
CREATE PROC sp_getCharacterDetail
@name varchar(50)
AS
SELECT
c.Name as 'Character Name',
c.Rank as 'Rank',
r.AccessibleLevel as 'AccessibleLevel',
w.Name as 'Accessible Weapons'
FROM
Characters c
LEFT JOIN
Rank r
ON
c.Rank = r.Name
INNER JOIN
Weapons w
ON
r.AccessibleLevel>=w.AccessibleLevel
WHERE c.Name = @name
ORDER BY w.AccessibleLevel ASC
GO
										--[INSERT COMMANDS]
--Procedure-> Add Item in Weapon Table
CREATE PROC sp_addweapon
@name varchar(30),
@weapontype varchar(30),
@purchasingstatus smallint,
@ammo int,
@magazine int,
@damage int,
@accessiblelevel int,
@price bigint
AS
INSERT INTO Weapons
values(@name,@weapontype,@purchasingstatus,@ammo,@magazine,@damage,@accessiblelevel,@price)
GO
--Procedure->  Add Item in Character Table

CREATE PROC sp_addcharacter
@name varchar(30),
@health int,
@armor int,
@rank varchar(50),
@usingstatus smallint=0
AS
INSERT INTO Characters
values(@name,@health,@armor,@rank,@usingstatus)
GO
--Procedure-> Add Item in Level Table
CREATE PROC sp_addlevel
@enemyid int,
@reward int 
AS
INSERT INTO Level
values(@enemyid,@reward)
GO
--Procedure-> Add Item in GeneralData Table
CREATE PROC sp_addgeneraldata
@money bigint,
@unlockedlevel int,
@maxlevel int
AS
INSERT INTO GeneralData
values(@money,@unlockedlevel,@maxlevel)
GO
--Procedure-> Add Item in Enemy Table
CREATE PROC sp_addenemy
@health int,
@armor int,
@difficultylevel smallint
AS
INSERT INTO Enemy
values(@health,@armor,@difficultylevel)
GO
--Procedure-> Add Item in Difficulty Table
CREATE PROC sp_adddifficulty
@difficulty varchar(20)
AS
INSERT INTO Difficulty
values(@difficulty)
GO
--Procedure-> Add Item in Rank Table
CREATE PROC sp_addrank
@accessiblelevel int,
@rank varchar(50)
AS
INSERT INTO Rank
values(@accessiblelevel,@rank)
GO
								--[UPDATE COMMANDS]
--Procedure-> Update Character
CREATE PROC sp_updateCharacter
@characterid int=0,
@name varchar(30)='Empty',
@health int=0,
@armor int=0,
@rank varchar(50)='Empty',
@usingstatus smallint=0
AS
UPDATE Characters
SET
Name=@name,
Health=@health,
Armor=@armor,
Rank=@rank,
UsingStatus=@usingstatus
WHERE Characters.ID=@characterid;
GO
--Procedure-> Update Weapon
CREATE PROC sp_updateWeapon
@weaponid int=0,
@name varchar(30)='Empty',
@weapontype varchar(30)='Empty',
@purchasingstatus smallint=0,
@ammo int=0,
@magazine int=0,
@damage int=0,
@accessiblelevel int=0,
@price bigint=0
AS
UPDATE Weapons
SET
Name=@name,
WeaponType=@weapontype,
PurchasingStatus=@purchasingstatus,
Ammo=@ammo,
Magazine=@magazine,
Damage=@damage,
AccessibleLevel=@accessiblelevel,
Price=@price
WHERE Weapons.ID=@weaponid;
GO
--Procedure-> Update Level
CREATE PROC sp_updatelevel
@levelid int=0,
@enemyid int=0,
@reward int=0
AS
UPDATE Level
SET
EnemyID=@enemyid,
Reward=@reward
WHERE Level.LevelID=@levelid;
GO
--Procedure-> Update GeneralData
CREATE PROC sp_updateGeneraldata
@money bigint=0,
@unlockedlevel int=0,
@maxlevel int=0
AS
UPDATE GeneralData
SET
Money=@money,
UnlockedLevel=@unlockedlevel,
MaxLevel=@maxlevel;
GO
--Procedure-> Update InstantData
CREATE PROC sp_updateCurrentinstantdata
@health int=0,
@armor int=0,
@weaponid int=0,
@characterid int=0,
@rank varchar(50)='Empty',
@difficulty varchar(20)='Empty',
@level int=0
AS
UPDATE CurrentInstantData
SET
Health=@health,
Armor=@armor,
WeaponID=@weaponid,
CharacterID=@characterid,
Rank=@rank,
Difficulty=@difficulty,
Level=@level
GO
									--[DELETE COMMANDS]
CREATE PROC sp_deleteWeapon
@weaponid int=0
AS
DELETE FROM Weapons WHERE Weapons.ID=@weaponid
GO
CREATE PROC sp_deleteCharacter
@characterid int=0
AS
DELETE FROM Characters WHERE Characters.ID=@characterid
GO
CREATE PROC sp_deleteEnemy
@enemyid int=0
AS
DELETE FROM Enemy WHERE Enemy.ID=@enemyid;
GO
         --CALLING PROCEDURES
--Weapons(ADD WEAPON)
exec sp_addweapon @name='Pistol',@weapontype='Small',@purchasingstatus=1,@ammo=10,@magazine=30,@damage=30,@accessiblelevel=1,@price=0;
exec sp_addweapon @name='Havana',@weapontype='Small',@purchasingstatus=0,@ammo=15,@magazine=50,@damage=28,@accessiblelevel=1,@price=370;
exec sp_addweapon @name='Deagle',@weapontype='Small',@purchasingstatus=0,@ammo=5,@magazine=20,@damage=50,@accessiblelevel=1,@price=800;
exec sp_addweapon @name='Freaky',@weapontype='Semiautomatic',@purchasingstatus=0,@ammo=8,@magazine=40,@damage=38,@accessiblelevel=1,@price=750;
exec sp_addweapon @name='Leader S+',@weapontype='Chemical',@purchasingstatus=0,@ammo=1,@magazine=1,@damage=70,@accessiblelevel=3,@price=2500;
exec sp_addweapon @name='Aristocrat',@weapontype='Nuclear',@purchasingstatus=0,@ammo=1,@magazine=1,@damage=10000,@accessiblelevel=3,@price=500000;
exec sp_addweapon @name='Gandalf',@weapontype='Heavy',@purchasingstatus=0,@ammo=250,@magazine=750,@damage=35,@accessiblelevel=1,@price=10000; 
exec sp_addweapon @name='M 249',@weapontype='Heavy',@purchasingstatus=0,@ammo=100,@magazine=300,@damage=40,@accessiblelevel=1,@price=5000;
exec sp_addweapon @name='Rocket S2+',@weapontype='Missiles',@purchasingstatus=0,@ammo=2,@magazine=4,@damage=250,@accessiblelevel=2,@price=15000;
exec sp_addweapon @name='Maen WR1',@weapontype='Missiles',@purchasingstatus=0,@ammo=2,@magazine=4,@damage=500,@accessiblelevel=2,@price=25000;
exec sp_addweapon @name='Maen WR2',@weapontype='Missiles',@purchasingstatus=0,@ammo=1,@magazine=2,@damage=750,@accessiblelevel=2,@price=50000;

--Characters(ADD CHARACTER)
exec sp_addcharacter @name='Chris',@health=100,@armor=0,@rank='Private',@usingstatus=1;
exec sp_addcharacter @name='Freddich',@health=100,@armor=10,@rank='Corporal',@usingstatus=0;
exec sp_addcharacter @name='James',@health=100,@armor=20,@rank='Sergeant',@usingstatus=0;
exec sp_addcharacter @name='Rich',@health=100,@armor=30,@rank='Sergeant First Class',@usingstatus=0;
exec sp_addcharacter @name='Jenny',@health=100,@armor=10,@rank='Corporal',@usingstatus=0;
exec sp_addcharacter @name='Freddie',@health=100,@armor=40,@rank='Master Sergeant',@usingstatus=0;
exec sp_addcharacter @name='Alba',@health=100,@armor=40,@rank='Master Sergeant',@usingstatus=0;
exec sp_addcharacter @name='Witcher',@health=100,@armor=50,@rank='Second Lieutenant',@usingstatus=0;
exec sp_addcharacter @name='Riddick',@health=100,@armor=60,@rank='Captain',@usingstatus=0;
exec sp_addcharacter @name='Hancook',@health=100,@armor=70,@rank='Major',@usingstatus=0;
exec sp_addcharacter @name='Scott',@health=100,@armor=80,@rank='Lieutenant Colonel',@usingstatus=0;
exec sp_addcharacter @name='Arthur',@health=100,@armor=90,@rank='Colonel',@usingstatus=0;
exec sp_addcharacter @name='Adam',@health=100,@armor=100,@rank='Brigadier',@usingstatus=0;
exec sp_addcharacter @name='Reacher',@health=200,@armor=100,@rank='Major General',@usingstatus=0;
exec sp_addcharacter @name='Tom',@health=250,@armor=100,@rank='Lieutenant General',@usingstatus=0;
exec sp_addcharacter @name='Jack',@health=100,@armor=300,@rank='General',@usingstatus=0;
--General Data
exec sp_addgeneraldata @money=0,@unlockedlevel=1,@maxlevel=10;
--Level(ADD LEVEL)
exec sp_addlevel @enemyid=1,@reward=350;
exec sp_addlevel @enemyid=2,@reward=800;
exec sp_addlevel @enemyid=3,@reward=1500;
exec sp_addlevel @enemyid=4,@reward=2500;
exec sp_addlevel @enemyid=5,@reward=5000;
exec sp_addlevel @enemyid=6,@reward=10000;
exec sp_addlevel @enemyid=7,@reward=70000;
exec sp_addlevel @enemyid=8,@reward=120000;
exec sp_addlevel @enemyid=9,@reward=250000;
exec sp_addlevel @enemyid=10,@reward=500000;
--Enemy(ADD ENEMY)
exec sp_addenemy @health=50,@armor=0,@difficultylevel=1;
exec sp_addenemy @health=70,@armor=0,@difficultylevel=1;
exec sp_addenemy @health=80,@armor=0,@difficultylevel=1;
exec sp_addenemy @health=90,@armor=0,@difficultylevel=1;
exec sp_addenemy @health=100,@armor=0,@difficultylevel=2;
exec sp_addenemy @health=110,@armor=100,@difficultylevel=2;
exec sp_addenemy @health=125,@armor=150,@difficultylevel=3;
exec sp_addenemy @health=200,@armor=100,@difficultylevel=3;
exec sp_addenemy @health=250,@armor=100,@difficultylevel=4;
exec sp_addenemy @health=300,@armor=200,@difficultylevel=5;
--Difficulty(ADD DIFFICULTY)
exec sp_adddifficulty @difficulty='Basic';
exec sp_adddifficulty @difficulty='Normal';
exec sp_adddifficulty @difficulty='Medium';
exec sp_adddifficulty @difficulty='Hard';
exec sp_adddifficulty @difficulty='Very Hard';
--Rank(ADD RANK)
exec sp_addrank @accessiblelevel=1,@rank='Private';
exec sp_addrank @accessiblelevel=1,@rank='Corporal';
exec sp_addrank @accessiblelevel=1,@rank='Sergeant';
exec sp_addrank @accessiblelevel=1,@rank='Sergeant First Class';
exec sp_addrank @accessiblelevel=1,@rank='Master Sergeant';
exec sp_addrank @accessiblelevel=1,@rank='Second Lieutenant';
exec sp_addrank @accessiblelevel=2,@rank='Captain';
exec sp_addrank @accessiblelevel=2,@rank='Major';
exec sp_addrank @accessiblelevel=2,@rank='Lieutenant Colonel';
exec sp_addrank @accessiblelevel=2,@rank='Colonel';
exec sp_addrank @accessiblelevel=2,@rank='Brigadier';
exec sp_addrank @accessiblelevel=3,@rank='Major General';
exec sp_addrank @accessiblelevel=3,@rank='Lieutenant General';
exec sp_addrank @accessiblelevel=3,@rank='General';
/*--CurrentInstantData(DEFAULT DATA)[Oynanýlan levele ait karakteri , 
-levelin zorluðunu,düþmaný vb anlýk verilerin alýnmasý] Oyun ilk baþladýgýnda 1 kez alýnýr sonra update geçilir*/
INSERT INTO CurrentInstantData(Health,Armor,CharacterID,Rank,WeaponID,Difficulty,Level)
SELECT c.Health,c.Armor,c.ID,c.Rank,w.ID,d.Difficulty,l.LevelID
FROM Characters c,Weapons w,Difficulty d,Enemy e,Level l,GeneralData gd
WHERE c.ID=1 
and
w.ID=1 
and 
l.LevelID = gd.UnlockedLevel 
and 
e.ID=l.LevelID 
and 
d.DifficultyLevel=e.DifficultyLevel
--		ÖRNEK SORGULAR
--Karakteri güncelle(update)
exec sp_updateCharacter @characterid=1,@name='Chris',@health=100,@armor=0,@Rank='private',@usingstatus=1;
exec sp_updateCharacter @characterid=1,@name='Enes',@health=100,@armor=5000,@Rank='Master',@usingstatus=1;
--Rütbesi Master Sergeant Olan Karakterleri getir
SELECT *
FROM Characters c
WHERE c.Rank ='Master Sergeant'
--Zýrhý 50den fazla olan karakterleri getir
SELECT *
FROM Characters c
WHERE c.Armor>50
--Zorluk Seviyesi 2 ve üstü olan düþmanlarý getir ve zorluk derecesini yazdýr
SELECT e.ID,e.Health,e.Armor,e.DifficultyLevel,d.Difficulty
FROM Enemy e,Difficulty d
WHERE e.DifficultyLevel>=2 and d.DifficultyLevel=e.DifficultyLevel
--10.Seviyede gelecek olan düþmaný, zorluk seviyesini getir ve verilecek ödülü
SELECT l.LevelID as 'Level',l.Reward,e.ID as EnemyID,d.Difficulty,e.Health,e.Armor
FROM Enemy e,Difficulty d,Level l
WHERE l.LevelID=10 and e.ID=10 and d.DifficultyLevel=e.DifficultyLevel
--AccessibleLevel(Eriþim seviyesi) 2 olan karakterleri ve eriþebildikleri tüm silahlarý getir ve sýrala
--[Hatýrlatma:Eriþebilirlik seviyesi 2 olanlar eriþebilirlik seviyesi 1 olan silahlarý da kullanabiliyor]
--(JOÝNLÝ SP)
exec sp_getAccessData @accessiblelevel=2;
--Ýsmi girilen karakterin rütbesine göre eriþebilirlik seviyesini getir(JOÝNLÝ SP)
exec sp_getCharacterDetail @name='Tom';
