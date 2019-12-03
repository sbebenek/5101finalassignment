-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 03, 2019 at 10:36 PM
-- Server version: 5.7.24
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `website`
--

-- --------------------------------------------------------

--
-- Table structure for table `authors`
--

CREATE TABLE `authors` (
  `authorid` int(20) UNSIGNED NOT NULL,
  `authorfname` varchar(255) COLLATE latin1_bin NOT NULL,
  `authorlname` varchar(255) COLLATE latin1_bin NOT NULL,
  `authorjoindate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_bin;

--
-- Dumping data for table `authors`
--

INSERT INTO `authors` (`authorid`, `authorfname`, `authorlname`, `authorjoindate`) VALUES
(2, 'Tina', 'Bigglesby', '2019-11-26'),
(4, 'John', 'Smath', '2019-11-30'),
(5, 'Robert', 'Schneider', '2019-11-30'),
(8, 'Bobby', 'Bigglesby', '2019-11-30'),
(12, 'Strong', 'Person', '2019-11-30');

-- --------------------------------------------------------

--
-- Table structure for table `pages`
--

CREATE TABLE `pages` (
  `pageid` int(20) UNSIGNED NOT NULL,
  `pagetitle` varchar(255) COLLATE latin1_bin DEFAULT NULL,
  `pagebody` mediumtext COLLATE latin1_bin,
  `pagepublishdate` date DEFAULT NULL,
  `authorid` int(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_bin;

--
-- Dumping data for table `pages`
--

INSERT INTO `pages` (`pageid`, `pagetitle`, `pagebody`, `pagepublishdate`, `authorid`) VALUES
(2, 'Some Good News', 'With so much bad news in the world, it is easy forget that otters in fact still exist, and therefore, the world cannot be such a bad place.', '2019-11-23', 2),
(17, 'The Last Article', 'One day I was doing an assignment in ASP.NET to create a content management system. After a long and arduous development process, I created this article, hoping that it would in fact be the final article I would need to make. ', '2019-11-30', 4);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `authors`
--
ALTER TABLE `authors`
  ADD PRIMARY KEY (`authorid`);

--
-- Indexes for table `pages`
--
ALTER TABLE `pages`
  ADD PRIMARY KEY (`pageid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `authors`
--
ALTER TABLE `authors`
  MODIFY `authorid` int(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `pages`
--
ALTER TABLE `pages`
  MODIFY `pageid` int(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
