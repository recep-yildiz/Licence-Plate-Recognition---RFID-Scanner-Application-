-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 07 Haz 2017, 13:28:35
-- Sunucu sürümü: 5.7.14
-- PHP Sürümü: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `kks`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `administrators`
--

CREATE TABLE `administrators` (
  `id` int(11) UNSIGNED NOT NULL,
  `username` varchar(30) DEFAULT NULL,
  `password` varchar(64) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `administrators`
--

INSERT INTO `administrators` (`id`, `username`, `password`, `created_at`, `updated_at`) VALUES
(1, 'admin', '123', NULL, NULL),
(2, 'root', '827ccb0eea8a706c4c34a16891f84e7b', NULL, NULL);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `configs`
--

CREATE TABLE `configs` (
  `id` int(10) UNSIGNED NOT NULL,
  `config_key` varchar(50) DEFAULT NULL,
  `config_value` varchar(50) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `entries`
--

CREATE TABLE `entries` (
  `id` int(11) UNSIGNED NOT NULL,
  `value` varchar(50) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `entries`
--

INSERT INTO `entries` (`id`, `value`, `created_at`, `updated_at`) VALUES
(1, 'A', NULL, NULL),
(2, 'B', NULL, NULL),
(3, 'C', NULL, NULL),
(4, 'D', NULL, NULL),
(6, 'D', '2017-05-21 18:48:25', NULL);

--
-- Tetikleyiciler `entries`
--
DELIMITER $$
CREATE TRIGGER `ENTRIES_BEFORE_INSERT` BEFORE INSERT ON `entries` FOR EACH ROW BEGIN
	SET new.created_at = SYSDATE();
    END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `faculties`
--

CREATE TABLE `faculties` (
  `id` int(11) UNSIGNED NOT NULL,
  `value` varchar(50) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `faculties`
--

INSERT INTO `faculties` (`id`, `value`, `created_at`, `updated_at`) VALUES
(0, 'Kocaeli Universitesi', NULL, NULL),
(1, 'deneme', NULL, NULL),
(13, 'Teknoloji Fakültesi', NULL, NULL);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `logs_`
--

CREATE TABLE `logs_` (
  `id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `sicil_no` varchar(20) DEFAULT NULL,
  `rfid` varchar(35) DEFAULT NULL,
  `plate` varchar(15) DEFAULT NULL,
  `input_entry` varchar(50) DEFAULT NULL,
  `output_entry` varchar(50) DEFAULT NULL,
  `input_date` timestamp NULL DEFAULT NULL,
  `output_date` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `logs_nonuser`
--

CREATE TABLE `logs_nonuser` (
  `id` int(11) NOT NULL,
  `rfid` varchar(35) DEFAULT NULL,
  `plate` varchar(50) DEFAULT NULL,
  `input_date` timestamp NULL DEFAULT NULL,
  `input_entry` varchar(50) DEFAULT NULL,
  `output_date` timestamp NULL DEFAULT NULL,
  `output_entry` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `titles`
--

CREATE TABLE `titles` (
  `id` int(11) UNSIGNED NOT NULL,
  `value` varchar(50) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `titles`
--

INSERT INTO `titles` (`id`, `value`, `created_at`, `updated_at`) VALUES
(0, 'Kocaeli Universitesi', NULL, NULL),
(7, 'Bilişim Sistemleri Mühendisliği', NULL, NULL),
(11, 'dennbolum', NULL, NULL);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `id` int(11) UNSIGNED NOT NULL,
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
  `bolum` varchar(150) COLLATE utf8_turkish_ci DEFAULT 'Kocaeli Universitesi'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `users`
--

INSERT INTO `users` (`id`, `rfid_no`, `sicil_no`, `plate`, `image`, `name`, `lastname`, `faculty`, `title`, `status`, `list`, `created_at`, `updated_at`, `fakulte`, `bolum`) VALUES
(6, '6336103', '4419', '34DEN34', '', 'Sumeyya', 'Ilkin', 13, 7, 'active', 'green', NULL, NULL, 'Teknoloji Fakultesi', 'Bilisim Sistemleri Muhendisligi'),
(9, '6336104', '2444', '34NT3685', '', 'adnan', 'sondas', 13, 7, 'active', 'green', NULL, NULL, 'Teknoloji', 'Bilişim');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `user_types`
--

CREATE TABLE `user_types` (
  `id` int(11) UNSIGNED NOT NULL,
  `value` varchar(50) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `administrators`
--
ALTER TABLE `administrators`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `configs`
--
ALTER TABLE `configs`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `entries`
--
ALTER TABLE `entries`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `faculties`
--
ALTER TABLE `faculties`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `logs_`
--
ALTER TABLE `logs_`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `logs_nonuser`
--
ALTER TABLE `logs_nonuser`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `titles`
--
ALTER TABLE `titles`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `gsd` (`rfid_no`);

--
-- Tablo için indeksler `user_types`
--
ALTER TABLE `user_types`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `administrators`
--
ALTER TABLE `administrators`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- Tablo için AUTO_INCREMENT değeri `configs`
--
ALTER TABLE `configs`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- Tablo için AUTO_INCREMENT değeri `entries`
--
ALTER TABLE `entries`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- Tablo için AUTO_INCREMENT değeri `faculties`
--
ALTER TABLE `faculties`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- Tablo için AUTO_INCREMENT değeri `logs_`
--
ALTER TABLE `logs_`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2112;
--
-- Tablo için AUTO_INCREMENT değeri `logs_nonuser`
--
ALTER TABLE `logs_nonuser`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=215;
--
-- Tablo için AUTO_INCREMENT değeri `titles`
--
ALTER TABLE `titles`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
--
-- Tablo için AUTO_INCREMENT değeri `user_types`
--
ALTER TABLE `user_types`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
