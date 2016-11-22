-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: education
-- ------------------------------------------------------
-- Server version	5.7.16-log

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
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(50) CHARACTER SET utf8 NOT NULL,
  `Description` varchar(200) CHARACTER SET utf8 DEFAULT NULL,
  `CategoryTypeID` int(11) DEFAULT NULL,
  `Alias` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  `Status` bit(1) DEFAULT NULL,
  `ImageUrl` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  `ForAdminPost` bit(1) DEFAULT NULL,
  `IsHighLight` bit(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (20,'Tin tức và sự kiện về giáo dục',NULL,0,'tin-tuc-su-kien-giao-duc','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL,'\0',NULL),(21,'Kinh nghiệm học tập',NULL,NULL,'kinh-nghiem-hoc-tap','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL,'\0',NULL),(22,'Sức khỏe cho thanh thiếu niên',NULL,NULL,'suc-khoe-thanh-thieu-nien','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL,'\0',NULL),(23,'Kinh nghiệm thi cử',NULL,NULL,'kinh-nghiem-thi-cu','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL,'\0',NULL),(24,'Các phương pháp học tập hiệu quả',NULL,NULL,'cac-phuong-phap-hoc-tap-hieu-qua','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL,'',NULL),(25,'Khung chương trình các môn học',NULL,NULL,'khung-chuong-trinh-cac-mon-hoc','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL,'',NULL),(26,'Thông tin tuyển sinh',NULL,NULL,'thong-tin-tuyen-sinh','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL,'',NULL);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `class` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL,
  `Status` bit(8) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Class_LevelID_FK_idx` (`LevelID`),
  CONSTRAINT `Class_LevelID_FK` FOREIGN KEY (`LevelID`) REFERENCES `leveleducation` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class`
--

LOCK TABLES `class` WRITE;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
INSERT INTO `class` VALUES (1,'Lớp 1',1,''),(2,'Lớp 2',1,''),(3,'Lớp 3',1,''),(4,'Lớp 4',1,''),(5,'Lớp 5',1,''),(6,'Lớp 6',2,''),(7,'Lớp 7',2,''),(8,'Lớp 8',2,''),(9,'Lớp 9',2,''),(10,'Lớp 10',3,''),(11,'Lớp 11',3,''),(12,'Lớp 12',3,'');
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commentlession`
--

DROP TABLE IF EXISTS `commentlession`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `commentlession` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `LessionID` int(11) DEFAULT NULL,
  `Content` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `CommentLession_UserID_FK_idx` (`UserID`),
  KEY `CommentLession_LessionID_FK_idx` (`LessionID`),
  CONSTRAINT `CommentLession_LessionID_FK` FOREIGN KEY (`LessionID`) REFERENCES `lesson` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `CommentLession_UserID_FK` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commentlession`
--

LOCK TABLES `commentlession` WRITE;
/*!40000 ALTER TABLE `commentlession` DISABLE KEYS */;
/*!40000 ALTER TABLE `commentlession` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commentpost`
--

DROP TABLE IF EXISTS `commentpost`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `commentpost` (
  `ID` int(18) NOT NULL AUTO_INCREMENT,
  `UserID` int(18) NOT NULL,
  `PostID` int(18) NOT NULL,
  `Content` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Created` datetime NOT NULL,
  `Modified` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `CommentPost_UserID_FK_idx` (`UserID`),
  KEY `CommentPost_PostID_FK_idx` (`PostID`),
  CONSTRAINT `CommentPost_PostID_FK` FOREIGN KEY (`PostID`) REFERENCES `post` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `CommentPost_UserID_FK` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commentpost`
--

LOCK TABLES `commentpost` WRITE;
/*!40000 ALTER TABLE `commentpost` DISABLE KEYS */;
/*!40000 ALTER TABLE `commentpost` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `district`
--

DROP TABLE IF EXISTS `district`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `district` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ProvinceID` int(11) DEFAULT NULL,
  `Code` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  `Name` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `District_ProvinceID_FK_idx` (`ProvinceID`),
  CONSTRAINT `District_ProvinceID_FK` FOREIGN KEY (`ProvinceID`) REFERENCES `province` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `district`
--

LOCK TABLES `district` WRITE;
/*!40000 ALTER TABLE `district` DISABLE KEYS */;
INSERT INTO `district` VALUES (1,1,'AnPhu','An Phú'),(2,1,'ChauDoc','Châu Đốc'),(3,1,'ChauPhu','Châu Phú'),(4,2,'BacNinh','Bắc Ninh'),(5,2,'GiaBinh','Gia Bình'),(6,2,'TienDu','Tiên Du'),(7,3,'BaDinh','Ba Đình'),(8,3,'CauGiay','Cầu Giấy'),(9,3,'HaiBaTrung','Hai Bà Trưng'),(10,4,'AnhSon','Anh Sơn'),(11,4,'ConCuong','Con Cuông'),(12,4,'NghiLoc','Nghi Lộc'),(13,4,'QuynhLuu','Quỳnh Lưu');
/*!40000 ALTER TABLE `district` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `feedback`
--

DROP TABLE IF EXISTS `feedback`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `feedback` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Created` datetime DEFAULT NULL,
  `Content` varchar(200) CHARACTER SET utf8 DEFAULT NULL,
  `Name` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  `Email` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feedback`
--

LOCK TABLES `feedback` WRITE;
/*!40000 ALTER TABLE `feedback` DISABLE KEYS */;
/*!40000 ALTER TABLE `feedback` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `file`
--

DROP TABLE IF EXISTS `file`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `file` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FileName` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  `FileExtension` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  `Status` bit(8) DEFAULT NULL,
  `FileUrl` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  `FileSize` int(11) DEFAULT NULL,
  `DownloadCount` int(11) DEFAULT NULL,
  `IsDownload` bit(1) DEFAULT NULL,
  `OldVersion` int(11) DEFAULT NULL,
  `LessionID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `File_LessionID_FK_idx` (`LessionID`),
  KEY `File_OldVersion_FK_idx` (`OldVersion`),
  CONSTRAINT `File_LessionID_FK` FOREIGN KEY (`LessionID`) REFERENCES `lesson` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `File_OldVersion_FK` FOREIGN KEY (`OldVersion`) REFERENCES `file` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci COMMENT='					';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `file`
--

LOCK TABLES `file` WRITE;
/*!40000 ALTER TABLE `file` DISABLE KEYS */;
/*!40000 ALTER TABLE `file` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lesson`
--

DROP TABLE IF EXISTS `lesson`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lesson` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Description` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  `Alias` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Status` bit(8) DEFAULT NULL,
  `ImageUrl` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `TeacherID` int(11) DEFAULT NULL,
  `RateAverage` float DEFAULT NULL,
  `SubjectID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Lession_TeacherID_FK_idx` (`TeacherID`),
  KEY `Lession_SubjectID_FK_idx` (`SubjectID`),
  CONSTRAINT `Lession_SubjectID_FK` FOREIGN KEY (`SubjectID`) REFERENCES `subject` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Lession_TeacherID_FK` FOREIGN KEY (`TeacherID`) REFERENCES `teacher` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lesson`
--

LOCK TABLES `lesson` WRITE;
/*!40000 ALTER TABLE `lesson` DISABLE KEYS */;
/*!40000 ALTER TABLE `lesson` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `leveleducation`
--

DROP TABLE IF EXISTS `leveleducation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `leveleducation` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Code` varchar(45) DEFAULT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leveleducation`
--

LOCK TABLES `leveleducation` WRITE;
/*!40000 ALTER TABLE `leveleducation` DISABLE KEYS */;
INSERT INTO `leveleducation` VALUES (1,'th','Tiểu học'),(2,'thcs','Trung học cơ sở'),(3,'thpt','Trung học phổ thông');
/*!40000 ALTER TABLE `leveleducation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `likepost`
--

DROP TABLE IF EXISTS `likepost`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `likepost` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PostID` int(11) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `Created` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `LikePost_PostID_FK_idx` (`PostID`),
  KEY `LikePost_UserID_FK_idx` (`UserID`),
  CONSTRAINT `LikePost_PostID_FK` FOREIGN KEY (`PostID`) REFERENCES `post` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `LikePost_UserID_FK` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `likepost`
--

LOCK TABLES `likepost` WRITE;
/*!40000 ALTER TABLE `likepost` DISABLE KEYS */;
/*!40000 ALTER TABLE `likepost` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `post`
--

DROP TABLE IF EXISTS `post`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `post` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Alias` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `CategoryID` int(11) DEFAULT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  `Status` bit(8) DEFAULT NULL,
  `Description` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ImageUrl` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Post_CategoryID_FK_idx` (`CategoryID`),
  KEY `Post_UserID_FK_idx` (`UserID`),
  CONSTRAINT `Post_CategoryID_FK` FOREIGN KEY (`CategoryID`) REFERENCES `category` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Post_UserID_FK` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `post`
--

LOCK TABLES `post` WRITE;
/*!40000 ALTER TABLE `post` DISABLE KEYS */;
/*!40000 ALTER TABLE `post` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `province`
--

DROP TABLE IF EXISTS `province`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `province` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Code` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  `Name` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `province`
--

LOCK TABLES `province` WRITE;
/*!40000 ALTER TABLE `province` DISABLE KEYS */;
INSERT INTO `province` VALUES (1,'AnGiang','An Giang'),(2,'BacNinh','Bắc Ninh'),(3,'HaNoi','Hà Nội'),(4,'NgheAn','Nghệ An');
/*!40000 ALTER TABLE `province` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ratelession`
--

DROP TABLE IF EXISTS `ratelession`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ratelession` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `LessionID` int(11) DEFAULT NULL,
  `Point` int(11) DEFAULT NULL,
  `Created` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `RateLession_UserID_FK_idx` (`UserID`),
  KEY `RateLession_LessionID_FK_idx` (`LessionID`),
  CONSTRAINT `RateLession_LessionID_FK` FOREIGN KEY (`LessionID`) REFERENCES `lesson` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `RateLession_UserID_FK` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ratelession`
--

LOCK TABLES `ratelession` WRITE;
/*!40000 ALTER TABLE `ratelession` DISABLE KEYS */;
/*!40000 ALTER TABLE `ratelession` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `report`
--

DROP TABLE IF EXISTS `report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `report` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `Content` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Created` datetime DEFAULT NULL,
  `ReportTypeID` int(11) DEFAULT NULL,
  `ObjectID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `report`
--

LOCK TABLES `report` WRITE;
/*!40000 ALTER TABLE `report` DISABLE KEYS */;
/*!40000 ALTER TABLE `report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reporttype`
--

DROP TABLE IF EXISTS `reporttype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reporttype` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Code` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Name` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Description` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Status` bit(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reporttype`
--

LOCK TABLES `reporttype` WRITE;
/*!40000 ALTER TABLE `reporttype` DISABLE KEYS */;
INSERT INTO `reporttype` VALUES (1,'report_post','Báo cáo bài viết',NULL,''),(2,'report_user','Báo cáo tài khoản',NULL,''),(3,'report_lession','Báo cáo bài giảng',NULL,'');
/*!40000 ALTER TABLE `reporttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `role` (
  `ID` int(18) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Description` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Administrators','Quản trị cao nhất của hệ thống'),(2,'Registered Users','Người dùng đăng ký'),(3,'Guests','Khách'),(4,'Registered Teacher','Giáo viên đăng ký'),(5,'Registered Student','Học sinh đăng ký');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `school`
--

DROP TABLE IF EXISTS `school`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `school` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `TownID` int(11) DEFAULT NULL,
  `SchoolTypeID` int(11) DEFAULT NULL,
  `Address` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `School_SchoolTypeID_FK_idx` (`SchoolTypeID`),
  CONSTRAINT `School_SchoolTypeID_FK` FOREIGN KEY (`SchoolTypeID`) REFERENCES `schooltype` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `school`
--

LOCK TABLES `school` WRITE;
/*!40000 ALTER TABLE `school` DISABLE KEYS */;
/*!40000 ALTER TABLE `school` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schooltype`
--

DROP TABLE IF EXISTS `schooltype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `schooltype` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Code` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  `Name` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  `Description` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schooltype`
--

LOCK TABLES `schooltype` WRITE;
/*!40000 ALTER TABLE `schooltype` DISABLE KEYS */;
INSERT INTO `schooltype` VALUES (1,'chuyenhuyen','Trường chuyên cấp huyện',NULL),(2,'chuyentinh','Trường chuyên cấp tỉnh/thành phố',NULL);
/*!40000 ALTER TABLE `schooltype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `student` (
  `ID` int(18) NOT NULL AUTO_INCREMENT,
  `UserID` int(18) NOT NULL,
  `CurrentClass` int(5) NOT NULL,
  `ClassName` varchar(25) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Student_UserID_FK_idx` (`UserID`),
  CONSTRAINT `Student_UserID_FK` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subject`
--

DROP TABLE IF EXISTS `subject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subject` (
  `ID` int(18) NOT NULL AUTO_INCREMENT,
  `SubjectName` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
INSERT INTO `subject` VALUES (1,'Toán'),(2,'Tiếng Việt'),(3,'Tự nhiên và xã hội'),(4,'Khoa học'),(5,'Lịch sử'),(6,'Địa lý'),(7,'Âm nhạc'),(8,'Mỹ thuật'),(9,'Đạo đức'),(10,'Thể dục'),(11,'Tin học'),(12,'Vật lý'),(13,'Hóa học'),(14,'Sinh học'),(15,'Công nghệ'),(16,'Ngữ Văn'),(17,'Giáo dục công dân'),(18,'Tiếng Pháp'),(19,'Tiếng Nga'),(20,'Tiếng Nhật'),(21,'Tiếng Trung');
/*!40000 ALTER TABLE `subject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subjectclass`
--

DROP TABLE IF EXISTS `subjectclass`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subjectclass` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `SubjectID` int(11) DEFAULT NULL,
  `ClassID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `SubjectClass_SubjectID_FK_idx` (`SubjectID`),
  KEY `SubjectClass_ClassID_FK_idx` (`ClassID`),
  CONSTRAINT `SubjectClass_ClassID_FK` FOREIGN KEY (`ClassID`) REFERENCES `class` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `SubjectClass_SubjectID_FK` FOREIGN KEY (`SubjectID`) REFERENCES `subject` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subjectclass`
--

LOCK TABLES `subjectclass` WRITE;
/*!40000 ALTER TABLE `subjectclass` DISABLE KEYS */;
INSERT INTO `subjectclass` VALUES (1,1,1),(2,2,1),(3,3,1),(4,1,2),(5,2,2),(6,3,2);
/*!40000 ALTER TABLE `subjectclass` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teacher` (
  `ID` int(18) NOT NULL AUTO_INCREMENT,
  `UserID` int(18) NOT NULL,
  `ExperienceYear` int(5) DEFAULT NULL,
  `MainSubjectID` int(18) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `UserID_FK_idx` (`UserID`),
  KEY `Teacher_MainSubjectID_FK_idx` (`MainSubjectID`),
  CONSTRAINT `Teacher_MainSubjectID_FK` FOREIGN KEY (`MainSubjectID`) REFERENCES `subject` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Teacher_UserID_FK` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
/*!40000 ALTER TABLE `teacher` DISABLE KEYS */;
/*!40000 ALTER TABLE `teacher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `town`
--

DROP TABLE IF EXISTS `town`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `town` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DistrictID` int(11) DEFAULT NULL,
  `Code` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  `Name` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Town_DistrictID_FK_idx` (`DistrictID`),
  CONSTRAINT `Town_DistrictID_FK` FOREIGN KEY (`DistrictID`) REFERENCES `district` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `town`
--

LOCK TABLES `town` WRITE;
/*!40000 ALTER TABLE `town` DISABLE KEYS */;
INSERT INTO `town` VALUES (14,1,'DaKhuoc','Đa Khước'),(15,2,'VinhChau','Vĩnh Châu'),(16,3,'TanChau','Tân Châu'),(17,4,'SuoiHoa','Suối Hoa'),(18,5,'BinhDuong','Bình Dương'),(19,6,'PhuLam','Phú Lâm'),(20,7,'DoiCan','Đội Cấn'),(21,8,'DichVong','Dịch Vọng'),(22,9,'BachKhoa','Bách Khoa'),(23,10,'BinhSon','Bình Sơn'),(24,11,'BinhChuan','Bình Chuẩn'),(25,12,'NghiCongBac','Nghi Công Bắc'),(26,13,'QuynhDien','Quỳnh Diện');
/*!40000 ALTER TABLE `town` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `ID` int(18) NOT NULL AUTO_INCREMENT,
  `FullName` varchar(25) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Email` varchar(25) COLLATE utf8_unicode_ci DEFAULT NULL,
  `UserName` varchar(25) COLLATE utf8_unicode_ci NOT NULL,
  `Password` varchar(50) CHARACTER SET utf8 NOT NULL,
  `Birthday` date DEFAULT NULL,
  `Sex` bit(1) DEFAULT NULL,
  `ImageUrl` varchar(100) CHARACTER SET utf32 COLLATE utf32_unicode_ci DEFAULT NULL,
  `Description` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Created` datetime NOT NULL,
  `Modified` datetime NOT NULL,
  `IsActive` bit(1) DEFAULT NULL,
  `Address` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Nguyễn Đình Huỳnh','huynhnd@gmail.com','huynhnd','c4ca4238a0b923820dcc509a6f75849b','1995-11-07','\0','~/Upload/Images/Users/huynhnd.png','xxx','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL),(2,'Trần Văn Lộc','loctv@gmail.com','loctv','c4ca4238a0b923820dcc509a6f75849b','1995-07-09','\0','~/Upload/Images/Users/loctv.png','xxx','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL),(3,'Ngô Văn Huy','huynv@gmail.com','huynv','c4ca4238a0b923820dcc509a6f75849b','1995-09-03','\0','~/Upload/Images/Users/huynv.png','xxx','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL),(4,'Nguyễn Thị A','ant@gmail.com','ant','c4ca4238a0b923820dcc509a6f75849b','1995-01-01','','~/Upload/Images/Users/ant.png','xxx','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL),(7,'Phạm Thị B','bpt@gmail.com','bpt','c4ca4238a0b923820dcc509a6f75849b','1995-01-01','','~/Upload/Images/Users/bpt.png','xxx','2016-11-22 05:32:35','2016-11-22 05:32:35','',NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userrole`
--

DROP TABLE IF EXISTS `userrole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userrole` (
  `ID` int(18) NOT NULL AUTO_INCREMENT,
  `UserID` int(18) NOT NULL,
  `RoleID` int(18) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `ID_idx` (`UserID`),
  KEY `RoleID_FK_idx` (`RoleID`),
  CONSTRAINT `UserRole_RoleID_FK` FOREIGN KEY (`RoleID`) REFERENCES `role` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `UserRole_UserID_FK` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userrole`
--

LOCK TABLES `userrole` WRITE;
/*!40000 ALTER TABLE `userrole` DISABLE KEYS */;
INSERT INTO `userrole` VALUES (1,1,1),(2,2,1),(3,3,1),(4,4,4),(5,7,5);
/*!40000 ALTER TABLE `userrole` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-11-22 23:01:47
