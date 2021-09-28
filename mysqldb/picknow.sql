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
-- Table structure for table `brand`
--

DROP TABLE IF EXISTS `brand`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brand` (
  `id` int NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `parent` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uniq_brand_name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brand`
--

LOCK TABLES `brand` WRITE;
/*!40000 ALTER TABLE `brand` DISABLE KEYS */;
INSERT INTO `brand` VALUES (1,'CoopMart',NULL),(2,'Coop Select',1),(3,'Orion',NULL),(4,'ChocoPie',3),(5,'Richeese',NULL),(6,'Nabati',5),(7,'Danisa',NULL),(8,'Gouté',3),(9,'Tường An',NULL),(10,'Nam Ngư',NULL),(11,'Liên Thành',NULL),(12,'Ba Huân',NULL),(13,'Unilever',NULL),(14,'Omo',13),(15,'P & G',NULL),(16,'Ariel',15),(17,'Lifebuoy',13);
/*!40000 ALTER TABLE `brand` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `color`
--

DROP TABLE IF EXISTS `color`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `color` (
  `id` smallint NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uniq_color_name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `color`
--

LOCK TABLES `color` WRITE;
/*!40000 ALTER TABLE `color` DISABLE KEYS */;
/*!40000 ALTER TABLE `color` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company` (
  `id` int NOT NULL,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `phone` varchar(30) DEFAULT NULL,
  `phone2` varchar(30) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `tax_code` varchar(20) DEFAULT NULL,
  `logo` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`),
  KEY `fk_company_logo_idx` (`logo`),
  CONSTRAINT `fk_company_logo` FOREIGN KEY (`logo`) REFERENCES `image_info` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES (1,'CoopMart',NULL,NULL,NULL,NULL,8),(2,'FamilyMart',NULL,NULL,NULL,NULL,11),(3,'CircleK',NULL,NULL,NULL,NULL,9),(4,'MiniStop',NULL,NULL,NULL,NULL,10),(5,'CoopSmile',NULL,NULL,NULL,NULL,12);
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `company_logo`
--

DROP TABLE IF EXISTS `company_logo`;
/*!50001 DROP VIEW IF EXISTS `company_logo`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `company_logo` AS SELECT 
 1 AS `company_id`,
 1 AS `logo`,
 1 AS `file_name`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `country`
--

DROP TABLE IF EXISTS `country`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `country` (
  `id` smallint NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
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
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
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
-- Table structure for table `image_info`
--

DROP TABLE IF EXISTS `image_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `image_info` (
  `id` int NOT NULL,
  `file_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `image_info`
--

LOCK TABLES `image_info` WRITE;
/*!40000 ALTER TABLE `image_info` DISABLE KEYS */;
INSERT INTO `image_info` VALUES (1,'46cc79c5-1d73-11ec-b980-00ffc71f7bf7.png'),(2,'82858338-1d73-11ec-b980-00ffc71f7bf7.png'),(3,'89ba6bbc-1d75-11ec-b980-00ffc71f7bf7.png'),(4,'ed9f22a7-1d83-11ec-b980-00ffc71f7bf7.png'),(5,'68e7b05c-1d84-11ec-b980-00ffc71f7bf7'),(6,'82d56927-1d84-11ec-b980-00ffc71f7bf7.png'),(7,'89b9bcbe-1d85-11ec-b980-00ffc71f7bf7.png'),(8,'70feb4d8-1d86-11ec-b980-00ffc71f7bf7.png'),(9,'7969b336-1d86-11ec-b980-00ffc71f7bf7.png'),(10,'7c944386-1d86-11ec-b980-00ffc71f7bf7.jpeg'),(11,'efce6933-1d86-11ec-b980-00ffc71f7bf7.png'),(12,'8e1a8c5c-1d87-11ec-b980-00ffc71f7bf7.png');
/*!40000 ALTER TABLE `image_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `origin`
--

DROP TABLE IF EXISTS `origin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `origin` (
  `id` smallint NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uniq_origin_name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `origin`
--

LOCK TABLES `origin` WRITE;
/*!40000 ALTER TABLE `origin` DISABLE KEYS */;
INSERT INTO `origin` VALUES (1,'Việt Nam');
/*!40000 ALTER TABLE `origin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `id` bigint NOT NULL,
  `name` varchar(100) NOT NULL,
  `unit` int NOT NULL,
  `code` varchar(45) DEFAULT NULL,
  `brand` int DEFAULT NULL,
  `origin` smallint DEFAULT '1',
  `size` int DEFAULT NULL,
  `color` smallint DEFAULT NULL,
  `description` text CHARACTER SET utf8 COLLATE utf8_bin,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uniq_product_name` (`name`),
  KEY `idx_product_code` (`code`),
  KEY `fk_product_unit_idx` (`unit`),
  KEY `fk_product_brand_idx` (`brand`),
  KEY `fk_product_size_idx` (`size`),
  KEY `fk_product_color_idx` (`color`),
  KEY `fk_product_origin_idx` (`origin`),
  CONSTRAINT `fk_product_brand` FOREIGN KEY (`brand`) REFERENCES `brand` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_product_color` FOREIGN KEY (`color`) REFERENCES `color` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_product_origin` FOREIGN KEY (`origin`) REFERENCES `origin` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_product_size` FOREIGN KEY (`size`) REFERENCES `size` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_product_unit` FOREIGN KEY (`unit`) REFERENCES `unit` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,'Bột yến mạch nếp cẩm Coop Select 450g',11,NULL,2,1,3,NULL,NULL),(2,'Yến mạch nguyên hạt Coop Select 400g',11,NULL,2,1,4,NULL,NULL),(3,'Bánh Chocopie Orion hộp 396g',14,NULL,4,1,5,NULL,NULL),(4,'Bánh xốp Nabati Richeese hộp 20×7,5g',14,NULL,6,1,6,NULL,NULL),(5,'Bánh Chocopie Orion Cacao hộp 360g',14,NULL,4,1,7,NULL,NULL),(6,'Bánh Quy Bơ Danisa hộp thiếc 200g',14,NULL,7,1,8,NULL,NULL),(7,'Bánh mè giòn Goute Orion hộp 288g',14,NULL,8,1,9,NULL,NULL),(8,'Mực rim me Coop Select 100g',19,NULL,2,1,10,NULL,NULL),(9,'Dầu ăn Tường An Cooking Nutri Plus chai 1L',12,NULL,9,1,2,NULL,NULL),(10,'Dầu ăn Tường An chai 1L',12,NULL,9,1,2,NULL,NULL),(11,'Nước mắm Nam Ngư 3in1 chai 750ml',12,NULL,10,1,11,NULL,NULL),(12,'Nước mắm Nam Ngư 3in1 chai 900ml',12,NULL,10,1,12,NULL,NULL),(13,'Nước mắm cao cấp Liên Thành nhãn bạc chai thủy tinh 40 độ đạm 600ml',12,NULL,11,1,13,NULL,NULL),(14,'Nước mắm Liên Thành nhãn đồng 25 độ đạm chai thủy tinh 600ml',12,NULL,11,1,13,NULL,NULL),(15,'Trứng Gà Ba Huân vỉ 10 trứng',18,NULL,12,1,14,NULL,NULL),(16,'Trứng vịt Ba Huân vỉ 10 trứng',18,NULL,12,1,14,NULL,NULL),(17,'Cá rô làm sạch',2,NULL,NULL,1,NULL,NULL,NULL),(18,'Cá lóc cắt lát gói 300g',11,NULL,NULL,1,15,NULL,NULL),(19,'Nước giặt OMO Matic Comfort Tinh dầu thơm túi 3.7kg',13,NULL,14,1,16,NULL,NULL),(20,'Nước giặt Ariel Matic cửa trước tươi mát túi 1.85kg',13,NULL,16,1,17,NULL,NULL),(21,'Nước rửa tay Lifebuoy bảo vệ vượt trội diệt khuẩn chai 500g',12,NULL,17,1,18,NULL,NULL);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_attribute`
--

DROP TABLE IF EXISTS `product_attribute`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_attribute` (
  `id` int NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uniq_product_attribute_name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_attribute`
--

LOCK TABLES `product_attribute` WRITE;
/*!40000 ALTER TABLE `product_attribute` DISABLE KEYS */;
INSERT INTO `product_attribute` VALUES (1,'Brand'),(4,'Color'),(2,'Origin'),(5,'Packing Type'),(3,'Size');
/*!40000 ALTER TABLE `product_attribute` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `province`
--

DROP TABLE IF EXISTS `province`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `province` (
  `id` smallint NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
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
INSERT INTO `province` VALUES (1,'TP. HCM',1);
/*!40000 ALTER TABLE `province` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `size`
--

DROP TABLE IF EXISTS `size`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `size` (
  `id` int NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `weight` double DEFAULT NULL,
  `volumn` double DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uniq_size_name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `size`
--

LOCK TABLES `size` WRITE;
/*!40000 ALTER TABLE `size` DISABLE KEYS */;
INSERT INTO `size` VALUES (1,'1kg',1,NULL),(2,'1L',NULL,1),(3,'450g',0.45,NULL),(4,'400g',0.4,NULL),(5,'396g',0.396,NULL),(6,'20×7.5g',0.15,NULL),(7,'360g',0.36,NULL),(8,'200g',0.2,NULL),(9,'288g',0.288,NULL),(10,'100g',0.1,NULL),(11,'750ml',NULL,0.75),(12,'900ml',NULL,0.9),(13,'600ml',NULL,0.6),(14,'10 trứng',NULL,NULL),(15,'300g',0.3,NULL),(16,'3.7kg',3.7,NULL),(17,'1.85kg',1.85,NULL),(18,'500g',0.5,NULL);
/*!40000 ALTER TABLE `size` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `store`
--

DROP TABLE IF EXISTS `store`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `store` (
  `id` int NOT NULL,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `province` smallint NOT NULL,
  `district` int NOT NULL,
  `ward` int NOT NULL,
  `address` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `store_group` int NOT NULL,
  `contact_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_phone` varchar(20) DEFAULT NULL,
  `contact_phone2` varchar(20) DEFAULT NULL,
  `website` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_ward_idx` (`ward`),
  KEY `fk_province_idx` (`province`),
  KEY `fk_district_idx` (`district`),
  KEY `fk_store_store_group_idx` (`store_group`),
  CONSTRAINT `fk_store_district` FOREIGN KEY (`district`) REFERENCES `district` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_store_province` FOREIGN KEY (`province`) REFERENCES `province` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_store_store_group` FOREIGN KEY (`store_group`) REFERENCES `store_group` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_store_ward` FOREIGN KEY (`ward`) REFERENCES `ward` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `store`
--

LOCK TABLES `store` WRITE;
/*!40000 ALTER TABLE `store` DISABLE KEYS */;
INSERT INTO `store` VALUES (1,'CoopMart NDC',1,3,27,'NDC',1,NULL,NULL,NULL,NULL),(2,'CoopSmile 01 NDC',1,1,1,'ABC',2,NULL,NULL,NULL,NULL),(3,'FamilyMart Nguyễn Bỉnh Khiêm',1,1,2,'3 Nguyễn Bỉnh Khiêm',3,NULL,NULL,NULL,NULL),(4,'FamilyMart 20 Nguyễn Đình Chiểu',1,1,2,'20 Nguyễn Đình Chiểu',3,NULL,NULL,NULL,NULL),(5,'CoopMart Hiệp Bình Chánh',1,3,28,'1248/4 Quốc Lộ 23',1,NULL,NULL,NULL,NULL),(6,'FamilyMart 22 Xô Viết Nghệ Tĩnh',1,6,75,'22 Xô Viết Nghệ Tĩnh',3,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `store` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `store_group`
--

DROP TABLE IF EXISTS `store_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `store_group` (
  `id` int NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `company` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uniq_store_group_name` (`name`),
  KEY `fk_store_group_company_idx` (`company`),
  CONSTRAINT `fk_store_group_company` FOREIGN KEY (`company`) REFERENCES `company` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `store_group`
--

LOCK TABLES `store_group` WRITE;
/*!40000 ALTER TABLE `store_group` DISABLE KEYS */;
INSERT INTO `store_group` VALUES (1,'CoopMart',1),(2,'CoopSmile',1),(3,'FamiliyMart',2),(4,'CircleK',3);
/*!40000 ALTER TABLE `store_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `store_product`
--

DROP TABLE IF EXISTS `store_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `store_product` (
  `store_product_group` int NOT NULL,
  `product` bigint NOT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`store_product_group`,`product`),
  KEY `fk_store_product_product_idx` (`product`),
  CONSTRAINT `fk_store_product_product` FOREIGN KEY (`product`) REFERENCES `product` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_store_product_store_product_group` FOREIGN KEY (`store_product_group`) REFERENCES `store_product_group` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `store_product`
--

LOCK TABLES `store_product` WRITE;
/*!40000 ALTER TABLE `store_product` DISABLE KEYS */;
INSERT INTO `store_product` VALUES (41,15,28000),(42,3,50500),(42,4,24000),(42,5,50500),(42,6,55300),(42,7,52400),(42,8,40500),(43,9,46000),(43,10,38500),(44,11,44700),(44,12,53000),(44,13,71200),(44,14,62300),(45,16,31000),(46,17,75900),(46,18,52000),(47,19,199000),(47,20,112000),(48,21,69000);
/*!40000 ALTER TABLE `store_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `store_product_group`
--

DROP TABLE IF EXISTS `store_product_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `store_product_group` (
  `id` int NOT NULL,
  `store_group` int NOT NULL,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `parent` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `store_product_group`
--

LOCK TABLES `store_product_group` WRITE;
/*!40000 ALTER TABLE `store_product_group` DISABLE KEYS */;
INSERT INTO `store_product_group` VALUES (1,1,'Công nghệ',NULL),(2,1,'Đồ dùng',NULL),(3,1,'Hóa mỹ phẩm',NULL),(4,1,'May mặc',NULL),(5,1,'Tươi sống',NULL),(6,1,'Bánh kẹo',1),(7,1,'Dầu ăn - nước chấm',1),(8,1,'Đông lạnh',1),(9,1,'Gia vị - hạt nêm',1),(10,1,'Mì - bún - cháo - nui',1),(11,1,'Nước uống - rượu bia',1),(12,1,'Sản phẩm đóng gói',1),(13,1,'Sữa - bột',1),(14,1,'Dụng cụ',2),(15,1,'Điện',2),(16,1,'Gia đình',2),(17,1,'Nhà bếp',2),(18,1,'Nhựa',2),(19,1,'Bột giặt - nước xả',3),(20,1,'Chất tẩy rửa',3),(21,1,'Dầu gội -  sữa tắm',3),(22,1,'Đồ em bé',3),(23,1,'Giấy - khăn',3),(24,1,'Mỹ phẩm',3),(25,1,'Vệ sinh cá nhân',3),(26,1,'Đồng phục học sinh',4),(27,1,'Khẩu trang',4),(28,1,'Thời trang nam',4),(29,1,'Thời trang nữ',4),(30,1,'Tổng hợp',4),(31,1,'Bánh mì',5),(32,1,'Gia cầm',5),(33,1,'Hải sản',5),(34,1,'Hoa tươi',5),(35,1,'Rau - củ - quả',5),(36,1,'Thịt - Cá',5),(37,1,'Thực phẩm đóng gói',5),(38,1,'Thực phẩm nấu chín',5),(39,1,'Thực phẩm sơ chế',5),(40,1,'Trái cây',5),(41,1,'Trứng vịt - gà - cút',5),(42,1,'Bánh - snack',6),(43,1,'Dầu ăn - Dầu hào',7),(44,1,'Nước mắm',7),(45,1,'Trứng vịt',41),(46,1,'Cá',36),(47,1,'Nước Giặt',19),(48,1,'Nước - Gel Rửa Tay',25),(49,1,'Dung cu 1',14),(51,2,'Đồ dùng',0),(52,2,'Công nghệ',0),(53,2,'May mặc',0),(54,2,'Đồ điện',51),(55,2,'Thực phẩm',0),(56,2,'Bánh kẹo',55),(57,2,'Áo quần',53),(58,2,'Giày dép',53);
/*!40000 ALTER TABLE `store_product_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `string_object`
--

DROP TABLE IF EXISTS `string_object`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `string_object` (
  `id` varchar(1000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `string_object`
--

LOCK TABLES `string_object` WRITE;
/*!40000 ALTER TABLE `string_object` DISABLE KEYS */;
/*!40000 ALTER TABLE `string_object` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unit`
--

DROP TABLE IF EXISTS `unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unit` (
  `id` int NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `base_unit` tinyint DEFAULT '1',
  `exchange` double DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uniq_unit_name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit`
--

LOCK TABLES `unit` WRITE;
/*!40000 ALTER TABLE `unit` DISABLE KEYS */;
INSERT INTO `unit` VALUES (1,'each',1,1),(2,'kg',2,1),(3,'L',3,1),(4,'m',4,1),(10,'cái',1,1),(11,'gói',1,1),(12,'chai',1,1),(13,'túi',1,1),(14,'hộp',1,1),(15,'cuộn',1,1),(16,'cây',1,1),(17,'bịch',1,1),(18,'vỉ',1,1),(19,'hũ',1,1),(20,'lọ',1,1),(21,'lốc',1,1),(22,'bộ',1,1),(23,'cuốn',1,1);
/*!40000 ALTER TABLE `unit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ward`
--

DROP TABLE IF EXISTS `ward`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ward` (
  `id` int NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `district` int NOT NULL,
  `code` int DEFAULT NULL,
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
INSERT INTO `ward` VALUES (1,'Phường Tân Định',1,26734),(2,'Phường Đa Kao',1,26737),(3,'Phường Bến Nghé',1,26740),(4,'Phường Bến Thành',1,26743),(5,'Phường Nguyễn Thái Bình',1,26746),(6,'Phường Phạm Ngũ Lão',1,26749),(7,'Phường Cầu Ông Lãnh',1,26752),(8,'Phường Cô Giang',1,26755),(9,'Phường Nguyễn Cư Trinh',1,26758),(10,'Phường Cầu Kho',1,26761),(11,'Phường Thạnh Xuân',2,26764),(12,'Phường Thạnh Lộc',2,26767),(13,'Phường Hiệp Thành',2,26770),(14,'Phường Thới An',2,26773),(15,'Phường Tân Chánh Hiệp',2,26776),(16,'Phường An Phú Đông',2,26779),(17,'Phường Tân Thới Hiệp',2,26782),(18,'Phường Trung Mỹ Tây',2,26785),(19,'Phường Tân Hưng Thuận',2,26787),(20,'Phường Đông Hưng Thuận',2,26788),(21,'Phường Tân Thới Nhất',2,26791),(22,'Phường Linh Xuân',3,26794),(23,'Phường Bình Chiểu',3,26797),(24,'Phường Linh Trung',3,26800),(25,'Phường Tam Bình',3,26803),(26,'Phường Tam Phú',3,26806),(27,'Phường Hiệp Bình Phước',3,26809),(28,'Phường Hiệp Bình Chánh',3,26812),(29,'Phường Linh Chiểu',3,26815),(30,'Phường Linh Tây',3,26818),(31,'Phường Linh Đông',3,26821),(32,'Phường Bình Thọ',3,26824),(33,'Phường Trường Thọ',3,26827),(34,'Phường Long Bình',4,26830),(35,'Phường Long Thạnh Mỹ',4,26833),(36,'Phường Tân Phú',4,26836),(37,'Phường Hiệp Phú',4,26839),(38,'Phường Tăng Nhơn Phú A',4,26842),(39,'Phường Tăng Nhơn Phú B',4,26845),(40,'Phường Phước Long B',4,26848),(41,'Phường Phước Long A',4,26851),(42,'Phường Trường Thạnh',4,26854),(43,'Phường Long Phước',4,26857),(44,'Phường Long Trường',4,26860),(45,'Phường Phước Bình',4,26863),(46,'Phường Phú Hữu',4,26866),(47,'Phường 15',5,26869),(48,'Phường 13',5,26872),(49,'Phường 17',5,26875),(50,'Phường 06',5,26876),(51,'Phường 16',5,26878),(52,'Phường 12',5,26881),(53,'Phường 14',5,26882),(54,'Phường 10',5,26884),(55,'Phường 05',5,26887),(56,'Phường 07',5,26890),(57,'Phường 04',5,26893),(58,'Phường 01',5,26896),(59,'Phường 09',5,26897),(60,'Phường 08',5,26898),(61,'Phường 11',5,26899),(62,'Phường 03',5,26902),(63,'Phường 13',6,26905),(64,'Phường 11',6,26908),(65,'Phường 27',6,26911),(66,'Phường 26',6,26914),(67,'Phường 12',6,26917),(68,'Phường 25',6,26920),(69,'Phường 05',6,26923),(70,'Phường 07',6,26926),(71,'Phường 24',6,26929),(72,'Phường 06',6,26932),(73,'Phường 14',6,26935),(74,'Phường 15',6,26938),(75,'Phường 02',6,26941),(76,'Phường 01',6,26944),(77,'Phường 03',6,26947),(78,'Phường 17',6,26950),(79,'Phường 21',6,26953),(80,'Phường 22',6,26956),(81,'Phường 19',6,26959),(82,'Phường 28',6,26962),(83,'Phường 02',7,26965),(84,'Phường 04',7,26968),(85,'Phường 12',7,26971),(86,'Phường 13',7,26974),(87,'Phường 01',7,26977),(88,'Phường 03',7,26980),(89,'Phường 11',7,26983),(90,'Phường 07',7,26986),(91,'Phường 05',7,26989),(92,'Phường 10',7,26992),(93,'Phường 06',7,26995),(94,'Phường 08',7,26998),(95,'Phường 09',7,27001),(96,'Phường 14',7,27004),(97,'Phường 15',7,27007),(98,'Phường Tân Sơn Nhì',8,27010),(99,'Phường Tây Thạnh',8,27013),(100,'Phường Sơn Kỳ',8,27016),(101,'Phường Tân Qúy',8,27019),(102,'Phường Tân Thành',8,27022),(103,'Phường Phú Thọ Hoà',8,27025),(104,'Phường Phú Thạnh',8,27028),(105,'Phường Phú Trung',8,27031),(106,'Phường Hoà Thạnh',8,27034),(107,'Phường Hiệp Tân',8,27037),(108,'Phường Tân Thới Hoà',8,27040),(109,'Phường 04',9,27043),(110,'Phường 05',9,27046),(111,'Phường 09',9,27049),(112,'Phường 07',9,27052),(113,'Phường 03',9,27055),(114,'Phường 01',9,27058),(115,'Phường 02',9,27061),(116,'Phường 08',9,27064),(117,'Phường 15',9,27067),(118,'Phường 10',9,27070),(119,'Phường 11',9,27073),(120,'Phường 17',9,27076),(121,'Phường 14',9,27079),(122,'Phường 12',9,27082),(123,'Phường 13',9,27085),(124,'Phường Thảo Điền',10,27088),(125,'Phường An Phú',10,27091),(126,'Phường Bình An',10,27094),(127,'Phường Bình Trưng Đông',10,27097),(128,'Phường Bình Trưng Tây',10,27100),(129,'Phường Bình Khánh',10,27103),(130,'Phường An Khánh',10,27106),(131,'Phường Cát Lái',10,27109),(132,'Phường Thạnh Mỹ Lợi',10,27112),(133,'Phường An Lợi Đông',10,27115),(134,'Phường Thủ Thiêm',10,27118),(135,'Phường 08',11,27121),(136,'Phường 07',11,27124),(137,'Phường 14',11,27127),(138,'Phường 12',11,27130),(139,'Phường 11',11,27133),(140,'Phường 13',11,27136),(141,'Phường 06',11,27139),(142,'Phường 09',11,27142),(143,'Phường 10',11,27145),(144,'Phường 04',11,27148),(145,'Phường 05',11,27151),(146,'Phường 03',11,27154),(147,'Phường 02',11,27157),(148,'Phường 01',11,27160),(149,'Phường 15',12,27163),(150,'Phường 13',12,27166),(151,'Phường 14',12,27169),(152,'Phường 12',12,27172),(153,'Phường 11',12,27175),(154,'Phường 10',12,27178),(155,'Phường 09',12,27181),(156,'Phường 01',12,27184),(157,'Phường 08',12,27187),(158,'Phường 02',12,27190),(159,'Phường 04',12,27193),(160,'Phường 07',12,27196),(161,'Phường 05',12,27199),(162,'Phường 06',12,27202),(163,'Phường 03',12,27205),(164,'Phường 15',13,27208),(165,'Phường 05',13,27211),(166,'Phường 14',13,27214),(167,'Phường 11',13,27217),(168,'Phường 03',13,27220),(169,'Phường 10',13,27223),(170,'Phường 13',13,27226),(171,'Phường 08',13,27229),(172,'Phường 09',13,27232),(173,'Phường 12',13,27235),(174,'Phường 07',13,27238),(175,'Phường 06',13,27241),(176,'Phường 04',13,27244),(177,'Phường 01',13,27247),(178,'Phường 02',13,27250),(179,'Phường 16',13,27253),(180,'Phường 12',14,27256),(181,'Phường 13',14,27259),(182,'Phường 09',14,27262),(183,'Phường 06',14,27265),(184,'Phường 08',14,27268),(185,'Phường 10',14,27271),(186,'Phường 05',14,27274),(187,'Phường 18',14,27277),(188,'Phường 14',14,27280),(189,'Phường 04',14,27283),(190,'Phường 03',14,27286),(191,'Phường 16',14,27289),(192,'Phường 02',14,27292),(193,'Phường 15',14,27295),(194,'Phường 01',14,27298),(195,'Phường 04',15,27301),(196,'Phường 09',15,27304),(197,'Phường 03',15,27307),(198,'Phường 12',15,27310),(199,'Phường 02',15,27313),(200,'Phường 08',15,27316),(201,'Phường 15',15,27319),(202,'Phường 07',15,27322),(203,'Phường 01',15,27325),(204,'Phường 11',15,27328),(205,'Phường 14',15,27331),(206,'Phường 05',15,27334),(207,'Phường 06',15,27337),(208,'Phường 10',15,27340),(209,'Phường 13',15,27343),(210,'Phường 14',16,27346),(211,'Phường 13',16,27349),(212,'Phường 09',16,27352),(213,'Phường 06',16,27355),(214,'Phường 12',16,27358),(215,'Phường 05',16,27361),(216,'Phường 11',16,27364),(217,'Phường 02',16,27367),(218,'Phường 01',16,27370),(219,'Phường 04',16,27373),(220,'Phường 08',16,27376),(221,'Phường 03',16,27379),(222,'Phường 07',16,27382),(223,'Phường 10',16,27385),(224,'Phường 08',17,27388),(225,'Phường 02',17,27391),(226,'Phường 01',17,27394),(227,'Phường 03',17,27397),(228,'Phường 11',17,27400),(229,'Phường 09',17,27403),(230,'Phường 10',17,27406),(231,'Phường 04',17,27409),(232,'Phường 13',17,27412),(233,'Phường 12',17,27415),(234,'Phường 05',17,27418),(235,'Phường 14',17,27421),(236,'Phường 06',17,27424),(237,'Phường 15',17,27427),(238,'Phường 16',17,27430),(239,'Phường 07',17,27433),(240,'Phường Bình Hưng Hòa',18,27436),(241,'Phường Bình Hưng Hoà A',18,27439),(242,'Phường Bình Hưng Hoà B',18,27442),(243,'Phường Bình Trị Đông',18,27445),(244,'Phường Bình Trị Đông A',18,27448),(245,'Phường Bình Trị Đông B',18,27451),(246,'Phường Tân Tạo',18,27454),(247,'Phường Tân Tạo A',18,27457),(248,'Phường An Lạc',18,27460),(249,'Phường An Lạc A',18,27463),(250,'Phường Tân Thuận Đông',19,27466),(251,'Phường Tân Thuận Tây',19,27469),(252,'Phường Tân Kiểng',19,27472),(253,'Phường Tân Hưng',19,27475),(254,'Phường Bình Thuận',19,27478),(255,'Phường Tân Quy',19,27481),(256,'Phường Phú Thuận',19,27484),(257,'Phường Tân Phú',19,27487),(258,'Phường Tân Phong',19,27490),(259,'Phường Phú Mỹ',19,27493),(260,'Thị trấn Củ Chi',20,27496),(261,'Xã Phú Mỹ Hưng',20,27499),(262,'Xã An Phú',20,27502),(263,'Xã Trung Lập Thượng',20,27505),(264,'Xã An Nhơn Tây',20,27508),(265,'Xã Nhuận Đức',20,27511),(266,'Xã Phạm Văn Cội',20,27514),(267,'Xã Phú Hòa Đông',20,27517),(268,'Xã Trung Lập Hạ',20,27520),(269,'Xã Trung An',20,27523),(270,'Xã Phước Thạnh',20,27526),(271,'Xã Phước Hiệp',20,27529),(272,'Xã Tân An Hội',20,27532),(273,'Xã Phước Vĩnh An',20,27535),(274,'Xã Thái Mỹ',20,27538),(275,'Xã Tân Thạnh Tây',20,27541),(276,'Xã Hòa Phú',20,27544),(277,'Xã Tân Thạnh Đông',20,27547),(278,'Xã Bình Mỹ',20,27550),(279,'Xã Tân Phú Trung',20,27553),(280,'Xã Tân Thông Hội',20,27556),(281,'Thị trấn Hóc Môn',21,27559),(282,'Xã Tân Hiệp',21,27562),(283,'Xã Nhị Bình',21,27565),(284,'Xã Đông Thạnh',21,27568),(285,'Xã Tân Thới Nhì',21,27571),(286,'Xã Thới Tam Thôn',21,27574),(287,'Xã Xuân Thới Sơn',21,27577),(288,'Xã Tân Xuân',21,27580),(289,'Xã Xuân Thới Đông',21,27583),(290,'Xã Trung Chánh',21,27586),(291,'Xã Xuân Thới Thượng',21,27589),(292,'Xã Bà Điểm',21,27592),(293,'Thị trấn Tân Túc',22,27595),(294,'Xã Phạm Văn Hai',22,27598),(295,'Xã Vĩnh Lộc A',22,27601),(296,'Xã Vĩnh Lộc B',22,27604),(297,'Xã Bình Lợi',22,27607),(298,'Xã Lê Minh Xuân',22,27610),(299,'Xã Tân Nhựt',22,27613),(300,'Xã Tân Kiên',22,27616),(301,'Xã Bình Hưng',22,27619),(302,'Xã Phong Phú',22,27622),(303,'Xã An Phú Tây',22,27625),(304,'Xã Hưng Long',22,27628),(305,'Xã Đa Phước',22,27631),(306,'Xã Tân Quý Tây',22,27634),(307,'Xã Bình Chánh',22,27637),(308,'Xã Quy Đức',22,27640),(309,'Thị trấn Nhà Bè',23,27643),(310,'Xã Phước Kiển',23,27646),(311,'Xã Phước Lộc',23,27649),(312,'Xã Nhơn Đức',23,27652),(313,'Xã Phú Xuân',23,27655),(314,'Xã Long Thới',23,27658),(315,'Xã Hiệp Phước',23,27661),(316,'Thị trấn Cần Thạnh',24,27664),(317,'Xã Bình Khánh',24,27667),(318,'Xã Tam Thôn Hiệp',24,27670),(319,'Xã An Thới Đông',24,27673),(320,'Xã Thạnh An',24,27676),(321,'Xã Long Hòa',24,27679),(322,'Xã Lý Nhơn',24,27682),(400,'Phường CCC',2,123456),(401,'Phường 1234',1,40000);
/*!40000 ALTER TABLE `ward` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Final view structure for view `company_logo`
--

/*!50001 DROP VIEW IF EXISTS `company_logo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `company_logo` AS select `com`.`id` AS `company_id`,`com`.`logo` AS `logo`,`imf`.`file_name` AS `file_name` from (`company` `com` join `image_info` `imf` on((`com`.`logo` = `imf`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-09-29  5:17:40
