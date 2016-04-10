-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 10, 2016 at 05:43 PM
-- Server version: 5.6.26-log
-- PHP Version: 5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `firmi`
--

-- --------------------------------------------------------

--
-- Table structure for table `firms`
--

CREATE TABLE IF NOT EXISTS `firms` (
`CodF` int(1) NOT NULL,
  `NameF` varchar(14) DEFAULT NULL,
  `Adres` varchar(22) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `firms`
--

INSERT INTO `firms` (`CodF`, `NameF`, `Adres`) VALUES
(1, 'Роса', 'Русе, Рига 5'),
(2, 'Аквилон', 'Русе, Дунав 5'),
(3, 'Маги', 'Варна, Лом 17');

-- --------------------------------------------------------

--
-- Table structure for table `magazins`
--

CREATE TABLE IF NOT EXISTS `magazins` (
`CodM` int(1) NOT NULL,
  `Type` varchar(20) DEFAULT NULL,
  `NameM` varchar(16) DEFAULT NULL,
  `AdresM` varchar(31) DEFAULT NULL,
  `Boss` varchar(16) DEFAULT NULL,
  `CodF` int(1) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `magazins`
--

INSERT INTO `magazins` (`CodM`, `Type`, `NameM`, `AdresM`, `Boss`, `CodF`) VALUES
(1, 'хранителен', 'Зора', 'Иглика 15', 'Димитров', 1),
(2, 'хранителен', 'Малина', 'Асен 14', 'Иванов', 1),
(3, 'книжарница', 'АБВ', 'Вазов 77', 'Стоянова', 3),
(4, 'книжарница', 'Пингвини', 'Александровска 20', 'Петров', 3),
(5, 'книжарница', 'z', 'Николаевска 10', 'Павлов', 3),
(6, 'облекло', 'Яница', 'Вазов 15', 'Иванова', 2);

-- --------------------------------------------------------

--
-- Table structure for table `meseci`
--

CREATE TABLE IF NOT EXISTS `meseci` (
  `CodM` int(2) NOT NULL DEFAULT '0',
  `ImeM` varchar(18) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `meseci`
--

INSERT INTO `meseci` (`CodM`, `ImeM`) VALUES
(1, 'Януари'),
(2, 'Февруари'),
(3, 'Март'),
(4, 'Април'),
(5, 'Май'),
(6, 'Юни'),
(7, 'Юли'),
(8, 'Август'),
(9, 'Септември'),
(10, 'Октомври'),
(11, 'Ноември'),
(12, 'Декември');

-- --------------------------------------------------------

--
-- Table structure for table `prodajbi`
--

CREATE TABLE IF NOT EXISTS `prodajbi` (
`Id` int(11) NOT NULL,
  `CodM` int(1) NOT NULL DEFAULT '0',
  `CodMes` int(1) NOT NULL DEFAULT '0',
  `StPlan` int(5) DEFAULT NULL,
  `StIzp` int(5) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `prodajbi`
--

INSERT INTO `prodajbi` (`Id`, `CodM`, `CodMes`, `StPlan`, `StIzp`) VALUES
(1, 1, 1, 23433, 20000),
(2, 1, 2, 16500, 17000),
(3, 1, 3, 25000, 23500),
(4, 2, 1, 3500, 3000),
(5, 2, 2, 2750, 2500),
(6, 3, 1, 6800, 7500),
(7, 4, 4, 4570, 4851),
(8, 4, 2, 3200, 3700);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `firms`
--
ALTER TABLE `firms`
 ADD PRIMARY KEY (`CodF`), ADD UNIQUE KEY `CodF` (`CodF`);

--
-- Indexes for table `magazins`
--
ALTER TABLE `magazins`
 ADD PRIMARY KEY (`CodM`);

--
-- Indexes for table `meseci`
--
ALTER TABLE `meseci`
 ADD PRIMARY KEY (`CodM`);

--
-- Indexes for table `prodajbi`
--
ALTER TABLE `prodajbi`
 ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `firms`
--
ALTER TABLE `firms`
MODIFY `CodF` int(1) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `magazins`
--
ALTER TABLE `magazins`
MODIFY `CodM` int(1) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `prodajbi`
--
ALTER TABLE `prodajbi`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
