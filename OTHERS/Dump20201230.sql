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
-- Table structure for table `boite_artiste`
--

DROP TABLE IF EXISTS `boite_artiste`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `boite_artiste` (
  `idBoite_Artiste` int(11) NOT NULL,
  `id_entreprise` int(11) DEFAULT NULL,
  `id_artiste` int(11) DEFAULT NULL,
  PRIMARY KEY (`idBoite_Artiste`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

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
  CONSTRAINT `fk_document_entrprise_entrprise` FOREIGN KEY (`id_entreprise`) REFERENCES `entreprise` (`identreprise`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-30 22:11:57
