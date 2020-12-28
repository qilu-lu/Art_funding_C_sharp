CREATE DATABASE  IF NOT EXISTS `art_funding` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `art_funding`;
-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: art_funding
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
  `idartiste` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  `prenom` varchar(45) DEFAULT NULL,
  `date_de_naissance` date NOT NULL,
  `adresse` varchar(45) NOT NULL,
  `code_postale` varchar(6) NOT NULL,
  `ville` varchar(25) NOT NULL,
  `pays` varchar(25) NOT NULL,
  `numero` varchar(20) NOT NULL,
  `description` text,
  `ecole_choisie_id` int(11) unsigned NOT NULL,
  `formation_choisie_id` int(11) DEFAULT NULL,
  `Disponibilite` date DEFAULT NULL,
  `categorie_id` int(11) NOT NULL,
  PRIMARY KEY (`idartiste`),
  KEY `fk_artiste_ecole_idx` (`ecole_choisie_id`),
  KEY `fr_artiste_categorie_idx` (`categorie_id`),
  CONSTRAINT `fk_artiste_categorie` FOREIGN KEY (`categorie_id`) REFERENCES `categorie` (`id_categorie`),
  CONSTRAINT `fk_artiste_ecole` FOREIGN KEY (`ecole_choisie_id`) REFERENCES `ecole` (`idecole`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `artiste`
--

LOCK TABLES `artiste` WRITE;
/*!40000 ALTER TABLE `artiste` DISABLE KEYS */;
INSERT INTO `artiste` VALUES (21,'lu','lu','1995-02-11','jlksjl','92400','paris','fr','1234567890','ff',4,NULL,'2020-02-11',1),(22,'amira','lu','1995-02-11','jlksjl','92400','paris','fr','1234567890','ff',1,NULL,'2020-02-11',1),(23,'lu','lu','1995-02-11','jlksjl','92400','paris','fr','1234567890','ff',2,NULL,'2020-02-11',1),(24,'lu','lu','1995-02-11','jlksjl','92400','paris','fr','1234567890','ff',1,NULL,'2020-02-11',1),(25,'lu','lu','1995-02-11','jlksjl','92400','paris','fr','1234567890','ff',2,NULL,'2020-02-11',1),(26,'lu','lu','1995-02-11','jlksjl','92400','paris','fr','1234567890','ff',4,NULL,'2020-02-11',1),(27,'lu','lu','1995-02-11','jlksjl','92400','paris','fr','1234567890','ff',2,NULL,'2020-02-11',1),(30,'lu','lu','1995-02-11','jlksjl','92400','paris','fr','1234567890','ff',3,NULL,'2020-02-11',2),(31,'lu','lu','1995-02-11','jlksjl','92400','paris','fr','1234567890','ff',2,NULL,'2020-02-11',2);
/*!40000 ALTER TABLE `artiste` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categorie`
--

DROP TABLE IF EXISTS `categorie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorie` (
  `id_categorie` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  PRIMARY KEY (`id_categorie`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorie`
--

LOCK TABLES `categorie` WRITE;
/*!40000 ALTER TABLE `categorie` DISABLE KEYS */;
INSERT INTO `categorie` VALUES (1,'PHOTOGRAPHE'),(2,'DESIGNER');
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
/*!40000 ALTER TABLE `contrat_ecole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contrat_entreprise`
--

DROP TABLE IF EXISTS `contrat_entreprise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contrat_entreprise` (
  `idContrat_entreprise` int(11) NOT NULL AUTO_INCREMENT,
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
/*!40000 ALTER TABLE `contrat_entreprise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `document_artiste`
--

DROP TABLE IF EXISTS `document_artiste`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `document_artiste` (
  `id_document_artiste` int(11) unsigned NOT NULL AUTO_INCREMENT,
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
/*!40000 ALTER TABLE `document_artiste` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `document_entreprise`
--

DROP TABLE IF EXISTS `document_entreprise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `document_entreprise` (
  `iddocument_entreprise` int(11) NOT NULL AUTO_INCREMENT,
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
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
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
  `SIRET` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`identreprise`),
  KEY `fk_entreprise_artiste_idx` (`artiste_choisi_id`),
  CONSTRAINT `fk_entreprise_artiste` FOREIGN KEY (`artiste_choisi_id`) REFERENCES `artiste` (`idartiste`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entreprise`
--

LOCK TABLES `entreprise` WRITE;
/*!40000 ALTER TABLE `entreprise` DISABLE KEYS */;
INSERT INTO `entreprise` VALUES (11,'ludf','lu','lu','lu','lu','jlksjl',92400,'paris','france','cccc@glail.com','0769411158',NULL,0,NULL,'12345678901234'),(12,'qi','kk','lu','lu','lu','jlksjl',92400,'paris','france','qilu@glail.com','0769411159',NULL,0,NULL,'12345678901234'),(13,'luz','lu','lu','lu','lu','jlksjl',92400,'paris','france','eaaa@gmail.com','0769411158',NULL,0,NULL,'12345678901234'),(14,'lu','lu','lu','lu','lu','jlksjl',92400,'paris','france','cele@glail.com','0769411158',NULL,0,NULL,'12345678901234'),(15,'jgljf','jlsdf','lu','lu','lu','jlksjl',92400,'paris','france','euu@glail.com','0769411150',NULL,0,NULL,'12345678901238'),(16,'luz','kk','lu','lu','lu','jlksjl',92400,'paris','france','wwwle@glail.com','0769411150',NULL,0,NULL,'12345678901238'),(17,'luz','kk','lu','lu','lu','jlksjl',92400,'paris','france','aaaa@glail.com','0769411158',NULL,0,NULL,'12345678901234'),(18,'lu','lu','lu','lu','lu','jlksjl',92400,'paris','france','cele@glail.com444','0769411158',NULL,0,NULL,'12345678901234'),(19,'lu','lu','lu','lu','lu','jlksjl',92400,'paris','france','chele@glail.com','0769411158',NULL,0,NULL,'12345678901234'),(20,'lu','lu','lu','lu','lu','jlksjl',92400,'paris','france','celes@glail.com','0769411158',NULL,0,NULL,'12345678901234'),(21,'xx','xxxxx','xx','xx','xx','xx',75001,'paris','france','bb@glail.com','0769411159',NULL,0,NULL,'12345678901234'),(22,'ludf','lu','lu','lu','xx','jlksjl',92400,'paris','france','bb3@glail.com','0769411158',NULL,0,NULL,'12345678901238'),(23,'ff','ff','lu','lu','fff','jlksjl',92400,'paris','f','cele7@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(24,'ff','ff','lu','lu','fff','jlksjl',92400,'paris','f','cele5@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(25,'ff','ff','lu','lu','fff','jlksjl',92400,'paris','f','amira@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(26,'ff','ff','lu','lu','fff','jlksjl',92400,'paris','f','123@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(27,'gi','bk','lu','lu','fff','jlksjl',92400,'paris','f','hiyi@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(28,'ff','ff','lu','lu','fff','jlksjl',92400,'paris','f','cele44@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(29,'ai','j','lu','lu','fff','jlksjl',75001,'paris','f','cele@glail.fr','1234567890',NULL,0,NULL,'1345678901244'),(30,'ff','ff','lu','lu','fff','jlksjl',92400,'paris','f','cee@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(31,'ff','ff','lu','lu','fff','jlksjl',92400,'paris','f','celeA@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(32,'ff','ff','lu','lu','fff','jlksjl',92400,'paris','f','celle@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(33,'ff','bk','lu','lu','fff','jlksjl',92400,'paris','f','cele22@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(34,'gi','ff','lu','lu','fff','jlksjl',92400,'paris','f','xxi@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(35,'ff','ff','lu','lu','fff','jlksjl',75011,'paris','f','1@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(36,'ff','ff','lu','lu','fff','jlksjl',92400,'paris','f','cele@glail.22','1234567890',NULL,0,NULL,'1345678901244'),(37,'ff','ff','lu','lu','fff','jlksjl',92400,'paris','f','c49ele@glail.com','1234567890',NULL,0,NULL,'1345678901244'),(38,'ff','ff','xx','xx','fff','xx',75001,'paris','f','bb5@glail.comz','1234567890',NULL,0,NULL,'1345678901244');
/*!40000 ALTER TABLE `entreprise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fomation`
--

DROP TABLE IF EXISTS `fomation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fomation` (
  `idfomation` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  PRIMARY KEY (`idfomation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fomation`
--

LOCK TABLES `fomation` WRITE;
/*!40000 ALTER TABLE `fomation` DISABLE KEYS */;
/*!40000 ALTER TABLE `fomation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formation_ecole`
--

DROP TABLE IF EXISTS `formation_ecole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `formation_ecole` (
  `idformation_ecole` int(11) unsigned NOT NULL AUTO_INCREMENT,
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
/*!40000 ALTER TABLE `photo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateurartiste`
--

DROP TABLE IF EXISTS `utilisateurartiste`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateurartiste` (
  `idUtilisateurArtiste` int(11) NOT NULL AUTO_INCREMENT,
  `mailUA` varchar(45) DEFAULT NULL,
  `mot_de_passe` varchar(45) DEFAULT NULL,
  `idartiste` int(11) DEFAULT NULL,
  `role` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idUtilisateurArtiste`),
  KEY `fk_UtilisateurArtiste_Artiste_idx` (`idartiste`),
  CONSTRAINT `fk_UtilisateurArtiste_Artiste` FOREIGN KEY (`idartiste`) REFERENCES `artiste` (`idartiste`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateurartiste`
--

LOCK TABLES `utilisateurartiste` WRITE;
/*!40000 ALTER TABLE `utilisateurartiste` DISABLE KEYS */;
INSERT INTO `utilisateurartiste` VALUES (1,'fff@gg.fr','123',21,NULL),(2,'amira@gg.fr','123',22,NULL),(3,'123@gg.fr','123',23,NULL),(4,'458@gg.com','123',24,NULL),(5,'ffdf@gg.fr','123',25,NULL),(6,'ttt@gg.fr','123',26,NULL),(7,'fffoo@gg.fr','123',27,NULL),(8,'fff9@gg.fr','123',30,NULL),(9,'12344@gg.fr','123',31,NULL);
/*!40000 ALTER TABLE `utilisateurartiste` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateurentreprise`
--

DROP TABLE IF EXISTS `utilisateurentreprise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateurentreprise` (
  `idUtilisateurEntreprise` int(11) NOT NULL AUTO_INCREMENT,
  `adresse_mailUE` varchar(45) DEFAULT NULL,
  `mot_de_passeUE` varchar(60) DEFAULT NULL,
  `identreprise` int(11) DEFAULT NULL,
  `role` varchar(45) DEFAULT NULL,
  `Nocartebancaire` varchar(45) DEFAULT NULL,
  `MoisExpiration` varchar(45) DEFAULT NULL,
  `AnneeExpiration` varchar(45) DEFAULT NULL,
  `CodeVerfication` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idUtilisateurEntreprise`),
  KEY `fk_UtilsateurEntreprise_entreprise_idx` (`identreprise`),
  CONSTRAINT `fk_UtilsateurEntreprise_entreprise` FOREIGN KEY (`identreprise`) REFERENCES `entreprise` (`identreprise`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateurentreprise`
--

LOCK TABLES `utilisateurentreprise` WRITE;
/*!40000 ALTER TABLE `utilisateurentreprise` DISABLE KEYS */;
INSERT INTO `utilisateurentreprise` VALUES (1,'cele@glail.com',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(2,'e@glail.com',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(3,'cccc@glail.com',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(4,'cccc@glail.com','123',NULL,NULL,NULL,NULL,NULL,NULL),(5,'qilu@glail.com','456',NULL,NULL,NULL,NULL,NULL,NULL),(6,'eaaa@gmail.com','789',NULL,NULL,NULL,NULL,NULL,NULL),(7,'cele@glail.com','123',NULL,NULL,NULL,NULL,NULL,NULL),(8,'cele@glail.com','123',NULL,NULL,NULL,NULL,NULL,NULL),(9,'euu@glail.com','123',NULL,NULL,NULL,NULL,NULL,NULL),(10,'wwwle@glail.com','456',NULL,NULL,NULL,NULL,NULL,NULL),(11,'aaaa@glail.com','123',NULL,NULL,NULL,NULL,NULL,NULL),(12,'cele@glail.com444','123',NULL,NULL,NULL,NULL,NULL,NULL),(13,'chele@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',19,NULL,NULL,NULL,NULL,NULL),(14,'celes@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',20,NULL,NULL,NULL,NULL,NULL),(15,'bb@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',21,NULL,NULL,NULL,NULL,NULL),(16,'bb3@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',22,NULL,NULL,NULL,NULL,NULL),(17,'cele7@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',23,NULL,NULL,NULL,NULL,NULL),(18,'cele5@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',24,NULL,NULL,NULL,NULL,NULL),(19,'amira@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',25,NULL,NULL,NULL,NULL,NULL),(20,'123@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',26,NULL,NULL,NULL,NULL,NULL),(21,'hiyi@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',27,NULL,NULL,NULL,NULL,NULL),(22,'cele44@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',28,NULL,NULL,NULL,NULL,NULL),(23,'cele@glail.fr','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',29,NULL,NULL,NULL,NULL,NULL),(24,'cee@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',30,NULL,'kjml','2023','12','123'),(25,'celeA@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',31,NULL,NULL,NULL,NULL,NULL),(26,'celle@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',32,NULL,'kjml',NULL,NULL,NULL),(27,'cele22@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',33,NULL,'0444589','12','2020','120'),(28,'xxi@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',34,NULL,'010698572','04','2025','11'),(29,'1@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',35,NULL,NULL,NULL,NULL,NULL),(30,'cele@glail.22','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',36,NULL,NULL,NULL,NULL,NULL),(31,'c49ele@glail.com','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',37,NULL,NULL,NULL,NULL,NULL),(32,'bb5@glail.comz','AE-C7-0B-BD-1C-BB-E5-45-B0-97-1D-CC-EC-C9-C3-C5',38,NULL,NULL,NULL,NULL,NULL);
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

-- Dump completed on 2020-12-28 22:10:21
