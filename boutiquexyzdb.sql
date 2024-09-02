CREATE DATABASE  IF NOT EXISTS `boutiquexyzdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `boutiquexyzdb`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: boutiquexyzdb
-- ------------------------------------------------------
-- Server version	8.4.2

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20240901023750_InitialMigration','8.0.8'),('20240901183951_CamposParaLogin','8.0.8');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedidos`
--

DROP TABLE IF EXISTS `pedidos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pedidos` (
  `NumeroPedido` int NOT NULL AUTO_INCREMENT,
  `FechaPedido` datetime(6) NOT NULL,
  `FechaRecepcion` datetime(6) DEFAULT NULL,
  `FechaDespacho` datetime(6) DEFAULT NULL,
  `FechaEntrega` datetime(6) DEFAULT NULL,
  `Vendedor` int NOT NULL,
  `Repartidor` int DEFAULT NULL,
  `Estado` int NOT NULL,
  PRIMARY KEY (`NumeroPedido`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedidos`
--

LOCK TABLES `pedidos` WRITE;
/*!40000 ALTER TABLE `pedidos` DISABLE KEYS */;
INSERT INTO `pedidos` VALUES (1,'2024-09-01 14:10:18.995000','2024-09-01 11:19:13.880459','2024-09-01 11:57:29.414224',NULL,2,0,3),(2,'2024-09-01 17:17:32.655000',NULL,NULL,NULL,2,NULL,1),(3,'2024-09-01 17:17:32.655000',NULL,NULL,NULL,2,NULL,1),(4,'2024-09-01 17:41:02.410000','2024-09-01 12:47:10.908742','2024-09-01 12:50:56.096727','2024-09-01 12:51:15.392817',2,4,4),(5,'2024-09-02 06:51:57.453000','2024-09-02 05:13:01.562866','2024-09-02 05:19:28.428093',NULL,6,5,3),(6,'2024-09-02 07:37:11.941000',NULL,NULL,NULL,2,NULL,1),(7,'2024-09-02 09:36:53.392000',NULL,NULL,NULL,2,NULL,1),(8,'2024-09-02 09:36:53.392000',NULL,NULL,NULL,2,NULL,1);
/*!40000 ALTER TABLE `pedidos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productopedidos`
--

DROP TABLE IF EXISTS `productopedidos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productopedidos` (
  `NumeroPedido` int NOT NULL,
  `SKU` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Cantidad` int NOT NULL,
  `PedidoNumeroPedido` int DEFAULT NULL,
  `ProductoSKU` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`NumeroPedido`,`SKU`),
  KEY `IX_ProductoPedidos_PedidoNumeroPedido` (`PedidoNumeroPedido`),
  KEY `IX_ProductoPedidos_ProductoSKU` (`ProductoSKU`),
  CONSTRAINT `FK_ProductoPedidos_Pedidos_PedidoNumeroPedido` FOREIGN KEY (`PedidoNumeroPedido`) REFERENCES `pedidos` (`NumeroPedido`),
  CONSTRAINT `FK_ProductoPedidos_Productos_ProductoSKU` FOREIGN KEY (`ProductoSKU`) REFERENCES `productos` (`SKU`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productopedidos`
--

LOCK TABLES `productopedidos` WRITE;
/*!40000 ALTER TABLE `productopedidos` DISABLE KEYS */;
INSERT INTO `productopedidos` VALUES (1,'A-L-M-433696',3,1,NULL),(2,'A-G-K-399346',4,2,NULL),(2,'A-L-M-433696',2,2,NULL),(3,'A-G-K-399346',4,3,NULL),(3,'A-L-M-433696',2,3,NULL),(4,'A-G-K-399346',3,4,NULL),(5,'A-G-K-545534',5,5,NULL),(6,'A-G-K-399346',2,6,NULL),(7,'A-G-K-399346',1,7,NULL),(8,'A-G-K-399346',1,8,NULL);
/*!40000 ALTER TABLE `productopedidos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `SKU` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Nombre` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Tipo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Cantidad` int NOT NULL,
  `Etiquetas` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Precio` decimal(65,2) NOT NULL,
  `UnidadMedida` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`SKU`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES ('A-G-K-399346','Azúcar','Grano',5,'Endulzante,Rubia,',2.50,'Kg'),('A-G-K-545534','Arroz','Grano',5,'Integral,',4.50,'KG'),('A-L-M-433696','Aceite','Liquido',8,'Prueba 1,Prueba 2,',10.00,'ML'),('L-L-M-372854','Leche','Liquido',20,'Sin lactosa,250 cal,',2.50,'ML');
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `CodigoTrabajador` int NOT NULL AUTO_INCREMENT,
  `Nombre` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CorreoElectronico` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Telefono` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Puesto` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Rol` int NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `User` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`CodigoTrabajador`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'Juan','juan@boutique.com','957373323',NULL,1,'$2a$11$AmEzhc5Lrff6JiDFq8VYkO14bIufljoeC0Z4.IUzvMDMSHxwf7RVO','juan'),(2,'María','maria@boutique.com','957334321',NULL,2,'$2a$11$AmEzhc5Lrff6JiDFq8VYkO14bIufljoeC0Z4.IUzvMDMSHxwf7RVO','maria'),(3,'Jose','jose@boutique.com','934673248',NULL,3,'$2a$11$AmEzhc5Lrff6JiDFq8VYkO14bIufljoeC0Z4.IUzvMDMSHxwf7RVO','jose'),(4,'Pablo','pablo@boutique.com','973264732',NULL,4,'$2a$11$AmEzhc5Lrff6JiDFq8VYkO14bIufljoeC0Z4.IUzvMDMSHxwf7RVO','pablo'),(5,'Karina','karina@boutique.com','9783488282','Puesto 1',4,'$2a$11$AmEzhc5Lrff6JiDFq8VYkO14bIufljoeC0Z4.IUzvMDMSHxwf7RVO','karina'),(6,'Laura','laura@boutique.com','951335658','Puesto 2',2,'$2a$11$AmEzhc5Lrff6JiDFq8VYkO14bIufljoeC0Z4.IUzvMDMSHxwf7RVO','laura');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-09-02  6:32:57
