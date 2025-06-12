-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: smarthome
-- ------------------------------------------------------
-- Server version	9.2.0

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
-- Table structure for table `Board`
--

DROP TABLE IF EXISTS `Board`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Board` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(125) NOT NULL,
  `Writer` varchar(50) DEFAULT NULL,
  `Title` varchar(250) NOT NULL,
  `Contents` longtext NOT NULL,
  `PostDate` datetime DEFAULT NULL,
  `ReadCount` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Board`
--

LOCK TABLES `Board` WRITE;
/*!40000 ALTER TABLE `Board` DISABLE KEYS */;
INSERT INTO `Board` VALUES (1,'peachk12@naver.com','피치','게시판 첫 번째 글','내일부터 3일 쉰다','2025-06-05 16:10:10',15),(5,'poiu123@gmail.com','아무개','테스트','테스트 입니다','2025-06-05 17:17:15',6),(7,'poiu123@gmail.com','아무개','test','<p>test입니다ㅏ.</p>','2025-06-09 16:45:40',3),(9,'monday12@gmail.com','월요일','이번주의 시작','<p>월요일은 한 주의 시작입니다.</p><p>이번 주도 모두 화이팅입니다.</p><p>오늘부터 내가 짱이라는 마인드로 꾸준히 해보겠습니다!!</p><p><img src=\"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbBkShYEDDGlmY9CPoBFApHsxUuH3ucgYreQ&amp;s\" alt=\"\"></p>','2025-06-09 17:08:01',2),(10,'abcd@gmail.com','abc','알파벳송','<p>abcdefghijklmnop</p>','2025-06-09 17:17:28',0),(11,'dog@gmail.com','강아지','강아지','<p>강아지는 귀여워</p>','2025-06-09 17:17:52',0),(12,'cat@gmail.com','고양이','고양이','<p>고양이는 귀여워</p>','2025-06-09 17:18:08',0),(13,'mno@gmail.com','엠엔오','이번주','<p>이번주는 휴일이 없습니다.</p>','2025-06-09 17:18:34',0),(14,'test100@gmail.com','만점자','이번주 토요일은 시험','<p>이번주 토요일은 자격증 시험이 있습니다.</p>','2025-06-09 17:19:08',0),(15,'test12@gmail.com','테스트','테스트','<p>테스트입니다.</p>','2025-06-09 17:19:28',0),(16,'test1@gmail.com','테스터','테스트10','<p>테스트10입니다.</p>','2025-06-09 17:19:53',1);
/*!40000 ALTER TABLE `Board` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-12 16:06:12
