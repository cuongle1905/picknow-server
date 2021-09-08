-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: localhost    Database: picknow
-- ------------------------------------------------------
-- Server version	8.0.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `country`
--

DROP TABLE IF EXISTS `country`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `country` (
  `id` smallint NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `country`
--

LOCK TABLES `country` WRITE;
/*!40000 ALTER TABLE `country` DISABLE KEYS */;
INSERT INTO `country` VALUES (1,'Việt Nam');
/*!40000 ALTER TABLE `country` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `district`
--

DROP TABLE IF EXISTS `district`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `district` (
  `id` int NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `province` smallint NOT NULL,
  `code` smallint DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`),
  KEY `fk_province_idx` (`province`),
  CONSTRAINT `fk_province` FOREIGN KEY (`province`) REFERENCES `province` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `district`
--

LOCK TABLES `district` WRITE;
/*!40000 ALTER TABLE `district` DISABLE KEYS */;
INSERT INTO `district` VALUES (1,'Quận 1',1,760),(2,'Quận 12',1,761),(3,'Quận Thủ Đức',1,762),(4,'Quận 9',1,763),(5,'Quận Gò Vấp',1,764),(6,'Quận Bình Thạnh',1,765),(7,'Quận Tân Bình',1,766),(8,'Quận Tân Phú',1,767),(9,'Quận Phú Nhuận',1,768),(10,'Quận 2',1,769),(11,'Quận 3',1,770),(12,'Quận 10',1,771),(13,'Quận 11',1,772),(14,'Quận 4',1,773),(15,'Quận 5',1,774),(16,'Quận 6',1,775),(17,'Quận 8',1,776),(18,'Quận Bình Tân',1,777),(19,'Quận 7',1,778),(20,'Huyện Củ Chi',1,783),(21,'Huyện Hóc Môn',1,784),(22,'Huyện Bình Chánh',1,785),(23,'Huyện Nhà Bè',1,786),(24,'Huyện Cần Giờ',1,787);
/*!40000 ALTER TABLE `district` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `driver`
--

DROP TABLE IF EXISTS `driver`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `driver` (
  `id` int NOT NULL,
  `first_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `mid_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) NOT NULL,
  `phone` varchar(45) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `photo` varchar(45) DEFAULT NULL,
  `dob` date NOT NULL,
  `description` varchar(200) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `ward` int NOT NULL,
  `address` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `driver`
--

LOCK TABLES `driver` WRITE;
/*!40000 ALTER TABLE `driver` DISABLE KEYS */;
/*!40000 ALTER TABLE `driver` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `province`
--

DROP TABLE IF EXISTS `province`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `province` (
  `id` smallint NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `country` smallint NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`),
  KEY `fk_country_idx` (`country`),
  CONSTRAINT `fk_country` FOREIGN KEY (`country`) REFERENCES `country` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `province`
--

LOCK TABLES `province` WRITE;
/*!40000 ALTER TABLE `province` DISABLE KEYS */;
INSERT INTO `province` VALUES (1,'TP. Hồ Chí Minh',1);
/*!40000 ALTER TABLE `province` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ward`
--

DROP TABLE IF EXISTS `ward`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ward` (
  `id` int NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `district` int NOT NULL,
  `code` smallint DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_district_idx` (`district`),
  CONSTRAINT `fk_district` FOREIGN KEY (`district`) REFERENCES `district` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ward`
--

LOCK TABLES `ward` WRITE;
/*!40000 ALTER TABLE `ward` DISABLE KEYS */;
INSERT INTO `ward` VALUES (1,'Phường Tân Định',1,26734),(2,'Phường Đa Kao',1,26737),(3,'Phường Bến Nghé',1,26740),(4,'Phường Bến Thành',1,26743),(5,'Phường Nguyễn Thái Bình',1,26746),(6,'Phường Phạm Ngũ Lão',1,26749),(7,'Phường Cầu Ông Lãnh',1,26752),(8,'Phường Cô Giang',1,26755),(9,'Phường Nguyễn Cư Trinh',1,26758),(10,'Phường Cầu Kho',1,26761),(11,'Phường Thạnh Xuân',2,26764),(12,'Phường Thạnh Lộc',2,26767),(13,'Phường Hiệp Thành',2,26770),(14,'Phường Thới An',2,26773),(15,'Phường Tân Chánh Hiệp',2,26776),(16,'Phường An Phú Đông',2,26779),(17,'Phường Tân Thới Hiệp',2,26782),(18,'Phường Trung Mỹ Tây',2,26785),(19,'Phường Tân Hưng Thuận',2,26787),(20,'Phường Đông Hưng Thuận',2,26788),(21,'Phường Tân Thới Nhất',2,26791),(22,'Phường Linh Xuân',3,26794),(23,'Phường Bình Chiểu',3,26797),(24,'Phường Linh Trung',3,26800),(25,'Phường Tam Bình',3,26803),(26,'Phường Tam Phú',3,26806),(27,'Phường Hiệp Bình Phước',3,26809),(28,'Phường Hiệp Bình Chánh',3,26812),(29,'Phường Linh Chiểu',3,26815),(30,'Phường Linh Tây',3,26818),(31,'Phường Linh Đông',3,26821),(32,'Phường Bình Thọ',3,26824),(33,'Phường Trường Thọ',3,26827),(34,'Phường Long Bình',4,26830),(35,'Phường Long Thạnh Mỹ',4,26833),(36,'Phường Tân Phú',4,26836),(37,'Phường Hiệp Phú',4,26839),(38,'Phường Tăng Nhơn Phú A',4,26842),(39,'Phường Tăng Nhơn Phú B',4,26845),(40,'Phường Phước Long B',4,26848),(41,'Phường Phước Long A',4,26851),(42,'Phường Trường Thạnh',4,26854),(43,'Phường Long Phước',4,26857),(44,'Phường Long Trường',4,26860),(45,'Phường Phước Bình',4,26863),(46,'Phường Phú Hữu',4,26866),(47,'Phường 15',5,26869),(48,'Phường 13',5,26872),(49,'Phường 17',5,26875),(50,'Phường 06',5,26876),(51,'Phường 16',5,26878),(52,'Phường 12',5,26881),(53,'Phường 14',5,26882),(54,'Phường 10',5,26884),(55,'Phường 05',5,26887),(56,'Phường 07',5,26890),(57,'Phường 04',5,26893),(58,'Phường 01',5,26896),(59,'Phường 09',5,26897),(60,'Phường 08',5,26898),(61,'Phường 11',5,26899),(62,'Phường 03',5,26902),(63,'Phường 13',6,26905),(64,'Phường 11',6,26908),(65,'Phường 27',6,26911),(66,'Phường 26',6,26914),(67,'Phường 12',6,26917),(68,'Phường 25',6,26920),(69,'Phường 05',6,26923),(70,'Phường 07',6,26926),(71,'Phường 24',6,26929),(72,'Phường 06',6,26932),(73,'Phường 14',6,26935),(74,'Phường 15',6,26938),(75,'Phường 02',6,26941),(76,'Phường 01',6,26944),(77,'Phường 03',6,26947),(78,'Phường 17',6,26950),(79,'Phường 21',6,26953),(80,'Phường 22',6,26956),(81,'Phường 19',6,26959),(82,'Phường 28',6,26962),(83,'Phường 02',7,26965),(84,'Phường 04',7,26968),(85,'Phường 12',7,26971),(86,'Phường 13',7,26974),(87,'Phường 01',7,26977),(88,'Phường 03',7,26980),(89,'Phường 11',7,26983),(90,'Phường 07',7,26986),(91,'Phường 05',7,26989),(92,'Phường 10',7,26992),(93,'Phường 06',7,26995),(94,'Phường 08',7,26998),(95,'Phường 09',7,27001),(96,'Phường 14',7,27004),(97,'Phường 15',7,27007),(98,'Phường Tân Sơn Nhì',8,27010),(99,'Phường Tây Thạnh',8,27013),(100,'Phường Sơn Kỳ',8,27016),(101,'Phường Tân Qúy',8,27019),(102,'Phường Tân Thành',8,27022),(103,'Phường Phú Thọ Hoà',8,27025),(104,'Phường Phú Thạnh',8,27028),(105,'Phường Phú Trung',8,27031),(106,'Phường Hoà Thạnh',8,27034),(107,'Phường Hiệp Tân',8,27037),(108,'Phường Tân Thới Hoà',8,27040),(109,'Phường 04',9,27043),(110,'Phường 05',9,27046),(111,'Phường 09',9,27049),(112,'Phường 07',9,27052),(113,'Phường 03',9,27055),(114,'Phường 01',9,27058),(115,'Phường 02',9,27061),(116,'Phường 08',9,27064),(117,'Phường 15',9,27067),(118,'Phường 10',9,27070),(119,'Phường 11',9,27073),(120,'Phường 17',9,27076),(121,'Phường 14',9,27079),(122,'Phường 12',9,27082),(123,'Phường 13',9,27085),(124,'Phường Thảo Điền',10,27088),(125,'Phường An Phú',10,27091),(126,'Phường Bình An',10,27094),(127,'Phường Bình Trưng Đông',10,27097),(128,'Phường Bình Trưng Tây',10,27100),(129,'Phường Bình Khánh',10,27103),(130,'Phường An Khánh',10,27106),(131,'Phường Cát Lái',10,27109),(132,'Phường Thạnh Mỹ Lợi',10,27112),(133,'Phường An Lợi Đông',10,27115),(134,'Phường Thủ Thiêm',10,27118),(135,'Phường 08',11,27121),(136,'Phường 07',11,27124),(137,'Phường 14',11,27127),(138,'Phường 12',11,27130),(139,'Phường 11',11,27133),(140,'Phường 13',11,27136),(141,'Phường 06',11,27139),(142,'Phường 09',11,27142),(143,'Phường 10',11,27145),(144,'Phường 04',11,27148),(145,'Phường 05',11,27151),(146,'Phường 03',11,27154),(147,'Phường 02',11,27157),(148,'Phường 01',11,27160),(149,'Phường 15',12,27163),(150,'Phường 13',12,27166),(151,'Phường 14',12,27169),(152,'Phường 12',12,27172),(153,'Phường 11',12,27175),(154,'Phường 10',12,27178),(155,'Phường 09',12,27181),(156,'Phường 01',12,27184),(157,'Phường 08',12,27187),(158,'Phường 02',12,27190),(159,'Phường 04',12,27193),(160,'Phường 07',12,27196),(161,'Phường 05',12,27199),(162,'Phường 06',12,27202),(163,'Phường 03',12,27205),(164,'Phường 15',13,27208),(165,'Phường 05',13,27211),(166,'Phường 14',13,27214),(167,'Phường 11',13,27217),(168,'Phường 03',13,27220),(169,'Phường 10',13,27223),(170,'Phường 13',13,27226),(171,'Phường 08',13,27229),(172,'Phường 09',13,27232),(173,'Phường 12',13,27235),(174,'Phường 07',13,27238),(175,'Phường 06',13,27241),(176,'Phường 04',13,27244),(177,'Phường 01',13,27247),(178,'Phường 02',13,27250),(179,'Phường 16',13,27253),(180,'Phường 12',14,27256),(181,'Phường 13',14,27259),(182,'Phường 09',14,27262),(183,'Phường 06',14,27265),(184,'Phường 08',14,27268),(185,'Phường 10',14,27271),(186,'Phường 05',14,27274),(187,'Phường 18',14,27277),(188,'Phường 14',14,27280),(189,'Phường 04',14,27283),(190,'Phường 03',14,27286),(191,'Phường 16',14,27289),(192,'Phường 02',14,27292),(193,'Phường 15',14,27295),(194,'Phường 01',14,27298),(195,'Phường 04',15,27301),(196,'Phường 09',15,27304),(197,'Phường 03',15,27307),(198,'Phường 12',15,27310),(199,'Phường 02',15,27313),(200,'Phường 08',15,27316),(201,'Phường 15',15,27319),(202,'Phường 07',15,27322),(203,'Phường 01',15,27325),(204,'Phường 11',15,27328),(205,'Phường 14',15,27331),(206,'Phường 05',15,27334),(207,'Phường 06',15,27337),(208,'Phường 10',15,27340),(209,'Phường 13',15,27343),(210,'Phường 14',16,27346),(211,'Phường 13',16,27349),(212,'Phường 09',16,27352),(213,'Phường 06',16,27355),(214,'Phường 12',16,27358),(215,'Phường 05',16,27361),(216,'Phường 11',16,27364),(217,'Phường 02',16,27367),(218,'Phường 01',16,27370),(219,'Phường 04',16,27373),(220,'Phường 08',16,27376),(221,'Phường 03',16,27379),(222,'Phường 07',16,27382),(223,'Phường 10',16,27385),(224,'Phường 08',17,27388),(225,'Phường 02',17,27391),(226,'Phường 01',17,27394),(227,'Phường 03',17,27397),(228,'Phường 11',17,27400),(229,'Phường 09',17,27403),(230,'Phường 10',17,27406),(231,'Phường 04',17,27409),(232,'Phường 13',17,27412),(233,'Phường 12',17,27415),(234,'Phường 05',17,27418),(235,'Phường 14',17,27421),(236,'Phường 06',17,27424),(237,'Phường 15',17,27427),(238,'Phường 16',17,27430),(239,'Phường 07',17,27433),(240,'Phường Bình Hưng Hòa',18,27436),(241,'Phường Bình Hưng Hoà A',18,27439),(242,'Phường Bình Hưng Hoà B',18,27442),(243,'Phường Bình Trị Đông',18,27445),(244,'Phường Bình Trị Đông A',18,27448),(245,'Phường Bình Trị Đông B',18,27451),(246,'Phường Tân Tạo',18,27454),(247,'Phường Tân Tạo A',18,27457),(248,'Phường An Lạc',18,27460),(249,'Phường An Lạc A',18,27463),(250,'Phường Tân Thuận Đông',19,27466),(251,'Phường Tân Thuận Tây',19,27469),(252,'Phường Tân Kiểng',19,27472),(253,'Phường Tân Hưng',19,27475),(254,'Phường Bình Thuận',19,27478),(255,'Phường Tân Quy',19,27481),(256,'Phường Phú Thuận',19,27484),(257,'Phường Tân Phú',19,27487),(258,'Phường Tân Phong',19,27490),(259,'Phường Phú Mỹ',19,27493),(260,'Thị trấn Củ Chi',20,27496),(261,'Xã Phú Mỹ Hưng',20,27499),(262,'Xã An Phú',20,27502),(263,'Xã Trung Lập Thượng',20,27505),(264,'Xã An Nhơn Tây',20,27508),(265,'Xã Nhuận Đức',20,27511),(266,'Xã Phạm Văn Cội',20,27514),(267,'Xã Phú Hòa Đông',20,27517),(268,'Xã Trung Lập Hạ',20,27520),(269,'Xã Trung An',20,27523),(270,'Xã Phước Thạnh',20,27526),(271,'Xã Phước Hiệp',20,27529),(272,'Xã Tân An Hội',20,27532),(273,'Xã Phước Vĩnh An',20,27535),(274,'Xã Thái Mỹ',20,27538),(275,'Xã Tân Thạnh Tây',20,27541),(276,'Xã Hòa Phú',20,27544),(277,'Xã Tân Thạnh Đông',20,27547),(278,'Xã Bình Mỹ',20,27550),(279,'Xã Tân Phú Trung',20,27553),(280,'Xã Tân Thông Hội',20,27556),(281,'Thị trấn Hóc Môn',21,27559),(282,'Xã Tân Hiệp',21,27562),(283,'Xã Nhị Bình',21,27565),(284,'Xã Đông Thạnh',21,27568),(285,'Xã Tân Thới Nhì',21,27571),(286,'Xã Thới Tam Thôn',21,27574),(287,'Xã Xuân Thới Sơn',21,27577),(288,'Xã Tân Xuân',21,27580),(289,'Xã Xuân Thới Đông',21,27583),(290,'Xã Trung Chánh',21,27586),(291,'Xã Xuân Thới Thượng',21,27589),(292,'Xã Bà Điểm',21,27592),(293,'Thị trấn Tân Túc',22,27595),(294,'Xã Phạm Văn Hai',22,27598),(295,'Xã Vĩnh Lộc A',22,27601),(296,'Xã Vĩnh Lộc B',22,27604),(297,'Xã Bình Lợi',22,27607),(298,'Xã Lê Minh Xuân',22,27610),(299,'Xã Tân Nhựt',22,27613),(300,'Xã Tân Kiên',22,27616),(301,'Xã Bình Hưng',22,27619),(302,'Xã Phong Phú',22,27622),(303,'Xã An Phú Tây',22,27625),(304,'Xã Hưng Long',22,27628),(305,'Xã Đa Phước',22,27631),(306,'Xã Tân Quý Tây',22,27634),(307,'Xã Bình Chánh',22,27637),(308,'Xã Quy Đức',22,27640),(309,'Thị trấn Nhà Bè',23,27643),(310,'Xã Phước Kiển',23,27646),(311,'Xã Phước Lộc',23,27649),(312,'Xã Nhơn Đức',23,27652),(313,'Xã Phú Xuân',23,27655),(314,'Xã Long Thới',23,27658),(315,'Xã Hiệp Phước',23,27661),(316,'Thị trấn Cần Thạnh',24,27664),(317,'Xã Bình Khánh',24,27667),(318,'Xã Tam Thôn Hiệp',24,27670),(319,'Xã An Thới Đông',24,27673),(320,'Xã Thạnh An',24,27676),(321,'Xã Long Hòa',24,27679),(322,'Xã Lý Nhơn',24,27682);
/*!40000 ALTER TABLE `ward` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-09-09  6:38:25
