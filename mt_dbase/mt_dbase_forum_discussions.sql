CREATE DATABASE  IF NOT EXISTS `mt_dbase` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `mt_dbase`;
-- MySQL dump 10.13  Distrib 5.1.40, for Win32 (ia32)
--
-- Host: localhost    Database: mt_dbase
-- ------------------------------------------------------
-- Server version	5.0.45-community-nt

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Not dumping tablespaces as no INFORMATION_SCHEMA.FILES table on this server
--

--
-- Table structure for table `forum_discussions`
--

DROP TABLE IF EXISTS `forum_discussions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `forum_discussions` (
  `post_id` int(11) NOT NULL auto_increment,
  `forum_name` varchar(100) default NULL,
  `post_subject` varchar(100) NOT NULL,
  `post_content` varchar(700) NOT NULL,
  `post_category` varchar(100) default NULL,
  `post_date` varchar(50) default NULL,
  `post_time` time default NULL,
  `views` int(11) default NULL,
  `comments` int(11) default NULL,
  `date_log` datetime default NULL,
  `posted_by` varchar(100) default NULL,
  PRIMARY KEY  (`post_id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `forum_discussions`
--

LOCK TABLES `forum_discussions` WRITE;
/*!40000 ALTER TABLE `forum_discussions` DISABLE KEYS */;
INSERT INTO `forum_discussions` VALUES (1,'Otad_Group','Greetings','This is to welcome all TechOps Members to this forum...',NULL,'14 April 2014','21:16:00',31,3,'2014-04-12 00:00:00','Micheal'),(2,'Otad_Group','Testing New Discussion Module','Hi Team,\r\n\r\nHere\'s another discussion startup to test the functionality of this module over a web browser. Kindly comment on the output format or any amendments that could be added. Thanks all...','-','19 April 2014','00:53:00',33,2,'2014-04-19 00:53:33','mtadese'),(3,'dotNET Team','Starting a discussion','Testing the discussion module after further amendments. Thanks','Information Technology','24 July 2015','12:32:00',8,0,'2015-07-24 12:32:55','mtadese');
/*!40000 ALTER TABLE `forum_discussions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-07-24 15:59:30
