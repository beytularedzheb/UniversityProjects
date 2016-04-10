-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 20, 2014 at 09:16 AM
-- Server version: 5.1.65
-- PHP Version: 5.4.17

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `nhlxdbhx_pc1`
--

-- --------------------------------------------------------

--
-- Table structure for table `degrees`
--

CREATE TABLE IF NOT EXISTS `degrees` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `abbr` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `degrees`
--

INSERT INTO `degrees` (`ID`, `name`, `abbr`) VALUES
(1, 'Бакалавър', 'бак.'),
(2, 'Магистър', 'маг.'),
(3, 'Доктор', 'д-р'),
(4, 'Доктор на науките', 'дтн.');

-- --------------------------------------------------------

--
-- Table structure for table `educations`
--

CREATE TABLE IF NOT EXISTS `educations` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  `abbr` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `educations`
--

INSERT INTO `educations` (`ID`, `name`, `abbr`) VALUES
(1, 'Редовно', 'ред.'),
(2, 'Задочно', 'зад.'),
(3, 'Дистанционно', 'дист.');

-- --------------------------------------------------------

--
-- Table structure for table `faculties`
--

CREATE TABLE IF NOT EXISTS `faculties` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  `abbr` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `faculties`
--

INSERT INTO `faculties` (`ID`, `name`, `abbr`) VALUES
(8, 'Природни науки', 'ПН');

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE IF NOT EXISTS `groups` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `major` int(11) NOT NULL,
  `education` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `major` (`major`),
  KEY `education` (`education`),
  KEY `education_2` (`education`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `groups`
--

INSERT INTO `groups` (`ID`, `major`, `education`, `name`) VALUES
(1, 1, 1, '26'),
(2, 3, 2, '6'),
(3, 1, 3, '8'),
(4, 3, 1, '41'),
(5, 2, 2, '34');

-- --------------------------------------------------------

--
-- Table structure for table `majors`
--

CREATE TABLE IF NOT EXISTS `majors` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `faculty` int(11) NOT NULL,
  `name` varchar(200) NOT NULL,
  `abbr` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `faculty` (`faculty`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `majors`
--

INSERT INTO `majors` (`ID`, `faculty`, `name`, `abbr`) VALUES
(1, 1, 'Компютърни системи и технологии', 'КСТ'),
(2, 1, 'Автоматика и мехатроника', 'АМ'),
(3, 2, 'Софтуерно инженерство', 'СИ');

-- --------------------------------------------------------

--
-- Table structure for table `positions`
--

CREATE TABLE IF NOT EXISTS `positions` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `abbr` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `positions`
--

INSERT INTO `positions` (`ID`, `name`, `abbr`) VALUES
(1, 'Асистент', 'ас.'),
(3, 'Главен асистент', 'гл. ас.'),
(4, 'Доцент', 'доц.'),
(5, 'Професор', 'проф.');

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE IF NOT EXISTS `students` (
  `ID` int(11) NOT NULL,
  `groupID` int(11) NOT NULL,
  `facultyNumber` varchar(6) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `facultyNumber` (`facultyNumber`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`ID`, `groupID`, `facultyNumber`) VALUES
(3, 2, '082324'),
(4, 3, '143234'),
(5, 5, '147324'),
(6, 0, '123456'),
(7, 0, '456213'),
(9, 0, '789789');

-- --------------------------------------------------------

--
-- Table structure for table `subjects`
--

CREATE TABLE IF NOT EXISTS `subjects` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `abbr` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `subjects`
--

INSERT INTO `subjects` (`ID`, `name`, `abbr`) VALUES
(1, 'Висша математика 1', 'ВМ1'),
(2, 'Физика', 'физ.'),
(3, 'Операционни системи', 'ОС'),
(4, 'Организация на компютъра', 'ОК');

-- --------------------------------------------------------

--
-- Table structure for table `subjectsTeachers`
--

CREATE TABLE IF NOT EXISTS `subjectsTeachers` (
  `subject` int(11) NOT NULL,
  `teacher` int(11) NOT NULL,
  `type` enum('lecture','exercise','seminarExercise') NOT NULL,
  PRIMARY KEY (`subject`,`teacher`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `subjectsTeachers`
--

INSERT INTO `subjectsTeachers` (`subject`, `teacher`, `type`) VALUES
(1, 1, 'lecture'),
(2, 1, 'lecture'),
(3, 2, 'exercise'),
(4, 2, 'seminarExercise');

-- --------------------------------------------------------

--
-- Table structure for table `teachers`
--

CREATE TABLE IF NOT EXISTS `teachers` (
  `ID` int(11) NOT NULL,
  `position` int(11) NOT NULL,
  `degree` int(11) NOT NULL,
  `salary` decimal(10,2) NOT NULL,
  `info` text NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `position` (`position`),
  KEY `degree` (`degree`),
  KEY `degree_2` (`degree`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `teachers`
--

INSERT INTO `teachers` (`ID`, `position`, `degree`, `salary`, `info`) VALUES
(1, 1, 2, '700.00', 'кабинет 1'),
(2, 3, 3, '800.00', 'кабинет 122');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `emailAddress` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `dateAdded` int(11) NOT NULL,
  `dateLastLogIn` int(11) NOT NULL,
  `status` enum('active','inactive') NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `emailAddress` (`emailAddress`),
  KEY `password` (`password`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `emailAddress`, `password`, `firstname`, `lastname`, `dateAdded`, `dateLastLogIn`, `status`) VALUES
(1, 'asdfgh@abv.bg', 'qwerty', 'Петър', 'Иванов', 123456789, 123798456, 'inactive'),
(2, 'zxcvbn@abv.bg', 'qwerty1', 'Надя', 'Стоева', 121212334, 545252342, 'inactive'),
(3, 'asdffdgg@abv.bg', 'asdfg', 'Кирил', 'Стефанов', 234534234, 234832234, 'active'),
(4, 'klo45455@abv.bg', 'gjk3445b', 'Асен', 'Асенов', 123456787, 234567878, 'active'),
(5, 'kjdfhg@gmail.com', '123456', 'Зорница', 'Пешева', 654565644, 846634567, 'inactive'),
(6, 'absv@abv.bg', 'c4ca4238a0b923820dcc509a6f75849b', 'wwww', 'wwww', 0, 0, 'active'),
(7, 'dsww@safa.bg', '35f4a8d465e6e1edc05f3d8ab658c551', 'wwsdas', 'sdfdsd', 0, 0, 'active'),
(8, 'aaa', 'f1290186a5d0b1ceab27f4e77c0c5d68', 'w', 'w', 0, 0, 'active'),
(9, 'a@abv.bg', 'c4ca4238a0b923820dcc509a6f75849b', 'Test', 'Testov', 0, 0, 'active');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
