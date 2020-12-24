CREATE DATABASE  IF NOT EXISTS `art_funding` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `art_funding`;
-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: art_funding
-- ------------------------------------------------------
-- Server version	8.0.18

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `artiste`
--

DROP TABLE IF EXISTS `artiste`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `artiste` (
  `idartiste` int(11) NOT NULL,
  `nom` varchar(45) NOT NULL,
  `prenom` varchar(45) DEFAULT NULL,
  `date_de_naissance` date NOT NULL,
  `adresse` varchar(45) NOT NULL,
  `code_postale` varchar(6) NOT NULL,
  `ville` varchar(25) NOT NULL,
  `pays` varchar(25) NOT NULL,
  `mail` varchar(55) NOT NULL,
  `numero` varchar(20) NOT NULL,
  `projet_id` int(11) NOT NULL AUTO_INCREMENT,
  `description` text,
  `ecole_choisie_id` int(11) unsigned NOT NULL,
  `formation_choisie_id` int(11) DEFAULT NULL,
  `mot_de_passe` varchar(32) NOT NULL,
  `Disponibilite` date DEFAULT NULL,
  `categorie_id` int(11) NOT NULL,
  PRIMARY KEY (`idartiste`),
  KEY `fk_artiste_projet_idx` (`projet_id`),
  KEY `fk_artiste_ecole_idx` (`ecole_choisie_id`),
  KEY `fr_artiste_categorie_idx` (`categorie_id`),
  CONSTRAINT `fk_artiste_categorie` FOREIGN KEY (`categorie_id`) REFERENCES `categorie` (`id_categorie`),
  CONSTRAINT `fk_artiste_ecole` FOREIGN KEY (`ecole_choisie_id`) REFERENCES `ecole` (`idecole`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `artiste`
--

LOCK TABLES `artiste` WRITE;
/*!40000 ALTER TABLE `artiste` DISABLE KEYS */;
INSERT INTO `artiste` VALUES (1,'Tayolor','Jayme','1994-08-10','15 rue de Normandie','92400','courbevoie','France','cele@gmail.com','078955693',1,'la sensibilité d\'un artiste fait qu\'il ne ressent pas le monde de la façon que le font la majorité des gens mais avec une intensité supérieure. Il remarquera des choses que les gens ne remarquent habituellement pas par exemple.',1,1,'123e','2021-02-20',1),(2,'Lacroix','Rouge','1999-01-18','12 rue de Faubourg Saint-Antoine','75012','paris','France','lacroixrouge@gmail.com','060789432',2,'ca fait 10 ans que j\'ai fait ',1,2,'123f','2021-01-30',2),(3,'Dorian','howe','2000-10-09','663 rue Cras ','75008','paris','France','blandit@congueelitsed.co.uk','06 50 93 54 67',3,NULL,1,3,'123w','2021-01-01',3),(4,'Harper','Cross, Giacomo G','2000-07-29','1536 Magna. Ave','92400','courbevoie','France','nunc.est@vulputatenisi.org','07 29 00 55 04',4,NULL,1,4,'123d','2021-01-30',4),(5,'Carlson','Shafira','1993-03-03','Appartement 690-8668 Nam Ave','92800','puteaux','France','eu.Mauris@gmail.com','09 88 33 34 63',5,NULL,1,5,'123c','2020-12-31',5),(6,'Golden','Lee','1998-02-02','8257 Consectetuer Ave','91200','Athis-Mons','France','pellentesque.eget@orciUtsemper.com','04 80 99 87 90',6,NULL,2,6,'123e','2020-12-31',6),(7,'Pratt','Kimberkey','1977-08-09','CP 520, 2855 Aliquet, Ave','75011','paris','France','pede@126.com','01 39 36 44 18',7,NULL,2,1,'fjwer','2020-12-31',1),(8,'Neal','Leilani','1991-09-01','5661 At Av.','75014','paris','France','sagittis.augue@egetmetusIn.edu','06 62 76 14 23',8,NULL,3,2,'334','2020-12-31',2),(9,'Dudley','Cathrine','1992-09-09','Appartement 774-8186 Orci. Rd.','75019','paris','France','mattis@gmail.com','03 43 77 24 99',9,NULL,4,3,'fer34','2021-12-31',3),(10,'Leon','Thane','1995-07-09','8212  Rue Tristique','75018','paris','France','eu.erat.semper@hotmail.com','07 90 11 15 30',10,NULL,5,4,'r43w4c','2021-12-31',4),(11,'Kim','Wesley','1996-04-21','61 Rue  Dolor','75009','paris','France','wesley@126.com','01 43 03 32 92',11,NULL,5,5,'2312','2021-12-31',5),(12,'Chavez','Mara','1988-11-11','24 RueDui','75003','paris','France','maracha@gmail.com','06 96 05 94 78',12,NULL,5,6,'h65y','2021-12-31',6),(13,'Nolan','parsons,medge Q','1989-12-01','122 Rue Sagittis','75010','paris','France','nolan@hotmail.com','07 90 11 15 31',13,NULL,1,1,'g3t','2021-12-31',1);
/*!40000 ALTER TABLE `artiste` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categorie`
--

DROP TABLE IF EXISTS `categorie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorie` (
  `id_categorie` int(11) NOT NULL,
  `nom` varchar(45) NOT NULL,
  PRIMARY KEY (`id_categorie`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorie`
--

LOCK TABLES `categorie` WRITE;
/*!40000 ALTER TABLE `categorie` DISABLE KEYS */;
INSERT INTO `categorie` VALUES (1,'dessinateur'),(2,'photographes'),(3,'styliste'),(4,'peintre'),(5,'artiste du monde'),(6,'designer');
/*!40000 ALTER TABLE `categorie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contrat_abonnement`
--

DROP TABLE IF EXISTS `contrat_abonnement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contrat_abonnement` (
  `idcontrat_abonnement` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fichier_contrat` blob,
  PRIMARY KEY (`idcontrat_abonnement`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contrat_abonnement`
--

LOCK TABLES `contrat_abonnement` WRITE;
/*!40000 ALTER TABLE `contrat_abonnement` DISABLE KEYS */;
INSERT INTO `contrat_abonnement` VALUES (1,NULL),(2,NULL),(3,NULL),(4,NULL),(5,NULL),(6,NULL),(7,NULL),(8,NULL),(9,NULL),(10,NULL),(11,NULL),(12,NULL),(13,NULL);
/*!40000 ALTER TABLE `contrat_abonnement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contrat_ecole`
--

DROP TABLE IF EXISTS `contrat_ecole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contrat_ecole` (
  `idcontrat_ecole` int(11) NOT NULL AUTO_INCREMENT,
  `fichier_contrat` blob,
  `ecole_id` int(11) DEFAULT NULL,
  `artiste_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`idcontrat_ecole`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contrat_ecole`
--

LOCK TABLES `contrat_ecole` WRITE;
/*!40000 ALTER TABLE `contrat_ecole` DISABLE KEYS */;
INSERT INTO `contrat_ecole` VALUES (1,NULL,1,1),(2,NULL,1,2),(3,NULL,1,3),(4,NULL,1,4),(5,NULL,1,5),(6,NULL,2,6),(7,NULL,2,7),(8,NULL,3,8),(9,NULL,4,9),(10,NULL,5,10),(11,NULL,5,11),(12,NULL,5,12),(13,NULL,1,13);
/*!40000 ALTER TABLE `contrat_ecole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contrat_entreprise`
--

DROP TABLE IF EXISTS `contrat_entreprise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contrat_entreprise` (
  `idContrat_entreprise` int(11) NOT NULL,
  `fichier_contrat` blob,
  `entreprise_id` int(11) DEFAULT NULL,
  `ecole_id` int(11) DEFAULT NULL,
  `artiste_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`idContrat_entreprise`),
  KEY `fk_contrat_entreprise_idx` (`entreprise_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contrat_entreprise`
--

LOCK TABLES `contrat_entreprise` WRITE;
/*!40000 ALTER TABLE `contrat_entreprise` DISABLE KEYS */;
INSERT INTO `contrat_entreprise` VALUES (1,NULL,1,1,1),(2,NULL,2,1,2),(3,NULL,3,1,3),(4,NULL,4,1,4),(5,NULL,5,1,5),(6,NULL,6,2,6),(7,NULL,7,2,7),(8,NULL,8,3,8),(9,NULL,9,4,9),(10,NULL,10,5,10),(11,NULL,1,5,11),(12,NULL,1,5,12),(13,NULL,2,1,13);
/*!40000 ALTER TABLE `contrat_entreprise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `document_artiste`
--

DROP TABLE IF EXISTS `document_artiste`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `document_artiste` (
  `id_document_artiste` int(11) unsigned NOT NULL,
  `id_artiste` int(11) unsigned NOT NULL,
  `type_dossier` varchar(45) NOT NULL,
  `pdf` blob,
  PRIMARY KEY (`id_document_artiste`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `document_artiste`
--

LOCK TABLES `document_artiste` WRITE;
/*!40000 ALTER TABLE `document_artiste` DISABLE KEYS */;
INSERT INTO `document_artiste` VALUES (1,1,'piece d\'identite',NULL),(2,1,'justificatif de domicile',NULL),(3,2,'piece d\'identite',NULL),(4,2,'justificatif de domicile',NULL),(5,3,'piece d\'identite',NULL),(6,3,'justificatif de domicile',NULL),(7,4,'piece d\'identite',NULL),(8,4,'justificatif de domicile',NULL),(9,5,'piece d\'identite',NULL),(10,5,'justificatif de domicile',NULL),(11,6,'piece d\'identite',NULL),(12,6,'justificatif de domicile',NULL),(13,7,'piece d\'identite',NULL),(14,7,'justificatif de domicile',NULL),(15,8,'piece d\'identite',NULL),(16,8,'justificatif de domicile',NULL),(17,9,'piece d\'identite',NULL),(18,9,'justificatif de domicile',NULL),(19,10,'piece d\'identite',NULL),(20,10,'justificatif de domicile',NULL),(21,11,'piece d\'identite',NULL),(22,11,'justificatif de domicile',NULL),(23,12,'piece d\'identite',NULL),(24,12,'justificatif de domicile',NULL),(25,13,'piece d\'identite',NULL),(26,13,'justificatif de domicile',NULL);
/*!40000 ALTER TABLE `document_artiste` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `document_entreprise`
--

DROP TABLE IF EXISTS `document_entreprise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `document_entreprise` (
  `iddocument_entreprise` int(11) NOT NULL,
  `id_entreprise` int(11) NOT NULL,
  `Attestation_assurance` blob,
  `Kbis` blob,
  `RIB` blob,
  `Dernier_statut` blob,
  PRIMARY KEY (`iddocument_entreprise`),
  KEY `fk_document_entrprise_entrprise_idx` (`id_entreprise`),
  CONSTRAINT `fk_document_entrprise_entrprise` FOREIGN KEY (`id_entreprise`) REFERENCES `contrat_entreprise` (`entreprise_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `document_entreprise`
--

LOCK TABLES `document_entreprise` WRITE;
/*!40000 ALTER TABLE `document_entreprise` DISABLE KEYS */;
INSERT INTO `document_entreprise` VALUES (1,1,NULL,NULL,NULL,NULL),(2,1,NULL,NULL,NULL,NULL),(3,1,NULL,NULL,NULL,NULL),(4,1,NULL,NULL,NULL,NULL),(5,2,NULL,NULL,NULL,NULL),(6,2,NULL,NULL,NULL,NULL),(7,2,NULL,NULL,NULL,NULL),(8,2,NULL,NULL,NULL,NULL),(9,3,NULL,NULL,NULL,NULL),(10,3,NULL,NULL,NULL,NULL),(11,3,NULL,NULL,NULL,NULL),(12,3,NULL,NULL,NULL,NULL),(13,4,NULL,NULL,NULL,NULL),(14,4,NULL,NULL,NULL,NULL),(15,4,NULL,NULL,NULL,NULL),(16,4,NULL,NULL,NULL,NULL),(17,5,NULL,NULL,NULL,NULL),(18,5,NULL,NULL,NULL,NULL),(19,5,NULL,NULL,NULL,NULL),(20,5,NULL,NULL,NULL,NULL),(21,6,NULL,NULL,NULL,NULL),(22,6,NULL,NULL,NULL,NULL),(23,6,NULL,NULL,NULL,NULL),(24,6,NULL,NULL,NULL,NULL),(25,7,NULL,NULL,NULL,NULL),(26,7,NULL,NULL,NULL,NULL),(27,7,NULL,NULL,NULL,NULL),(28,7,NULL,NULL,NULL,NULL),(29,8,NULL,NULL,NULL,NULL),(30,8,NULL,NULL,NULL,NULL),(31,8,NULL,NULL,NULL,NULL),(32,8,NULL,NULL,NULL,NULL),(33,9,NULL,NULL,NULL,NULL),(34,9,NULL,NULL,NULL,NULL),(35,9,NULL,NULL,NULL,NULL),(36,9,NULL,NULL,NULL,NULL),(37,10,NULL,NULL,NULL,NULL),(38,10,NULL,NULL,NULL,NULL),(39,10,NULL,NULL,NULL,NULL),(40,10,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `document_entreprise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ecole`
--

DROP TABLE IF EXISTS `ecole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ecole` (
  `idecole` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `nom` varchar(90) NOT NULL,
  `SIRET` varchar(20) NOT NULL,
  `categorie` varchar(20) NOT NULL,
  `nom_du_responsable` varchar(45) NOT NULL,
  `prenom_du_responsable` varchar(45) NOT NULL,
  `adresse` varchar(45) NOT NULL,
  `code_postale` varchar(6) NOT NULL,
  `ville` varchar(25) NOT NULL,
  `pays` varchar(25) NOT NULL,
  `numero` varchar(20) NOT NULL,
  `adresse_mail` varchar(55) NOT NULL,
  PRIMARY KEY (`idecole`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ecole`
--

LOCK TABLES `ecole` WRITE;
/*!40000 ALTER TABLE `ecole` DISABLE KEYS */;
INSERT INTO `ecole` VALUES (1,'HESAM Université','130021447','peintre','Cruz','Gareth','15 rue soufflot','75005','paris','France','130021447','hesa@gmail.com'),(2,'ESMOD','572135077','Styliste','hughes','Quinlan','30 ave jean lolive','75009','paris','France','03 88 21 59 89','sodales@tincidunttempusrisus.edu'),(3,'IESA','534299749','desinger/peintre','Solis','Barrera','12 rue de poisonnerie','75008','paris','France','01 39 36 44 18','non.cursus.non@duiSuspendisse.ca'),(4,'ENSATT','397974773','photographie/dessin','Nielsen','kelley','102 rue de faubourge','75003','paris','France','08 85 73 05 86','purus@ultrices.com'),(5,'Ecole superieure d\'art et de design de Marseille-Mediterranee','390976665','dessin/peintre','Johns','Vergas','11 rue de gorge','13281','merseille','France','06 50 93 54 67','pellentesque.eget@orciUtsemper.com');
/*!40000 ALTER TABLE `ecole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entreprise`
--

DROP TABLE IF EXISTS `entreprise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entreprise` (
  `identreprise` int(11) NOT NULL AUTO_INCREMENT,
  `denomination_Commerciale` varchar(45) NOT NULL,
  `raison_Sociale` varchar(45) NOT NULL,
  `nom_de_l_ayant_droit` varchar(45) NOT NULL,
  `prenom_de_l_ayant_droit` varchar(45) NOT NULL,
  `fonction_au_sein_de_l_entreprise` varchar(45) NOT NULL,
  `adresse` varchar(45) NOT NULL,
  `code_postale` int(6) NOT NULL,
  `ville` varchar(25) NOT NULL,
  `pays` varchar(20) NOT NULL,
  `adresse_email` varchar(45) NOT NULL,
  `numero` varchar(20) NOT NULL,
  `artiste_choisi_id` int(11) DEFAULT NULL,
  `contrat_abonnement_id` int(11) NOT NULL,
  `contrat_avec_artiste_id` int(11) DEFAULT NULL,
  `mot_de_passe` varchar(20) NOT NULL,
  `SIRET` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`identreprise`),
  KEY `fk_entreprise_artiste_idx` (`artiste_choisi_id`),
  CONSTRAINT `fk_entreprise_artiste` FOREIGN KEY (`artiste_choisi_id`) REFERENCES `artiste` (`idartiste`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entreprise`
--

LOCK TABLES `entreprise` WRITE;
/*!40000 ALTER TABLE `entreprise` DISABLE KEYS */;
INSERT INTO `entreprise` VALUES (1,'l\'oreal','l\'oreal','Agon','Jean-paul','directeur','14 RUE ROYALE ',75008,'paris','France','manager@loeral.com','76509088',1,1,1,'123','632012100'),(2,'LVMH','loewe ','Belen ','Iglesias','manager des RH','22, avenue Montaigne',75008,'paris','France','at.sem@egestasurnajusto.co.uk','01 44 13 22 22',2,2,2,'123','31857106400324'),(3,'LVMH','dior','Roberta ','Novello','directeur des RH','15 RUE ROYALE ',75004,'paris','France','arcu@semvitae.com','02 23 37 95 18',NULL,3,NULL,'123','832859482-00008'),(4,'Expectra','expectra','Salle','Philippe','gerant ','12 RUE BOISSY D\'ANGLAS',75008,'pariis','France','Philippe@expectra.com','06 98 30 30 02',NULL,4,NULL,'123','433 867 249 00057'),(5,'Magna Consulting','Megna Conltin','Chang','Aquila','directeur','149 RUE ROYALE ',69300,'Lyon','Fance','rutrum.magna@Donec.co.uk','02 74 26 34 01',NULL,5,NULL,'123','822884631-00000'),(6,'Egestas Incorporated','Egestas Incorporated','Lucius ','Gordon','gerant','14 RUE Amande',94300,'Vincenne','Fance','dolor@malesuadaaugue.co.uk','06 98 30 30 02',NULL,6,NULL,'123','62349607200009'),(7,'Augue Ut Lacus Limited','Augue Ut Lacus Limited','Otto','Wall','manager','22 RUE Porttitor ',75003,'Paris','France','bibendum.ullamcorper@velitegetlaoreet.ca','09 37 44 59 49',NULL,7,NULL,'123','81164190-00005'),(8,'Quam A Corp.','Quam A Corp.','Daria','Riley','manager','109 RUE Porttito',75019,'Paris ','France','molestie.in.tempus@nibhdolornonummy.edu','07 34 60 31 48',NULL,8,NULL,'123','325975902-00009'),(9,'Diam PC','Diam PC','Ali','Barker','manager','99 RUE Nulla',92400,'Courbevoie','France','est.ac@neque.com','03 67 58 61 74',NULL,9,NULL,'123','369320650-00004'),(10,'Sodales Industries','Commodo PC','Sean','Strehenson','directeur','995 RUE Porttito',92300,'Levallois-Perret','France','In.lorem@ullamcorpervelit.com','0367 58 61 74',NULL,10,NULL,'123','093585537-00009');
/*!40000 ALTER TABLE `entreprise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fomation`
--

DROP TABLE IF EXISTS `fomation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fomation` (
  `idfomation` int(10) unsigned NOT NULL,
  `nom` varchar(45) NOT NULL,
  PRIMARY KEY (`idfomation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fomation`
--

LOCK TABLES `fomation` WRITE;
/*!40000 ALTER TABLE `fomation` DISABLE KEYS */;
INSERT INTO `fomation` VALUES (1,'dessin'),(2,'photographie'),(3,'la mode'),(4,'cours de peintre en bâtiment'),(5,'peintre idustriel'),(6,'designer');
/*!40000 ALTER TABLE `fomation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formation_ecole`
--

DROP TABLE IF EXISTS `formation_ecole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `formation_ecole` (
  `idformation_ecole` int(11) unsigned NOT NULL,
  `formation_id` int(11) unsigned NOT NULL,
  `ecole_id` int(11) unsigned NOT NULL,
  `cout_de_formation` int(11) DEFAULT NULL,
  PRIMARY KEY (`idformation_ecole`),
  KEY `fk_formation_ecole_formation_idx` (`formation_id`),
  KEY `fk_formation_ecole_ecole_idx` (`ecole_id`),
  CONSTRAINT `fk_formation_ecole_ecole` FOREIGN KEY (`ecole_id`) REFERENCES `ecole` (`idecole`),
  CONSTRAINT `fk_formation_ecole_formation` FOREIGN KEY (`formation_id`) REFERENCES `fomation` (`idfomation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formation_ecole`
--

LOCK TABLES `formation_ecole` WRITE;
/*!40000 ALTER TABLE `formation_ecole` DISABLE KEYS */;
INSERT INTO `formation_ecole` VALUES (1,1,1,3000),(2,2,1,4500),(3,3,2,6000),(4,4,3,8000),(5,5,3,9000),(6,6,4,7000),(7,1,4,7000),(8,2,5,5500),(9,3,5,7500);
/*!40000 ALTER TABLE `formation_ecole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `photo`
--

DROP TABLE IF EXISTS `photo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `photo` (
  `idphoto` int(11) NOT NULL AUTO_INCREMENT,
  `idartist` int(11) unsigned NOT NULL,
  `photo` blob,
  PRIMARY KEY (`idphoto`),
  KEY `fk_photo_artist_idx` (`idartist`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `photo`
--

LOCK TABLES `photo` WRITE;
/*!40000 ALTER TABLE `photo` DISABLE KEYS */;
INSERT INTO `photo` VALUES (1,1,NULL),(2,1,NULL),(3,1,NULL),(4,1,NULL),(5,1,NULL),(6,2,NULL),(7,2,NULL),(8,2,NULL),(9,3,NULL),(10,3,NULL),(11,3,NULL),(12,4,NULL),(13,4,NULL),(14,4,NULL),(15,4,NULL),(16,5,NULL),(17,5,NULL),(18,5,NULL),(19,5,NULL),(20,5,NULL),(21,5,NULL),(22,6,NULL),(23,6,NULL),(24,6,NULL),(25,6,NULL),(26,6,NULL),(27,6,NULL),(28,7,NULL),(29,7,NULL),(30,7,NULL),(31,7,NULL),(32,7,NULL),(33,7,NULL),(34,7,NULL),(35,7,NULL),(36,8,NULL),(37,8,NULL),(38,8,NULL),(39,9,NULL),(40,9,NULL),(41,9,NULL),(42,10,NULL),(43,10,NULL),(44,10,NULL),(45,11,NULL),(46,11,NULL),(47,11,NULL),(48,12,NULL),(49,12,NULL),(50,12,NULL),(51,13,NULL),(52,13,NULL),(53,13,NULL);
/*!40000 ALTER TABLE `photo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateurartiste`
--

DROP TABLE IF EXISTS `utilisateurartiste`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateurartiste` (
  `idUtilisateurArtiste` int(11) NOT NULL,
  `mailUA` varchar(45) DEFAULT NULL,
  `mot_de_passe` varchar(45) DEFAULT NULL,
  `idartiste` int(11) DEFAULT NULL,
  `role` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idUtilisateurArtiste`),
  KEY `fk_UtilisateurArtiste_Artiste_idx` (`idartiste`),
  CONSTRAINT `fk_UtilisateurArtiste_Artiste` FOREIGN KEY (`idartiste`) REFERENCES `artiste` (`idartiste`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateurartiste`
--

LOCK TABLES `utilisateurartiste` WRITE;
/*!40000 ALTER TABLE `utilisateurartiste` DISABLE KEYS */;
/*!40000 ALTER TABLE `utilisateurartiste` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateurentreprise`
--

DROP TABLE IF EXISTS `utilisateurentreprise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateurentreprise` (
  `idUtilisateurEntreprise` int(11) NOT NULL,
  `adresse_mailUE` varchar(45) DEFAULT NULL,
  `mot_de_passeUE` varchar(45) DEFAULT NULL,
  `identreprise` int(11) DEFAULT NULL,
  `role` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idUtilisateurEntreprise`),
  KEY `fk_UtilsateurEntreprise_entreprise_idx` (`identreprise`),
  CONSTRAINT `fk_UtilsateurEntreprise_entreprise` FOREIGN KEY (`identreprise`) REFERENCES `entreprise` (`identreprise`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateurentreprise`
--

LOCK TABLES `utilisateurentreprise` WRITE;
/*!40000 ALTER TABLE `utilisateurentreprise` DISABLE KEYS */;
INSERT INTO `utilisateurentreprise` VALUES (0,'aaa@TOTO.COM',NULL,NULL,NULL);
/*!40000 ALTER TABLE `utilisateurentreprise` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-24 15:17:54
