-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jun 07, 2017 at 11:52 AM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `kks`
--
CREATE DATABASE IF NOT EXISTS `kks` DEFAULT CHARACTER SET utf8 COLLATE utf8_turkish_ci;
USE `kks`;

-- --------------------------------------------------------

--
-- Table structure for table `administrators`
--

DROP TABLE IF EXISTS `administrators`;
CREATE TABLE IF NOT EXISTS `administrators` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(30) DEFAULT NULL,
  `password` varchar(64) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `administrators`
--

INSERT INTO `administrators` (`id`, `username`, `password`, `created_at`, `updated_at`) VALUES
(1, 'admin', '123', NULL, NULL),
(2, 'root', '827ccb0eea8a706c4c34a16891f84e7b', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `configs`
--

DROP TABLE IF EXISTS `configs`;
CREATE TABLE IF NOT EXISTS `configs` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `config_key` varchar(50) DEFAULT NULL,
  `config_value` varchar(50) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `entries`
--

DROP TABLE IF EXISTS `entries`;
CREATE TABLE IF NOT EXISTS `entries` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `value` varchar(50) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `entries`
--

INSERT INTO `entries` (`id`, `value`, `created_at`, `updated_at`) VALUES
(1, 'A', NULL, NULL),
(2, 'B', NULL, NULL),
(3, 'C', NULL, NULL),
(4, 'D', NULL, NULL),
(6, 'D', '2017-05-21 18:48:25', NULL);

--
-- Triggers `entries`
--
DROP TRIGGER IF EXISTS `ENTRIES_BEFORE_INSERT`;
DELIMITER //
CREATE TRIGGER `ENTRIES_BEFORE_INSERT` BEFORE INSERT ON `entries`
 FOR EACH ROW BEGIN
	SET new.created_at = SYSDATE();
    END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `faculties`
--

DROP TABLE IF EXISTS `faculties`;
CREATE TABLE IF NOT EXISTS `faculties` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `value` varchar(50) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=14 ;

--
-- Dumping data for table `faculties`
--

INSERT INTO `faculties` (`id`, `value`, `created_at`, `updated_at`) VALUES
(0, 'Kocaeli Universitesi', NULL, NULL),
(1, 'deneme', NULL, NULL),
(13, 'Teknoloji Fakültesi', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `logs_`
--

DROP TABLE IF EXISTS `logs_`;
CREATE TABLE IF NOT EXISTS `logs_` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) DEFAULT NULL,
  `sicil_no` varchar(20) DEFAULT NULL,
  `rfid` varchar(35) DEFAULT NULL,
  `plate` varchar(15) DEFAULT NULL,
  `input_entry` varchar(50) DEFAULT NULL,
  `output_entry` varchar(50) DEFAULT NULL,
  `input_date` timestamp NULL DEFAULT NULL,
  `output_date` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2112 ;

-- --------------------------------------------------------

--
-- Table structure for table `logs_nonuser`
--

DROP TABLE IF EXISTS `logs_nonuser`;
CREATE TABLE IF NOT EXISTS `logs_nonuser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `rfid` varchar(35) DEFAULT NULL,
  `plate` varchar(50) DEFAULT NULL,
  `input_date` timestamp NULL DEFAULT NULL,
  `input_entry` varchar(50) DEFAULT NULL,
  `output_date` timestamp NULL DEFAULT NULL,
  `output_entry` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=215 ;

--
-- Dumping data for table `logs_nonuser`
--

INSERT INTO `logs_nonuser` (`id`, `rfid`, `plate`, `input_date`, `input_entry`, `output_date`, `output_entry`) VALUES
(213, 'E2 00 50 24 86 12 02 65 13 60 AE 67', '', NULL, NULL, '2017-06-07 09:49:24', '1'),
(214, 'E2 00 50 24 86 12 02 65 13 60 AE 68', '', '2017-06-07 09:49:31', '0', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `titles`
--

DROP TABLE IF EXISTS `titles`;
CREATE TABLE IF NOT EXISTS `titles` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `value` varchar(50) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- Dumping data for table `titles`
--

INSERT INTO `titles` (`id`, `value`, `created_at`, `updated_at`) VALUES
(0, 'Kocaeli Universitesi', NULL, NULL),
(7, 'Bilişim Sistemleri Mühendisliği', NULL, NULL),
(11, 'dennbolum', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `rfid_no` varchar(35) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sicil_no` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `plate` varchar(15) CHARACTER SET utf8 DEFAULT NULL,
  `image` varchar(200) COLLATE utf8_turkish_ci DEFAULT NULL,
  `name` varchar(30) CHARACTER SET utf8 NOT NULL,
  `lastname` varchar(30) CHARACTER SET utf8 NOT NULL,
  `faculty` int(11) NOT NULL DEFAULT '0',
  `title` int(11) DEFAULT '0',
  `status` enum('active','deleted','blocked') CHARACTER SET utf8 DEFAULT 'active',
  `list` enum('red','yellow','green') CHARACTER SET utf8 DEFAULT 'green',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `fakulte` varchar(150) COLLATE utf8_turkish_ci DEFAULT 'Kocaeli Universitesi',
  `bolum` varchar(150) COLLATE utf8_turkish_ci DEFAULT 'Kocaeli Universitesi',
  PRIMARY KEY (`id`),
  KEY `gsd` (`rfid_no`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci AUTO_INCREMENT=15 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `rfid_no`, `sicil_no`, `plate`, `image`, `name`, `lastname`, `faculty`, `title`, `status`, `list`, `created_at`, `updated_at`, `fakulte`, `bolum`) VALUES
(1, '1234', '5151', '41den41', '', 'Deneme', 'deneme', 0, 0, 'active', 'red', NULL, NULL, NULL, NULL),
(2, '1', '21', '1', '', 'HGJHGJ', 'df', 13, 7, 'active', 'green', NULL, NULL, NULL, NULL),
(6, 'E2 00 50 24 86 12 02 65 13 60 AE 61', '4419', '34DEN34', '', 'Ad', 'Soyad', 13, 7, 'active', 'green', NULL, NULL, 'Teknoloji Fakultesi', 'Bilisim Sistemleri Muhendisligi'),
(8, '789', '15', '41ooo41', '', 'yeni', 'den', 0, 0, 'active', 'red', NULL, NULL, NULL, NULL),
(9, 'E2 00 50 24 86 12 02 65 13 60 AE 60', '2444', '34NT3685', '', 'Ad2', 'Soyad2', 13, 7, 'active', 'green', NULL, NULL, 'Teknoloji', 'Deneme'),
(11, '1234566', '5', '34', '', 'combo', 'bom', 0, 2, 'deleted', 'red', NULL, NULL, NULL, NULL),
(14, '', '221', '', '', '', '', 0, 0, 'blocked', 'green', NULL, NULL, 'hgj', 'ghj');

-- --------------------------------------------------------

--
-- Table structure for table `user_types`
--

DROP TABLE IF EXISTS `user_types`;
CREATE TABLE IF NOT EXISTS `user_types` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `value` varchar(50) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
