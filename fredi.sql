-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  lun. 27 mai 2019 à 01:19
-- Version du serveur :  5.7.24
-- Version de PHP :  7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `fredi`
--

-- --------------------------------------------------------

--
-- Structure de la table `adherents`
--

DROP TABLE IF EXISTS `adherents`;
CREATE TABLE IF NOT EXISTS `adherents` (
  `IDAdherents` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `LicenceNumber` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `FamilyName` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Password` varchar(250) COLLATE utf8_unicode_ci NOT NULL,
  `FristOrNot` varchar(3) COLLATE utf8_unicode_ci NOT NULL,
  `LeaguesNumber` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`IDAdherents`),
  UNIQUE KEY `ligues` (`LeaguesNumber`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table `adherents`
--

INSERT INTO `adherents` (`IDAdherents`, `LicenceNumber`, `FamilyName`, `Name`, `Email`, `Password`, `FristOrNot`, `LeaguesNumber`) VALUES
('', '', '', '', 'ga', 'ga', 'yes', ''),
('01', '01', '01', '01', 'az', 'az', 'yes', '000000000000000');

-- --------------------------------------------------------

--
-- Structure de la table `demandeurs`
--

DROP TABLE IF EXISTS `demandeurs`;
CREATE TABLE IF NOT EXISTS `demandeurs` (
  `IDDemandeurs` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `FamilyName` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `DateOfBirthday` date NOT NULL,
  `Address` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `PostalCode` int(10) NOT NULL,
  `City` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `ReceiptNumber` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`IDDemandeurs`),
  UNIQUE KEY `lien` (`Email`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `lien`
--

DROP TABLE IF EXISTS `lien`;
CREATE TABLE IF NOT EXISTS `lien` (
  `IDLink` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `LicenceNumber` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `lignesdefrais`
--

DROP TABLE IF EXISTS `lignesdefrais`;
CREATE TABLE IF NOT EXISTS `lignesdefrais` (
  `Date` varchar(8) COLLATE utf8_unicode_ci NOT NULL,
  `Journey` varchar(250) COLLATE utf8_unicode_ci NOT NULL,
  `TotalKm` int(10) NOT NULL,
  `CostToll` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `CostLunches` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `CostAccommodation` varchar(10) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table `lignesdefrais`
--

INSERT INTO `lignesdefrais` (`Date`, `Journey`, `TotalKm`, `CostToll`, `CostLunches`, `CostAccommodation`) VALUES
('1', '1', 1, '1', '1', '1');

-- --------------------------------------------------------

--
-- Structure de la table `ligues`
--

DROP TABLE IF EXISTS `ligues`;
CREATE TABLE IF NOT EXISTS `ligues` (
  `IDLeagues` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `LName` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Sigle` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `PName` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`IDLeagues`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `ReasonID` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Reason` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`ReasonID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
